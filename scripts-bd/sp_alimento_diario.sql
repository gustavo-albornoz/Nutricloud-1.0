USE [nutricloud]
GO
/****** Object:  StoredProcedure [dbo].[sp_alimento_diario]    Script Date: 11/26/2016 14:48:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER proc [dbo].[sp_alimento_diario] (
	@id_usuario int,
	@id_comida_tipo int,
	@fecha datetime
)
AS
BEGIN

	Select
	ua.id_usuario_alimento
	,ua.id_usuario
	,ua.id_alimento
	,ua.id_comida_tipo
	,ua.cantidad
	,ua.f_ingreso

	,al.nombre_alimento
	,CONVERT(decimal(5,2), ua.cantidad * al.energia_kcal /al.porcion) energia_kcal

	,at.unidad_medida

	From usuario_alimento ua
	inner join alimento al on al.id_alimento = ua.id_alimento
	inner join alimento_tipo at on at.id_alimento_tipo = al.id_alimento_tipo
	where ua.id_usuario = @id_usuario
	and ua.id_comida_tipo = @id_comida_tipo
	and DAY(ua.f_ingreso) = DAY(@fecha)
	and MONTH(ua.f_ingreso) = MONTH(@fecha)
	and YEAR(ua.f_ingreso) = YEAR(@fecha)
	order by f_ingreso desc

END
