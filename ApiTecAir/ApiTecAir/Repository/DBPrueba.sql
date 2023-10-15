CREATE TABLE Sale
(
    SaleId SERIAL,
    SaleStart DATE,
    SaleEnd DATE,
    Discount INT,
    Destination VARCHAR(15),
    Origin VARCHAR(15),
    PRIMARY KEY (SaleId)
);

CREATE TABLE Client
(
    Ssn VARCHAR(9) NOT NULL,
    Email VARCHAR(30),
    Phone VARCHAR(15),
    FirstLName VARCHAR(15),
    SecondLName VARCHAR(15),
    Name VARCHAR(15),
    PRIMARY KEY (Ssn)
);

CREATE TABLE UserT
(
    UserId SERIAL ,
    Password VARCHAR(20),
    PRIMARY KEY (UserId)
);

CREATE TABLE Student
(
    StudentId VARCHAR(10),
    University VARCHAR(60),
    Miles INT,
    PRIMARY KEY (StudentId)
);

CREATE TABLE Price
(
    PriceId SERIAL,
    Type VARCHAR(10),
    Value INT,
    PRIMARY KEY (PriceId)
);

CREATE TABLE Bill
(
    BillId SERIAL,
    PRIMARY KEY (BillId)
);

CREATE TABLE TICKET
(
    TicketId SERIAL,
    Gate VARCHAR(2),
    DepartureTime DATE,
    PRIMARY KEY (TicketId)
);

CREATE TABLE Suitcase
(
    SuitcaseId SERIAL,
    Weight DECIMAL (3,2),
    Color VARCHAR(15),
    PRIMARY KEY (SuitcaseId)
);

CREATE TABLE Flight
(
    FlightId SERIAL,
    Origin VARCHAR (20),
    Destination VARCHAR(20),
    DepartureTime DATE,
    PRIMARY KEY (FlightId)
);

CREATE TABLE Scale
(
    ScaleId SERIAL,
    PlaceOrder VARCHAR(20),
    Origin VARCHAR(15),
    Destination VARCHAR(15),
    PRIMARY KEY (ScaleId)
);

CREATE TABLE FlightCalendar
(
    CalendarId SERIAL,
    Date DATE,
    PRIMARY KEY (CalendarId)
);

CREATE TABLE Aeroplane
(
    PlateNo VARCHAR(10),
    Row INT,
    --Renamed to PColumn do to Column being a key word
    PColumn INT,
    Size INT,
    PRIMARY KEY (PlateNo)
);

CREATE TABLE Seat
(
    SeatId SERIAL,
    Availability BOOL,
    SeatNo VARCHAR(2),
    PRIMARY KEY (SeatId)
);