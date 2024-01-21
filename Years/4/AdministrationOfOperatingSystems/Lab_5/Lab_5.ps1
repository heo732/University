$filePath = Read-Host -Prompt 'Input file path';

if (![System.IO.File]::Exists($filePath))
{
    'File not found.';
    pause;
    exit;
}

$charToInt = @{};
$intToChar = @{};

filter Encryption
{
    if (!$charToInt.ContainsKey($_))
    {
        $charToInt.Add($_, $charToInt.Count);
        $intToChar.Add($intToChar.Count, $_);
    }
    return $charToInt[$_].ToString() + ' ';
}

filter Decryption
{
    if (($intToChar.ContainsKey([int]$_)) -and ($_ -ne ''))
    {
        return $intToChar[[int]$_];
    }
    return '';
}

$originContent = Get-Content -Path $filePath;
$encryptedContent = ($originContent.ToCharArray() | Encryption) -join ' ';
$decryptedContent = ($encryptedContent.split() | Decryption) -join '';

'';
'Origin:';
$originContent;
'';
'Encrypted:';
$encryptedContent;
'';
'Decrypted:';
$decryptedContent;

pause;