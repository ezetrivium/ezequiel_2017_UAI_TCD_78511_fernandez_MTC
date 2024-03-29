USE [ProyectoCampo]
;

;

CREATE TABLE [dbo].[Familia](
	[ID_Familia] [int] NOT NULL,
	[Nombre_Familia] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Familia] PRIMARY KEY CLUSTERED 
(
	[ID_Familia] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

;

;

CREATE TABLE [dbo].[FamiliaGrupoPatente](
	[ID_FamGrppat] [int] NOT NULL,
	[ID_Fam] [int] NOT NULL,
	[ID_Grppat] [int] NOT NULL,
 CONSTRAINT [PK_FamiliaGrupoPatente] PRIMARY KEY CLUSTERED 
(
	[ID_FamGrppat] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]


;

;

CREATE TABLE [dbo].[FamiliaPatente](
	[ID_Fampat] [int] NOT NULL,
	[ID_Fam] [int] NOT NULL,
	[ID_Pat] [int] NOT NULL,
 CONSTRAINT [PK_FamiliaPatente] PRIMARY KEY CLUSTERED 
(
	[ID_Fampat] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

;

;

CREATE TABLE [dbo].[GrupoPatente](
	[ID_Grppat] [int] NOT NULL,
	[Nombre_Grppat] [varchar](50) NOT NULL,
	[ID_Padre] [int] NULL,
 CONSTRAINT [PK_GrupoPatente] PRIMARY KEY CLUSTERED 
(
	[ID_Grppat] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]


;

;

CREATE TABLE [dbo].[Patente](
	[ID_Patente] [int] NOT NULL,
	[Nombre_Patente] [varchar](50) NOT NULL,
	[Form_Patente] [varchar](50) NULL,
	[ID_Grppat] [nchar](10) NOT NULL,
 CONSTRAINT [PK_Patente] PRIMARY KEY CLUSTERED 
(
	[ID_Patente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]


;

;

CREATE TABLE [dbo].[Usuario](
	[ID_Usu] [int] NOT NULL,
	[Nombre_Usu] [varchar](50) NOT NULL,
	[FechaNac_Usu] [date] NOT NULL,
	[Contraseña_Usu] [varchar](50) NOT NULL,
	[ID_Familia] [int] NOT NULL,
 CONSTRAINT [PK_Usuario] PRIMARY KEY CLUSTERED 
(
	[ID_Usu] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

USE [ProyectoCampo]
Begin try
INSERT [dbo].[Familia] ([ID_Familia], [Nombre_Familia]) VALUES (1, N'Administrador')
INSERT [dbo].[Familia] ([ID_Familia], [Nombre_Familia]) VALUES (2, N'Invitado')
INSERT [dbo].[Familia] ([ID_Familia], [Nombre_Familia]) VALUES (3, N'Prueba')
INSERT [dbo].[FamiliaGrupoPatente] ([ID_FamGrppat], [ID_Fam], [ID_Grppat]) VALUES (1, 1, 1)
INSERT [dbo].[FamiliaGrupoPatente] ([ID_FamGrppat], [ID_Fam], [ID_Grppat]) VALUES (2, 1, 2)
INSERT [dbo].[FamiliaGrupoPatente] ([ID_FamGrppat], [ID_Fam], [ID_Grppat]) VALUES (3, 2, 2)
INSERT [dbo].[FamiliaGrupoPatente] ([ID_FamGrppat], [ID_Fam], [ID_Grppat]) VALUES (4, 3, 1)
INSERT [dbo].[FamiliaGrupoPatente] ([ID_FamGrppat], [ID_Fam], [ID_Grppat]) VALUES (5, 3, 2)
INSERT [dbo].[FamiliaPatente] ([ID_Fampat], [ID_Fam], [ID_Pat]) VALUES (1, 1, 3)
INSERT [dbo].[FamiliaPatente] ([ID_Fampat], [ID_Fam], [ID_Pat]) VALUES (2, 1, 1)
INSERT [dbo].[FamiliaPatente] ([ID_Fampat], [ID_Fam], [ID_Pat]) VALUES (3, 1, 2)
INSERT [dbo].[FamiliaPatente] ([ID_Fampat], [ID_Fam], [ID_Pat]) VALUES (4, 2, 3)
INSERT [dbo].[FamiliaPatente] ([ID_Fampat], [ID_Fam], [ID_Pat]) VALUES (5, 3, 3)
INSERT [dbo].[FamiliaPatente] ([ID_Fampat], [ID_Fam], [ID_Pat]) VALUES (6, 3, 5)
INSERT [dbo].[FamiliaPatente] ([ID_Fampat], [ID_Fam], [ID_Pat]) VALUES (7, 3, 1)
INSERT [dbo].[FamiliaPatente] ([ID_Fampat], [ID_Fam], [ID_Pat]) VALUES (8, 3, 2)
INSERT [dbo].[FamiliaPatente] ([ID_Fampat], [ID_Fam], [ID_Pat]) VALUES (9, 3, 4)
INSERT [dbo].[GrupoPatente] ([ID_Grppat], [Nombre_Grppat], [ID_Padre]) VALUES (1, N'Sistema', 0)
INSERT [dbo].[GrupoPatente] ([ID_Grppat], [Nombre_Grppat], [ID_Padre]) VALUES (2, N'Hola', 1)
INSERT [dbo].[Patente] ([ID_Patente], [Nombre_Patente], [Form_Patente], [ID_Grppat]) VALUES (1, N'Usuarios', N'CampoProyecto.FormRegistro', N'1         ')
INSERT [dbo].[Patente] ([ID_Patente], [Nombre_Patente], [Form_Patente], [ID_Grppat]) VALUES (2, N'Patentes', N'CampoProyecto.FormPatentes', N'1         ')
INSERT [dbo].[Patente] ([ID_Patente], [Nombre_Patente], [Form_Patente], [ID_Grppat]) VALUES (3, N'fami', N'CampoProyecto.FormFamilia', N'2         ')
INSERT [dbo].[Patente] ([ID_Patente], [Nombre_Patente], [Form_Patente], [ID_Grppat]) VALUES (4, N'NOSE', N'CampoProyecto.FormRegistro', N'1         ')
INSERT [dbo].[Patente] ([ID_Patente], [Nombre_Patente], [Form_Patente], [ID_Grppat]) VALUES (5, N'ESO', N'CampoProyecto.FormPatentesDialog', N'2         ')
INSERT [dbo].[Usuario] ([ID_Usu], [Nombre_Usu], [FechaNac_Usu], [Contraseña_Usu], [ID_Familia]) VALUES (1, N'Ezequiel', CAST(0xC73C0B00 AS Date), N'1234', 1)

End try
Begin catch
End catch;

;