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
('Samsung','2024-01-01','2030-01-01'),
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

INSERT INTO dbo.pcmodel (name, active_from,active_to) VALUES
('HP','2024-01-01','2030-01-01'),
('Lenovo Basis','2024-01-01','2030-01-01'),
('Levnovo','2024-01-01','2030-01-01'),
('ProDesk','2024-01-01','2030-01-01'),
('HP EliteDesk','2024-01-01','2030-01-01'),
('HP ProDesk','2024-01-01','2030-01-01')

INSERT INTO dbo.pc (name, serial, brand_id, os_id, net_id, ram_id, model_id) VALUES 
('PC 1', 'Serial001', 1, 1, 1, 1, 1),
('PC 2', 'Serial002', 2, 2, 2, 2, 2),
('PC 3', 'Serial003', 3, 3, 3, 3, 3),
('PC 4', 'Serial004', 1, 1, 1, 2, 4),
('PC 5', 'Serial005', 2, 2, 2, 3, 5)


INSERT INTO dbo.tabletmodel (name, active_from, active_to) VALUES
('TabletModel1','2024-01-01','2030-01-01'),
('TabletModel2','2024-01-01','2030-01-01'),
('TabletModel3','2024-01-01','2030-01-01')

INSERT INTO dbo.tabletram (size, active_from,active_to) VALUES
('10,5"','2024-01-01','2030-01-01'),
('Mini 3','2024-01-01','2030-01-01'),
('9,7"','2024-01-01','2030-01-01'),
('8,5"','2024-01-01','2030-01-01')

SELECT dbo.device.id, device.pc_id, device.tablet_id, device.sim_id, device.phone_id
FROM dbo.device
INNER JOIN dbo.pc ON device.id = pc.id
INNER JOIN dbo.tablet ON device.id = tablet.id
INNER JOIN dbo.phone ON device.id = phone.id
INNER JOIN dbo.simcard ON device.id = simcard.id;

INSERT INTO dbo.device (phone_id,tablet_id,sim_id,pc_id) VALUES
(NULL,1,NULL,NULL)

SELECT * FROM tablet;
SELECT * FROM phone;
SELECT * FROM simcard;
SELECT * FROM pc;