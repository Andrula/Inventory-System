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



