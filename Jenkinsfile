node('master') {  
    stage('Checkout') 
	{ 
        git 'https://github.com/tymchyshynn/JenkinsTests.git'
    }
    stage('Restore NuGet') 
	{ 
      bat '"C:\\nuget.exe" restore src/PhpTravels.UITests.sln'
    }
}