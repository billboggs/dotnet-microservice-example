# dotnet-microservice-example
Example microservice repo to show how to structure / setup .NET core microservices.

## Understanding the Repository Structure

- `/src` - Where all of the microservice source code is stored.
    - `Dotnet.Example.Api` - Project ( webapi - command: `dotnet new web -n Dotnet.Example.Api` ) that houses Application Layer code. This includes any network access to the api and api contracts.
    - `Dotnet.Example.Business` - Project ( classlib - command: `dotnet new classlib -n Dotnet.Example.Business` ) containing all of the business logic for the microservice.
    - `Dotnet.Example.Core` - Project ( classlib - command: `dotnet new classlib -n Dotnet.Example.Core` ) containing all of the interface and model definitions. 
- `/tests` - Where all of the microservice tests are stored ( unit and functional/integration tests ).
- `Dockerfile` - File containing the instructions needed to build the docker image.  
- `Dotnet.Example.sln` - Solution file for the microservice. This solution file contains a reference to all of the projects included within the microservice repository. 
