# GlucosePatrolAPI
Eleven Fifty Academy Blue Badge Final Project 

## Requirements:

* Come up with an idea for an application that will use a minimum of 3 custom data tables
* Including at least one Foreign Key relationship
* Create a wireframe of the application and review it with an instructor
* Build out an n-tier structured API (think ElevenNote) with the following tiers
* Data: This layer houses your classes that relate to the DB (POCOs, Identity, etc)
* Models: This layer houses the reusable models for the rest of the layers
* Services: This layer is where you’ll have most of your heavy backend logic
* Web API: This is where the controllers and API endpoints will be
* Link to repository site on your deployed Portfolio
* Repository has a README.md (Links to an external site.) associated with the project

## Mission Statement
With Glucose Patrol, diabetic users are able to log and track their blood sugar levels, with an ability to return data trends over time . By also adding in their daily activities, Glucose Patrol provides useful information for diabetes management.

## Authors
* Seth McLaughlin   Seth-d-mclaughlin
* Greg Murray    gremurra 
* Gurpreet Singh   Gurpreet10581

## Important Project Links
* Project Planing Template- https://docs.google.com/document/d/1baDJirR-G36P69SaufzsseLLMiEovCGpLgAhkhKSDLg/edit#heading=h.apyy2fblhnhk
* WireFrame- https://docs.google.com/spreadsheets/d/1ejaVnSb47qH7iWpG4AxuUu2lwiwq92950iz3FqIfKQs/edit#gid=2002344431

## Steps to follow for proper implementation of Endpoints
Glucose Patrol has 3 classes- Patient, Entry, and Event. All the classes communicate with each other for the application to work properly. Every class has been assigned its own designated route for proper functioning. In the API controller section, each table has been assigned unique RoutePrefix and Routes for every method to work effectively. We have multiple methods within one Controller class and routing each method uniquely helps an individual to test and pass the endpoints.

To test all the methods in Postman, one must follow the exact route of the endpoints provided in the host API title section. All the inputs are required to be added to the body parameters of PostMan. 
For instance- URL should look like- https://localhost:44326/Entry/Start={Start}/End={End}

and the body parameters should have the required Keys and Values.
In this case, PatientId->2, Start->2020-04-30(Format-YYYY-MM-DD), and End->2020-05-05(Format-YYYY-MM-DD).

Every route is different than others since it requires changing the Keys, Values, and route path for endpoints to work accordingly. So it is very important to have the route path as is in the Postman URL section and only change/add Keys and Values in Body. 

## Resources Implemented 
* Introduction to ASP.NET Web API-
  https://dotnettutorials.net/lesson/web-api-architecture/
* Enabling CRUD Operations in ASP.NET Web API-
  https://docs.microsoft.com/en-us/aspnet/web-api/overview/older-versions/creating-a-web-api-that-supports-crud-operations
* Identity model customization in ASP.NET-
  https://docs.microsoft.com/en-us/aspnet/core/security/authentication/customize-identity-model?view=aspnetcore-3.1
* Data Annotations - ForeignKey Attribute-
  https://www.entityframeworktutorial.net/code-first/foreignkey-dataannotations-attribute-in-code-first.aspx
* Use of .NET Timer Class-
  https://stackoverflow.com/questions/4529019/how-to-use-the-net-timer-class-to-trigger-an-event-at-a-specific-time
* Adding routes on Web.Api-
  https://stackoverflow.com/questions/57521517/how-can-i-add-multiple-routes-in-web-api
* Routing with multiple Get methods-
  https://stackoverflow.com/questions/12775590/routing-with-multiple-get-methods-in-asp-net-web-api/12778214
* Writing a Good Documentation-
	https://guides.lib.berkeley.edu/how-to-write-good-documentation
