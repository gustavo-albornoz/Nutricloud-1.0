USE [nutricloud]
GO
/****** Object:  StoredProcedure [dbo].[sp_notificacion_blog_nota_insertar]    Script Date: 11/26/2016 14:50:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[sp_notificacion_blog_nota_insertar](@id_nota int, @id_usuario int)

AS
BEGIN
    
	--SELECT u.id_usuario 
	--FROM usuario AS u 
	--WHERE u.id_usuario_tipo = 1;

	INSERT INTO notificacion_blog_nota (id_blog_nota, id_usuario) VALUES (@id_nota, @id_usuario)
END

