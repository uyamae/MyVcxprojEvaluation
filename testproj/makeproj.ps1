# スクリプトファイルのディレクトリに移動
Set-Location $PSScriptRoot
# build に作成
cmake -S . -B build -G "Visual Studio 17 2022"
