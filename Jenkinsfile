node('master') {  
    stage('Checkout') 
	{ 
        git 'https://github.com/tymchyshynn/JenkinsTests.git'
    }
    stage('Restore NuGet') 
	{ 
       bat '"C:/Dev/nuget.exe" restore PhpTravels.UITests.sln'
    }
}