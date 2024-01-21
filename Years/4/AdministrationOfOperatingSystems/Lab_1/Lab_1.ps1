'';
$filePath = Read-Host -Prompt 'Input file path';
'';

if (!(Test-Path $filePath))
{
    'File not found.';
    '';
    pause;
    exit;
}

$fileContent = [string](Get-Content $filePath);
$separatorToCount = @{[char]' ' = 0; [char]',' = 0; [char]'.' = 0; [char]'!' = 0; [char]'?' = 0};

foreach ($c in $fileContent.ToCharArray())
{
    if ($separatorToCount.ContainsKey($c))
    {
        $separatorToCount[$c]++;
    }
}

$words = $fileContent.Split($separatorToCount.Keys).Where{$_ -ne ""};

'Number of words: ' + $words.Count;
'';

"Separator to it's number:";
foreach ($key in $separatorToCount.Keys)
{
    [string]::Format("'{0}' = {1}", $key, $separatorToCount[$key]);
}
'';

'Words:';
$words;
'';

pause;