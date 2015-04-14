# AsyncCoverage 

Sample code

I'm currently using this code with nunit, opencover, and reportgenerator to attempt to figure out how to get this last line of code/branch coverage.

My opencover command:
C:\Users\dmcmullen\AppData\Local\Apps\OpenCover\OpenCover.Console.exe -target:"C:\Program Files (x86)\NUnit 2.6.4\bin\nunit-console.exe" -targetargs:"C:\myrepos\danielmcmullen\SampleCode\AsyncCoverage\AsyncCoverage.nunit /config=debug /noshadow /result=C:\Tools\NunitResults\NUnitResults.xml" -filter:"+[AsyncCoverage]*" -mergebyhash -log:All -register:user -excludebyattribute:*.ExcludeFromCodeCoverage* -output:C:\Tools\CoverageReports\OpenCoverReport.xml

My report generator command:
C:\Tools\ReportGenerator\bin\ReportGenerator.exe -reports:C:\Tools\CoverageReports\OpenCoverReport.xml -targetdir:C:\Tools\CodeCoverage

[![Coverage Status](https://coveralls.io/repos/danielmcmullen/AsyncCoverage/badge.svg)](https://coveralls.io/r/danielmcmullen/AsyncCoverage)
