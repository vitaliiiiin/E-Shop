# MyStore (CHI Software Technical Task Assignment)
Hello there!
I've been doing this for really long time :)

So, This is an instruction on how to prepare the project for work.
<br />
  **1.** Open project, go to ```MyStore/appsettings.json```
```json
"ConnectionStrings": {
    "DefaultConnection": "Server=VITALII_N;Database=MyStore;Trusted_Connection=True;MultipleActiveResultSets=True"
  }
```
Change ```Server=VITALII_N``` in such way that instead of ```VITALII_N``` there should be your Server name.
You can get it when you connect to DB in Ms SQL Server Management Studio.

  **2.** When Connection string is done, write ```Update-Database``` in Package Manager Console.
  <br />
  **3.** Open ```DataForDb.sql``` file in main directory. It's right behind ```MyStore.sln```
  <br />
  It is opened in Ms SQL Serrver Management Studio.
  Before run this query, make sure you **don't have** a database with **the same name** ```MyStore```.
  <br />
  If it's okay, go ahead and run ```DataForDb.sql```.
  It just adds examples to DataBase, so you don't need to do it by yourself.

**Some information about my project's features**

**1.** First registered account becomes admin-account, so you have the following permissions:
   - you can manage Categories (e.g. add new one, delete one or rename one)
   - you can manage Manufacturers as well (e.g. add new one, delete one or rename one)
   - you can manage Products (e.g. rename one, change its price, its description, its category and its manufacturer)
   - you can add a new admin
<br />

**2.** When you done your order, you will **recive an email** with order details, so please enter real email (or temp-mail if you don't wanna use your personal one)
<br />
All the other features you will see in the project :)

P.S. If you have any troubles, you ask me via Telegram (```@vitaliiiiin```) :)
