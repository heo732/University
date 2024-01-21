using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

using MainTool.Enums;
using MainTool.Exceptions;
using MainTool.Models;
using MainTool.Utils;
using MainTool.WPF;
using InvalidDataException = MainTool.Exceptions.InvalidDataException;

namespace MainTool.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        public event EventHandler WindowDrag;
        public event EventHandler WindowClose;
        public event EventHandler GraphZoomToFill;

        public MainWindowViewModel()
        {
            ReplaceUI();

            LoadGraphCommand = new DelegateCommand(LoadGraphAction);
            SaveResultCommand = new DelegateCommand(SaveResultAction);
            SaveGraphCommand = new DelegateCommand(SaveGraphAction);
            AboutCommand = new DelegateCommand(AboutAction);
            EditGraphConnection_AddCommand = new DelegateCommand(EditGraphConnection_AddAction);
            EditGraphConnection_RemoveCommand = new DelegateCommand(EditGraphConnection_RemoveAction);
            WindowDragCommand = new DelegateCommand(WindowDragAction);
            WindowCloseCommand = new DelegateCommand(WindowCloseAction);
            WindowMaximizeCommand = new DelegateCommand(WindowMaximizeAction);
            WindowMinimizeCommand = new DelegateCommand(WindowMinimizeAction);
            BuildVersionCommand = new DelegateCommand(BuildVersionAction);
            LoadPresetCommand = new DelegateCommand((presetNumber) => LoadPresetAction(presetNumber));
            ClearGraphCommand = new DelegateCommand(ClearGraphAction);
            RefreshGraphCommand = new DelegateCommand(() => RefreshVisualGraph(true));
        }

        public ObservableCollection<int> InitialNodeItems { get; private set; } = new ObservableCollection<int>();

        public ObservableCollection<int> SourceNodeItems { get; private set; } = new ObservableCollection<int>();

        public ObservableCollection<int> TargetNodeItems { get; private set; } = new ObservableCollection<int>();

        public ObservableCollection<ResultRepresentation> Result { get; private set; } = new ObservableCollection<ResultRepresentation>();

        public double ResultTotalValue => Result.Sum(r => r.AsDouble);

        public List<GraphConnection> Graph { get; private set; } = new List<GraphConnection>();

        public VisualGraphArea VisualGraphArea { get; } = new VisualGraphArea();

        public string EditGraphConnection_Start { get; set; }

        public string EditGraphConnection_End { get; set; }

        public string EditGraphConnection_Weight { get; set; }

        public TaskType SelectedTaskType
        {
            get => selectedTaskType;
            set
            {
                selectedTaskType = value;
                RaisePropertyChanged(nameof(SelectedTaskType));
                ReplaceUI();
            }
        }

        public WindowState WindowState
        {
            get => windowState;
            set
            {
                windowState = value;
                RaisePropertyChanged(nameof(WindowState));
            }
        }

        public int InitialNode
        {
            get => initialNode;
            set
            {
                initialNode = value;
                RaisePropertyChanged(nameof(InitialNode));
                UpdateResult();
            }
        }

        public int SourceNode
        {
            get => sourceNode;
            set
            {
                sourceNode = value;
                RaisePropertyChanged(nameof(SourceNode));
                UpdateTargetNodeItems(false, false);
                UpdateResult();
            }
        }

        public int TargetNode
        {
            get => targetNode;
            set
            {
                targetNode = value;
                RaisePropertyChanged(nameof(TargetNode));
                UpdateSourceNodeItems(false);
                UpdateResult();
            }
        }

        public Visibility GraphZoomFinderVisibility
        {
            get => graphZoomFinderVisibility;
            set
            {
                graphZoomFinderVisibility = value;
                RaisePropertyChanged(nameof(GraphZoomFinderVisibility));
            }
        }

        public string EditConnectionWeightLabel
        {
            get => editConnectionWeightLabel;
            private set
            {
                editConnectionWeightLabel = value;
                RaisePropertyChanged(nameof(EditConnectionWeightLabel));
            }
        }

        public string ResultsTitle
        {
            get => resultsTitle;
            private set
            {
                resultsTitle = value;
                RaisePropertyChanged(nameof(ResultsTitle));
            }
        }

        public string ResultsFirstColumnHeader
        {
            get => resultsFirstColumnHeader;
            private set
            {
                resultsFirstColumnHeader = value;
                RaisePropertyChanged(nameof(ResultsFirstColumnHeader));
            }
        }

        public string ResultsSecondColumnHeader
        {
            get => resultsSecondColumnHeader;
            private set
            {
                resultsSecondColumnHeader = value;
                RaisePropertyChanged(nameof(ResultsSecondColumnHeader));
            }
        }

        public string ResultMessage
        {
            get => resultMessage;
            private set
            {
                resultMessage = value;
                RaisePropertyChanged(nameof(ResultMessage));
            }
        }

        public Visibility ResultMessageVisibility
        {
            get => resultMessageVisibility;
            private set
            {
                resultMessageVisibility = value;
                RaisePropertyChanged(nameof(ResultMessageVisibility));
            }
        }

        public DelegateCommand LoadGraphCommand { get; }

        public DelegateCommand SaveResultCommand { get; }

        public DelegateCommand SaveGraphCommand { get; }

        public DelegateCommand AboutCommand { get; }

        public DelegateCommand EditGraphConnection_AddCommand { get; }

        public DelegateCommand EditGraphConnection_RemoveCommand { get; }

        public DelegateCommand WindowDragCommand { get; }

        public DelegateCommand WindowCloseCommand { get; }

        public DelegateCommand WindowMaximizeCommand { get; }

        public DelegateCommand WindowMinimizeCommand { get; }

        public DelegateCommand BuildVersionCommand { get; }

        public DelegateCommand LoadPresetCommand { get; }

        public DelegateCommand ClearGraphCommand { get; }

        public DelegateCommand RefreshGraphCommand { get; }

        private void WindowDragAction()
        {
            WindowDrag?.Invoke(this, null);
        }

        private void WindowCloseAction()
        {
            WindowClose?.Invoke(this, null);
        }

        private void WindowMaximizeAction()
        {
            WindowState = WindowState == WindowState.Maximized ? WindowState.Normal : WindowState.Maximized;
        }

        private void WindowMinimizeAction()
        {
            WindowState = WindowState.Minimized;
        }

        private void LoadGraphAction()
        {
            try
            {
                var dialog = new OpenFileDialog
                {
                    Filter = "JSON files (*.json)|*.json|Text files (*.txt)|*.txt|All files|*.*",
                    FilterIndex = 3
                };

                if (dialog.ShowDialog() ?? false)
                {
                    string fileContent = File.ReadAllText(dialog.FileName);
                    string[] fileLines = File.ReadAllLines(dialog.FileName);
                    List<GraphConnection> graph_temp = null;

                    if (!fileLines.Any())
                    {
                        CustomMessageBox.Show("Помилка", "Файл порожній!");
                        return;
                    }

                    try
                    {
                        graph_temp = JsonConvert.DeserializeObject<List<GraphConnection>>(fileContent);
                    }
                    catch
                    {
                        graph_temp = GetGraphFromText(fileLines, out HashSet<int> invalidRows);

                        if (invalidRows.Count == fileLines.Length)
                        {
                            CustomMessageBox.Show("Помилка", "Неможливо отримати коректні дані з обраного файлу!");
                            return;
                        }
                        else if (invalidRows.Any())
                        {
                            CustomMessageBox.Show("Увага!", "Не вдалося прочитати дані в наступних рядках:" + Environment.NewLine + Environment.NewLine + string.Join(Environment.NewLine, invalidRows));
                        }
                    }

                    Graph = graph_temp.Distinct(SelectedTaskType == TaskType.ShortestWay ? (IEqualityComparer<GraphConnection>)new GraphConnectionIgnoreOrderStartEndComparer() : new GraphConnectionOrderedStartEndComparer()).ToList();
                    GraphChangedUpdates(true);
                }
            }
            catch (Exception ex)
            {
                ShowExceptionWithStackTrace(ex);
            }
        }

        private void SaveResultAction()
        {
            try
            {
                var dialog = new SaveFileDialog
                {
                    Filter = "JSON data format (*.json)|*.json|Plain text data format (*.txt)|*.txt",
                    FileName = "Result",
                    FilterIndex = 2
                };

                if (dialog.ShowDialog() ?? false)
                {
                    string outputString = string.Empty;

                    // JSON format.
                    if (dialog.FilterIndex == 1)
                    {
                        switch (SelectedTaskType)
                        {
                            case TaskType.ShortestWay:
                                outputString = JsonConvert.SerializeObject(Result, Formatting.Indented);
                                break;
                            case TaskType.MaxFlow:
                                outputString = new JObject
                                {
                                    { "MiminumSelection", JToken.FromObject(Result) },
                                    { "MaximumFlow", JToken.FromObject(Result.Sum(c => c.AsDouble)) }
                                }.ToString();
                                break;
                        }
                    }
                    // Plain text format.
                    else
                    {
                        switch (SelectedTaskType)
                        {
                            case TaskType.ShortestWay:
                                outputString = string.Join(Environment.NewLine, Result.Select(w => w.AsFullString));
                                break;
                            case TaskType.MaxFlow:
                                outputString = string.Join(Environment.NewLine, Result.Select(c => c.AsFullString).Concat(new string[] { "b: " + Result.Sum(c => c.AsDouble).ToString() }));
                                break;
                        }
                    }

                    File.WriteAllText(dialog.FileName, outputString);
                }
            }
            catch (Exception ex)
            {
                ShowExceptionWithStackTrace(ex);
            }
        }

        private void SaveGraphAction()
        {
            try
            {
                var dialog = new SaveFileDialog
                {
                    Filter = "JSON data format (*.json)|*.json|Plain text data format (*.txt)|*.txt",
                    FileName = "Graph",
                    FilterIndex = 2
                };

                if (dialog.ShowDialog() ?? false)
                {
                    string outputString = string.Empty;

                    // JSON format.
                    if (dialog.FilterIndex == 1)
                    {
                        outputString = JsonConvert.SerializeObject(Graph, Formatting.Indented);
                    }
                    // Plain text format.
                    else
                    {
                        outputString = string.Join(Environment.NewLine, Graph.Select(c => c.AsPlainString));
                    }

                    File.WriteAllText(dialog.FileName, outputString);
                }
            }
            catch (Exception ex)
            {
                ShowExceptionWithStackTrace(ex);
            }
        }

        private void AboutAction()
        {
            string roles = SelectedTaskType == TaskType.ShortestWay ?

                "Тім лідом — Беленчуком Олексієм Ігоровичем" + Environment.NewLine
                + "Розробниками — Бужаком Андрієм Васильовичем та Максименко Михайлом Сергійовичем" + Environment.NewLine
                + "Тестувальником — Кушнірик Яною Олександрівною" + Environment.NewLine
                + "Розробником документації — Чайковським Станіславом Валерійовичем" :

                "Тім лідом — Максименко Михайлом Сергійовичем" + Environment.NewLine
                + "Розробниками — Беленчуком Олексієм Ігоровичем та Кушнірик Яною Олександрівною" + Environment.NewLine
                + "Тестувальником — Чайковським Станіславом Валерійовичем" + Environment.NewLine
                + "Розробником документації — Бужаком Андрієм Васильовичем";

            string message = "Дана програма розроблена в межах вивчення дисципліни \"Мережі та потоки\"" + Environment.NewLine
                + "(викладач — доцент Руснак Микола Андрійович)" + Environment.NewLine + Environment.NewLine
                + "студентами групи 441" + Environment.NewLine
                + "кафедри Математичних Проблем Управління і Кібернетики" + Environment.NewLine
                + "відділу Комп'ютерних технологій" + Environment.NewLine
                + "інституту Фізико-Технічних та Комп'ютерних Наук" + Environment.NewLine + Environment.NewLine
                + roles + Environment.NewLine + Environment.NewLine
                + "у 2020 році" + Environment.NewLine
                + "Для зв'язку використовувати електронну пошту: belenchuk.oleksiy@chnu.edu.ua";

            CustomMessageBox.ShowAnimated("Про авторів", message);
        }

        private void EditGraphConnection_AddAction()
        {
            try
            {
                string errorParsingMessageFormat = "Некоректні дані у полі: \"{0}\"";

                if (!int.TryParse(EditGraphConnection_Start, out int source) || source <= 0)
                {
                    throw new InvalidDataException(string.Format(errorParsingMessageFormat, "Перша вершина"));
                }

                if (!int.TryParse(EditGraphConnection_End, out int target) || target <= 0)
                {
                    throw new InvalidDataException(string.Format(errorParsingMessageFormat, "Друга вершина"));
                }

                if (!double.TryParse(EditGraphConnection_Weight, out double value) || value <= 0)
                {
                    throw new InvalidDataException(string.Format(errorParsingMessageFormat, EditConnectionWeightLabel));
                }

                var newConnection = new GraphConnection(source, target, value);
                var comparer = SelectedTaskType == TaskType.ShortestWay ? (IEqualityComparer<GraphConnection>)new GraphConnectionIgnoreOrderStartEndComparer() : new GraphConnectionOrderedStartEndComparer();

                if (Graph.Any(c => comparer.Equals(c, newConnection) && c.Value == newConnection.Value))
                {
                    throw new InvalidDataException("Вказаний зв'язок вже існує!");
                }
                else if (Graph.Any(c => comparer.Equals(c, newConnection)))
                {
                    Graph.Remove(Graph.First(c => comparer.Equals(c, newConnection)));
                    Graph.Add(newConnection);
                    RefreshVisualGraph(true);
                    UpdateResult();
                    return;
                }

                if (newConnection.Source == newConnection.Target)
                {
                    throw new InvalidDataException("Перша та друга вершина мають бути різними!");
                }

                Graph.Add(newConnection);
                GraphChangedUpdates(false);
            }
            catch (InvalidDataException ex)
            {
                ShowExceptionWithoutStackTrace(ex);
            }
            catch (Exception ex)
            {
                ShowExceptionWithStackTrace(ex);
            }
        }

        private void EditGraphConnection_RemoveAction()
        {
            try
            {
                string errorParsingMessageFormat = "Некоректні дані у полі: \"{0}\"";

                if (!int.TryParse(EditGraphConnection_Start, out int source) || source <= 0)
                {
                    throw new InvalidDataException(string.Format(errorParsingMessageFormat, "Перша вершина"));
                }

                if (!int.TryParse(EditGraphConnection_End, out int target) || target <= 0)
                {
                    throw new InvalidDataException(string.Format(errorParsingMessageFormat, "Друга вершина"));
                }

                var removeConnection = new GraphConnection(source, target, -1);
                var comparer = SelectedTaskType == TaskType.ShortestWay ? (IEqualityComparer<GraphConnection>)new GraphConnectionIgnoreOrderStartEndComparer() : new GraphConnectionOrderedStartEndComparer();

                if (Graph.All(c => !comparer.Equals(c, removeConnection)))
                {
                    throw new InvalidDataException("У графі не існує вказаного зв'язку!");
                }

                Graph.Remove(Graph.First(c => comparer.Equals(c, removeConnection)));

                GraphChangedUpdates(false);
            }
            catch (InvalidDataException ex)
            {
                ShowExceptionWithoutStackTrace(ex);
            }
            catch (Exception ex)
            {
                ShowExceptionWithStackTrace(ex);
            }
        }

        private void UpdateResult()
        {
            try
            {
                HideResultMessage();
                Result = new ObservableCollection<ResultRepresentation>();
                switch (SelectedTaskType)
                {
                    case TaskType.ShortestWay:
                        Result = new ObservableCollection<ResultRepresentation>(MethodMinti.GetAllShortestWays(InitialNode, Graph));
                        break;
                    case TaskType.MaxFlow:
                        Result = new ObservableCollection<ResultRepresentation>(MethodFordFulkerson.GetMinimumNetworkSection(SourceNode, TargetNode, Graph));
                        break;
                }
            }
            catch (FlowImpossibleException ex)
            {
                ShowResultMessage(ex.Message);
            }
            catch (Exception ex)
            {
                string message = ex.Message + Environment.NewLine + Environment.NewLine + Environment.NewLine + ex.StackTrace;
                ShowResultMessage(message);
            }

            RaisePropertyChanged(nameof(Result));
            RaisePropertyChanged(nameof(ResultTotalValue));
        }

        private void UpdateInitialNodeItems()
        {
            InitialNodeItems = new ObservableCollection<int>(Graph.SelectMany(connection => new GraphConnection[] { connection.GetOrderedAscending(), connection.GetOrderedDescending() }).Select(c => c.Source).Distinct().OrderBy(s => s));
            RaisePropertyChanged(nameof(InitialNodeItems));

            if (InitialNodeItems.All(item => item != InitialNode))
            {
                InitialNode = InitialNodeItems.Any() ? InitialNodeItems.First() : -1;
            }
            else
            {
                InitialNode = InitialNode;
            }
        }

        private void UpdateSourceNodeItems(bool refreshSelectedNode)
        {
            SourceNodeItems = new ObservableCollection<int>(Graph.Select(c => c.Source).Distinct().Where(s => s != TargetNode).OrderBy(s => s));
            RaisePropertyChanged(nameof(SourceNodeItems));
            
            if (refreshSelectedNode)
            {
                if (SourceNodeItems.All(item => item != SourceNode))
                {
                    SourceNode = SourceNodeItems.Any() ? SourceNodeItems.First() : -1;
                }
                else
                {
                    SourceNode = SourceNode;
                }
            }
        }

        private void UpdateTargetNodeItems(bool refreshSelectedNode, bool force)
        {
            TargetNodeItems = new ObservableCollection<int>(Graph.Select(c => c.Target).Distinct().Where(t => t != SourceNode).OrderBy(t => t));
            RaisePropertyChanged(nameof(TargetNodeItems));

            if (refreshSelectedNode)
            {
                if (TargetNodeItems.All(item => item != TargetNode))
                {
                    TargetNode = TargetNodeItems.Any() ? TargetNodeItems.Last() : -1;
                }
                else if (force)
                {
                    TargetNode = TargetNodeItems.Any() ? TargetNodeItems.Last() : -1;
                }
                else
                {
                    TargetNode = TargetNode;
                }
            }
        }

        private List<GraphConnection> GetGraphFromText(IEnumerable<string> rows, out HashSet<int> invalidRows)
        {
            var graph = new List<GraphConnection>();
            invalidRows = new HashSet<int>();

            foreach (string line in rows)
            {
                string[] values = line.Split(' ', ';', '\t').Where(v => !string.IsNullOrWhiteSpace(v)).ToArray();

                if (values.Length >= 3 && int.TryParse(values[0], out int source) && source > 0 && int.TryParse(values[1], out int target) && target > 0 && int.TryParse(values[2], out int value) && value > 0)
                {
                    graph.Add(new GraphConnection(source, target, value));
                }
                else
                {
                    invalidRows.Add(invalidRows.Count + 1);
                }
            }

            return graph;
        }

        private void ShowExceptionWithStackTrace(Exception ex)
        {
            string message = ex.Message + Environment.NewLine + Environment.NewLine + Environment.NewLine + ex.StackTrace;
            CustomMessageBox.Show("Помилка", message);
        }

        private void ShowExceptionWithoutStackTrace(Exception ex)
        {
            CustomMessageBox.Show("Помилка", ex.Message);
        }

        private bool IsCurrentGraphEqualToPrevious()
        {
            if (Graph.Count != previousGraph.Length)
            {
                return false;
            }

            if (!Graph.Any())
            {
                return false;
            }

            if (string.Join(";", Graph.ToUniqueIds()) != string.Join(";", previousGraph.ToUniqueIds()))
            {
                return false;
            }

            var comparer = new GraphConnectionOrderedStartEndComparer();
            foreach (var c in Graph)
            {
                if (!previousGraph.Contains(c, comparer))
                {
                    return false;
                }
            }

            return true;
        }

        private void RefreshVisualGraph(bool force)
        {
            try
            {
                if (!force && IsCurrentGraphEqualToPrevious())
                {
                    return;
                }

                VisualGraphHelper.DrawGraph(VisualGraphArea, Graph, SelectedTaskType == TaskType.MaxFlow);
                GraphZoomToFill?.Invoke(this, null);
                previousGraph = Graph.ToArray();
            }
            catch (Exception ex)
            {
                ShowExceptionWithStackTrace(ex);
            }
        }

        private void BuildVersionAction()
        {
            CustomMessageBox.Show("Версія збірки", "v" + FileVersionInfo.GetVersionInfo(Assembly.GetExecutingAssembly().Location).ProductVersion);
        }

        private void LoadPresetAction(object presetNumber_obj)
        {
            int presetNumber = -1;

            if (!(presetNumber_obj is string) || !int.TryParse((string)presetNumber_obj, out presetNumber))
            {
                return;
            }

            string graph_preset_string = string.Empty;

            switch (presetNumber)
            {
                case 1:
                    graph_preset_string = GraphPresets.ShortestWay_Preset1;
                    break;
                case 2:
                    graph_preset_string = GraphPresets.ShortestWay_Preset2;
                    break;
                case 3:
                    graph_preset_string = GraphPresets.ShortestWay_Preset3;
                    break;
                case 4:
                    graph_preset_string = GraphPresets.ShortestWay_Preset4;
                    break;
                case 5:
                    graph_preset_string = GraphPresets.ShortestWay_Preset5;
                    break;
                case 6:
                    graph_preset_string = GraphPresets.MaxFlow_Preset1;
                    break;
                case 7:
                    graph_preset_string = GraphPresets.MaxFlow_Preset2;
                    break;
                case 8:
                    graph_preset_string = GraphPresets.MaxFlow_Preset3;
                    break;
                case 9:
                    graph_preset_string = GraphPresets.MaxFlow_Preset4;
                    break;
                case 10:
                    graph_preset_string = GraphPresets.MaxFlow_Preset5;
                    break;
                default:
                    return;
            }

            Graph = GetGraphFromText(graph_preset_string.Split('\r', '\n').Where(line => !string.IsNullOrEmpty(line)), out HashSet<int> invalidRows).Distinct(SelectedTaskType == TaskType.ShortestWay ? (IEqualityComparer<GraphConnection>)new GraphConnectionIgnoreOrderStartEndComparer() : new GraphConnectionOrderedStartEndComparer()).ToList();

            if (invalidRows.Any())
            {
                CustomMessageBox.Show("Увага!", "Не вдалося прочитати дані в наступних рядках:" + Environment.NewLine + Environment.NewLine + string.Join(Environment.NewLine, invalidRows));
            }

            GraphChangedUpdates(true);
        }

        private void ClearGraphAction()
        {
            Graph = new List<GraphConnection>();

            GraphChangedUpdates(true);
        }

        private void ReplaceUI()
        {
            switch (SelectedTaskType)
            {
                case TaskType.ShortestWay:
                    EditConnectionWeightLabel = "Вага дуги";
                    ResultsTitle = "Відстані до вершин";
                    ResultsFirstColumnHeader = "Довжина";
                    ResultsSecondColumnHeader = "Шлях";
                    break;
                case TaskType.MaxFlow:
                    EditConnectionWeightLabel = "Пропускна спроможність дуги";
                    ResultsTitle = "Мінімальний переріз на мережі";
                    ResultsFirstColumnHeader = "Пропускна спроможність дуги";
                    ResultsSecondColumnHeader = "Дуга";
                    break;
            }
            UpdateResult();
            RefreshVisualGraph(true);
        }

        private void GraphChangedUpdates(bool refreshTargetForce)
        {
            UpdateInitialNodeItems();
            UpdateSourceNodeItems(true);
            UpdateTargetNodeItems(true, refreshTargetForce);
            RefreshVisualGraph(false);
        }

        private void ShowResultMessage(string message)
        {
            ResultMessage = message;
            ResultMessageVisibility = Visibility.Visible;
        }

        private void HideResultMessage()
        {
            ResultMessage = string.Empty;
            ResultMessageVisibility = Visibility.Collapsed;
        }

        private TaskType selectedTaskType = TaskType.ShortestWay;
        private WindowState windowState;
        private int initialNode = -1;
        private int sourceNode = -1;
        private int targetNode = -1;
        private GraphConnection[] previousGraph = new GraphConnection[0];
        private Visibility graphZoomFinderVisibility = Visibility.Collapsed;
        private string editConnectionWeightLabel;
        private string resultsTitle;
        private string resultsFirstColumnHeader;
        private string resultsSecondColumnHeader;
        private string resultMessage;
        private Visibility resultMessageVisibility = Visibility.Collapsed;
    }
}