'Process list:';
Get-Process;
'';
'==============================================================================';
'';

$pathToStartProcess = Read-Host -Prompt 'Input filePath to start process';
$startedProcess = Start-Process -FilePath $pathToStartProcess -PassThru;
Start-Sleep -Seconds 2;
Stop-Process -Id $startedProcess.Id;

'';
'==============================================================================';
'';
'Running services:';
Get-Service | Where-Object -Property Status -eq Running | Format-Table Name, DisplayName;

'';
'==============================================================================';
'';
$serviceNameToStart = Read-Host -Prompt 'Input name of service to start';
Start-Service -Name $serviceNameToStart;

'';
'==============================================================================';
'';
'Commands that runs on system loading:';
Get-WmiObject Win32_StartupCommand | Format-Table Caption, Command, Location;

'';
'==============================================================================';
'';
'OS info.';
$osInfo = Get-WmiObject Win32_OperatingSystem;
'Name: ' + $osInfo.Name.Split('|')[0];
'Version: ' + $osInfo.Version;
'Architecture: ' + $osInfo.OSArchitecture;

'';
'==============================================================================';
'';
'Installed applications:';
Get-ItemProperty HKLM:\Software\Wow6432Node\Microsoft\Windows\CurrentVersion\Uninstall\* `
    | Select-Object DisplayName, DisplayVersion, Publisher, InstallDate `
    | Sort-Object DisplayName `
    | Where-Object DisplayName -ne $null `
    | Format-Table;

'';
'==============================================================================';
'';
'Physical memory size: ' + (Get-CimInstance Win32_PhysicalMemory | Measure-Object -Property Capacity -Sum).Sum / 1gb + ' GB';

'';
'==============================================================================';
'';
'Processors info:';
$property = 'Name', 'MaxClockSpeed', 'AddressWidth', 'NumberOfCores', 'NumberOfLogicalProcessors';
Get-WmiObject Win32_Processor -Property $property | Format-Table -Property $property;

'';
'==============================================================================';
'';
'Network adapters:';
Get-NetAdapter;

'';
'==============================================================================';
'';
'IP-address: ' + (Test-Connection -ComputerName (hostname) -Count 1).IPV4Address;
'';
'==============================================================================';
pause;