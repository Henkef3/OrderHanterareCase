
# OrderHanterareCase----

Welcome! Here you can find out how to run the OrderHanterareCase project
## Dependencies
	* dotnet cli ( if you want to run the website from the command prompt)
	* visual studio 2017 ( 2015 might work aswell)
	* ASP .Net Core

## Running the webclient
	
### Run the Website from Visual Studio
	- Locate the file OrderHanterare.sln. Doubleclick and open it in Visual Studio 2017
	- Make sure OrderHanterare is setup as the starting object. If not, right click and choose Set as StartUp Project
	- Now press IIS Express and the site will launch in Internet Explorer

### Run the Website from the commandprompt ( CMD )
	- Open up the commandprompt. 
	- Navigate to ..\OrderHandler\OrderHandler\bin\Release\netcoreapp2.2\publish\. If this folder doesnt exist, continue down this document to "Publish with Visual Studio" and follow the instructions. After your done, continue here.
	- Type 'dotnet OrderHandler.dll'
	- Your prompt should now show you that the service is running locally



## Publish with Visual Studio
	- Locate the file OrderHandler.sln. Doubleclick and open it in Visual Studio 2017
	- Go to the Solution Explorer and right click on OrderHandler. Find and press Publish
	- Press Folder and then Publish
	- Go to the path you specified. Default root is ..\OrderHandler\OrderHandler\bin\Release\netcoreapp2.2\publish
	
