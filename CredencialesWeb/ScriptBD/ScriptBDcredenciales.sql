--Sql server 2019 18.11.1
CREATE DATABASE credenciales;
GO

USE [credenciales]
GO
/****** Object:  Table [dbo].[Categoria]    Script Date: 18/05/2022 09:42:07 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categoria](
	[Id] [int] NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Categoria] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[credenciales]    Script Date: 18/05/2022 09:42:07 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[credenciales](
	[Id] [int] NOT NULL,
	[Empresa] [varchar](50) NULL,
	[Clave] [varchar](50) NULL,
	[Usuario] [varchar](50) NULL,
	[Producto] [varchar](80) NULL,
	[Baja] [tinyint] NULL,
 CONSTRAINT [PK_credenciales] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Protocolo]    Script Date: 18/05/2022 09:42:07 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Protocolo](
	[Id] [int] NOT NULL,
	[Nombre] [varchar](12) NOT NULL,
 CONSTRAINT [PK_Protocolo] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SitiosWeb]    Script Date: 18/05/2022 09:42:07 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SitiosWeb](
	[Id] [int] NOT NULL,
	[RutaUrl] [varchar](50) NOT NULL,
	[CategoriaId] [int] NOT NULL,
	[ProtocoloId] [int] NULL,
 CONSTRAINT [PK_SitiosWeb] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[SitiosWeb]  WITH CHECK ADD  CONSTRAINT [FK_SitiosWeb_Categoria] FOREIGN KEY([CategoriaId])
REFERENCES [dbo].[Categoria] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[SitiosWeb] CHECK CONSTRAINT [FK_SitiosWeb_Categoria]
GO
ALTER TABLE [dbo].[SitiosWeb]  WITH CHECK ADD  CONSTRAINT [FK_SitiosWeb_Protocolo] FOREIGN KEY([ProtocoloId])
REFERENCES [dbo].[Protocolo] ([Id])
GO
ALTER TABLE [dbo].[SitiosWeb] CHECK CONSTRAINT [FK_SitiosWeb_Protocolo]
GO
