-- Active: 1717530146900@@b09wts93kpzuvw5t8owx-mysql.services.clever-cloud.com@3306
-- Table Owner
create table Owners(
    Id int not null auto_increment PRIMARY KEY,
    Names varchar(45),
    LastNames varchar(45),
    Email varchar(100) UNIQUE,
    Address varchar(200),
    Phone varchar(25)
);

--Add Information
insert into Owners(Names, LastNames, Email, Address, Phone) values ("Fernando", "Gómez", "fjgt2000@gmail.com", "Cra 65 cc # 32 A 06", "3024559977");

-- Table Vets
create table Vets(
    Id int not null auto_increment PRIMARY KEY,
    Name varchar(120),
    Phone varchar(25),
    Address varchar(30),
    Email varchar(100) UNIQUE
);

--Add Information
insert into Vets(Name, Phone, Address, Email) values ("Roberto", "3024539876", "calle 30 # 02 B", "roberto@veterinaria.com"),
("Juan", "3004556677", "calle 30 # 02 B", "juan@veterinaria.com");

-- Table Pets
create table Pets(
    Id int not null auto_increment PRIMARY KEY,
    Name varchar(25),
    Specie enum ("Perro", "Gato", "Araña", "Serpiente", "Ave"),
    Race enum ("Pinscher", "Pitbull", "BorderCollins", "Schnauzer", "Chihuahua", "Siemens", "Criollo", "Persa", "Coral", "Boa", "Cascabel", "Turpial"),
    DateBirth DATE,
    OwnerId int,
    Foreign Key (OwnerId) REFERENCES Owners(Id),
    Photo text
);

--Add Information
insert into Pets(Name, Specie, Race, DateBirth, OwnerId, Photo) values ("Firulais", "Perro", "Pitbull", "2024-05-12", 1, "https://images.pexels.com/photos/137020/pexels-photo-137020.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1");

--Table Quotes
create table Quotes(
    Id int not null auto_increment PRIMARY KEY,
    Date DATETIME,
    PetId int,
    Foreign Key (PetId) REFERENCES Pets(Id),
    VetId int,
    Foreign Key (VetId) REFERENCES Vets(Id),
    Description text
);

--Add Information
insert into Quotes(Date, PetId, VetId, Description) values ("2024-06-04 09:00:00", 1, 1, "Seguimiento para toma de Rx antes de la cirugía");


drop table `Owners`;
drop table `Pets`;
drop table `Quotes`;
drop table `Vets`;

select * from `Owners`;
select * from `Pets`;
select * from `Quotes`;
select * from `Vets`;