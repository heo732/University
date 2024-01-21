::mkdir bin

"C:\Program Files (x86)\IronPython 2.7"\ipy.exe "C:\Program Files (x86)\IronPython 2.7"\Tools\Scripts\pyc.py /main:App.py App.py /target:winexe

::move App.exe bin\App.exe
::move App.dll bin\App.dll