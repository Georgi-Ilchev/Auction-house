# Auction-house

# :pencil2: Home Services and Solutions
This is my defence project for **ASP.NET Core MVC** course at [SoftUni](https://softuni.bg).
- Niki Kostov's Template: https://github.com/NikolayIT/ASP.NET-Core-Template
- Ivaylo Kenov's Test Library: https://github.com/ivaylokenov/MyTested.AspNetCore.Mvc

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
  
**Alpha Auction House** е платформа за онлайн търгове, която е безплатна за купувачите и продавачите. Нужна е само регистрация.
Всеки може да вземе участие в купуването/продаването/наддаването на аукциони.

  Администраторите имат право да виждат всички регистрирани потребители и да добавят пари към техните акаунти. Могат да добавят, променят или трият дадена обява и да я правят 'аукцион на седмицата'. Също така могат да добавят или премахват категории.
  
  Клиентите могат да купуват и да продават аукциони. При създаването на аукцион се отбелязва колко дни ще бъде активен той. След изтичането на това време, аукционът става неактивен и никой не може да наддава за него.
След като аукционът е качен - за собственика - отива в секция 'мои аукциони', за другите потребители - отива в общия лист с аукциони. 
Само собственика може да променя дадени полета (без цената), може да добавя коментар, може да изтрие обявата, освен ако все още никой не участва в наддаването и не е наддал. 
След като активността на аукциона приключи, последният наддал получава правото да вземе покупката си (съответно да заплати наддадената стойност на собственика).
След успешно продаване на аукцион - за собственика - отива в секция 'продадени', за спечелилият - в секция 'закупени'.
Парите на потребителят - баланс, с който разполага, който се учеличава или намаля само при успешно закупуване или продажба.
Виртуални пари - или пари в движение, които намалят, когато потребителя наддаде за даден аукцион и се връщат, когато друг наддаде над неговата стойност.

URL: <https://auctionshouse.azurewebsites.net/>

**Test Accounts**:

Username: Admin  
Password: 123456  

Username: Client  
Password: 123456  

Username: Test  
Password: 123456

# :hammer: Built With
- ASP.NET Core
- MS SQL Server
- Entity Framework Core
- AutoMapper 
- Bootstrap
- jQuery
- xUnit
- MyTested.AspNetCore.Mvc
- Moq
- SignalR -> Real-Time Bidding
