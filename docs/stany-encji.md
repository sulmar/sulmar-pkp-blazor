
``` mermaid
stateDiagram-v2
    [*] --> Detached: new T
    [*] --> Unchanged: First(), ToList()

    Detached --> Unchanged: Attach
    Detached --> Added: Add

    Unchanged --> Modified: SetProperty
    Modified --> Unchanged: SaveChanges

    Unchanged --> Deleted: Remove
    Modified --> Deleted: Remove

    Deleted --> Detached: SaveChanges

    Added --> Unchanged: SaveChanges
    Added --> Detached: Remove

    Unchanged --> Detached: SaveChanges (no tracking)
```

| Stan | Opis |
| ---- | ---- |
| Detached | Encja nie jest obecnie śledzona przez kontekst EF Core. To znaczy, że nie jest monitorowana pod kątem zmian i nie ma powiązania z żadnym kontekstem bazy danych. |
| Added | Encja została dodana do kontekstu i oznacza, że nie istnieje jeszcze w bazie danych. Po wykonaniu operacji `SaveChanges`, encja przechodzi do stanu **Unchanged**, ponieważ zostaje zapisana w bazie danych, a jej stan zostaje zaktualizowany. |
| Unchanged | Encja jest śledzona przez kontekst i istnieje w bazie danych w niezmienionej formie. To oznacza, że żadne właściwości nie zostały zmienione od czasu ostatniego zapisu zmian. |
| Modified | Encja jest śledzona przez kontekst, istnieje w bazie danych, ale jej właściwości zostały zmienione. Po wykonaniu operacji `SaveChanges`, encja przechodzi z powrotem do stanu "Unchanged", ponieważ jej zmodyfikowane dane zostają zaktualizowane w bazie danych. |
| Deleted | Encja jest śledzona przez kontekst, istnieje w bazie danych, ale została oznaczona do usunięcia. Po wykonaniu operacji `SaveChanges`, encja zostaje usunięta z bazy danych, a jej stan przechodzi do **Detached**, co oznacza, że nie jest już śledzona przez kontekst. |
