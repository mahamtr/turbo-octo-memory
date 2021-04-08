# CleanArquitectureTemplate .NetCore3.1
 A proyect template implementing Clean Arquitecture with Net CORE 3.1.

## Brief Description

### Core Layer
 This layer AKA Domain layer implements Entities, Value Objects, Events, Services, Interfaces and Handlers.
 This layer only has a AuthService consumed by the JWT controller using PBKDF2-HMAC-SHA1 for password HASH and a static SALT
 
 
 
#### Infraestructure Layer
 This layer implements EntityFramework, it already has a code first built DbContext template.
 It also includes a GenericRepository implementation of the interface from the Core Layer.



#### Api Layer
 This includes a REST-API template with a already working JWT controller
 
 
 ## TODO
 ```
Implement UnitOfWork to include Multi-Transaction Commit
Add a UnitTest Project
```
 
 
