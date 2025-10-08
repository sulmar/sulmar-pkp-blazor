# Sulmar PKP Blazor - Projekt szkoleniowy

Ten projekt zawiera różne implementacje aplikacji Blazor do celów szkoleniowych, demonstrujące różne architektury i wzorce programowania.

## Struktura projektów

| Projekt | Typ | Opis | Technologie | Port |
|---------|-----|------|-------------|------|
| **Api** | Web API | REST API z endpointami dla klientów | ASP.NET Core, Minimal APIs | 5000/5001 |
| **BlazorServerApp** | Blazor Server | Aplikacja Blazor Server z renderowaniem po stronie serwera | Blazor Server, ASP.NET Core | 5002/5003 |
| **BlazorWebAssemblyApp** | Blazor WebAssembly (Hosted) | Aplikacja Blazor WebAssembly z hostem ASP.NET Core | Blazor WebAssembly, ASP.NET Core | 5004/5005 |
| **BlazorWebAssemblyStandaloneApp** | Blazor WebAssembly (Standalone) | Samodzielna aplikacja Blazor WebAssembly | Blazor WebAssembly | 5006/5007 |
| **Domain** | Class Library | Warstwa domenowa z modelami i abstrakcjami | .NET Standard | - |
| **Infrastructure** | Class Library | Implementacja repozytoriów i logiki infrastruktury | .NET Standard | - |

## Szczegółowy opis projektów

### 🚀 Api
- **Cel**: REST API dostarczające dane dla aplikacji klienckich
- **Funkcjonalności**: 
  - Endpointy dla zarządzania klientami (`/api/customers`)
  - Minimal APIs pattern
  - OpenAPI/Swagger w trybie development
- **Architektura**: Clean Architecture z warstwą API

### 🖥️ BlazorServerApp
- **Cel**: Aplikacja Blazor Server z renderowaniem po stronie serwera
- **Funkcjonalności**:
  - Interaktywne komponenty po stronie serwera
  - Layout z nawigacją
  - Strony: Home, Counter, Weather, Error
- **Zalety**: Szybkie ładowanie, mniejsze rozmiary plików, łatwiejsze debugowanie

### 🌐 BlazorWebAssemblyApp (Hosted)
- **Cel**: Aplikacja Blazor WebAssembly z hostem ASP.NET Core
- **Funkcjonalności**:
  - Renderowanie po stronie klienta
  - Hosting przez ASP.NET Core
  - Współdzielenie kodu między serwerem a klientem
- **Zalety**: Pełna funkcjonalność po stronie klienta, możliwość pracy offline

### 📱 BlazorWebAssemblyStandaloneApp
- **Cel**: Samodzielna aplikacja Blazor WebAssembly
- **Funkcjonalności**:
  - Komponenty: AddressComponent
  - Strony: Home, Contact, Customers/List
  - PWA-ready (Progressive Web App)
- **Zalety**: Niezależność od serwera, możliwość hostingu na CDN

### 🏗️ Domain
- **Cel**: Warstwa domenowa z modelami biznesowymi
- **Zawartość**:
  - Modele: `Customer`, `Address`
  - Abstrakcje: `ICustomerRepository`
- **Zasady**: Nie zależy od żadnej innej warstwy

### 🔧 Infrastructure
- **Cel**: Implementacja logiki infrastruktury
- **Zawartość**:
  - `FakeCustomerRepository` - implementacja repozytorium z danymi testowymi
- **Zasady**: Implementuje abstrakcje z warstwy Domain

## Uruchomienie projektów

### Wymagania
- .NET 9.0 SDK
- Visual Studio 2022 lub VS Code

### Kroki uruchomienia
1. Otwórz terminal w katalogu głównym projektu
2. Uruchom wybrany projekt:
   ```bash
   # API
   dotnet run --project src/Api
   
   # Blazor Server
   dotnet run --project src/BlazorServerApp
   
   # Blazor WebAssembly (Hosted)
   dotnet run --project src/BlazorWebAssemblyApp
   
   # Blazor WebAssembly (Standalone)
   dotnet run --project src/BlazorWebAssemblyApp/BlazorWebAssemblyStandaloneApp
   ```

## Architektura

Projekt demonstruje wzorce Clean Architecture:
- **Domain**: Modele biznesowe i abstrakcje
- **Infrastructure**: Implementacje zewnętrznych zależności
- **API**: Warstwa prezentacji dla REST API
- **Blazor Apps**: Warstwy prezentacji dla interfejsu użytkownika

## Funkcjonalności

- ✅ Zarządzanie klientami (CRUD)
- ✅ Różne architektury Blazor
- ✅ Dependency Injection
- ✅ Clean Architecture
- ✅ Minimal APIs
- ✅ OpenAPI/Swagger

## Struktura katalogów

```
src/
├── Api/                    # REST API
├── BlazorServerApp/        # Blazor Server
├── BlazorWebAssemblyApp/   # Blazor WebAssembly (Hosted)
│   ├── BlazorWebAssemblyApp/
│   ├── BlazorWebAssemblyApp.Client/
│   └── BlazorWebAssemblyStandaloneApp/
├── Domain/                 # Warstwa domenowa
└── Infrastructure/         # Warstwa infrastruktury

# Instalacja szablonów MudBlazor w trybie offline

Ten dokument opisuje, jak zainstalować szablony **MudBlazor.Templates** bez dostępu do Internetu lub bez możliwości połączenia z `nuget.org`.

---

## 🧩 Wymagania

- Zainstalowane środowisko **.NET SDK** (6.0 lub nowsze)
- Dostęp do innego komputera z Internetem (w celu pobrania paczki `.nupkg`)
- Nośnik wymienny (np. pendrive) lub inny sposób przeniesienia pliku `.nupkg` do środowiska docelowego

---

## 🚀 Krok po kroku

### 1. Pobierz paczkę `.nupkg`

Na komputerze z dostępem do Internetu:

1. Otwórz stronę NuGet:  
   [https://www.nuget.org/packages/MudBlazor.Templates](https://www.nuget.org/packages/MudBlazor.Templates)
2. Wybierz wersję, np. **7.0.3**
3. Kliknij przycisk **Download package (.nupkg)**
4. Zapisz plik np. jako:
```
