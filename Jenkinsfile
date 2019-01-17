properties([
    parameters([
        string (name: 'branchName', defaultValue: 'master', description: 'Branch to get the tests from')
    ])
])
def isFailed = false 
def branch = params.branchName
def buildArtifactsFolder = "C:/BuildPackagesFromPipeline/$BUILD_ID"
currentBuild.description = "Branch: $branch"


	def RunNUnitTests(String pathToDll, String condition, String reportName)
	{
		try
		{
			bat "C:/Users/vasyl.tymchyshyn/Desktop/NUnit.Console-3.9.0/nunit3-console.exe $pathToDll $condition --result=$reportName"
		}
		finally
		{
			stash name: reportName, includes: reportName
		}
	
	}

node('master') {  
    stage('Checkout') 
	{ 
      git branch: branch, url: 'https://github.com/tymchyshynn/JenkinsTests.git'
    }
    stage('Restore NuGet') 
	{ 
       powershell "build.ps1 RestoreNuGetPackages"
    }
	stage('Build Solution')
    {
        bat '"C:/Program Files (x86)/Microsoft Visual Studio/2017/Community/MSBuild/15.0/Bin/MSBuild.exe" PhpTravels.UITests.sln'
    }	
	stage('Copy Artifacts')
    {
        bat "(robocopy PhpTravels.UITests/bin/Debug $buildArtifactsFolder /MIR /XO) ^& IF %ERRORLEVEL% LEQ 1 exit 0"
    }
}

catchError
	{
		isFailed = true
		stage('Run Tests')
		{
		    parallel FirstTest:{		
				node('master')
				{
					RunNUnitTests("$buildArtifactsFolder/PhpTravels.UITests.dll", "--where cat==FirstTest", "TestResult1.xml")
				}
			}, SecondTest:{
				node('Slave')
				{
					RunNUnitTests("$buildArtifactsFolder/PhpTravels.UITests.dll", "--where cat==SecondTest", "TestResult2.xml")
				}
			}
		}
		isFailed =true
	}
	
	
	node('master')
{
    stage('Reporting')
    {
        unstash "TestResult1.xml"
        unstash "TestResult2.xml"

        archiveArtifacts '*.xml'
        nunit testResultsPattern: 'TestResult1.xml, TestResult2.xml'
  
    }
}
	