USE [nutricloud]
GO
SET IDENTITY_INSERT [dbo].[alimento_tipo] ON 
INSERT [dbo].[alimento_tipo] ([id_alimento_tipo], [alimento_tipo], [unidad_medida]) VALUES (1, N'Sólidos', N'gr')
INSERT [dbo].[alimento_tipo] ([id_alimento_tipo], [alimento_tipo], [unidad_medida]) VALUES (2, N'Líquidos', N'ml')
SET IDENTITY_INSERT [dbo].[alimento_tipo] OFF
GO
SET IDENTITY_INSERT [dbo].[usuario_actividad] ON
INSERT [dbo].[usuario_actividad] ([id_usuario_actividad], [usuario_actividad]) VALUES (1, N'Sedentario')
INSERT [dbo].[usuario_actividad] ([id_usuario_actividad], [usuario_actividad]) VALUES (2, N'Poco activo')
INSERT [dbo].[usuario_actividad] ([id_usuario_actividad], [usuario_actividad]) VALUES (3, N'Activo')
INSERT [dbo].[usuario_actividad] ([id_usuario_actividad], [usuario_actividad]) VALUES (4, N'Deportista')
SET IDENTITY_INSERT [dbo].[usuario_actividad] OFF
GO
SET IDENTITY_INSERT [dbo].[usuario_tipo] ON
INSERT [dbo].[usuario_tipo] ([id_usuario_tipo], [usuario_tipo]) VALUES (1, N'Paciente')
INSERT [dbo].[usuario_tipo] ([id_usuario_tipo], [usuario_tipo]) VALUES (2, N'Profesional')
SET IDENTITY_INSERT [dbo].[usuario_tipo] OFF
GO
SET IDENTITY_INSERT [dbo].[usuario_objetivo] ON
INSERT [dbo].[usuario_objetivo] ([id_usuario_objetivo], [usuario_objetivo]) VALUES (1, N'Bajar')
INSERT [dbo].[usuario_objetivo] ([id_usuario_objetivo], [usuario_objetivo]) VALUES (2, N'Mantener')
INSERT [dbo].[usuario_objetivo] ([id_usuario_objetivo], [usuario_objetivo]) VALUES (3, N'Subir')
INSERT [dbo].[usuario_objetivo] ([id_usuario_objetivo], [usuario_objetivo]) VALUES (4, N'Aumentar rendimiento')
SET IDENTITY_INSERT [dbo].[usuario_objetivo] OFF
GO
SET IDENTITY_INSERT [dbo].[comida_tipo] ON
INSERT [dbo].[comida_tipo] ([id_comida_tipo], [comida_tipo], [imagen]) VALUES (1, N'Desayuno', N'healthy-breakfast.png')
INSERT [dbo].[comida_tipo] ([id_comida_tipo], [comida_tipo], [imagen]) VALUES (2, N'Almuerzo', N'salad-bowl.png')
INSERT [dbo].[comida_tipo] ([id_comida_tipo], [comida_tipo], [imagen]) VALUES (3, N'Merienda', N'oatmeal.png')
INSERT [dbo].[comida_tipo] ([id_comida_tipo], [comida_tipo], [imagen]) VALUES (4, N'Cena', N'dinner.png')
INSERT [dbo].[comida_tipo] ([id_comida_tipo], [comida_tipo], [imagen]) VALUES (5, N'Aperitivo', N'coffee.png')
SET IDENTITY_INSERT [dbo].[comida_tipo] OFF
GO
SET IDENTITY_INSERT [dbo].[alimento_genero] ON
INSERT [dbo].[alimento_genero] ([id_alimento_genero], [alimento_genero]) VALUES (0, N'No definido')
INSERT [dbo].[alimento_genero] ([id_alimento_genero], [alimento_genero]) VALUES (1, N'Carnes')
INSERT [dbo].[alimento_genero] ([id_alimento_genero], [alimento_genero]) VALUES (2, N'Cereales')
INSERT [dbo].[alimento_genero] ([id_alimento_genero], [alimento_genero]) VALUES (3, N'Frutas')
INSERT [dbo].[alimento_genero] ([id_alimento_genero], [alimento_genero]) VALUES (4, N'Grasas y aceites')
INSERT [dbo].[alimento_genero] ([id_alimento_genero], [alimento_genero]) VALUES (5, N'Huevos')
INSERT [dbo].[alimento_genero] ([id_alimento_genero], [alimento_genero]) VALUES (6, N'Lacteos')
INSERT [dbo].[alimento_genero] ([id_alimento_genero], [alimento_genero]) VALUES (7, N'Pescados y mariscos')
INSERT [dbo].[alimento_genero] ([id_alimento_genero], [alimento_genero]) VALUES (8, N'Vegetales')
INSERT [dbo].[alimento_genero] ([id_alimento_genero], [alimento_genero]) VALUES (9, N'Dulces')
SET IDENTITY_INSERT [dbo].[alimento_genero] OFF
USE [nutricloud]
GO
SET IDENTITY_INSERT [dbo].[usuario] ON
INSERT [dbo].[usuario] ([id_usuario], [email], [clave], [nombre], [sexo], [f_nacimiento], [f_registro], [f_ultimo_ingreso], [id_usuario_tipo]) VALUES (1, N'usuario1@prueba.com', N'KQ83RRF7N21CqICiirrSEfsxtbA=', 'usuario 1', NULL, NULL, CAST(N'2016-07-08 16:19:55.040' AS DateTime), NULL, 1)
INSERT [dbo].[usuario] ([id_usuario], [email], [clave], [nombre], [sexo], [f_nacimiento], [f_registro], [f_ultimo_ingreso], [id_usuario_tipo]) VALUES (2, N'usuario2@prueba.com', N'IPNtrjFY0sbP/4HJUeLN8mIbsGs=', NULL, NULL, NULL, CAST(N'2016-07-08 16:24:23.577' AS DateTime), NULL, 1)
INSERT [dbo].[usuario] ([id_usuario], [email], [clave], [nombre], [sexo], [f_nacimiento], [f_registro], [f_ultimo_ingreso], [id_usuario_tipo]) VALUES (3, N'usuario3@prueba.com', N'1z4x9yVPaQ2+9aviU4HcMkgqZ1c=', 'usuario3', NULL, NULL, CAST(N'2016-07-08 16:25:45.450' AS DateTime), NULL, 1)
INSERT [dbo].[usuario] ([id_usuario], [email], [clave], [nombre], [sexo], [f_nacimiento], [f_registro], [f_ultimo_ingreso], [id_usuario_tipo]) VALUES (4, N'usuario4@prueba.com', N'M25TfrkoZfjXa3SB6GpR2lJUPDM=', 'usuario 4', NULL, NULL, CAST(N'2016-07-08 16:28:14.127' AS DateTime), NULL, 1)
INSERT [dbo].[usuario] ([id_usuario], [email], [clave], [nombre], [sexo], [f_nacimiento], [f_registro], [f_ultimo_ingreso], [id_usuario_tipo]) VALUES (5, N'profesional1@prueba.com', N'avqZH3R2jZOBbj+WfqJKmMbzJRk=', 'profesional 1', NULL, NULL, CAST(N'2016-07-08 16:28:58.393' AS DateTime), NULL, 2)
INSERT [dbo].[usuario] ([id_usuario], [email], [clave], [nombre], [sexo], [f_nacimiento], [f_registro], [f_ultimo_ingreso], [id_usuario_tipo]) VALUES (6, N'profesional2@prueba.com', N'Tu6MT6mql0Amu3iYfgO3vmq77v4=', 'profesional 2', NULL, NULL, CAST(N'2016-07-08 16:29:20.503' AS DateTime), NULL, 2)
INSERT [dbo].[usuario] ([id_usuario], [email], [clave], [nombre], [sexo], [f_nacimiento], [f_registro], [f_ultimo_ingreso], [id_usuario_tipo]) VALUES (7, N'profesional3@prueba.com', N'mB1QcchhnQvzQ85LWFRk1uOJqyw=', 'profesional 3', NULL, NULL, CAST(N'2016-07-08 16:29:41.310' AS DateTime), NULL, 2)
SET IDENTITY_INSERT [dbo].[usuario] OFF
GO
insert into usuario_muro (id_usuario,estado,f_publicacion)
values
(1, 'Me siento bien hoy', '20160803 20:00'),
(2, 'Hermoso dia', '20160803 20:05'),
(3, 'Vamos a correr!', '20160803 20:10'),
(4, 'Debo comer menos', '20160803 20:15'),
(1, 'Estoy genial', '20160802 23:00'),
(2, 'Siiiii', '20160802 23:05'),
(3, 'Veamos que sucede hoy', '20160802 23:10'),
(4, 'Estoy gordito', '20160802 23:15'),
(1, 'Estoy genial parte 2', '20160730 12:00'),
(2, 'Siiiii parte 2', '20160730 12:05'),
(3, 'Veamos que sucede hoy parte 2', '20160730 12:10'),
(4, 'Estoy gordito parte 2', '20160730 12:15'),
(1, 'Estoy genial parte 3', '20160801 22:00'),
(2, 'Siiiii parte 3', '20160801 22:05'),
(3, 'Veamos que sucede hoy parte 3', '20160801 22:10'),
(4, 'Estoy gordito parte 3', '20160801 22:15'),
(1, 'Estoy genial parte 4', '20160731 14:00'),
(2, 'Siiiii parte 4', '20160731 14:05'),
(3, 'Veamos que sucede hoy parte 4', '20160731 14:10'),
(4, 'Estoy gordito parte 4', '20160731 14:15'),
(1, 'Estoy genial parte 5', '20160728 13:00'),
(2, 'Siiiii parte 5', '20160728 13:05'),
(3, 'Veamos que sucede hoy parte 5', '20160728 13:10'),
(4, 'Estoy gordito parte 5', '20160728 13:15'),
(1, 'Estoy genial parte 6', '20160728 17:00'),
(2, 'Siiiii parte 6', '20160728 17:05'),
(3, 'Veamos que sucede hoy parte 6', '20160728 17:10'),
(4, 'Estoy gordito parte 6', '20160728 17:15'),
(1, 'Estoy genial parte 7', '20160801 21:00'),
(2, 'Siiiii parte 7', '20160801 21:05'),
(3, 'Veamos que sucede hoy parte 7', '20160801 21:10'),
(4, 'Estoy gordito parte 7', '20160801 21:15'),
(1, 'Estoy genial parte 8', '20160803 22:00'),
(2, 'Siiiii parte 8', '20160803 22:05'),
(3, 'Veamos que sucede hoy parte 8', '20160803 22:10'),
(4, 'Estoy gordito parte 8', '20160803 22:15')
GO
insert into usuario_usuario (id_usuario_seguidor,id_usuario_seguido)
values
(1,2),
(1,3),
(1,4),
(2,1),
(2,3),
(2,4),
(3,1),
(3,2),
(3,4),
(4,1),
(4,2),
(4,3)
