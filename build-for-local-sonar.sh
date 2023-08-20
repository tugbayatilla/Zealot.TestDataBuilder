rm dotCover.Output -rf
rm .sonarqube -rf

dotnet sonarscanner begin /k:"Zealot.TestDataBuilder" /d:sonar.token="$LOCAL_SONARQUBE_TOKEN" /d:sonar.host.url="http://localhost:9000"  /d:sonar.cs.dotcover.reportsPaths=dotCover.Output.html

dotnet build –no-incremental

dotnet dotcover test --dcReportType=HTML

dotnet sonarscanner end /d:sonar.token="$LOCAL_SONARQUBE_TOKEN"
