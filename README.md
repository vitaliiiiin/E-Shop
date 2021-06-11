# MyStore (CHI Software Technical Assignment)
Hello there!
I've done my best for this technical assignment :)

So, this is an instruction on how to prepare the project for work:
<br />

  **1.** Open project, go to ```MyStore/appsettings.json```.
```json
"ConnectionStrings": {
    "DefaultConnection": "Server=YOUR_SERVER_HERE;Database=MyStore;Trusted_Connection=True;MultipleActiveResultSets=True"
  }
```
Change ```Server=YOUR_SERVER_HERE``` in such way that instead of ```YOUR_SERVER_HERE``` there would be your Server name.
You can get it when you connect to DB in Ms SQL Server Management Studio.

```
"MailJet": {
    "ApiKey": "8078b8d5603638751a604e929ddfe5b5",
    "SecretKey": "SECRET_KEY_HERE"
  }
```
Change ```"SecretKey": "SECRET_KEY_HERE"``` in such way that instead of ```SECRET_KEY_HERE``` there should be **the secret key I've sent** with this technical assingnment.
Example: ```"SecretKey":"8078b8d5603638751a604e929ddfe5b5"``` (don't use this key, it's just an example).

  **2.** When Connection string is done, write ```Update-Database``` in Package Manager Console.
  
  But before run this command, make sure you **don't have** a database with **the same** ```MyStore``` name.
  <br />
  If you have, rename it or delete it.
  <br />
  If everything's okay, go ahead and run ```Update-Database``` command.
  <br />
  
  **3.** Open ```DataForDb.sql``` file in main directory. It's right behind ```MyStore.sln```.
  <br />
  It is opened in Ms SQL Serrver Management Studio.
  It just adds examples to DataBase, so you don't need to do it by yourself.

**Some information about my project's features**

**1.** First registered account becomes admin-account, so you have the following permissions:
   - you can manage Categories (e.g. add new one, delete one or rename one)
   - you can manage Manufacturers as well (e.g. add new one, delete one or rename one)
   - you can manage Products (e.g. rename one, change its price, its description, its category and its manufacturer)
   - you can add a new admin
<br />

**2.** When you done your order, you will **recieve an email** with order details, so please enter real email 
(or temp-mail if you don't wanna use your personal one).
<br />
All the other features you will see in the project :)

P.S. If you have any troubles with this project, you can ask me via Telegram (```@vitaliiiiin```) :)
