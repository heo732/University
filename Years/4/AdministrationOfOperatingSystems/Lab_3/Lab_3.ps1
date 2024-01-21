$scriptPath = $(Split-Path $script:MyInvocation.MyCommand.Path);
$fioDirectoryPath = Join-Path -Path $scriptPath -ChildPath 'FIO';
if (!(Test-Path $fioDirectoryPath))
{
    try
    {
        New-Item -Path $fioDirectoryPath -ItemType Directory -ErrorAction Stop | Out-Null;
    }
    catch
    {
        $_.Exception.Message;
        pause;
        exit;
    }
}
$wordDocPath = Join-Path -Path $fioDirectoryPath -ChildPath 'Lab3.doc';

$wordApp = New-Object -ComObject Word.Application;
$wordApp.Visible = $true;
$wordDoc = $wordApp.Documents.Add();
$wordAppSelection = $wordApp.Selection;
$wordAppSelection.Font.Bold = $false;
$wordAppSelection.Font.Italic = $false;
$wordAppSelection.Font.Name = 'Times New Roman';
$wordAppSelection.Font.Size = 14;
$wordAppSelection.ParagraphFormat.Alignment = 3;

$wordAppSelection.TypeText('Lab3');
$wordAppSelection.TypeParagraph();
$wordAppSelection.InlineShapes.AddPicture($(Join-Path -Path $scriptPath -ChildPath 'image_1.jpg')) | Out-Null;
$wordAppSelection.TypeParagraph();
$wordAppSelection.InlineShapes.AddPicture($(Join-Path -Path $scriptPath -ChildPath 'image_2.png')) | Out-Null;
$wordAppSelection.TypeParagraph();

$wordAppSelectionRange = $wordAppSelection.Range;
$wordAppSelectionRange.Text = ('F = ' + [char]0x222c + [char]0x005e + 'n' + [char]0x005f + '1' + '-f(x,y)ds');
$formula = $wordDoc.OMaths.Add($wordAppSelectionRange);
$formula.OMaths.BuildUp();
$wordAppSelection.TypeParagraph();
$wordAppSelection.TypeParagraph();

$wordAppSelectionRange = $wordAppSelection.Range;
$wordAppSelectionRange.Text = ('S = ' + [char]0x2211 + [char]0x005e + '100' + [char]0x005f + '10' + '+f(x,y)');
$formula = $wordDoc.OMaths.Add($wordAppSelectionRange);
$formula.OMaths.BuildUp();
$wordAppSelection.TypeParagraph();

$wordDoc.SaveAs([ref][string]$wordDocPath, [ref][Microsoft.Office.Interop.Word.WdSaveFormat]::wdFormatPrf);
$wordDoc.Close([Microsoft.Office.Interop.Word.WdSaveOptions]::wdDoNotSaveChanges);
$wordApp.Quit();

Invoke-Item $wordDocPath;