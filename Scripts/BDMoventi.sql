
CREATE DATABASE BDMoventi
GO
CREATE SCHEMA RTMoventi
GO
CREATE TABLE RTMoventi.Usuario
(
 UsuarioId INT PRIMARY KEY IDENTITY(1,1),
 Usuario Varchar(50),
 Clave Varchar(50),
 Estado BIT
)
GO 
INSERT INTO RTMoventi.Usuario(Usuario, Clave, Estado) VALUES('moventi', 'moventi', 1);
GO
SELECT * FROM RTMoventi.Usuario 

GO 

CREATE TABLE RTMoventi.JefeOrganizacion
(
JefeOrganizacionId  INT PRIMARY KEY IDENTITY(1, 1),
NombreJefe VARCHAR(50),
Estado BIT,
UsuarioRegistro INT,
FechaRegistro DATETIME
)

GO 

INSERT INTO RTMoventi.JefeOrganizacion(NombreJefe, Estado, UsuarioRegistro, FechaRegistro)
VALUES('José Ruiz', 1, 1, GETDATE());
GO 
SELECT * FROM RTMoventi.JefeOrganizacion

GO
CREATE TABLE RTMoventi.TipoComplejo
(
TipoComplejoId INT PRIMARY KEY IDENTITY(1, 1),
NombreTipoComplejo VARCHAR(50),
Estado BIT,
UsuarioRegistro INT,
FechaRegistro DATETIME
)

GO 
INSERT INTO RTMoventi.TipoComplejo(NombreTipoComplejo, Estado, UsuarioRegistro, FechaRegistro)
VALUES('UNICO DEPORTE', 1, 1, GETDATE());

INSERT INTO RTMoventi.TipoComplejo(NombreTipoComplejo, Estado, UsuarioRegistro, FechaRegistro)
VALUES('POLIDEPORTIVO', 1, 1, GETDATE());

SELECT * FROM RTMoventi.TipoComplejo 

GO 
CREATE TABLE RTMoventi.TipoDeporte
(
TipoDeporteId INT PRIMARY KEY IDENTITY(1, 1),
NombreDeporte VARCHAR(50),
Estado BIT,
UsuarioRegistro INT,
FechaRegistro DATETIME
)

GO 

INSERT INTO RTMoventi.TipoDeporte(NombreDeporte, Estado, UsuarioRegistro, FechaRegistro) VALUES('Futbol', 1, 1, GETDATE());
INSERT INTO RTMoventi.TipoDeporte(NombreDeporte, Estado, UsuarioRegistro, FechaRegistro) VALUES('Voley', 1, 1, GETDATE());
INSERT INTO RTMoventi.TipoDeporte(NombreDeporte, Estado, UsuarioRegistro, FechaRegistro) VALUES('Basquet', 1, 1, GETDATE());

SELECT * FROM RTMoventi.TipoDeporte 


GO 
CREATE TABLE RTMoventi.ComplejoDeportivo
(
ComplejoDeportivoId INT PRIMARY KEY IDENTITY(1, 1),
CodigoComplejo VARCHAR(20),
NombreComplejo VARCHAR(50),
PresupuestoAproximado DECIMAL(8, 2),
Localizacion VARCHAR(50),
JefeOrganizacionId INT NOT NULL,
AreaTotalOcupada DECIMAL(8, 2),
TipoComplejoId INT NOT NULL,
TipoDeporteId INT,
Estado BIT,
UsuarioRegistro INT,
FechaRegistro DATETIME
)
GO 
ALTER TABLE RTMoventi.ComplejoDeportivo
ADD FOREIGN KEY (JefeOrganizacionId) REFERENCES RTMoventi.JefeOrganizacion(JefeOrganizacionId);

ALTER TABLE RTMoventi.ComplejoDeportivo
ADD FOREIGN KEY (TipoComplejoId) REFERENCES RTMoventi.TipoComplejo(TipoComplejoId);


GO 

INSERT INTO RTMoventi.ComplejoDeportivo(CodigoComplejo, NombreComplejo, PresupuestoAproximado, Localizacion, JefeOrganizacionId, AreaTotalOcupada, TipoComplejoId, TipoDeporteId, Estado, UsuarioRegistro, FechaRegistro)
VALUES ('0001', 'Complejo Deportivo', 5000, 'AV PRINCIPAL', 1, 125, 1, 0, 1, 1, GETDATE());

SELECT * FROM RTMoventi.ComplejoDeportivo



GO 

CREATE TABLE RTMoventi.Evento
(
EventoId INT PRIMARY KEY IDENTITY(1, 1),
CodigoEvento VARCHAR(10),
NombreEvento VARCHAR(50),
FechaEvento DATETIME,
DuracionHoras INT,
NumeroParticipantes INT,
NumeroComisarios INT,
Estado BIT,
UsuarioRegistro INT,
FechaRegistro DATETIME
)

GO 

CREATE TABLE RTMoventi.Comisario
(
ComisarioId INT PRIMARY KEY IDENTITY(1, 1),
NombreComisario VARCHAR(50),
Estado BIT,
UsuarioRegistro INT,
FechaRegistro DATETIME
)

GO

CREATE TABLE RTMoventi.DetalleEventoComisario
(
DetalleEventoComisarioId INT PRIMARY KEY IDENTITY(1, 1),
EventoId INT,
ComisarioId INT,
Estado BIT
)

GO 
ALTER TABLE RTMoventi.DetalleEventoComisario
ADD FOREIGN KEY (EventoId) REFERENCES RTMoventi.Evento(EventoId);

ALTER TABLE RTMoventi.DetalleEventoComisario
ADD FOREIGN KEY (ComisarioId) REFERENCES RTMoventi.Comisario(ComisarioId);

GO 

CREATE TABLE RTMoventi.Equipamiento
(
EquipamientoId INT PRIMARY KEY IDENTITY(1, 1),
NombreEquipamiento VARCHAR(50),
Estado BIT,
UsuarioRegistro INT,
FechaRegistro DATETIME
)


GO 

CREATE TABLE RTMoventi.DetalleEventoEquipamiento
(
DetalleEventoEquipamientoId INT PRIMARY KEY IDENTITY(1, 1),
EventoId INT,
EquipamientoId INT,
Estado BIT 
)

ALTER TABLE RTMoventi.DetalleEventoEquipamiento
ADD FOREIGN KEY (EventoId) REFERENCES RTMoventi.Evento(EventoId);

ALTER TABLE RTMoventi.DetalleEventoEquipamiento
ADD FOREIGN KEY (EquipamientoId) REFERENCES RTMoventi.Equipamiento(EquipamientoId);


