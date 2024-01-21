import clr
clr.AddReference("PresentationFramework")
clr.AddReference("PresentationCore")
from System.IO import File
from System.Windows.Markup import XamlReader
from System.Windows import Application
from ViewModels.MainWindowViewModel import MainWindowViewModel

class XamlLoader(object):
    def __init__(self, xamlPath):
        stream = File.OpenRead(xamlPath)
        self.Root = XamlReader.Load(stream)
        
    def __getattr__(self, item):
        """Maps values to attributes.
        Only called if there *isn't* an attribute with this name
        """
        return self.Root.FindName(item)

xaml = XamlLoader('MainWindow.xaml')
xaml.Root.DataContext = MainWindowViewModel()
Application().Run(xaml.Root)