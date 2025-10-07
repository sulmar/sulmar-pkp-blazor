# 📊 Zadanie: Dashboard

## 🧩 Cel:
Twoim zadaniem jest stworzenie wielokrotnego komponentu Blazora (InfoCard.razor), który posłuży jako element dashboardu prezentujący kluczowe dane – takie jak liczba klientów, produktów, status systemu itp.
Celem jest przećwiczenie tworzenia komponentu wielokrotnego użytku.

## 🖼️ Szkic: 
  ![alt text](dashboard.png)

---

## ✅ Wymagania funkcjonalne:
1. **Komponent** `InfoCard.razor`
Stwórz komponent, który wyświetla przekazane dane w formie estetycznego „boxa”.

Parametry komponentu:
  - Tytuł (string) – etykieta informacji
  - Wartość (string lub liczba) – główna dana
  - KolorTła (opcjonalny) – klasa CSS (np. bg-primary, bg-success, bg-warning)
  - Ikona (opcjonalna)  – emoji lub ikona z biblioteki (np. 🛒, 👤, ✅)
  
Wymagania wizualne:
- Zaokrąglone rogi
- Cień (box-shadow)
- Estetyczny layout gotowy do użycia w siatce


2. **Strona** `Dashboard.razor` 
Użyj komponentu `InfoCard.razor` co najmniej cztery razy z różnymi danymi w układzie siatki (grid/flex)

**Przykładowe karty:**
- 👤 Liczba klientów: `125`
- 🛒 Liczba produktów: `58`
- 💰 Średnia cena produktu: `48,90 zł`
- ✅ Status systemu: `Online`


--- 

## 💡 Wskazówki
- Możesz użyć Bootstrap (`bg-light`, `text-white`, `shadow-sm`, `rounded`) lub własnego CSS


### 👉 Przy projektowaniu układu pomocne może być narzędzie: [`https://flexboxlabs.netlify.app`](https://flexboxlabs.netlify.app/) 


---


## ⏱️ Czas realizacji: **45 minut**


W razie pytań — zapytaj prowadzącego 🙂
