CREATE TABLE  T_User (
  email varchar(200) NOT NULL,
  pass varbinary(200) NOT NULL,
  premium bit NOT NULL,
  DNI varchar(9) NOT NULL,
  name varchar(35) NOT NULL,
  surname varchar(55) NOT NULL,
  phone int NOT NULL,
  address varchar(200) NOT NULL,
  city varchar(100) NOT NULL,
  birthDate date NOT NULL,
  drivingLicense bit NOT NULL,
  PRIMARY KEY (email),
  UNIQUE (DNI)
);

CREATE TABLE  T_Office (
  code int,
  name varchar(50) NOT NULL,
  address varchar(200) NOT NULL,
  city varchar(100) NOT NULL,
  cX decimal(10,7) NOT NULL,
  cY decimal(10,7) NOT NULL,
  PRIMARY KEY(code)
);

CREATE TABLE  T_Car (
  code int NOT NULL,
  category int NOT NULL,
  name varchar(30) NOT NULL,
  descrip varchar(100) DEFAULT NULL,
  price decimal(7,2) NOT NULL,
  automaticTransmission bit NOT NULL,
  doors int DEFAULT 4,
  IMG varchar(200),
  PRIMARY KEY (code)
);

CREATE TABLE T_Offer (
  code int,
  car int NOT NULL,
  startDate date NOT NULL,
  finishDate date NOT NULL,
  IMG varchar(200),
  newPrice decimal(7,2) NOT NULL,
  title varchar(20) NOT NULL,
  description varchar(100) DEFAULT NULL,
  PRIMARY KEY (code),
  CONSTRAINT FK_TOffer_2_TCar FOREIGN KEY (car) REFERENCES T_Car(code) ON UPDATE CASCADE
);


CREATE TABLE  T_Booking (
  code int,
  usr varchar(200) NOT NULL,
  car int NOT NULL,
  startDate date NOT NULL,
  finishDate date,
  driver bit NOT NULL,
  satNav bit NOT NULL,
  babyChair bit NOT NULL,
  childChair bit NOT NULL,
  baca bit NOT NULL,
  insurance bit NOT NULL,
  youngDriver bit NOT NULL,
  pickUp int NOT NULL,
  delivery int,
  totPrice decimal(7,2),
  PRIMARY KEY(code),
  FOREIGN KEY(car) REFERENCES T_Car(code) ON UPDATE CASCADE,
  FOREIGN KEY(usr) REFERENCES T_User(email) ON UPDATE CASCADE,
  FOREIGN KEY(pickUp) REFERENCES T_Office(code) ON UPDATE CASCADE,
  FOREIGN KEY(delivery) REFERENCES T_Office(code) ON UPDATE NO ACTION
);


CREATE TABLE  T_PaymentMethod (
  usr varchar(100) NOT NULL,
  pass varbinary(200) NOT NULL,
  client varchar(200),
  PRIMARY KEY(client),
  FOREIGN KEY(client) REFERENCES T_User(email) ON UPDATE CASCADE
);