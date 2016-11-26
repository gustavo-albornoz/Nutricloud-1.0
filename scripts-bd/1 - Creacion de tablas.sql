use nutricloud
go
drop table consulta_mensaje
drop table consulta_conversacion
drop table usuario_alimento
drop table comida_tipo
drop view v_usuario_muro
drop table usuario_receta
drop table usuario_muro
drop table usuario_datos
drop table usuario_objetivo
drop table usuario_usuario
drop table usuario_idr
drop table notificacion_blog_nota
drop table blog_nota
drop table usuario_alimento_favorito
drop table usuario
drop table usuario_tipo
drop table usuario_actividad
drop table alimento
drop table alimento_tipo
drop table alimento_genero
go
--Opciones como: liquidos (litros), solidos (gr)
create table alimento_tipo (
    id_alimento_tipo int identity(1,1) primary key,
    alimento_tipo varchar(30) not null,
    unidad_medida varchar(2) not null
)
GO
-- carnes, pescados, lacteos...
create table alimento_genero (
    id_alimento_genero int identity(1,1) primary key,
    alimento_genero varchar(30) not null
)
GO
CREATE TABLE [dbo].[alimento](
    [id_alimento] [int] IDENTITY(1,1) NOT NULL,
    [nro] [int] NULL,
    [nombre_alimento] [varchar](100) NOT NULL,
    [energia_kj] [decimal](10, 3) NULL default 0,
    [energia_kcal] [decimal](10, 3) NULL default 0,
    [sodio_mg] [decimal](10, 3) NULL default 0,
    [potasio_mg] [decimal](10, 3) NULL default 0,
    [calcio_mg] [decimal](10, 3) NULL default 0,
    [fosforo_mg] [decimal](10, 3) NULL default 0,
    [hierro_mg] [decimal](10, 3) NULL default 0,
    [zinc_mg] [decimal](10, 3) NULL default 0,
    [tiamina_mg] [decimal](10, 3) NULL default 0,
    [rivoflavina_mg] [decimal](10, 3) NULL default 0,
    [niacina_mg] [decimal](10, 3) NULL default 0,
    [vitamina_c_mg] [decimal](10, 3) NULL default 0,
    [colesterol_mg] [decimal](10, 3) NULL default 0,
    [cenizas_g] [decimal](10, 3) NULL default 0,
    [agua_g] [decimal](10, 3) NULL default 0,
    [grasa_total_g] [decimal](10, 3) NULL default 0,
    [carbohidratos_totales_g] [decimal](10, 3) NULL default 0,
    [carbohidratos_disponibles_g] [decimal](10, 3) NULL default 0,
    [ac_grasos_saturados_g] [decimal](10, 3) NULL default 0,
    [ac_grasos_monoinsaturados_g] [decimal](10, 3) NULL default 0,
    [ac_grasos_poliinsaturados_g] [decimal](10, 3) NULL default 0,
    [fibra_dietetica_g] [decimal](10, 3) NULL default 0,
    [proteinas_g] [decimal](10, 3) NULL default 0,
    [agp_w6_g] [decimal](10, 3) NULL default 0,
    [agp_w3_g] [decimal](10, 3) NULL default 0,
    [porcion] [decimal](10, 3) NOT NULL,
    [id_alimento_tipo] [int] NOT NULL,
    [id_alimento_genero] [int] NOT NULL default 0,
PRIMARY KEY CLUSTERED 
(
    [id_alimento] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[alimento]  WITH CHECK ADD  CONSTRAINT [FK_alimento_alimento_genero] FOREIGN KEY([id_alimento_genero])
REFERENCES [dbo].[alimento_genero] ([id_alimento_genero])
GO

ALTER TABLE [dbo].[alimento] CHECK CONSTRAINT [FK_alimento_alimento_genero]
GO

ALTER TABLE [dbo].[alimento]  WITH CHECK ADD  CONSTRAINT [FK_alimento_alimento_tipo] FOREIGN KEY([id_alimento_tipo])
REFERENCES [dbo].[alimento_tipo] ([id_alimento_tipo])
GO

ALTER TABLE [dbo].[alimento] CHECK CONSTRAINT [FK_alimento_alimento_tipo]
GO
create table usuario_tipo (
    id_usuario_tipo int identity(1,1) primary key,
    usuario_tipo varchar(30) not null
)
GO
CREATE TABLE [dbo].[usuario_actividad](
    [id_usuario_actividad] [int] IDENTITY(1,1) NOT NULL,
    [usuario_actividad] [varchar](50) NOT NULL,
 CONSTRAINT [PK_usuario_usuario_actividad] PRIMARY KEY CLUSTERED 
(
    [id_usuario_actividad] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

go

CREATE TABLE [dbo].[usuario](
    [id_usuario] [int] IDENTITY(1,1) NOT NULL,
    [email] [varchar](100) NOT NULL,
    [clave] [varchar](100) NOT NULL,
    [nombre] [varchar](100) NULL,
    [sexo] [char](1) NULL,
    [f_nacimiento] [date] NULL,
    [f_registro] [datetime] NOT NULL,
    [f_ultimo_ingreso] [datetime] NULL,
    [id_usuario_tipo] [int] NOT NULL,
    vegetariano bit default 0,
    vegano bit default 0,
PRIMARY KEY CLUSTERED 
(
    [id_usuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [IX_usuario] UNIQUE NONCLUSTERED 
(
    [email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[usuario]  WITH CHECK ADD  CONSTRAINT [FK_usuario_usuario_tipo] FOREIGN KEY([id_usuario_tipo])
REFERENCES [dbo].[usuario_tipo] ([id_usuario_tipo])
GO

ALTER TABLE [dbo].[usuario] CHECK CONSTRAINT [FK_usuario_usuario_tipo]
GO
CREATE TABLE [dbo].[usuario_objetivo](
    [id_usuario_objetivo] [int] IDENTITY(1,1) NOT NULL,
    [usuario_objetivo] [varchar](50) NOT NULL,
 CONSTRAINT [PK_usuario_objetivo] PRIMARY KEY CLUSTERED 
(
    [id_usuario_objetivo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
CREATE TABLE [dbo].[usuario_datos](
    [id_usuario_datos] [int] IDENTITY(1,1) NOT NULL,
    [id_usuario] [int] NOT NULL,
    [altura_cm] [int] NOT NULL,
    [peso_kg] [decimal](5, 2) NOT NULL,
    [f_ingreso] [datetime] NOT NULL DEFAULT (getdate()),
    [id_usuario_objetivo] [int] NOT NULL,
    [id_usuario_actividad] [int] NULL,
PRIMARY KEY CLUSTERED 
(
    [id_usuario_datos] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[usuario_datos]  WITH CHECK ADD  CONSTRAINT [FK_usuario_datos_usuario_objetivo] FOREIGN KEY([id_usuario_objetivo])
REFERENCES [dbo].[usuario_objetivo] ([id_usuario_objetivo])
GO

ALTER TABLE [dbo].[usuario_datos] CHECK CONSTRAINT [FK_usuario_datos_usuario_objetivo]
GO

ALTER TABLE [dbo].[usuario_datos]  WITH CHECK ADD  CONSTRAINT [FK_usuario_datos_usuario] FOREIGN KEY([id_usuario])
REFERENCES [dbo].[usuario] ([id_usuario])
GO

ALTER TABLE [dbo].[usuario_datos]  WITH CHECK ADD  CONSTRAINT [FK_usuario_usuario_actividad] FOREIGN KEY([id_usuario_actividad])
REFERENCES [dbo].[usuario_actividad] ([id_usuario_actividad])
GO

ALTER TABLE [dbo].[usuario_datos] CHECK CONSTRAINT [FK_usuario_usuario_actividad]
GO

ALTER TABLE [dbo].[usuario_datos] CHECK CONSTRAINT [FK_usuario_datos_usuario]
GO

CREATE TABLE [dbo].[usuario_usuario](
    [id_usuario_usuario] [int] IDENTITY(1,1) NOT NULL,
    [id_usuario_seguidor] [int] NOT NULL,
    [id_usuario_seguido] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
    [id_usuario_usuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[usuario_usuario]  WITH CHECK ADD  CONSTRAINT [FK_usuario_usuario_usuario] FOREIGN KEY([id_usuario_seguido])
REFERENCES [dbo].[usuario] ([id_usuario])
GO

ALTER TABLE [dbo].[usuario_usuario] CHECK CONSTRAINT [FK_usuario_usuario_usuario]
GO

ALTER TABLE [dbo].[usuario_usuario]  WITH CHECK ADD  CONSTRAINT [FK_usuario_usuario_usuario1] FOREIGN KEY([id_usuario_seguidor])
REFERENCES [dbo].[usuario] ([id_usuario])
GO

ALTER TABLE [dbo].[usuario_usuario] CHECK CONSTRAINT [FK_usuario_usuario_usuario1]
GO

CREATE TABLE [dbo].[usuario_muro](
    [id_usuario_muro] [int] IDENTITY(1,1) NOT NULL,
    [id_usuario] [int] NOT NULL,
    [estado] [text] NOT NULL,
    [f_publicacion] [datetime] NOT NULL DEFAULT (getdate()),
PRIMARY KEY CLUSTERED 
(
    [id_usuario_muro] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
ALTER TABLE [dbo].[usuario_muro]  WITH CHECK ADD  CONSTRAINT [FK_usuario_muro_usuario] FOREIGN KEY([id_usuario])
REFERENCES [dbo].[usuario] ([id_usuario])
GO

ALTER TABLE [dbo].[usuario_muro] CHECK CONSTRAINT [FK_usuario_muro_usuario]
GO
create table comida_tipo (
    id_comida_tipo int identity(1,1) primary key,
    comida_tipo varchar(30) not null,
    imagen varchar(50) null
)
go
CREATE TABLE [dbo].[usuario_alimento](
    [id_usuario_alimento] [int] IDENTITY(1,1) NOT NULL,
    [id_usuario] [int] NOT NULL,
    [id_alimento] [int] NOT NULL,
    [id_comida_tipo] [int] NOT NULL,
    [cantidad] [decimal](5, 2) NOT NULL,
    [f_ingreso] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
    [id_usuario_alimento] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[usuario_alimento] ADD  DEFAULT (getdate()) FOR [f_ingreso]
GO

ALTER TABLE [dbo].[usuario_alimento]  WITH CHECK ADD  CONSTRAINT [FK_usuario_alimento_alimento] FOREIGN KEY([id_alimento])
REFERENCES [dbo].[alimento] ([id_alimento])
GO

ALTER TABLE [dbo].[usuario_alimento] CHECK CONSTRAINT [FK_usuario_alimento_alimento]
GO

ALTER TABLE [dbo].[usuario_alimento]  WITH CHECK ADD  CONSTRAINT [FK_usuario_alimento_comida_tipo] FOREIGN KEY([id_comida_tipo])
REFERENCES [dbo].[comida_tipo] ([id_comida_tipo])
GO

ALTER TABLE [dbo].[usuario_alimento] CHECK CONSTRAINT [FK_usuario_alimento_comida_tipo]
GO

ALTER TABLE [dbo].[usuario_alimento]  WITH CHECK ADD  CONSTRAINT [FK_usuario_alimento_usuario] FOREIGN KEY([id_usuario])
REFERENCES [dbo].[usuario] ([id_usuario])
GO

ALTER TABLE [dbo].[usuario_alimento] CHECK CONSTRAINT [FK_usuario_alimento_usuario]
GO

CREATE TABLE [dbo].[blog_nota](
    [id_blog_nota] [int] IDENTITY(1,1) NOT NULL,
    [nota] [text] NOT NULL,
    [titulo_nota] [varchar](50) NOT NULL,
    [f_publicacion] [datetime] NOT NULL DEFAULT (getdate()),
    [id_usuario] [int] NOT NULL,
    [descripcion_nota] [varchar](100) NOT NULL,
    [imagen_nota] [varchar](100),
 CONSTRAINT [PK_blog_nota] PRIMARY KEY CLUSTERED 
(
    [id_blog_nota] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

ALTER TABLE [dbo].[blog_nota]  WITH CHECK ADD  CONSTRAINT [FK_blog_nota_usuario] FOREIGN KEY([id_usuario])
REFERENCES [dbo].[usuario] ([id_usuario])
GO

ALTER TABLE [dbo].[blog_nota] CHECK CONSTRAINT [FK_blog_nota_usuario]
GO

CREATE TABLE [dbo].[usuario_receta](
    [id_usuario_receta] [int] IDENTITY(1,1) NOT NULL,
    [receta] [text] NOT NULL,
    [titulo_receta] [varchar](50) NOT NULL,
    [descripcion_receta] [varchar](100) NOT NULL,
    [imagen_receta] [varchar](100),
    [f_publicacion] [datetime] NOT NULL DEFAULT (getdate()),
    [id_usuario] [int] NOT NULL,
 CONSTRAINT [PK_usuario_receta] PRIMARY KEY CLUSTERED 
(
    [id_usuario_receta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

ALTER TABLE [dbo].[usuario_receta]  WITH CHECK ADD  CONSTRAINT [FK_usuario_receta_usuario] FOREIGN KEY([id_usuario])
REFERENCES [dbo].[usuario] ([id_usuario])
GO

ALTER TABLE [dbo].[usuario_receta] CHECK CONSTRAINT [FK_usuario_receta_usuario]
GO

CREATE TABLE [dbo].[consulta_conversacion](
    [id_consulta_conversacion] [int] IDENTITY(1,1) NOT NULL,
    [asunto] [varchar](100) NOT NULL,
    [id_usuario_remitente] [int] NOT NULL,
    [id_usuario_destinatario] [int] NULL,
    f_ultimo_mensaje datetime not null default GETDATE(),
    [cerrada] [bit] NOT NULL,
 CONSTRAINT [PK_consulta_conversacion] PRIMARY KEY CLUSTERED 
(
    [id_consulta_conversacion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[consulta_conversacion] ADD  DEFAULT ((0)) FOR [cerrada]
GO

ALTER TABLE [dbo].[consulta_conversacion]  WITH CHECK ADD  CONSTRAINT [FK_consulta_conversacion_usuario] FOREIGN KEY([id_usuario_destinatario])
REFERENCES [dbo].[usuario] ([id_usuario])
GO

ALTER TABLE [dbo].[consulta_conversacion] CHECK CONSTRAINT [FK_consulta_conversacion_usuario]
GO

ALTER TABLE [dbo].[consulta_conversacion]  WITH CHECK ADD  CONSTRAINT [FK_consulta_conversacion_usuario1] FOREIGN KEY([id_usuario_remitente])
REFERENCES [dbo].[usuario] ([id_usuario])
GO

ALTER TABLE [dbo].[consulta_conversacion] CHECK CONSTRAINT [FK_consulta_conversacion_usuario1]
GO

CREATE TABLE [dbo].[consulta_mensaje](
    [id_consulta_mensaje] [int] IDENTITY(1,1) NOT NULL,
    [mensaje] [text] NOT NULL,
    [f_mensaje] [datetime] NOT NULL,
    [id_consulta_conversacion] [int] NOT NULL,
    [id_usuario_remitente] [int] NOT NULL,
    leido bit
 CONSTRAINT [PK_consulta_mensaje] PRIMARY KEY CLUSTERED 
(
    [id_consulta_mensaje] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

ALTER TABLE [dbo].[consulta_mensaje] ADD  DEFAULT (getdate()) FOR [f_mensaje]
GO

ALTER TABLE [dbo].[consulta_mensaje]  WITH CHECK ADD  CONSTRAINT [FK_consulta_mensaje_consulta_conversacion] FOREIGN KEY([id_consulta_conversacion])
REFERENCES [dbo].[consulta_conversacion] ([id_consulta_conversacion])
GO

ALTER TABLE [dbo].[consulta_mensaje] CHECK CONSTRAINT [FK_consulta_mensaje_consulta_conversacion]
GO

ALTER TABLE [dbo].[consulta_mensaje]  WITH CHECK ADD  CONSTRAINT [FK_consulta_mensaje_usuario1] FOREIGN KEY([id_usuario_remitente])
REFERENCES [dbo].[usuario] ([id_usuario])
GO

ALTER TABLE [dbo].[consulta_mensaje] CHECK CONSTRAINT [FK_consulta_mensaje_usuario1]
GO

CREATE TABLE [dbo].[usuario_idr](
    [id_valores] [int] IDENTITY(1,1) NOT NULL,
    [id_usuario] [int] NOT NULL,
    [energia_kj] [decimal](10, 3) NULL,
    [energia_kcal] [decimal](10, 3) NULL,
    [sodio_mg] [decimal](10, 3) NULL,
    [potasio_mg] [decimal](10, 3) NULL,
    [calcio_mg] [decimal](10, 3) NULL,
    [fosforo_mg] [decimal](10, 3) NULL,
    [hierro_mg] [decimal](10, 3) NULL,
    [zinc_mg] [decimal](10, 3) NULL,
    [vitamina_c_mg] [decimal](10, 3) NULL,
    [colesterol_mg] [decimal](10, 3) NULL,
    [agua_g] [decimal](10, 3) NULL,
    [grasa_total_g] [decimal](10, 3) NULL,
    [carbohidratos_totales_g] [decimal](10, 3) NULL,
    [carbohidratos_disponibles_g] [decimal](10, 3) NULL,
    [proteinas_g] [decimal](10, 3) NULL,
    [fibra_dietetica_g] [decimal](10, 3) NULL,
    [tiamina_mg] [decimal](10, 3) NULL,
    [riboflavina_mg] [decimal](10, 3) NULL,
    [niacina_mg] [decimal](10, 3) NULL,
 CONSTRAINT [PK_usuario_idr] PRIMARY KEY CLUSTERED 
(
    [id_valores] ASC,
    [id_usuario] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[usuario_idr]  WITH CHECK ADD  CONSTRAINT [FK_usuario_idr_usuario] FOREIGN KEY([id_usuario])
REFERENCES [dbo].[usuario] ([id_usuario])
GO

ALTER TABLE [dbo].[usuario_idr] CHECK CONSTRAINT [FK_usuario_idr_usuario]
GO

CREATE VIEW [dbo].[v_usuario_muro]
AS
SELECT
um.id_usuario AS id_usuario_seguido,
CASE When us.nombre is null or ltrim(rtrim(us.nombre)) = '' Then 'Anónimo' Else us.nombre END AS nombre_usuario_seguido,
convert(varchar(5000),um.estado) estado,
um.f_publicacion,
us.sexo,
uu.id_usuario_seguidor id_usuario_seguidor
FROM dbo.usuario_muro AS um INNER JOIN
dbo.usuario AS us ON us.id_usuario = um.id_usuario INNER JOIN
dbo.usuario_usuario AS uu ON uu.id_usuario_seguido = um.id_usuario
UNION
SELECT
um.id_usuario AS id_usuario_seguido,
CASE When us.nombre is null or ltrim(rtrim(us.nombre)) = '' Then 'Anónimo' Else us.nombre END AS nombre_usuario_seguido,
convert(varchar(5000),um.estado) estado,
um.f_publicacion,
us.sexo,
us.id_usuario id_usuario_seguidor
FROM dbo.usuario_muro AS um INNER JOIN
dbo.usuario AS us ON us.id_usuario = um.id_usuario

GO
CREATE TABLE [dbo].[notificacion_blog_nota](
    [id_notificacion_blog_nota] [int] IDENTITY(1,1) NOT NULL,
    [leido] [bit] NOT NULL CONSTRAINT [DF_notificacion_blog_nota_leido]  DEFAULT ((0)),
    [descripcion] [varchar](100) NULL CONSTRAINT [DF_notificacion_blog_nota_descripcion]  DEFAULT (NULL),
    [id_blog_nota] [int] NOT NULL,
    [id_usuario] [int] NOT NULL,
    [notificacion_fecha] [datetime] NOT NULL CONSTRAINT [DF_notificacion_blog_nota_notificacion_fecha]  DEFAULT (getdate()),
 CONSTRAINT [PK_notificacion_blog_nota] PRIMARY KEY CLUSTERED 
(
    [id_notificacion_blog_nota] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[notificacion_blog_nota]  WITH CHECK ADD  CONSTRAINT [FK_notificacion_blog_nota_blog_nota] FOREIGN KEY([id_blog_nota])
REFERENCES [dbo].[blog_nota] ([id_blog_nota])
GO
ALTER TABLE [dbo].[notificacion_blog_nota] CHECK CONSTRAINT [FK_notificacion_blog_nota_blog_nota]
GO
ALTER TABLE [dbo].[notificacion_blog_nota]  WITH CHECK ADD  CONSTRAINT [FK_notificacion_blog_nota_usuario] FOREIGN KEY([id_usuario])
REFERENCES [dbo].[usuario] ([id_usuario])
GO
ALTER TABLE [dbo].[notificacion_blog_nota] CHECK CONSTRAINT [FK_notificacion_blog_nota_usuario]
GO

CREATE TABLE [dbo].[usuario_alimento_favorito](
	[id_favorito] [int] IDENTITY(1,1) NOT NULL,
	[id_usuario] [int] NOT NULL,
	[id_alimento] [int] NOT NULL,
 CONSTRAINT [PK_usuario_alimento_favorito] PRIMARY KEY CLUSTERED 
(
	[id_usuario] ASC,
	[id_alimento] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[usuario_alimento_favorito]  WITH CHECK ADD  CONSTRAINT [FK_usuario_alimento_favorito_alimento1] FOREIGN KEY([id_alimento])
REFERENCES [dbo].[alimento] ([id_alimento])
GO

ALTER TABLE [dbo].[usuario_alimento_favorito] CHECK CONSTRAINT [FK_usuario_alimento_favorito_alimento1]
GO

ALTER TABLE [dbo].[usuario_alimento_favorito]  WITH CHECK ADD  CONSTRAINT [FK_usuario_alimento_favorito_usuario] FOREIGN KEY([id_usuario])
REFERENCES [dbo].[usuario] ([id_usuario])
GO

ALTER TABLE [dbo].[usuario_alimento_favorito] CHECK CONSTRAINT [FK_usuario_alimento_favorito_usuario]
GO