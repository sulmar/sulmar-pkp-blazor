# Przygotowanie bazy danych Sakila z LocalDB

## 1. Utworzenie i uruchomienie instancji LocalDB
Utworz instancje LocalDB
```bash
sqllocaldb create efcore-demo
```

Uruchom
```bash
sqllocaldb start efcore-demo
```

Sprawdz czy dziala
```bash
sqllocaldb info efcore-demo
```

To wszystko — instancja SQL Server działa lokalnie.

## 2. Utworzenie bazy na podstawie skryptu

Masz plik, `sql-server-sakila-schema.sql` , który zawiera `CREATE DATABASE sakila + USE sakila`

W takim przypadku nie tworzysz bazy ręcznie — skrypt zrobi to za Ciebie.

Uruchamiasz:
```bash
sqlcmd -S "(localdb)\efcore-demo" -i sql-server-sakila-schema.sql
```

To polecenie:
	•	uruchomi skrypt
	•	utworzy bazę sakila
	•	utworzy tabele


## 3. Załadowanie przykładowych danych (insert)

Gdy baza i schema są gotowe, ładujesz dane:

```bash
sqlcmd -S "(localdb)\efcore-demo" -d sakila -i sql-server-sakila-insert-data.sql
```


## 4. Weryfikacja

```bash
sqlcmd -S "(localdb)\efcore-demo" -d sakila -Q "SELECT COUNT(*) FROM customer;"
```

Powinno zwrócić 599 klientów.


---

# Usuwanie instancji LocalDB

1. Zatrzymaj instancję
```
sqllocaldb stop efcore-demo
```

Jeśli instancja jest w trakcie użycia, możesz wymusić:

```
sqllocaldb stop efcore-demo -k
```

(-k = kill)

2. Usuń instancję
```
sqllocaldb delete efcore-demo
```
To natychmiast usuwa instancję wraz ze wszystkimi bazami w niej, które fizycznie siedzą w katalogu .mdf instancji LocalDB.


3. Sprawdzenie, czy usunięta
```
sqllocaldb info
```
