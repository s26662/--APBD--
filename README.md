# ✈️ BiuroPodróżyAPI - Readme do Cwiczenia_5

REST API służące do zarządzania bazą danych biura podróży – klientów, wycieczek oraz ich powiązań.

---

## 🚀 Uruchamianie

1. Otwórz projekt w IDE (np. Rider, Visual Studio)
2. Uruchom aplikację (np. `Program.cs`)
3. W pliku appsettings.json należy umieścić swój ConnectionString
---

## 📡 Endpointy

### 🌍 Wycieczki

#### ✅ GET `/api/trips`
Zwraca listę wszystkich dostępnych wycieczek:
- ID, nazwa, opis, daty, maks. liczba uczestników
- Lista krajów przypisanych do każdej wycieczki

---

### 👤 Klienci i ich wycieczki

#### ✅ GET `/api/clients/{id}/trips`
Zwraca wszystkie wycieczki przypisane do danego klienta:
- Szczegóły wycieczki
- Dane o rejestracji i płatnościach

Obsługuje przypadki:
- Czy Klient istnieje

#### ✅ POST `/api/clients`
Dodaje nowego klienta. Wymagane dane:

```json
{
  "firstName": "Anna",
  "lastName": "Kowalska",
  "email": "anna@example.com",
  "telephone": "+48123456789",
  "pesel": "90010112345"
}
```

Walidacja danych:
- Wszystkie pola są wymagane
- Format PESEL, e-mailu i telefonu musi być poprawny

Zwraca:
- Status 201 Created
- ID nowo utworzonego klienta

