$answer = Read-Host -Prompt "Do you want enable scheduled shutdown? ['y' = enable; otherwise = disable]";
'';

if (!($answer.ToLower()[0] -eq 'y'))
{
    shutdown -a;
    'Scheduled shutdown disabled.';
    '';    
    pause;
    exit;
}

function IsTimeValid ([string]$time)
{
    if ([regex]::IsMatch($time, '\d\d:\d\d:\d\d'))
    {
        $timeItems = $time.Split(':');
        if ([int]$timeItems[0] -le 23 -and [int]$timeItems[1] -le 59 -and [int]$timeItems[2] -le 59)
        {
            $true;
        }
        else
        {
            $false;
        }
    }
    else
    {
        $false;
    }
}

do
{
    $targetTime = Read-Host -Prompt "Input target shutdown time in next format - 'hh:mm:ss', for example - 18:30:00   ";
}
while (!(IsTimeValid $targetTime));

$currentDateTime = Get-Date;
$targetTimeItems = $targetTime.Split(':');
$targetDateTime = Get-Date -Date $currentDateTime -Hour $targetTimeItems[0] -Minute $targetTimeItems[1] -Second $targetTimeItems[2];

$timespan = (New-TimeSpan -Start $currentDateTime -End $targetDateTime).TotalSeconds;
if ($timespan -lt 0)
{
    $timespan = 86400 + $timespan;
}

shutdown -f -s -t $timespan;

'';
'Scheduled shutdown enabled.';
'System will shutdown after ' + $timespan + ' seconds.';
'';
pause;