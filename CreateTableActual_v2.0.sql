CREATE DATABASE SaleTicket
GO
USE SaleTicket
GO

select * from Product
delete from Product 
CREATE TABLE Administrator
( 
	idAdministrator     char(36)    NOT NULL ,
	name				varchar(50) NOT NULL ,
	lastName    		varchar(50) NOT NULL ,
	code     			varchar(50)    NOT NULL ,
	mail     			varchar(50) NOT NULL ,
	password    		varchar(30)    NOT NULL ,
	phone     		char(9)     NOT NULL ,
	dni     			char(8)     NOT NULL ,
	PRIMARY KEY (idAdministrator)
)
go

CREATE TABLE Period
( 
	idPeriod         	char(36)	 NOT NULL ,
	startDate        	datetime  	 NOT NULL ,
	endDate         	datetime	 NOT NULL ,
	name         		varchar(50) NOT NULL ,
	PRIMARY KEY (idPeriod)
)
go

CREATE TABLE Opening
( 
	idOpening  			char(36)  	NOT NULL ,
	idPeriod   			char(36)  	NOT NULL ,
	priorityQuantity   	INT		   	NOT NULL ,
	quantity   			INT			NOT NULL ,
	openState 		bit			NOT NULL ,
	PRIMARY KEY (idOpening),
	FOREIGN KEY (idPeriod) REFERENCES Period(idPeriod)
)
go

CREATE TABLE AdministratorOpening
( 
	idOpeningAdministrator char(36)  NOT NULL ,
	idAdministrator        char(36)		NOT NULL ,
	idOpening	          char(36)		NOT NULL ,	
	PRIMARY KEY (idOpeningAdministrator),
	FOREIGN KEY (idAdministrator) REFERENCES Administrator(idAdministrator),
	FOREIGN KEY (idOpening) REFERENCES Opening(idOpening)
)
go

CREATE TABLE Product
( 
	idProduct         char(36)	 NOT NULL ,
	name              varchar(20) NOT NULL ,
	price             int		 NOT NULL ,
	PRIMARY KEY (idProduct)
)
go

create table Student(
	    idStudent 		char(36) 		not null,
		profileImg		varchar(150)    not null,
        dni 			char(8)			not null,
        name 			varchar(80) 	not null,
        lastName	 	varchar(100) 	not null,
        condition	bit 			not null,
        school	 		varchar(100) 	not null,
        faculty	 		varchar(100) 	not null,
        disability	 	bit 			not null,
		phone	 	char(9) 		null,
        address	 		varchar(150) 	not null,
        sex	 			char(1) 		null,
        studentState	bit 			null, 
        password		varchar(max) 	null,
        mail	 		varchar(60) 	null,
        code	 		char(6) not 	null,
		PRIMARY KEY (idStudent)
)
go
CREATE TABLE SaleDetail
( 
	idSaleDetail        char(36)   NOT NULL ,
	idProduct        	char(36)   NOT NULL ,
	date               datetime   NOT NULL ,
	PRIMARY KEY (idSaleDetail),
	FOREIGN KEY (idProduct) REFERENCES Product(idProduct)
)
go

CREATE TABLE Sale
( 
	idSale             	char(36)		NOT NULL ,
	idStudent        	char(36)		NOT NULL ,
	idOpening          	char(36)		NOT NULL ,	
	idSaleDetail		char(36)        NOT NULL,
	couponImg           varchar(50)		NOT NULL ,
	saleState       	bit				NOT NULL ,
	total				int				NOT NULL,
	PRIMARY KEY (idSale),
	FOREIGN KEY (idStudent) REFERENCES Student(idStudent),
	FOREIGN KEY (idOpening) REFERENCES Opening(idOpening),
	FOREIGN KEY (idSaleDetail) REFERENCES SaleDetail(idSaleDetail),
)
go

