New-Item -ItemType Directory -Force -Path C:\Temp\recover | Out-Null
$files = Get-ChildItem -Path C:\Users\master\.gemini\antigravity\brain\45df4975-f485-4932-a60c-70622ac5c704\.tempmediaStorage -Filter *.png | Where-Object { $_.Length -gt 100000 -and $_.Length -lt 300000 }
$i=1
foreach ($f in $files) {
    Copy-Item $f.FullName -Destination C:\Temp\recover\$i.png
    $i++
}
Write-Host "Copied $($files.Count) files."
