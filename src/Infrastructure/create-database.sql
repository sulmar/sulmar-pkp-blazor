-- ===========================================================
-- 1. Tworzenie tabel tylko jeśli nie istnieją (z OBJECT_ID)
-- ===========================================================

IF OBJECT_ID('dbo.Addresses', 'U') IS NULL
BEGIN
    CREATE TABLE dbo.Addresses (
        AddressID INT IDENTITY(1,1) PRIMARY KEY,
        Street NVARCHAR(100) NOT NULL,
        City NVARCHAR(50) NOT NULL,
        PostalCode NVARCHAR(20) NOT NULL,
        Country NVARCHAR(50) NOT NULL
    );
END;

IF OBJECT_ID('dbo.Customers', 'U') IS NULL
BEGIN
    CREATE TABLE dbo.Customers (
        CustomerID INT IDENTITY(1,1) PRIMARY KEY,
        FirstName NVARCHAR(50) NOT NULL,
        LastName NVARCHAR(50) NOT NULL,
        Email NVARCHAR(100) NOT NULL UNIQUE,
        CompanyName NVARCHAR(100) NULL,
        Phone NVARCHAR(20) NULL,
        AddressID INT NULL,
        CreatedAt DATETIME DEFAULT GETDATE(),
        CONSTRAINT FK_Customers_Addresses
            FOREIGN KEY (AddressID)
            REFERENCES dbo.Addresses(AddressID)
            ON DELETE SET NULL
    );
END;

-- ===========================================================
-- 2. Wstawianie przykładowych danych tylko jeśli tabele są puste
-- ===========================================================

IF NOT EXISTS (SELECT 1 FROM dbo.Addresses)
BEGIN
    INSERT INTO dbo.Addresses (Street, City, PostalCode, Country) VALUES
    ('ul. Lipowa 12', 'Warszawa', '00-123', 'Polska'),
    ('ul. Długa 5', 'Kraków', '31-045', 'Polska'),
    ('ul. Słoneczna 7', 'Gdańsk', '80-001', 'Polska'),
    ('ul. Polna 18', 'Wrocław', '50-200', 'Polska'),
    ('ul. Mickiewicza 3', 'Poznań', '60-100', 'Polska'),
    ('ul. Leśna 22', 'Szczecin', '70-300', 'Polska'),
    ('ul. Ogrodowa 9', 'Łódź', '90-001', 'Polska'),
    ('ul. Krótka 4', 'Lublin', '20-400', 'Polska'),
    ('ul. Spacerowa 10', 'Katowice', '40-100', 'Polska'),
    ('ul. Wesoła 8', 'Białystok', '15-200', 'Polska');
END;

IF NOT EXISTS (SELECT 1 FROM dbo.Customers)
BEGIN
    INSERT INTO dbo.Customers (FirstName, LastName, Email, CompanyName, Phone, AddressID) VALUES
    ('Jan', 'Kowalski', 'jan.kowalski@example.com', 'Kowalski Sp. z o.o.', '+48 501 111 222', 1),
    ('Anna', 'Nowak', 'anna.nowak@example.com', 'Nowak Consulting', '+48 502 333 444', 2),
    ('Piotr', 'Wiśniewski', 'piotr.wisniewski@example.com', NULL, '+48 503 222 111', 3),
    ('Katarzyna', 'Wójcik', 'katarzyna.wojcik@example.com', 'TechSoft', '+48 504 555 666', 4),
    ('Tomasz', 'Kowalczyk', 'tomasz.kowalczyk@example.com', 'Kowalczyk Group', '+48 505 777 888', 5),
    ('Agnieszka', 'Kamińska', 'agnieszka.kaminska@example.com', NULL, '+48 506 333 999', 6),
    ('Marek', 'Lewandowski', 'marek.lewandowski@example.com', 'Lewandowski Solutions', '+48 507 111 000', 7),
    ('Ewa', 'Zielińska', 'ewa.zielinska@example.com', 'GreenTech', '+48 508 999 222', 8),
    ('Paweł', 'Szymański', 'pawel.szymanski@example.com', NULL, '+48 509 888 333', 9),
    ('Magdalena', 'Dąbrowska', 'magdalena.dabrowska@example.com', 'Dąbrowska Design', '+48 510 444 555', 10);
END;

-- ===========================================================
-- 3. Podgląd danych klientów i ich adresów
-- ===========================================================

SELECT 
    c.CustomerID,
    c.FirstName,
    c.LastName,
    c.Email,
    c.CompanyName,
    c.Phone,
    a.Street,
    a.City,
    a.PostalCode,
    a.Country,
    c.CreatedAt
FROM dbo.Customers AS c
LEFT JOIN dbo.Addresses AS a ON c.AddressID = a.AddressID
ORDER BY c.CustomerID;