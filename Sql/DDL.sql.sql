-- Drop tables if they exist
IF OBJECT_ID('Review', 'U') IS NOT NULL
    DROP TABLE Review;

IF OBJECT_ID('Booking', 'U') IS NOT NULL
    DROP TABLE Booking;

IF OBJECT_ID('Employee', 'U') IS NOT NULL
    DROP TABLE Employee;

IF OBJECT_ID('Guest', 'U') IS NOT NULL
    DROP TABLE Guest;

IF OBJECT_ID('Room', 'U') IS NOT NULL
    DROP TABLE Room;

IF OBJECT_ID('Position', 'U') IS NOT NULL
    DROP TABLE Position;

IF OBJECT_ID('Category', 'U') IS NOT NULL
    DROP TABLE Category;

IF OBJECT_ID('Document', 'U') IS NOT NULL
    DROP TABLE Document;

-- Create Category Table
CREATE TABLE Category (
    Id INT PRIMARY KEY,
    Name NVARCHAR(MAX),
    Price DECIMAL
);

-- Create Room Table
CREATE TABLE Room (
    Id INT PRIMARY KEY,
    CategoryId INT,
    Number INT,
    Floor INT,
    CONSTRAINT FK_Category_Room FOREIGN KEY (CategoryId) REFERENCES Category(Id),
    CONSTRAINT FK_Room_Category FOREIGN KEY (CategoryId) REFERENCES Category(Id)
);

-- Create Booking Table
CREATE TABLE Booking (
    Id INT PRIMARY KEY,
    GuestId INT,
    EmployeeId INT,
    RoomId INT,
    Check_In_Date DATETIME,
    Check_Out_Date DATETIME,
    Total_Price DECIMAL,
    CONSTRAINT FK_Booking_Guest FOREIGN KEY (GuestId) REFERENCES Guest(Id),
    CONSTRAINT FK_Booking_Employee FOREIGN KEY (EmployeeId) REFERENCES Employee(Id),
    CONSTRAINT FK_Booking_Room FOREIGN KEY (RoomId) REFERENCES Room(Id)
);

-- Create Guest Table
CREATE TABLE Guest (
    Id INT PRIMARY KEY,
    DocumentId INT,
    PhoneNumber INT,
    CONSTRAINT FK_Guest_Document FOREIGN KEY (DocumentId) REFERENCES Document(Id)
);

-- Create Document Table
CREATE TABLE Document (
    Id INT PRIMARY KEY,
    SerialNumber INT,
    FirstName NVARCHAR(MAX),
    LastName NVARCHAR(MAX),
    BirthDate DATETIME,
    Gender NVARCHAR(MAX)
);

-- Create Employee Table
CREATE TABLE Employee (
    Id INT PRIMARY KEY,
    PositionId INT,
    FirstName NVARCHAR(MAX),
    LastName NVARCHAR(MAX),
    PhoneNumber INT,
    Salary DECIMAL,
    CONSTRAINT FK_Employee_Position FOREIGN KEY (PositionId) REFERENCES Position(Id)
);

-- Create Position Table
CREATE TABLE Position (
    Id INT PRIMARY KEY,
    Name NVARCHAR(MAX),
    Salary DECIMAL
);

-- Create Review Table
CREATE TABLE Review (
    Id INT PRIMARY KEY,
    BookingId INT,
    Comment NVARCHAR(MAX),
    Grade FLOAT,
    CONSTRAINT FK_Review_Booking FOREIGN KEY (BookingId) REFERENCES Booking(Id)
);
