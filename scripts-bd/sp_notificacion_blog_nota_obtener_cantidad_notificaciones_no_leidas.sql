USE [nutricloud]
GO
/****** Object:  StoredProcedure [dbo].[sp_notificacion_blog_nota_obtener_cantidad_notificaciones_no_leidas]    Script Date: 11/26/2016 14:51:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[sp_notificacion_blog_nota_obtener_cantidad_notificaciones_no_leidas] (@id_usuario int)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	SELECT 
		count(*)
	FROM 
		notificacion_blog_nota AS nbn
	WHERE 
		nbn.id_usuario = @id_usuario 
		AND nbn.leido = 0;
END

