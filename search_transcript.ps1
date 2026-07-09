$transcriptPath = "C:\Users\master\.gemini\antigravity\brain\45df4975-f485-4932-a60c-70622ac5c704\.system_generated\logs\transcript.jsonl"
$lines = Get-Content -Path $transcriptPath -Encoding UTF8
foreach ($line in $lines) {
    if ($line -match "사치") {
        # Only print USER_INPUT or MODEL responses that have content
        if ($line -match '"type":"USER_INPUT"') {
            $obj = $line | ConvertFrom-Json
            Write-Host "USER:" $obj.content
        }
        elseif ($line -match '"source":"MODEL"') {
            $obj = $line | ConvertFrom-Json
            if ($obj.content) {
                Write-Host "MODEL:" $obj.content
            }
        }
    }
}
