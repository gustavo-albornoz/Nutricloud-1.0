USE [nutricloud]
GO

/****** Object:  Table [dbo].[usuario_imagen]    Script Date: 02/12/2016 08:07:13 p.m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[usuario_imagen](
	[id_usuario_imagen] [int] IDENTITY(1,1) NOT NULL,
	[nombre_imagen] [varchar](100) NULL,
	[id_usuario] [int] NOT NULL,
 CONSTRAINT [PK_usuario_imagen] PRIMARY KEY CLUSTERED 
(
	[id_usuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

