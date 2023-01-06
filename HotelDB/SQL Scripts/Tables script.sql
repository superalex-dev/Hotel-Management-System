CREATE TABLE Guests(
  guestId INT PRIMARY KEY,
  name VARCHAR(255),
  phone VARCHAR(255),
  email VARCHAR(255),
  address VARCHAR(255)
);

CREATE TABLE Rooms(
  roomNumber INT PRIMARY KEY,
  roomType VARCHAR(255),
  capacity INT,
  rate DECIMAL(10,2)
);

CREATE TABLE Bookings(
  bookingId INT PRIMARY KEY,
  guestId INT,
  roomNumber INT,
  checkIn DATE,
  checkOut DATE,
  FOREIGN KEY (guestId) REFERENCES Guests(guestId),
  FOREIGN KEY (roomNumber) REFERENCES Rooms(roomNumber)
);

CREATE TABLE Payments(
  paymentId INT PRIMARY KEY,
  bookingId INT,
  amount DECIMAL(10,2),
  paymentMethod VARCHAR(255),
  FOREIGN KEY (bookingId) REFERENCES Bookings(bookingId)
);

CREATE TABLE Employees(
  employeeId INT PRIMARY KEY,
  name VARCHAR(255),
  roleId INT,
  phone VARCHAR(255),
  email VARCHAR(255),
  FOREIGN KEY (roleId) REFERENCES Roles(roleId)
);

CREATE TABLE Roles(
	roleId INT PRIMARY KEY,
	roleName NVARCHAR(50)
);