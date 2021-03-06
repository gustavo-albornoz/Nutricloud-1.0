USE [nutricloud]
GO
/****** Object:  StoredProcedure [dbo].[sp_listar_alimento_quincena]    Script Date: 11/26/2016 14:50:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[sp_listar_alimento_quincena] (
	@id_usuario int,
	@fechainicio datetime,
	@fechafin datetime
)
AS
BEGIN

select alimento.*,
usuario_alimento.cantidad,
usuario_alimento.f_ingreso,
usuario_alimento.id_comida_tipo,
usuario_alimento.id_usuario,
alimento_genero.alimento_genero 

from alimento 
inner join 
usuario_alimento on alimento.id_alimento=usuario_alimento.id_alimento 
inner join 
alimento_genero on alimento_genero.id_alimento_genero=alimento.id_alimento_genero
where usuario_alimento.id_usuario = @id_usuario 
and 
usuario_alimento.f_ingreso
between
cast(@fechainicio as date)
and
cast(@fechafin as date);

END