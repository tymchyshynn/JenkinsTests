node('master') {  
    stage('Checkout') 
	{ 
        git 'https://github.com/tymchyshynn/JenkinsTests.git'
    }
    stage('Restore NuGet') 
	{ 
       bat '"C:\\Dev\\nuget.exe" restore PhpTravels.UITests.sln'
    }
	stage('Build Solution')
    {
        bat '"C:/Program Files (x86)/Microsoft Visual Studio/2017/Community/MSBuild/15.0/Bin/MSBuild.exe" PhpTravels.UITests.sln'
    }
}   stage('Run tests')
    {
        bat '"C:/Users/vasyl.tymchyshyn/Desktop/NUnit.Console-3.9.0/nunit3-console.exe" PhpTravels.UITests/bin/Debug/PhpTravels.UITests.dll'
    }
}