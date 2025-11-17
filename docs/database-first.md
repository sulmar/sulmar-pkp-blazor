
# **1. Zainstaluj pakiety EF Core Tools**

W katalogu projektu:
```
dotnet add package Microsoft.EntityFrameworkCore.SqlServer --version 9.0.0
dotnet add package Microsoft.EntityFrameworkCore.Tools --version 9.0.0
```

Sprawdzenie
```
dotnet list package
```

Zobaczysz coś takiego:
```
Microsoft.EntityFrameworkCore.Design  9.0.0
Microsoft.EntityFrameworkCore.Tools  9.0.0
Microsoft.EntityFrameworkCore.SqlServer  9.0.0
```

Pakiet `Microsoft.EntityFrameworkCore.Tools` instaluje automatycznie `Microsoft.EntityFrameworkCore.Design`
# **2. Sprawdź connection string**

Dla LocalDB efcore-demo:
```
Server=(localdb)\efcore-demo;Database=sakila;Trusted_Connection=True;
```


# **3. Wykonaj scaffolding**

W katalogu projektu `Infrastructure` (gdzie jest .csproj):

```
dotnet ef dbcontext scaffold "Server=(localdb)\efcore-demo;Database=sakila;Trusted_Connection=True;" Microsoft.EntityFrameworkCore.SqlServer -o Models -c SakilaContext
```


Parametry:

- -o Models → folder na wygenerowane modele i DbContext
    
- -c SakilaContext → nazwa klasy DbContext (możesz zmienić)

---

# **🔍 Jak sprawdzić, że działa?**

Po scaffolding powinny pojawić się:

- Models/SakilaContext.cs
    
- klasy encji: Actor.cs, Film.cs, Category.cs, itd.


# **🧩 Przydatne opcje**

###  **Nadpisanie istniejących plików**

```
--force
```

### **Pominięcie tabel (jeśli jakieś są problematyczne)**

```
--exclude-tables table1 table2
```

