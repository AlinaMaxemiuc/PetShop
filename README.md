# Introduction 
Welcome to our project template for .NET 8 applications! 
This template serves as a base setup for new projects, providing a multilayer architecture with examples to help you understand the project flow. 
It includes features such as authentication, response caching, logging, and multi-tenancy setup.

The purpose of this project template is to streamline the initial setup process for new .NET 8 applications. 
It provides a structured architecture and includes common features that many applications require, saving time and effort during project initialization.

Technologies Used
-.NET 8 Core
-Entity Framework 8.0.3
-ASP.NET Core Identity

# Getting Started
For  start read about .net 8 https://learn.microsoft.com/en-us/aspnet/core/release-notes/aspnetcore-8.0?view=aspnetcore-8.0 .

Before starting the new project please use the following steps:

1. Modify the appsettings.json file to replace the connection string values with your database connection string, as well as values for Google/Facebook/Microsoft authentication and other app settings.
2. In Package Manager Console, select the default project ".backend" and run the following command to update the database: "EntityFrameworkCore\Update-Database -Context ApplicationDbContext"
3. After creating your tables in the database, update the "Context" and "Entities" in the project using the Scaffold command. In Package Manager Console, select "default project .Infrastructure" and execute the Scaffold command. 
An example of the command can be found in exp.Template.infrastructure\Context\ModelUpdate.txt.
4. Analyze the project structure and flow to retain only the necessary components for your application.

Microsoft login:
Login doesn't function on dev mode only on the fully deployed app. And only after the domain was added to microsoft.


If you want to learn more about creating good readme files then refer the following [guidelines](https://docs.microsoft.com/en-us/azure/devops/repos/git/create-a-readme?view=azure-devops). You can also seek inspiration from the below readme files:
- [ASP.NET Core](https://github.com/aspnet/Home)
- [Visual Studio Code](https://github.com/Microsoft/vscode)
- [Chakra Core](https://github.com/Microsoft/ChakraCore)