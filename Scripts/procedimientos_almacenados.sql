

CREATE PROCEDURE RTMoventi.ValidarUsuario
	@pUsuario VARCHAR(50),
	@pClave VARCHAR(50)
AS
BEGIN
	SELECT UsuarioId,
			Usuario,
			Clave,
			Estado 
	FROM RTMoventi.Usuario 
	WHERE Estado = 1	
		AND Usuario = @pUsuario AND Clave = @pClave
END

GO 

Exec RTMoventi.ValidarUsuario 'moventi', 'moventi'


GO 

CREATE OR ALTER PROCEDURE RTMoventi.ListarJefe
AS 
BEGIN 
	SELECT 
		JefeOrganizacionId,
		NombreJefe,
		Estado 
	FROM RTMoventi.JefeOrganizacion
	WHERE Estado = 1;
END

GO 

EXEC RTMoventi.ListarJefe

GO 
CREATE OR ALTER PROCEDURE RTMoventi.CrearEditarJefe
	@pNombreJefeId INT,
	@pNombreJefe VARCHAR(50),
	@pUsuarioId INT
AS 
BEGIN 
	IF @pNombreJefeId = 0
	BEGIN 
		INSERT INTO RTMoventi.JefeOrganizacion(NombreJefe, Estado, UsuarioRegistro, FechaRegistro)
		VALUES(@pNombreJefe, 1, @pUsuarioId, getdate());
	
		SELECT SCOPE_IDENTITY() AS UsuarioId;
	END
	ELSE
	BEGIN 
		UPDATE RTMoventi.JefeOrganizacion
		SET NombreJefe = @pNombreJefe, UsuarioRegistro = @pUsuarioId
		WHERE JefeOrganizacionId = @pNombreJefeId;
	
		SELECT @pNombreJefeId AS UsuarioId;
	END
	
END


EXEC RTMoventi.CrearEditarJefe 'Luis', 1
SELECT * FROM RTMoventi.JefeOrganizacion 

GO 

CREATE PROCEDURE RTMoventi.ObtenerrJefe
	@pNombreJefeId INT 
AS 
BEGIN 
	SELECT 
		JefeOrganizacionId,
		NombreJefe,
		Estado 
	FROM RTMoventi.JefeOrganizacion
		WHERE JefeOrganizacionId = @pNombreJefeId
END

GO

EXEC RTMoventi.ObtenerrJefe 1


CREATE OR ALTER PROCEDURE RTMoventi.EliminarJefe
	@pNombreJefeId INT,
	@pUsuarioId INT
AS 
BEGIN 
		UPDATE RTMoventi.JefeOrganizacion
		SET Estado = 0
		WHERE JefeOrganizacionId = @pNombreJefeId;
	
		SELECT @pNombreJefeId AS UsuarioId;
END



GO
CREATE PROCEDURE RTMoventi.ListarTipoComplejo
AS 
BEGIN 
	SELECT * 
	FROM RTMoventi.TipoComplejo 	
	WHERE Estado = 1
END

GO 
EXEC RTMoventi.ListarTipoComplejo 
GO 

CREATE PROCEDURE RTMoventi.ListarTipoDeporte
AS
BEGIN 
	SELECT * 
	FROM RTMoventi.TipoDeporte 	
	WHERE Estado = 1;
END

GO 
EXEC RTMoventi.ListarTipoDeporte 

GO 


CREATE OR ALTER PROCEDURE RTMoventi.ListarComplejosDeportivos
AS 
BEGIN 
	SELECT 
		CD.ComplejoDeportivoId,
		CD.CodigoComplejo,
		CD.NombreComplejo,
		CD.PresupuestoAproximado,
		CD.Localizacion,
		JO.JefeOrganizacionId,
		JO.NombreJefe,
		CD.AreaTotalOcupada,
		TC.TipoComplejoId ,
		TC.NombreTipoComplejo ,
		TD.TipoDeporteId,
		TD.NombreDeporte,
		CD.Estado 
	FROM RTMoventi.ComplejoDeportivo CD
		INNER JOIN RTMoventi.JefeOrganizacion JO 
			ON CD.JefeOrganizacionId = JO.JefeOrganizacionId 
		INNER JOIN RTMoventi.TipoComplejo TC 
			ON CD.TipoComplejoId = TC.TipoComplejoId 
		LEFT JOIN RTMoventi.TipoDeporte TD 
			ON CD.TipoDeporteId = TD.TipoDeporteId 
	WHERE CD.Estado = 1;
END

GO 

EXEC RTMoventi.ListarComplejosDeportivos

GO 

CREATE PROCEDURE RTMoventi.CrearEditarComplejoDeportivo
	@pComplejoDeportivoId INT,
	@pCodigoComplejo VARCHAR(50), 
	@pNombreComplejo VARCHAR(50), 
	@pPresupuestoAproximado DECIMAL(8, 2), 
	@pLocalizacion VARCHAR(50), 
	@pJefeOrganizacionId INT, 
	@pAreaTotalOcupada DECIMAL(8, 2), 
	@pTipoComplejoId INT, 
	@pTipoDeporteId INT, 
	@pUsuarioId INT
AS 
BEGIN 
	IF @pComplejoDeportivoId = 0
	BEGIN 
		INSERT INTO RTMoventi.ComplejoDeportivo(CodigoComplejo, NombreComplejo, PresupuestoAproximado, Localizacion, JefeOrganizacionId, AreaTotalOcupada, TipoComplejoId, TipoDeporteId, Estado, UsuarioRegistro, FechaRegistro)
		VALUES(@pCodigoComplejo, @pNombreComplejo, @pPresupuestoAproximado, @pLocalizacion, @pJefeOrganizacionId, @pAreaTotalOcupada, @pTipoComplejoId, @pTipoDeporteId, 1, @pUsuarioId, GETDATE());
	
		SELECT SCOPE_IDENTITY() AS ComplejoDeportivoId;
	END
	ELSE 
	BEGIN 
		UPDATE RTMoventi.ComplejoDeportivo
		SET CodigoComplejo = @pCodigoComplejo, 
			NombreComplejo = @pNombreComplejo, 
			PresupuestoAproximado = @pPresupuestoAproximado, 
			Localizacion = @pLocalizacion, 
			JefeOrganizacionId = @pJefeOrganizacionId, 
			AreaTotalOcupada = @pAreaTotalOcupada, 
			TipoComplejoId = @pTipoComplejoId, 
			TipoDeporteId = @pTipoDeporteId, 
			UsuarioRegistro = @pUsuarioId, 
			FechaRegistro = GETDATE()
		WHERE ComplejoDeportivoId = @pComplejoDeportivoId
		
		SELECT @pComplejoDeportivoId AS ComplejoDeportivoId;
	
	END
END
	
SELECT * FROM RTMoventi.ComplejoDeportivo 

go 
CREATE OR ALTER PROCEDURE RTMoventi.ObtenerComplejoDeportivo
@pComplejoDeportivoId INT 
AS 
BEGIN 
	SELECT 
		CD.ComplejoDeportivoId,
		CD.CodigoComplejo,
		CD.NombreComplejo,
		CD.PresupuestoAproximado,
		CD.Localizacion,
		JO.JefeOrganizacionId,
		JO.NombreJefe,
		CD.AreaTotalOcupada,
		TC.TipoComplejoId ,
		TC.NombreTipoComplejo ,
		TD.TipoDeporteId,
		TD.NombreDeporte,
		CD.Estado 
	FROM RTMoventi.ComplejoDeportivo CD
		INNER JOIN RTMoventi.JefeOrganizacion JO 
			ON CD.JefeOrganizacionId = JO.JefeOrganizacionId 
		INNER JOIN RTMoventi.TipoComplejo TC 
			ON CD.TipoComplejoId = TC.TipoComplejoId 
		LEFT JOIN RTMoventi.TipoDeporte TD 
			ON CD.TipoDeporteId = TD.TipoDeporteId 
	WHERE CD.Estado = 1 AND CD.ComplejoDeportivoId = @pComplejoDeportivoId;
END



GO 

CREATE OR ALTER PROCEDURE RTMoventi.EliminarComplejoDeportivo
@pComplejoDeportivoId INT ,
@pUsuarioId INT 
AS 
BEGIN 
	UPDATE RTMoventi.ComplejoDeportivo 
	SET Estado = 0, UsuarioRegistro = @pUsuarioId 
	WHERE ComplejoDeportivoId = @pComplejoDeportivoId;

	SELECT @pComplejoDeportivoId AS ComplejoDeportivoId
END


