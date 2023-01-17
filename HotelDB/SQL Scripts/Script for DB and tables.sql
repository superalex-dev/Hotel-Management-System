CREATE DATABASE HotelManagement;
GO

USE HotelManagement;
GO

CREATE TABLE Hotel (
    HotelID int IDENTITY(1,1) PRIMARY KEY,
    HotelName varchar(255) NOT NULL,
    Address varchar(255) NOT NULL,
    PhoneNumber varchar(255) NOT NULL
);

CREATE TABLE Room (
    RoomID int IDENTITY(1,1) PRIMARY KEY,
    HotelID int FOREIGN KEY REFERENCES Hotel(HotelID),
    RoomNumber varchar(255) NOT NULL,
    RoomType varchar(255) NOT NULL,
    Price decimal(10,2) NOT NULL,
    Available bit NOT NULL
);

CREATE TABLE Booking (
    BookingID int IDENTITY(1,1) PRIMARY KEY,
    RoomID int FOREIGN KEY REFERENCES Room(RoomID),
    GuestName varchar(255) NOT NULL,
    CheckInDate date NOT NULL,
    CheckOutDate date NOT NULL,
    NumberOfGuests int NOT NULL,
    TotalCost decimal(10,2) NOT NULL,
    PaymentStatus varchar(255) NOT NULL
);

CREATE TABLE Payment (
    PaymentID int IDENTITY(1,1) PRIMARY KEY,
    BookingID int FOREIGN KEY REFERENCES Booking(BookingID),
    PaymentMethod varchar(255) NOT NULL,
    PaymentDate date NOT NULL,
    Amount decimal(10,2) NOT NULL
);

CREATE TABLE Staff (
    StaffID int IDENTITY(1,1) PRIMARY KEY,
    HotelID int FOREIGN KEY REFERENCES Hotel(HotelID),
    FirstName varchar(255) NOT NULL,
    LastName varchar(255) NOT NULL,
    Email varchar(255) NOT NULL,
    PhoneNumber varchar(255) NOT NULL,
    HireDate date NOT NULL
);

CREATE TABLE Role (
    RoleID int IDENTITY(1,1) PRIMARY KEY,
    RoleName varchar(255) NOT NULL
);

CREATE TABLE StaffRole (
    StaffID int FOREIGN KEY REFERENCES Staff(StaffID),
    RoleID int FOREIGN KEY REFERENCES Role(RoleID),
    PRIMARY KEY (StaffID, RoleID)
);