from System.Windows.Input import ICommand

class Command(ICommand):
    def __init__(self, execute, canExecute = lambda : True):
        self.execute = execute
        self.canExecute = canExecute

    def Execute(self, parameter):
        self.execute()
        
    def add_CanExecuteChanged(self, handler):
        pass
    
    def remove_CanExecuteChanged(self, handler):
        pass

    def CanExecute(self, parameter):
        return self.canExecute()