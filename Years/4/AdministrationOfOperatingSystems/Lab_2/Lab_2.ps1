$scriptPath = $(Split-Path $script:MyInvocation.MyCommand.Path);
$fio1Path = Join-Path -Path $scriptPath -ChildPath 'FIO1';
$fio2Path = Join-Path -Path $scriptPath -ChildPath 'FIO2';

try
{
    New-Item -Path $fio1Path -ItemType Directory -ErrorAction Stop | Out-Null;
    New-Item -Path $fio2Path -ItemType Directory -ErrorAction Stop | Out-Null;
}
catch
{
    $_.Exception.Message;
    pause;
    exit;
}

$notepadPath = 'C:\Windows\System32\notepad.exe';
Copy-Item $notepadPath -Destination $fio1Path;
$badFilePath = Join-Path -Path $fio1Path -ChildPath 'notepad.exe';
$shortcutFilePath = Join-Path -Path $fio2Path -ChildPath 'notepad.lnk';
$shortcut = (New-Object -ComObject Wscript.Shell).CreateShortcut($shortcutFilePath);
$shortcut.TargetPath = $notepadPath;
$shortcut.Save();

function DisplayMessageWithTime
{
    param($Message);
    (Get-Date).ToString('HH:mm:ss.fff') + ' :: ' + $message;
}

'';
$invalidProcessId = (Start-Process -FilePath $badFilePath -PassThru).Id;
DisplayMessageWithTime -Message 'Started process by copied file.';
Wait-Process -Id $invalidProcessId;
DisplayMessageWithTime -Message 'Ended process by copied file.';
'';

$validProcessId = (Start-Process -FilePath $shortcutFilePath -PassThru).Id;
DisplayMessageWithTime -Message 'Started process by shortcut to origin file.';
Wait-Process -Id $validProcessId;
DisplayMessageWithTime -Message 'Ended process by shortcut to origin file.';
'';

'WARNING: FIO1 and FIO2 will be removed!';
'';
pause;
Remove-Item -Path @($fio1Path; $fio2Path) -Recurse;