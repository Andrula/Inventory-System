INSERT INTO dbo.simtype (typename,active_from,active_to) VALUES
('Telefon','2024-01-01','2030-01-01'),
('Tablet','2024-01-01','2030-01-01'),
('PC','2024-01-01','2030-01-01')

INSERT INTO dbo.simcard (number,ICCID,PIN,PUK,simtype_id) VALUES
('13','12315623422','4020','5238',1),
('15','12312312312','5203','1328',2),
('49','12312312312','3220','1128',3),
('50','41231238282','6021','9928',2),
('60','12312301203','6032','8028',1)

DELETE from simcard

SELECT simcard.id, simcard.number, simcard.PIN, simcard.PUK, simcard.ICCID, simtype.id ,simtype.typename
FROM simcard
INNER JOIN simtype ON simcard.simtype_id = simtype.id;

SELECT * from simtype

INSERT INTO dbo.brand (name,active_from,active_to) VALUES 
('Microsoft','2024-01-01','2030-01-01'),
('Apple','2024-01-01','2030-01-01'),
('HP','2024-01-01','2030-01-01')

INSERT INTO dbo.pcram (size, active_from,active_to) VALUES
(8,'2024-01-01','2030-01-01'),
(16,'2024-01-01','2030-01-01'),
(32,'2024-01-01','2030-01-01')

INSERT INTO dbo.pcos (name, active_from,active_to) VALUES
('Windows','2024-01-01','2030-01-01'),
('Linux','2024-01-01','2030-01-01'),
('MacOS','2024-01-01','2030-01-01')

INSERT INTO dbo.pcnet (name, active_from,active_to) VALUES
('APO7','2024-01-01','2030-01-01'),
('Politi.dk','2024-01-01','2030-01-01'),
('Politinet.dk','2024-01-01','2030-01-01')

INSERT INTO dbo.pcmodel(name, active_from,active_to) VALUES
('APO7','2024-01-01','2030-01-01'),
('Politi.dk','2024-01-01','2030-01-01'),
('Politinet.dk','2024-01-01','2030-01-01')

INSERT INTO dbo.Person (wrx, name, email, phone) VALUES
('WRXKODE4', 'Fuldtnavnt1','email@email1.dk','20202020'),
('WRXKODE5', 'Fuldtnavnt2','email@email2.dk','30303030'),
('WRXKODE6', 'Fuldtnavnt3','email@email3.dk','40404040')

INSERT INTO locationname (name, active_to, active_from) VALUES
('Landlystvej','2024-01-01','2030-01-01'),
('Polititorvet','2024-01-01','2030-01-01'),
('Hjemarbejde','2024-01-01','2030-01-01')

INSERT INTO dbo.location (location_name_id, note) VALUES
(1,'Hos landlystvej resten af levetid'),
(2,'Hos direktør på Polititorvet, afleveres om 2 måneder'),
(3,'Fast hjemarbejdscomputer')

INSERT INTO dbo.project (name, active_from, active_to) VALUES
('Polsas','2024-01-01','2030-01-01'),
('Polsis','2024-01-01','2030-01-01'),
('Polinventar','2024-01-01','2030-01-01')

INSERT INTO dbo.loan (active_from, active_to) VALUES
('2025-01-01','2030-01-01'),
('2025-01-01','2037-01-01'),
('2025-01-01','2050-01-01')

INSERT INTO udlaan (loan_id,person_id,project_id,location_id) VALUES
(2,4,2,3),
(1,5,2,2),
(3,6,3,3)

Select * from udlaan

SELECT 
    Person.name,
    Person.wrx,
    Person.email,
    Person.phone,
    Project.name,
    locationname.name,
    Loan.active_from,
    Loan.active_to
FROM 
    Udlaan
INNER JOIN 
    Person ON Udlaan.person_id = Person.id
INNER JOIN 
    Project ON Udlaan.project_id = Project.id
INNER JOIN 
    location ON Udlaan.location_id = location.location_name_id
INNER JOIN 
    locationname ON location.location_name_id = locationname.id
INNER JOIN 
    Loan ON Udlaan.loan_id = Loan.id;

INSERT INTO accountinghistory (lasttimeaccounted) VALUES 
('2023-05-09'),
('2023-11-26'),
('2021-02-22'),
('2021-02-16'),
('2023-12-21'),
('2021-10-20'),
('2021-03-06'),
('2023-03-07'),
('2023-02-25'),
('2023-01-28'),
('2022-09-26'),
('2023-03-12'),
('2022-04-16'),
('2022-07-19'),
('2022-10-03'),
('2024-01-30'),
('2021-12-01'),
('2021-12-14')

SELECT * FROM STATUS
SELECT * FROM DEVICE

INSERT INTO STATUS (accountinghistory_id,udlaan_id,device_id,note) VALUES
(1,1,1,'Det her er en lang note for at se hvad der sker'),
(2,2,2,'Det her er en lang note for at se hvad der sker'),
(3,3,3,'Det her er en lang note for at se hvad der sker'),
(4,4,4,'Det her er en lang note for at se hvad der sker'),
(5,5,5,'Det her er en lang note for at se hvad der sker'),
(6,6,6,'Det her er en lang note for at se hvad der sker'),
(7,7,7,'Det her er en lang note for at se hvad der sker'),
(8,6,8,'Det her er en lang note for at se hvad der sker'),
(9,5,9,'Det her er en lang note for at se hvad der sker'),
(10,5,10,'Det her er en lang note for at se hvad der sker'),
(11,3,11,'Det her er en lang note for at se hvad der sker'),
(12,2,12,'Det her er en lang note for at se hvad der sker'),
(13,1,13,'Det her er en lang note for at se hvad der sker'),
(14,2,14,'Det her er en lang note for at se hvad der sker'),
(15,3,15,'Det her er en lang note for at se hvad der sker'),
(16,4,16,'Det her er en lang note for at se hvad der sker'),
(17,4,17,'Det her er en lang note for at se hvad der sker'),
(18,5,18,'Det her er en lang note for at se hvad der sker')


SELECT 
    device.id AS DeviceID,
    accountinghistory.lasttimeaccounted,
    person.wrx,
    person.name AS PersonName,
    person.email,
    person.phone,
    locationname.name AS LocationName,
    project.name AS ProjectName,
    loan.active_from AS LoanActiveFrom,
    loan.active_to AS LoanActiveTo,
    s.note AS StatusNote
FROM 
    status s
INNER JOIN 
    device ON s.device_id = device.id
LEFT JOIN 
    pc ON device.pc_id = pc.id
LEFT JOIN 
    tablet ON device.tablet_id = tablet.id
LEFT JOIN 
    phone ON device.phone_id = phone.id
INNER JOIN 
    accountinghistory ON accountinghistory_id = accountinghistory.id
INNER JOIN 
    udlaan ON udlaan_id = udlaan.id
INNER JOIN 
    person ON person_id = person.id
INNER JOIN 
    project ON project_id = project.id
INNER JOIN 
    location ON location_id = location.id
INNER JOIN 
    locationname  ON location_name_id = locationname.id
INNER JOIN 
	loan on loan_id = loan.id


SELECT 
    d.id AS DeviceID,
    CASE
        WHEN d.pc_id IS NOT NULL THEN 'PC'
        WHEN d.tablet_id IS NOT NULL THEN 'Tablet'
        WHEN d.phone_id IS NOT NULL THEN 'Phone'
        WHEN d.sim_id IS NOT NULL THEN 'SIM-Card'
        ELSE 'Unknown'
    END AS EquipmentType,
    accountinghistory.lasttimeaccounted,
    person.wrx,
    person.name AS PersonName,
    person.email,
    person.phone,
    locationname.name AS LocationName,
    project.name AS ProjectName,
    loan.active_from AS LoanActiveFrom,
    loan.active_to AS LoanActiveTo,
    status.note AS StatusNote
FROM 
    dbo.device d
LEFT JOIN dbo.pc ON d.pc_id = pc.id
LEFT JOIN dbo.tablet ON d.tablet_id = tablet.id
LEFT JOIN dbo.phone ON d.phone_id = phone.id
LEFT JOIN dbo.simcard ON d.sim_id = simcard.id
INNER JOIN dbo.status ON device_id = d.id
INNER JOIN dbo.accountinghistory ON accountinghistory_id = accountinghistory.id
INNER JOIN dbo.udlaan ON udlaan_id = udlaan.id
INNER JOIN dbo.person ON person_id = person.id
INNER JOIN dbo.project ON project_id = project.id
INNER JOIN dbo.location ON location_id = location.id
INNER JOIN dbo.locationname ON location_name_id = locationname.id
INNER JOIN dbo.loan ON loan_id = loan.id;