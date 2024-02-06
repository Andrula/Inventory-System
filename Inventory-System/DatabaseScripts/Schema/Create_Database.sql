--Database creation:
Use master

CREATE DATABASE Polinventar;

USE Polinventar;


CREATE TABLE brand (
id INT IDENTITY (1,1) PRIMARY KEY,
name NVARCHAR(100),
active_from DATE,
active_to DATE
)


--SIM CARD Tabel:
CREATE TABLE simtype (
id INT IDENTITY (1,1) PRIMARY KEY,
typename NVARCHAR(100),
active_from DATE,
active_to DATE
)

CREATE TABLE simcard (
id INT IDENTITY (1,1) PRIMARY KEY,
simtype_id int,
number NVARCHAR(100), 
PIN NVARCHAR(100),
PUK NVARCHAR(100),
ICCID NVARCHAR(100),
FOREIGN KEY (simtype_id) REFERENCES simtype(id)
)

-- PC Tabel:
CREATE TABLE pcmodel (
id INT IDENTITY (1,1) PRIMARY KEY,
name NVARCHAR(250),
active_from DATE,
active_to DATE
)

CREATE TABLE pcram (
id INT IDENTITY (1,1) PRIMARY KEY,
size INT,
active_from DATE,
active_to DATE
)

CREATE TABLE pcnet (
id INT IDENTITY (1,1) PRIMARY KEY,
name NVARCHAR(250),
active_from DATE,
active_to DATE
)

CREATE TABLE pcos (
id INT IDENTITY (1,1) PRIMARY KEY,
name NVARCHAR(250),
active_from DATE,
active_to DATE
)

CREATE TABLE pc (
id INT IDENTITY (1,1) PRIMARY KEY,
name NVARCHAR(250),
serial NVARCHAR(250),
brand_id int,
os_id int,
net_id int,
ram_id int,
sim_id int,
model_id int,
FOREIGN KEY (os_id) REFERENCES pcos(id),
FOREIGN KEY (brand_id) REFERENCES brand(id),
FOREIGN KEY (net_id) REFERENCES pcnet(id),
FOREIGN KEY (model_id) REFERENCES pcmodel(id),
FOREIGN KEY (sim_id) REFERENCES simcard(id),
FOREIGN KEY (RAM_id) REFERENCES pcram(id),
)

-- Tablet Tabel:
CREATE TABLE tabletmodel (
id INT IDENTITY (1,1) PRIMARY KEY,
name NVARCHAR(250),
active_from DATE,
active_to DATE
)

CREATE TABLE tabletsize (
id INT IDENTITY (1,1) PRIMARY KEY,
size NVARCHAR(250),
active_from DATE,
active_to DATE
)

CREATE TABLE tabletram (
id INT IDENTITY (1,1) PRIMARY KEY,
size INT,
active_from DATE,
active_to DATE
)

CREATE TABLE tabletemei (
id INT IDENTITY (1,1) PRIMARY KEY,
EMEI1 NVARCHAR(250),
EMEI2 NVARCHAR(250)
)

CREATE TABLE tablet (
id INT IDENTITY (1,1) PRIMARY KEY,
serial NVARCHAR (250),
name NVARCHAR (250),
appleid NVARCHAR (250),
applecode NVARCHAR (250),
screenlock NVARCHAR (250),
brand_id int,
emei_id int,
size_id int,
ram_id int,
model_id int,
sim_id int,
FOREIGN KEY (brand_id) REFERENCES brand(id),
FOREIGN KEY (emei_id) REFERENCES tabletemei(id),
FOREIGN KEY (size_id) REFERENCES tabletsize(id),
FOREIGN KEY (ram_id) REFERENCES tabletram(id),
FOREIGN KEY (model_id) REFERENCES tabletmodel(id),
FOREIGN KEY (sim_id) REFERENCES simcard(id),
)

-- Phone Tabel:
CREATE TABLE phonemodel (
id INT IDENTITY (1,1) PRIMARY KEY,
name NVARCHAR(250),
active_from DATE,
active_to DATE
)

CREATE TABLE phoneemei (
id INT IDENTITY (1,1) PRIMARY KEY,
EMEI1 NVARCHAR(250),
EMEI2 NVARCHAR(250)
)

CREATE TABLE phone (
id INT IDENTITY (1,1) PRIMARY KEY,
serial NVARCHAR (250),
name NVARCHAR (250),
brand_id int,
emei_id int,
model_id int,
sim_id int,
FOREIGN KEY (brand_id) REFERENCES brand(id),
FOREIGN KEY (emei_id) REFERENCES phoneemei(id),
FOREIGN KEY (model_id) REFERENCES phonemodel(id),
FOREIGN KEY (sim_id) REFERENCES simcard(id),
)

CREATE TABLE device (
id INT IDENTITY (1,1) PRIMARY KEY,
phone_id int,
tablet_id int,
sim_id int,
pc_id int,
FOREIGN KEY (phone_id) REFERENCES phone(id),
FOREIGN KEY (tablet_id) REFERENCES tablet(id),
FOREIGN KEY (sim_id) REFERENCES simcard(id),
FOREIGN KEY (pc_id) REFERENCES pc(id)
)

CREATE TABLE accountinghistory (
id INT IDENTITY (1,1) PRIMARY KEY,
lasttimeaccounted DATE
)

CREATE TABLE locationname(
id INT IDENTITY (1,1) PRIMARY KEY,
name NVARCHAR (250),
active_from DATE,
active_to DATE
)

CREATE TABLE location (
id INT IDENTITY (1,1) PRIMARY KEY,
location_name_id INT,
note NVARCHAR (250)
FOREIGN KEY (location_name_id) REFERENCES locationname(id)
)

CREATE TABLE project (
id INT IDENTITY (1,1) PRIMARY KEY,
name NVARCHAR (250),
active_from DATE,
active_to DATE
)

CREATE TABLE person (
id INT IDENTITY (1,1) PRIMARY KEY,
wrx NVARCHAR (250),
name NVARCHAR (250),
email NVARCHAR (250),
phone NVARCHAR (15)
)

CREATE TABLE loan (
id INT IDENTITY (1,1) PRIMARY KEY,
active_from DATE,
active_to DATE
)

CREATE TABLE udlaan (
id INT IDENTITY (1,1) PRIMARY KEY,
loan_id INT,
person_id INT,
project_id INT,
location_id INT,
FOREIGN KEY (loan_id) REFERENCES loan(id),
FOREIGN KEY (person_id) REFERENCES person(id),
FOREIGN KEY (project_id) REFERENCES project(id),
FOREIGN KEY (location_id) REFERENCES location(id)
)

CREATE TABLE status (
id INT IDENTITY (1,1) PRIMARY KEY,
accountinghistory_id INT,
udlaan_id INT,
device_id INT,
note NVARCHAR (250),
FOREIGN KEY (accountinghistory_id) REFERENCES accountinghistory(id),
FOREIGN KEY (udlaan_id) REFERENCES udlaan(id),
FOREIGN KEY (device_id) REFERENCES device(id)
)





