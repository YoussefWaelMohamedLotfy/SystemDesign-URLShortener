# URL Shortener - System Design Interview

> This repository is my practical solution for the problem in [Chapter 8 in System Design Interview (Second Edition) by Dr. Alex Xu](https://printige.net/product/system-design-interview-an-insider-guide/)

## Steps to get the API up and running

1. Clone the repo using `git clone https://github.com/YoussefWaelMohamedLotfy/SystemDesign-URLShortener.git`
2. Build the project.
3. Run the command `Update-Database` in *VS Package Manager Console*, or `dotnet ef database update` with the *dotnet CLI*
4. Start the app using `Ctrl + F5`, or `dotnet run` in the terminal.

You will be redirected to swagger by default, and you can use the API.

## Shortening Algorithms implemented 
+ Base62 Conversion
+ MD5 Hashing (Collision not handled yet)

## Additional Components that can be added
+ Caching
+ Rate Limiting

> Both of them are implemented in my ASP.NET 6 Web API Template. [Check it out from here.](https://github.com/YoussefWaelMohamedLotfy/ASP-dotNET6-WebAPI-Template)