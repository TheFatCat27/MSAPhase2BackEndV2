# MSAPhase2BackEndV2

How middleware via DI simplifies my code:
swagger adds a UI to the api, which allows me to view it from the browser by doing this I can access the functions of the api without needing to create a front end for them

How middleware libraries make my code easier to test:
I used FakeItEasy for testing, which similar to NSubstitute allows me to test the api without having to actually make a call to the database, creating a "fake" class or interface which we can test it on instead.

The Development configuration only allows localhost as an allowed host, whereas in appsettings all hosts are allowed
