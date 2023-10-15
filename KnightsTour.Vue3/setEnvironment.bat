::Replace the character string '||ENV||' with the first passed parameter
@echo off
@echo Configuring environmental settings for quasar vue UI

powershell -Command "(Get-Content quasar.config.js) | ForEach-Object { $_ -replace '{ENV}', '%1%' } | Set-Content quasar.config.js"
powershell -Command "(Get-Content quasar.config.js) | ForEach-Object { $_ -replace '{PUBLIC_PATH}', '%2%' } | Set-Content quasar.config.js"
