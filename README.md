# Dotnet-Core-3.1-Microservice-Sample

### Components 

Simple layered architecture 

1. **FrontEnd.Web** - Browser based client 
2. **Backend.BusinessLogic** - all necessary logic shared by Both API's
3. **Contoso.BackEnd.Processor.Api** - Backend API used by Frontend for subsequent operations 
4. **Contoso.BackEnd.Generator.Api** - Secondary API used by Backend API for batch processing etc. 
3. **Contoso.Core** - cross cutting concerns 
4. **Contoso.Data** - Entity Framework core implementation 
5. **Contoso.Tests** - Backend Unit test   

![screenshot1](images/soln.png)
![screenshot2](images/swagger1.png)
![screenshot3](images/swagger2.png)