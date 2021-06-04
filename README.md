# MyStore (CHI Software Technical Task Assignment)
Hello there!
I've been douing this for really long time :)

So, This is an instruction on how to prepare a project for work.
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
  It opens in Ms SQL Serrver Management Studio.
  Before run this query, make sure you **don't have** a database with the same name ```MyStore```.
  <br />
  If it's okay, go ahead and run ```DataForDb.sql```.
  It just addes examples to DataBase, so you don't need to do it by yourself.

P.S. If you have any troubles, you can contact me via Telegram (```@vitaliiiiin```) :))
