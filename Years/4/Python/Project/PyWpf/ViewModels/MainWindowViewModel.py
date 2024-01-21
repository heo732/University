import os, sys
sys.path.append(os.path.join(os.path.dirname(__file__), "..\\..\\..\\Project"))

from ViewModels.ViewModelBase import ViewModelBase
from Command import Command
from ConvertersLogic.Enums.Temperature import Temperature
from ConvertersLogic.Enums.Mass import Mass
from ConvertersLogic.Converters.TemperatureConverter import TemperatureConverter
from ConvertersLogic.Converters.MassConverter import MassConverter

class MainWindowViewModel(ViewModelBase):
    def __init__(self):
        ViewModelBase.__init__(self)

        self.ConvertTemperatureCommand = Command(self.convertTemperatureAction)
        self.ConvertMassCommand = Command(self.convertMassAction)

        self.SelectedIndex_InputUnitTemperature = 1
        self.SelectedIndex_OutputUnitTemperature = 0

        self.SelectedIndex_InputUnitMass = 8
        self.SelectedIndex_OutputUnitMass = 1

    def convertTemperatureAction(self):
        try:
            inputUnitTemperature = Temperature().__dir__()[self.SelectedIndex_InputUnitTemperature]
            outputUnitTemperature = Temperature().__dir__()[self.SelectedIndex_OutputUnitTemperature]
            self.OutputValueTemperature = round(TemperatureConverter().convert(float(self.InputValueTemperature), inputUnitTemperature, outputUnitTemperature), 3)
        except Exception:
            self.OutputValueTemperature = "NaN"
        self.RaisePropertyChanged("OutputValueTemperature")

    def convertMassAction(self):
        try:
            inputUnitMass = Mass().__dir__()[self.SelectedIndex_InputUnitMass]
            outputUnitMass = Mass().__dir__()[self.SelectedIndex_OutputUnitMass]
            self.OutputValueMass = round(MassConverter().convert(float(self.InputValueMass), inputUnitMass, outputUnitMass), 3)
        except Exception:
            self.OutputValueMass = "NaN"
        self.RaisePropertyChanged("OutputValueMass")