
 
**Backend : **
There is a rest service developed with .Net Core 5 in the folder named TaskManagerApp. 

For each of the controller methods in the application, you can see the UnitTests written using xUnit in the project named TaskManagerApp.Test.

Since it was developed without using any database, there are 4 predefined tasks that I add to the code every time the application starts.

Since the project is developed with OpenAPI support, you can see the REST endpoints at https://localhost:5001/swagger

> Must be Rebuild Application and Restore Nuget Packages

**Frontend: **

Run First 

> npm install --also=dev

The client application located in *ClientApp* directory , you can run application with *ng serve* command 


**Pages  **
*new-task:*  Route to new task page

*task-list:*  Route to task list application
