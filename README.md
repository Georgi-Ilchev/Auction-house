# Auction-house

# :pencil2: Home Services and Solutions
This is my defense project for **ASP.NET Core MVC** course at [SoftUni](https://softuni.bg).
Project Template: Niki Kostov's Template: https://github.com/NikolayIT/ASP.NET-Core-Template

# :memo: Overview
**Alpha Auction House** is an online bidding platform which is free for buyers and sellers and is protecting them from fraud. You need to register only.
Anyone can take part in buying/selling/bidding of auctions.

  Administrators have the right to see all registered users and can add money to their accounts. They can add, edit or delete an ad and make it 'auction of the week'.
They can also add or remove categories.

  Clients can buy and sell auctions. When creating an auction, you have to enter the period (number of days) in wich is going to be active. After this period has expired, the auction becomes invalid and nobody can bid for it.
Information regarding the owner - if an auction is uploaded - it goes to 'my auctions' section.
Information regarding the visitors - it goes to 'all auctions' section.
Only owners can edit fields (except for the field price), add comments, delete an ad, but only when no one has bid yet.
After an auction has expired, the last bidder receives the right to get their purchase and to pay the owner accordingly.
Information regarding the owner - if an auction is sold - it goes to 'my sales' section.
Information regarding the buyer - it goes to 'my purchases' section.
User's balance is the money of the user wich can go up and down only if a purchase is successful.
User's virtual balance is the money wich can go up and down when the user has bid for a particular auction and then go back if another user has bid for the same auction.
  
URL: <https://myapphere.azurewebsites.net/>

**Test Accounts**:

Username: Admin  
Password: 123456  

Username: Client  
Password: 123456  

Username: Client  
Password: 123456

## :hammer: Built With
- ASP.NET Core
- MS SQL Server
- Entity Framework Core
- AutoMapper 
- Bootstrap
- jQuery
- xUnit
- Moq
- SignalR -> Real-Time Bidding
