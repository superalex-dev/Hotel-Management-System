CREATE DATABASE HotelManagementSystem;
GO

USE HotelManagementSystem;
GO

CREATE TABLE RoomTypes (
    RoomTypeId INT PRIMARY KEY,
    Name VARCHAR(50),
    Description VARCHAR(500),
    Rate DECIMAL(18,2)
);
GO

CREATE TABLE Rooms (
    RoomId INT PRIMARY KEY,
    RoomNumber VARCHAR(10),
    RoomTypeId INT,
    Status VARCHAR(20),
    CONSTRAINT FK_RoomType_Rooms FOREIGN KEY (RoomTypeId) REFERENCES RoomTypes(RoomTypeId)
);
GO


CREATE TABLE Guests (
    GuestId INT PRIMARY KEY,
    FirstName VARCHAR(50),
    LastName VARCHAR(50),
    Email VARCHAR(50),
    Phone VARCHAR(20),
    Address VARCHAR(200)
);
GO


CREATE TABLE Reservations (
    ReservationId INT PRIMARY KEY,
    RoomId INT,
    GuestId INT,
    CheckInDate DATE,
    CheckOutDate DATE,
    TotalPrice DECIMAL(18,2),
    CONSTRAINT FK_Room_Reservations FOREIGN KEY (RoomId) REFERENCES Rooms(RoomId),
    CONSTRAINT FK_Guest_Reservations FOREIGN KEY (GuestId) REFERENCES Guests(GuestId)
);
GO


