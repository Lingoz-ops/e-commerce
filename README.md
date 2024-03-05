# e-commerce

This is a small e-commerce application written in C# which allows the user to of the system to add customers, view products that are available, check past orders and has a checkout page.

The project uses a REST api to fetch and manipulate the data.

_What you need to run the App_

**Database**
- Download Microsoft SQL Server Express edition on https://www.microsoft.com/en-za/download/details.aspx?id=101064
- Download Microsoft SQL Server Management Studio(MSSMS) on https://learn.microsoft.com/en-us/sql/ssms/download-sql-server-management-studio-ssms?view=sql-server-ver16
- After they're done installing, login in to MSSMS using the credentials you got from the first step.
  
**Backend-setup**

-Download Visual Studio 22
-Go to file and open the project solution
-At the top of your screen, go to Buiild, and select Clean Solution 
-GO to developer powershell on visual studio and run the command 'dotnet restore'
-Run the Api on IIS Express

**Front-end-setup**
- Download NodeJS version 16.x.x upwards on https://nodejs.org/en
- run npm start to start the app

- When the API is run, it will pop up a swagger page which can be used to test the API's or optionally you can use Postman.

