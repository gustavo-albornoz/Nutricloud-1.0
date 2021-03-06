USE [nutricloud]
GO
/****** Object:  StoredProcedure [dbo].[sp_notificacion_blog_nota_obtener]    Script Date: 11/26/2016 14:51:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[sp_notificacion_blog_nota_obtener](@id_usuario int)
AS
BEGIN
	SELECT 
		bn.id_blog_nota as id_nota, 
		bn.titulo_nota, 
		u.id_usuario as id_autor_nota,
		u.nombre as nombre_autor_nota, 
		nbn.notificacion_fecha as fecha_notificacion, 
		nbn.leido as leida_notificacion,
		nbn.id_notificacion_blog_nota as id_notificacion
	FROM 
		notificacion_blog_nota AS nbn
		INNER JOIN blog_nota AS bn ON nbn.id_blog_nota = bn.id_blog_nota
		INNER JOIN usuario AS u ON bn.id_usuario = u.id_usuario 
	WHERE 
		nbn.id_usuario = @id_usuario  
	ORDER BY fecha_notificacion DESC;
END

