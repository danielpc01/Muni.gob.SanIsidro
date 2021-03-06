USE [master]
GO
/****** Object:  Database [UPC_MUNI]    Script Date: 26/08/2015 01:50:32 a.m. ******/
CREATE DATABASE [UPC_MUNI]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'UPC_MUNI', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\UPC_MUNI.mdf' , SIZE = 4160KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'UPC_MUNI_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\UPC_MUNI_log.ldf' , SIZE = 1040KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [UPC_MUNI] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [UPC_MUNI].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [UPC_MUNI] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [UPC_MUNI] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [UPC_MUNI] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [UPC_MUNI] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [UPC_MUNI] SET ARITHABORT OFF 
GO
ALTER DATABASE [UPC_MUNI] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [UPC_MUNI] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [UPC_MUNI] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [UPC_MUNI] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [UPC_MUNI] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [UPC_MUNI] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [UPC_MUNI] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [UPC_MUNI] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [UPC_MUNI] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [UPC_MUNI] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [UPC_MUNI] SET  ENABLE_BROKER 
GO
ALTER DATABASE [UPC_MUNI] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [UPC_MUNI] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [UPC_MUNI] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [UPC_MUNI] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [UPC_MUNI] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [UPC_MUNI] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [UPC_MUNI] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [UPC_MUNI] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [UPC_MUNI] SET  MULTI_USER 
GO
ALTER DATABASE [UPC_MUNI] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [UPC_MUNI] SET DB_CHAINING OFF 
GO
ALTER DATABASE [UPC_MUNI] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [UPC_MUNI] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [UPC_MUNI]
GO
/****** Object:  Schema [ControlPatrimonial]    Script Date: 26/08/2015 01:50:32 a.m. ******/
CREATE SCHEMA [ControlPatrimonial]
GO
/****** Object:  Schema [General]    Script Date: 26/08/2015 01:50:32 a.m. ******/
CREATE SCHEMA [General]
GO
/****** Object:  Schema [TesoreriaFinanzas]    Script Date: 26/08/2015 01:50:32 a.m. ******/
CREATE SCHEMA [TesoreriaFinanzas]
GO
/****** Object:  Schema [Transparencia]    Script Date: 26/08/2015 01:50:32 a.m. ******/
CREATE SCHEMA [Transparencia]
GO
/****** Object:  Table [ControlPatrimonial].[AsignacionBienMueble]    Script Date: 26/08/2015 01:50:32 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING OFF
GO
CREATE TABLE [ControlPatrimonial].[AsignacionBienMueble](
	[IdAsignacion] [int] IDENTITY(1,1) NOT NULL,
	[IdSolicitudAsignacion] [int] NOT NULL,
	[IdUsuarioTrabajador] [int] NOT NULL,
	[IdBienMueble] [int] NOT NULL,
	[Cantidad] [int] NOT NULL,
	[FechaAsignacion] [datetime] NOT NULL,
	[UsuRegistro] [varchar](15) NOT NULL,
	[FechaRegistro] [datetime] NOT NULL,
	[UsuModifica] [varchar](15) NULL,
	[FechaModifica] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdAsignacion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [ControlPatrimonial].[BienMueble]    Script Date: 26/08/2015 01:50:32 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [ControlPatrimonial].[BienMueble](
	[IdBienMueble] [int] IDENTITY(1,1) NOT NULL,
	[IdEstado] [int] NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[UsuRegistro] [varchar](15) NOT NULL,
	[FechaRegistro] [datetime] NOT NULL,
	[UsuModifica] [varchar](15) NULL,
	[FechaModifica] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdBienMueble] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [ControlPatrimonial].[Estado]    Script Date: 26/08/2015 01:50:32 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [ControlPatrimonial].[Estado](
	[IdEstado] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [varchar](50) NOT NULL,
	[Activo] [bit] NOT NULL,
	[UsuRegistro] [varchar](15) NOT NULL,
	[FechaRegistro] [datetime] NOT NULL,
	[UsuModifica] [varchar](15) NULL,
	[FechaModifica] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdEstado] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [ControlPatrimonial].[SolicitudAsignacionBienMueble]    Script Date: 26/08/2015 01:50:32 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING OFF
GO
CREATE TABLE [ControlPatrimonial].[SolicitudAsignacionBienMueble](
	[IdSolicitudAsignacion] [int] IDENTITY(1,1) NOT NULL,
	[IdEstado] [int] NOT NULL,
	[IdArea] [int] NOT NULL,
	[NroSolicitudAsignacion] [int] NOT NULL,
	[FechaSolicitudAsignacion] [datetime] NOT NULL,
	[IdUsuarioTrabajador] [int] NOT NULL,
	[UsuRegistro] [varchar](15) NOT NULL,
	[FechaRegistro] [datetime] NOT NULL,
	[UsuModifica] [varchar](15) NULL,
	[FechaModifica] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdSolicitudAsignacion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [ControlPatrimonial].[UsuarioTrabajador]    Script Date: 26/08/2015 01:50:32 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [ControlPatrimonial].[UsuarioTrabajador](
	[IdUsuarioTrabajador] [int] IDENTITY(1,1) NOT NULL,
	[IdArea] [int] NOT NULL,
	[IdCargo] [int] NOT NULL,
	[IdEstado] [int] NOT NULL,
	[Nombre] [varchar](100) NOT NULL,
	[ApePaterno] [varchar](50) NOT NULL,
	[ApeMaterno] [varchar](50) NULL,
	[IdDocumento] [int] NOT NULL,
	[NroDocumento] [varchar](50) NOT NULL,
	[FechaNacimiento] [datetime] NOT NULL,
	[FechaIngreso] [datetime] NOT NULL,
	[FechaCese] [datetime] NULL,
	[UsuRegistro] [varchar](15) NOT NULL,
	[FechaRegistro] [datetime] NOT NULL,
	[UsuModifica] [varchar](15) NULL,
	[FechaModifica] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdUsuarioTrabajador] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [General].[Area]    Script Date: 26/08/2015 01:50:32 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [General].[Area](
	[IdArea] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[Activo] [bit] NOT NULL,
	[UsuRegistro] [varchar](15) NOT NULL,
	[FechaRegistro] [datetime] NOT NULL,
	[UsuModifica] [varchar](15) NULL,
	[FechaModifica] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdArea] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [General].[Cargo]    Script Date: 26/08/2015 01:50:32 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [General].[Cargo](
	[IdCargo] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[Activo] [bit] NOT NULL,
	[UsuRegistro] [varchar](15) NOT NULL,
	[FechaRegistro] [datetime] NOT NULL,
	[UsuModifica] [varchar](15) NULL,
	[FechaModifica] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdCargo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [General].[GrupoTabla]    Script Date: 26/08/2015 01:50:32 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [General].[GrupoTabla](
	[IdGrupo] [varchar](4) NOT NULL,
	[NombreGrupo] [varchar](100) NULL,
	[Estado] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdGrupo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [General].[Multitabla]    Script Date: 26/08/2015 01:50:32 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [General].[Multitabla](
	[IdMultitabla] [varchar](7) NOT NULL,
	[IdGrupo] [varchar](4) NULL,
	[NombreValor] [varchar](150) NULL,
	[DescripcionLarga] [varchar](100) NULL,
	[Estado] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdMultitabla] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [TesoreriaFinanzas].[ConceptoPago]    Script Date: 26/08/2015 01:50:32 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [TesoreriaFinanzas].[ConceptoPago](
	[Codigo] [bigint] IDENTITY(1,1) NOT NULL,
	[Descripcion] [varchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[Codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [TesoreriaFinanzas].[ConceptoRecibo]    Script Date: 26/08/2015 01:50:32 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING OFF
GO
CREATE TABLE [TesoreriaFinanzas].[ConceptoRecibo](
	[Codigo] [bigint] IDENTITY(1,1) NOT NULL,
	[Descripcion] [varchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[Codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [TesoreriaFinanzas].[Contribuyente]    Script Date: 26/08/2015 01:50:32 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [TesoreriaFinanzas].[Contribuyente](
	[CodContribuyente] [bigint] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](200) NULL,
	[CodTipoDocumento] [varchar](7) NULL,
	[NumDocumento] [varchar](20) NULL,
	[Direccion] [varchar](200) NULL,
	[TelefonoFijo] [varchar](20) NULL,
	[TelefonoMovil] [varchar](20) NULL,
	[FechaCreacion] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[CodContribuyente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [TesoreriaFinanzas].[FormaPago]    Script Date: 26/08/2015 01:50:32 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [TesoreriaFinanzas].[FormaPago](
	[Codigo] [bigint] IDENTITY(1,1) NOT NULL,
	[Descripcion] [varchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[Codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [TesoreriaFinanzas].[MovimientoCajaChica]    Script Date: 26/08/2015 01:50:32 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING OFF
GO
CREATE TABLE [TesoreriaFinanzas].[MovimientoCajaChica](
	[CodigoMovimiento] [bigint] IDENTITY(1,1) NOT NULL,
	[FechaCreacion] [datetime] NULL,
	[FechaActualizacion] [datetime] NULL,
	[MontoMovimiento] [decimal](18, 0) NULL,
	[CodTipoMovimiento] [varchar](7) NULL,
	[CodOrigenMovimiento] [varchar](7) NULL,
PRIMARY KEY CLUSTERED 
(
	[CodigoMovimiento] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [TesoreriaFinanzas].[PagoServicio]    Script Date: 26/08/2015 01:50:32 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [TesoreriaFinanzas].[PagoServicio](
	[NumeroPago] [bigint] IDENTITY(1,1) NOT NULL,
	[NumSolicitudPago] [bigint] NULL,
	[CodFormaPago] [bigint] NULL,
	[CodTipoCambio] [bigint] NULL,
	[CodMonedaPago] [varchar](7) NULL,
	[MontoPago] [decimal](10, 3) NULL,
	[FechaPago] [datetime] NULL,
	[CodEstadoPago] [varchar](7) NULL,
PRIMARY KEY CLUSTERED 
(
	[NumeroPago] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [TesoreriaFinanzas].[ReciboProvisional]    Script Date: 26/08/2015 01:50:32 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING OFF
GO
CREATE TABLE [TesoreriaFinanzas].[ReciboProvisional](
	[NumeroRecibo] [bigint] IDENTITY(1,1) NOT NULL,
	[CodConceptoRecibo] [bigint] NULL,
	[Motivo] [varchar](200) NULL,
	[Monto] [decimal](18, 0) NULL,
	[FechaCreacion] [datetime] NULL,
	[FechaEnvio] [datetime] NULL,
	[CodEstado] [varchar](7) NULL,
	[CodTrabajador] [int] NULL,
	[MotivoRechazo] [varchar](200) NULL,
PRIMARY KEY CLUSTERED 
(
	[NumeroRecibo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [TesoreriaFinanzas].[SolicitudPagoServicio]    Script Date: 26/08/2015 01:50:32 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [TesoreriaFinanzas].[SolicitudPagoServicio](
	[NumSolicitudPago] [bigint] IDENTITY(1,1) NOT NULL,
	[CodContribuyente] [bigint] NULL,
	[FechaSolicitud] [datetime] NULL,
	[CodConceptoPago] [bigint] NULL,
	[Monto] [decimal](10, 3) NULL,
	[Motivo] [varchar](200) NULL,
	[CodEstadoSolicitud] [varchar](7) NULL,
PRIMARY KEY CLUSTERED 
(
	[NumSolicitudPago] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [TesoreriaFinanzas].[TipoCambio]    Script Date: 26/08/2015 01:50:32 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [TesoreriaFinanzas].[TipoCambio](
	[Codigo] [bigint] IDENTITY(1,1) NOT NULL,
	[CodMoneda] [varchar](7) NULL,
	[Fecha] [datetime] NULL,
	[Monto] [decimal](8, 4) NULL,
PRIMARY KEY CLUSTERED 
(
	[Codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [Transparencia].[Expediente]    Script Date: 26/08/2015 01:50:32 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING OFF
GO
CREATE TABLE [Transparencia].[Expediente](
	[NumeroExpediente] [bigint] IDENTITY(1,1) NOT NULL,
	[FechaExpediente] [datetime] NULL,
	[NumeroSolicitud] [bigint] NULL,
	[Tipo_Expediente] [varchar](7) NULL,
	[Asunto] [varchar](400) NULL,
	[Estado] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[NumeroExpediente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [Transparencia].[SolicitudInformacionMunicipal]    Script Date: 26/08/2015 01:50:32 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING OFF
GO
CREATE TABLE [Transparencia].[SolicitudInformacionMunicipal](
	[NumeroSolicitud] [bigint] IDENTITY(1,1) NOT NULL,
	[FechaSolicitud] [datetime] NULL,
	[NombresSolicitante] [varchar](100) NULL,
	[ApellidoPaternoSolicitante] [varchar](100) NULL,
	[ApellidoMaternoSolicitante] [varchar](100) NULL,
	[TipoDocumento] [varchar](7) NULL,
	[NumeroDocumento] [varchar](30) NULL,
	[Direccion] [varchar](70) NULL,
	[Telefono] [varchar](20) NULL,
	[Celular] [varchar](20) NULL,
	[Email] [varchar](60) NULL,
	[Modo_Envio] [varchar](40) NULL,
	[IdUsuarioTrabajador] [int] NULL,
	[Tipo_Informacion] [varchar](7) NULL,
	[Motivo_Solicitud] [varchar](150) NULL,
	[Observaciones] [varchar](300) NULL,
	[Estado] [varchar](7) NULL,
PRIMARY KEY CLUSTERED 
(
	[NumeroSolicitud] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [ControlPatrimonial].[BienMueble] ON 

INSERT [ControlPatrimonial].[BienMueble] ([IdBienMueble], [IdEstado], [Nombre], [UsuRegistro], [FechaRegistro], [UsuModifica], [FechaModifica]) VALUES (1, 1, N'Laptop TOSHIBA', N'ADMIN', CAST(N'2015-08-03 02:37:34.950' AS DateTime), NULL, NULL)
INSERT [ControlPatrimonial].[BienMueble] ([IdBienMueble], [IdEstado], [Nombre], [UsuRegistro], [FechaRegistro], [UsuModifica], [FechaModifica]) VALUES (2, 1, N'Smartphone SAMSUNG RPM', N'ADMIN', CAST(N'2015-08-03 02:37:34.950' AS DateTime), NULL, NULL)
INSERT [ControlPatrimonial].[BienMueble] ([IdBienMueble], [IdEstado], [Nombre], [UsuRegistro], [FechaRegistro], [UsuModifica], [FechaModifica]) VALUES (3, 1, N'Parlantes BOSS', N'ADMIN', CAST(N'2015-08-03 02:37:34.950' AS DateTime), NULL, NULL)
SET IDENTITY_INSERT [ControlPatrimonial].[BienMueble] OFF
SET IDENTITY_INSERT [ControlPatrimonial].[Estado] ON 

INSERT [ControlPatrimonial].[Estado] ([IdEstado], [Descripcion], [Activo], [UsuRegistro], [FechaRegistro], [UsuModifica], [FechaModifica]) VALUES (1, N'Registrado', 1, N'ADMIN', CAST(N'2015-08-03 02:37:34.937' AS DateTime), NULL, NULL)
INSERT [ControlPatrimonial].[Estado] ([IdEstado], [Descripcion], [Activo], [UsuRegistro], [FechaRegistro], [UsuModifica], [FechaModifica]) VALUES (2, N'Pendiente', 1, N'ADMIN', CAST(N'2015-08-03 02:37:34.937' AS DateTime), NULL, NULL)
INSERT [ControlPatrimonial].[Estado] ([IdEstado], [Descripcion], [Activo], [UsuRegistro], [FechaRegistro], [UsuModifica], [FechaModifica]) VALUES (3, N'Aprobado', 1, N'ADMIN', CAST(N'2015-08-03 02:37:34.937' AS DateTime), NULL, NULL)
INSERT [ControlPatrimonial].[Estado] ([IdEstado], [Descripcion], [Activo], [UsuRegistro], [FechaRegistro], [UsuModifica], [FechaModifica]) VALUES (4, N'Rechazado', 1, N'ADMIN', CAST(N'2015-08-03 02:37:34.937' AS DateTime), NULL, NULL)
INSERT [ControlPatrimonial].[Estado] ([IdEstado], [Descripcion], [Activo], [UsuRegistro], [FechaRegistro], [UsuModifica], [FechaModifica]) VALUES (5, N'En reparación', 1, N'ADMIN', CAST(N'2015-08-03 02:37:34.937' AS DateTime), NULL, NULL)
INSERT [ControlPatrimonial].[Estado] ([IdEstado], [Descripcion], [Activo], [UsuRegistro], [FechaRegistro], [UsuModifica], [FechaModifica]) VALUES (6, N'Anulado', 1, N'ADMIN', CAST(N'2015-08-03 02:37:34.937' AS DateTime), NULL, NULL)
SET IDENTITY_INSERT [ControlPatrimonial].[Estado] OFF
SET IDENTITY_INSERT [ControlPatrimonial].[UsuarioTrabajador] ON 

INSERT [ControlPatrimonial].[UsuarioTrabajador] ([IdUsuarioTrabajador], [IdArea], [IdCargo], [IdEstado], [Nombre], [ApePaterno], [ApeMaterno], [IdDocumento], [NroDocumento], [FechaNacimiento], [FechaIngreso], [FechaCese], [UsuRegistro], [FechaRegistro], [UsuModifica], [FechaModifica]) VALUES (1, 2, 1, 1, N'Juan', N'Perez', N'Sosa', 1, N'44599878', CAST(N'2015-08-03 02:37:35.000' AS DateTime), CAST(N'2015-08-03 02:37:35.000' AS DateTime), NULL, N'ADMIN', CAST(N'2015-08-03 02:37:35.000' AS DateTime), NULL, NULL)
INSERT [ControlPatrimonial].[UsuarioTrabajador] ([IdUsuarioTrabajador], [IdArea], [IdCargo], [IdEstado], [Nombre], [ApePaterno], [ApeMaterno], [IdDocumento], [NroDocumento], [FechaNacimiento], [FechaIngreso], [FechaCese], [UsuRegistro], [FechaRegistro], [UsuModifica], [FechaModifica]) VALUES (2, 2, 2, 1, N'Daniel', N'Ángeles', N'Luján', 1, N'78862309', CAST(N'2015-08-03 02:37:35.000' AS DateTime), CAST(N'2015-08-03 02:37:35.000' AS DateTime), NULL, N'ADMIN', CAST(N'2015-08-03 02:37:35.000' AS DateTime), NULL, NULL)
INSERT [ControlPatrimonial].[UsuarioTrabajador] ([IdUsuarioTrabajador], [IdArea], [IdCargo], [IdEstado], [Nombre], [ApePaterno], [ApeMaterno], [IdDocumento], [NroDocumento], [FechaNacimiento], [FechaIngreso], [FechaCese], [UsuRegistro], [FechaRegistro], [UsuModifica], [FechaModifica]) VALUES (3, 4, 1, 1, N'Johan', N'Asenjo', N'Duenas', 1, N'44003309', CAST(N'1985-08-08 00:00:00.000' AS DateTime), CAST(N'2014-08-03 00:00:00.000' AS DateTime), NULL, N'ADMIN', CAST(N'2015-08-05 00:00:00.000' AS DateTime), NULL, NULL)
INSERT [ControlPatrimonial].[UsuarioTrabajador] ([IdUsuarioTrabajador], [IdArea], [IdCargo], [IdEstado], [Nombre], [ApePaterno], [ApeMaterno], [IdDocumento], [NroDocumento], [FechaNacimiento], [FechaIngreso], [FechaCese], [UsuRegistro], [FechaRegistro], [UsuModifica], [FechaModifica]) VALUES (7, 4, 2, 1, N'Jonathan', N'Magina', N'Lazo', 1, N'44003310', CAST(N'1988-08-08 00:00:00.000' AS DateTime), CAST(N'2014-08-03 00:00:00.000' AS DateTime), NULL, N'ADMIN', CAST(N'2015-08-05 00:00:00.000' AS DateTime), NULL, NULL)
SET IDENTITY_INSERT [ControlPatrimonial].[UsuarioTrabajador] OFF
SET IDENTITY_INSERT [General].[Area] ON 

INSERT [General].[Area] ([IdArea], [Nombre], [Activo], [UsuRegistro], [FechaRegistro], [UsuModifica], [FechaModifica]) VALUES (1, N'Administración', 1, N'ADMIN', CAST(N'2015-08-03 02:37:34.913' AS DateTime), NULL, NULL)
INSERT [General].[Area] ([IdArea], [Nombre], [Activo], [UsuRegistro], [FechaRegistro], [UsuModifica], [FechaModifica]) VALUES (2, N'Control Patrimonial', 1, N'ADMIN', CAST(N'2015-08-03 02:37:34.913' AS DateTime), NULL, NULL)
INSERT [General].[Area] ([IdArea], [Nombre], [Activo], [UsuRegistro], [FechaRegistro], [UsuModifica], [FechaModifica]) VALUES (4, N'Gerencia de Administración y Finanzas', 1, N'ADMIN', CAST(N'2015-08-05 00:00:00.000' AS DateTime), NULL, NULL)
SET IDENTITY_INSERT [General].[Area] OFF
SET IDENTITY_INSERT [General].[Cargo] ON 

INSERT [General].[Cargo] ([IdCargo], [Nombre], [Activo], [UsuRegistro], [FechaRegistro], [UsuModifica], [FechaModifica]) VALUES (1, N'Jefe', 1, N'ADMIN', CAST(N'2015-08-03 02:37:34.927' AS DateTime), NULL, NULL)
INSERT [General].[Cargo] ([IdCargo], [Nombre], [Activo], [UsuRegistro], [FechaRegistro], [UsuModifica], [FechaModifica]) VALUES (2, N'Operario', 1, N'ADMIN', CAST(N'2015-08-03 02:37:34.927' AS DateTime), NULL, NULL)
INSERT [General].[Cargo] ([IdCargo], [Nombre], [Activo], [UsuRegistro], [FechaRegistro], [UsuModifica], [FechaModifica]) VALUES (3, N'Supervisor', 1, N'ADMIN', CAST(N'2015-08-03 02:37:34.927' AS DateTime), NULL, NULL)
SET IDENTITY_INSERT [General].[Cargo] OFF
INSERT [General].[GrupoTabla] ([IdGrupo], [NombreGrupo], [Estado]) VALUES (N'0001', N'Tipo de Documento', 1)
INSERT [General].[GrupoTabla] ([IdGrupo], [NombreGrupo], [Estado]) VALUES (N'0002', N'Tipo de Expediente', 1)
INSERT [General].[GrupoTabla] ([IdGrupo], [NombreGrupo], [Estado]) VALUES (N'0003', N'Tipo de Información Municipal', 1)
INSERT [General].[GrupoTabla] ([IdGrupo], [NombreGrupo], [Estado]) VALUES (N'0004', N'Modo de Envio', 1)
INSERT [General].[GrupoTabla] ([IdGrupo], [NombreGrupo], [Estado]) VALUES (N'0005', N'Estados de Solicitudes Municipales', 1)
INSERT [General].[GrupoTabla] ([IdGrupo], [NombreGrupo], [Estado]) VALUES (N'0006', N'Estados de Recibo Provsional', 1)
INSERT [General].[GrupoTabla] ([IdGrupo], [NombreGrupo], [Estado]) VALUES (N'0007', N'Tipo Movimiento Caja Chica', 1)
INSERT [General].[GrupoTabla] ([IdGrupo], [NombreGrupo], [Estado]) VALUES (N'0008', N'Origen Movimiento', 1)
INSERT [General].[GrupoTabla] ([IdGrupo], [NombreGrupo], [Estado]) VALUES (N'0009', N'Tipo de Moneda', 1)
INSERT [General].[GrupoTabla] ([IdGrupo], [NombreGrupo], [Estado]) VALUES (N'0010', N'Estado Solicitud Pago Servicio', 1)
INSERT [General].[GrupoTabla] ([IdGrupo], [NombreGrupo], [Estado]) VALUES (N'0011', N'Estado Pago Servicio', 1)
INSERT [General].[Multitabla] ([IdMultitabla], [IdGrupo], [NombreValor], [DescripcionLarga], [Estado]) VALUES (N'0001001', N'0001', N'DNI', N'Documento Nacional de Identidad', 1)
INSERT [General].[Multitabla] ([IdMultitabla], [IdGrupo], [NombreValor], [DescripcionLarga], [Estado]) VALUES (N'0001002', N'0001', N'RUC', N'Registro unico del Contribuyente', 1)
INSERT [General].[Multitabla] ([IdMultitabla], [IdGrupo], [NombreValor], [DescripcionLarga], [Estado]) VALUES (N'0001003', N'0001', N'CARNET DE EXTRANJERÍA', N'Carnet de Extranjeria', 1)
INSERT [General].[Multitabla] ([IdMultitabla], [IdGrupo], [NombreValor], [DescripcionLarga], [Estado]) VALUES (N'0002001', N'0002', N'Información Municipal', N'', 1)
INSERT [General].[Multitabla] ([IdMultitabla], [IdGrupo], [NombreValor], [DescripcionLarga], [Estado]) VALUES (N'0002002', N'0002', N'Información de Area', N'', 1)
INSERT [General].[Multitabla] ([IdMultitabla], [IdGrupo], [NombreValor], [DescripcionLarga], [Estado]) VALUES (N'0003001', N'0003', N'Presupuestos', N'', 1)
INSERT [General].[Multitabla] ([IdMultitabla], [IdGrupo], [NombreValor], [DescripcionLarga], [Estado]) VALUES (N'0003002', N'0003', N'Obras Públicas', N'', 1)
INSERT [General].[Multitabla] ([IdMultitabla], [IdGrupo], [NombreValor], [DescripcionLarga], [Estado]) VALUES (N'0003003', N'0003', N'Resoluciones', N'', 1)
INSERT [General].[Multitabla] ([IdMultitabla], [IdGrupo], [NombreValor], [DescripcionLarga], [Estado]) VALUES (N'0003004', N'0003', N'Educación', N'', 1)
INSERT [General].[Multitabla] ([IdMultitabla], [IdGrupo], [NombreValor], [DescripcionLarga], [Estado]) VALUES (N'0003005', N'0003', N'Catastro', N'', 1)
INSERT [General].[Multitabla] ([IdMultitabla], [IdGrupo], [NombreValor], [DescripcionLarga], [Estado]) VALUES (N'0004001', N'0004', N'Email', N'', 1)
INSERT [General].[Multitabla] ([IdMultitabla], [IdGrupo], [NombreValor], [DescripcionLarga], [Estado]) VALUES (N'0004002', N'0004', N'Fax', N'', 1)
INSERT [General].[Multitabla] ([IdMultitabla], [IdGrupo], [NombreValor], [DescripcionLarga], [Estado]) VALUES (N'0004003', N'0004', N'Courier', N'', 1)
INSERT [General].[Multitabla] ([IdMultitabla], [IdGrupo], [NombreValor], [DescripcionLarga], [Estado]) VALUES (N'0005001', N'0005', N'Pendiente', N'', 1)
INSERT [General].[Multitabla] ([IdMultitabla], [IdGrupo], [NombreValor], [DescripcionLarga], [Estado]) VALUES (N'0005002', N'0005', N'Asignada', N'', 1)
INSERT [General].[Multitabla] ([IdMultitabla], [IdGrupo], [NombreValor], [DescripcionLarga], [Estado]) VALUES (N'0005003', N'0005', N'Aprobada', N'', 1)
INSERT [General].[Multitabla] ([IdMultitabla], [IdGrupo], [NombreValor], [DescripcionLarga], [Estado]) VALUES (N'0005004', N'0005', N'Rechazada', N'', 1)
INSERT [General].[Multitabla] ([IdMultitabla], [IdGrupo], [NombreValor], [DescripcionLarga], [Estado]) VALUES (N'0005005', N'0005', N'Atendida', N'', 1)
INSERT [General].[Multitabla] ([IdMultitabla], [IdGrupo], [NombreValor], [DescripcionLarga], [Estado]) VALUES (N'0006001', N'0006', N'Aprobado', N'', 1)
INSERT [General].[Multitabla] ([IdMultitabla], [IdGrupo], [NombreValor], [DescripcionLarga], [Estado]) VALUES (N'0006002', N'0006', N'Rechazado', N'', 1)
INSERT [General].[Multitabla] ([IdMultitabla], [IdGrupo], [NombreValor], [DescripcionLarga], [Estado]) VALUES (N'0006003', N'0006', N'Pendiente', N'', 1)
INSERT [General].[Multitabla] ([IdMultitabla], [IdGrupo], [NombreValor], [DescripcionLarga], [Estado]) VALUES (N'0007001', N'0007', N'Apertura', N'', 1)
INSERT [General].[Multitabla] ([IdMultitabla], [IdGrupo], [NombreValor], [DescripcionLarga], [Estado]) VALUES (N'0007002', N'0007', N'Cierre', N'', 1)
INSERT [General].[Multitabla] ([IdMultitabla], [IdGrupo], [NombreValor], [DescripcionLarga], [Estado]) VALUES (N'0007003', N'0007', N'Salida', N'', 1)
INSERT [General].[Multitabla] ([IdMultitabla], [IdGrupo], [NombreValor], [DescripcionLarga], [Estado]) VALUES (N'0007004', N'0007', N'Ingreso', N'', 1)
INSERT [General].[Multitabla] ([IdMultitabla], [IdGrupo], [NombreValor], [DescripcionLarga], [Estado]) VALUES (N'0008001', N'0008', N'Recibo Provisional', N'', 1)
INSERT [General].[Multitabla] ([IdMultitabla], [IdGrupo], [NombreValor], [DescripcionLarga], [Estado]) VALUES (N'0009001', N'0009', N'S/. -Nuevos Soles', N'Nuevos Soles', 1)
INSERT [General].[Multitabla] ([IdMultitabla], [IdGrupo], [NombreValor], [DescripcionLarga], [Estado]) VALUES (N'0009002', N'0009', N'$ -Dolares Americanos', N'Dolares Americanos', 1)
INSERT [General].[Multitabla] ([IdMultitabla], [IdGrupo], [NombreValor], [DescripcionLarga], [Estado]) VALUES (N'0009003', N'0009', N'€ - Euros', N'Euros', 0)
INSERT [General].[Multitabla] ([IdMultitabla], [IdGrupo], [NombreValor], [DescripcionLarga], [Estado]) VALUES (N'0009004', N'0009', N'£ - Libras Esterlinas', N'Libras Esterlinas', 0)
INSERT [General].[Multitabla] ([IdMultitabla], [IdGrupo], [NombreValor], [DescripcionLarga], [Estado]) VALUES (N'0010001', N'0010', N'Pendiente', N'', 1)
INSERT [General].[Multitabla] ([IdMultitabla], [IdGrupo], [NombreValor], [DescripcionLarga], [Estado]) VALUES (N'0010002', N'0010', N'Pagado', N'', 1)
INSERT [General].[Multitabla] ([IdMultitabla], [IdGrupo], [NombreValor], [DescripcionLarga], [Estado]) VALUES (N'0010003', N'0010', N'Anulado', N'', 1)
INSERT [General].[Multitabla] ([IdMultitabla], [IdGrupo], [NombreValor], [DescripcionLarga], [Estado]) VALUES (N'0011001', N'0011', N'Registrado', N'', 1)
INSERT [General].[Multitabla] ([IdMultitabla], [IdGrupo], [NombreValor], [DescripcionLarga], [Estado]) VALUES (N'0011002', N'0011', N'Extornado', N'', 1)
SET IDENTITY_INSERT [TesoreriaFinanzas].[ConceptoPago] ON 

INSERT [TesoreriaFinanzas].[ConceptoPago] ([Codigo], [Descripcion]) VALUES (1, N'Deuda Tributaria')
INSERT [TesoreriaFinanzas].[ConceptoPago] ([Codigo], [Descripcion]) VALUES (2, N'Sevicio Municipal')
SET IDENTITY_INSERT [TesoreriaFinanzas].[ConceptoPago] OFF
SET IDENTITY_INSERT [TesoreriaFinanzas].[ConceptoRecibo] ON 

INSERT [TesoreriaFinanzas].[ConceptoRecibo] ([Codigo], [Descripcion]) VALUES (1, N'ALIMENTOS')
INSERT [TesoreriaFinanzas].[ConceptoRecibo] ([Codigo], [Descripcion]) VALUES (2, N'REPUESTOS IMPRESORA')
INSERT [TesoreriaFinanzas].[ConceptoRecibo] ([Codigo], [Descripcion]) VALUES (3, N'MOVILIDAD')
SET IDENTITY_INSERT [TesoreriaFinanzas].[ConceptoRecibo] OFF
SET IDENTITY_INSERT [TesoreriaFinanzas].[Contribuyente] ON 

INSERT [TesoreriaFinanzas].[Contribuyente] ([CodContribuyente], [Nombre], [CodTipoDocumento], [NumDocumento], [Direccion], [TelefonoFijo], [TelefonoMovil], [FechaCreacion]) VALUES (1, N'Johan Asenjo', N'0001001', N'43430001', NULL, NULL, NULL, CAST(N'2015-08-03 06:30:00.240' AS DateTime))
SET IDENTITY_INSERT [TesoreriaFinanzas].[Contribuyente] OFF
SET IDENTITY_INSERT [TesoreriaFinanzas].[FormaPago] ON 

INSERT [TesoreriaFinanzas].[FormaPago] ([Codigo], [Descripcion]) VALUES (1, N'Efectivo')
INSERT [TesoreriaFinanzas].[FormaPago] ([Codigo], [Descripcion]) VALUES (2, N'Cheque')
SET IDENTITY_INSERT [TesoreriaFinanzas].[FormaPago] OFF
SET IDENTITY_INSERT [TesoreriaFinanzas].[MovimientoCajaChica] ON 

INSERT [TesoreriaFinanzas].[MovimientoCajaChica] ([CodigoMovimiento], [FechaCreacion], [FechaActualizacion], [MontoMovimiento], [CodTipoMovimiento], [CodOrigenMovimiento]) VALUES (1, CAST(N'2015-08-05 04:06:51.537' AS DateTime), CAST(N'2015-08-05 04:06:51.537' AS DateTime), CAST(30 AS Decimal(18, 0)), N'0007003', N'0008001')
INSERT [TesoreriaFinanzas].[MovimientoCajaChica] ([CodigoMovimiento], [FechaCreacion], [FechaActualizacion], [MontoMovimiento], [CodTipoMovimiento], [CodOrigenMovimiento]) VALUES (2, CAST(N'2015-08-05 04:52:36.273' AS DateTime), CAST(N'2015-08-05 04:52:36.273' AS DateTime), CAST(40 AS Decimal(18, 0)), N'0007003', N'0008001')
INSERT [TesoreriaFinanzas].[MovimientoCajaChica] ([CodigoMovimiento], [FechaCreacion], [FechaActualizacion], [MontoMovimiento], [CodTipoMovimiento], [CodOrigenMovimiento]) VALUES (3, CAST(N'2015-08-06 20:15:35.583' AS DateTime), CAST(N'2015-08-06 20:15:35.583' AS DateTime), CAST(30 AS Decimal(18, 0)), N'0007003', N'0008001')
INSERT [TesoreriaFinanzas].[MovimientoCajaChica] ([CodigoMovimiento], [FechaCreacion], [FechaActualizacion], [MontoMovimiento], [CodTipoMovimiento], [CodOrigenMovimiento]) VALUES (4, CAST(N'2015-08-25 23:42:20.117' AS DateTime), CAST(N'2015-08-25 23:42:20.120' AS DateTime), CAST(40 AS Decimal(18, 0)), N'0007003', N'0008001')
SET IDENTITY_INSERT [TesoreriaFinanzas].[MovimientoCajaChica] OFF
SET IDENTITY_INSERT [TesoreriaFinanzas].[PagoServicio] ON 

INSERT [TesoreriaFinanzas].[PagoServicio] ([NumeroPago], [NumSolicitudPago], [CodFormaPago], [CodTipoCambio], [CodMonedaPago], [MontoPago], [FechaPago], [CodEstadoPago]) VALUES (10, 1, 1, NULL, N'0009001', CAST(1000.500 AS Decimal(10, 3)), CAST(N'2015-08-06 20:22:30.143' AS DateTime), N'0011001')
SET IDENTITY_INSERT [TesoreriaFinanzas].[PagoServicio] OFF
SET IDENTITY_INSERT [TesoreriaFinanzas].[ReciboProvisional] ON 

INSERT [TesoreriaFinanzas].[ReciboProvisional] ([NumeroRecibo], [CodConceptoRecibo], [Motivo], [Monto], [FechaCreacion], [FechaEnvio], [CodEstado], [CodTrabajador], [MotivoRechazo]) VALUES (1, 1, N'monto invalido', CAST(20 AS Decimal(18, 0)), CAST(N'2015-08-03 02:37:35.080' AS DateTime), CAST(N'2015-08-03 02:37:35.080' AS DateTime), N'0006002', 3, NULL)
INSERT [TesoreriaFinanzas].[ReciboProvisional] ([NumeroRecibo], [CodConceptoRecibo], [Motivo], [Monto], [FechaCreacion], [FechaEnvio], [CodEstado], [CodTrabajador], [MotivoRechazo]) VALUES (2, 2, NULL, CAST(30 AS Decimal(18, 0)), CAST(N'2015-08-03 02:37:35.103' AS DateTime), CAST(N'2015-08-03 02:37:35.103' AS DateTime), N'0006001', 3, NULL)
INSERT [TesoreriaFinanzas].[ReciboProvisional] ([NumeroRecibo], [CodConceptoRecibo], [Motivo], [Monto], [FechaCreacion], [FechaEnvio], [CodEstado], [CodTrabajador], [MotivoRechazo]) VALUES (3, 2, NULL, CAST(40 AS Decimal(18, 0)), CAST(N'2015-08-03 02:37:35.107' AS DateTime), CAST(N'2015-08-03 02:37:35.107' AS DateTime), N'0006001', 7, NULL)
INSERT [TesoreriaFinanzas].[ReciboProvisional] ([NumeroRecibo], [CodConceptoRecibo], [Motivo], [Monto], [FechaCreacion], [FechaEnvio], [CodEstado], [CodTrabajador], [MotivoRechazo]) VALUES (4, 3, NULL, CAST(50 AS Decimal(18, 0)), CAST(N'2015-08-03 02:37:35.107' AS DateTime), CAST(N'2015-08-03 02:37:35.107' AS DateTime), N'0006003', 7, NULL)
INSERT [TesoreriaFinanzas].[ReciboProvisional] ([NumeroRecibo], [CodConceptoRecibo], [Motivo], [Monto], [FechaCreacion], [FechaEnvio], [CodEstado], [CodTrabajador], [MotivoRechazo]) VALUES (5, 3, NULL, CAST(40 AS Decimal(18, 0)), CAST(N'2015-08-03 02:37:35.113' AS DateTime), CAST(N'2015-08-03 02:37:35.113' AS DateTime), N'0006003', 7, NULL)
SET IDENTITY_INSERT [TesoreriaFinanzas].[ReciboProvisional] OFF
SET IDENTITY_INSERT [TesoreriaFinanzas].[SolicitudPagoServicio] ON 

INSERT [TesoreriaFinanzas].[SolicitudPagoServicio] ([NumSolicitudPago], [CodContribuyente], [FechaSolicitud], [CodConceptoPago], [Monto], [Motivo], [CodEstadoSolicitud]) VALUES (1, 1, CAST(N'2015-08-03 06:52:04.843' AS DateTime), 1, CAST(1000.500 AS Decimal(10, 3)), N'PAGOS ATRASADOS', N'0010002')
INSERT [TesoreriaFinanzas].[SolicitudPagoServicio] ([NumSolicitudPago], [CodContribuyente], [FechaSolicitud], [CodConceptoPago], [Monto], [Motivo], [CodEstadoSolicitud]) VALUES (2, 1, CAST(N'2015-08-03 06:52:04.867' AS DateTime), 1, CAST(100.500 AS Decimal(10, 3)), N'PAGOS ATRASADOS', N'0010003')
INSERT [TesoreriaFinanzas].[SolicitudPagoServicio] ([NumSolicitudPago], [CodContribuyente], [FechaSolicitud], [CodConceptoPago], [Monto], [Motivo], [CodEstadoSolicitud]) VALUES (3, 1, CAST(N'2015-08-03 06:52:04.883' AS DateTime), 2, CAST(100.500 AS Decimal(10, 3)), N'PERMISOS', N'0010001')
SET IDENTITY_INSERT [TesoreriaFinanzas].[SolicitudPagoServicio] OFF
SET IDENTITY_INSERT [TesoreriaFinanzas].[TipoCambio] ON 

INSERT [TesoreriaFinanzas].[TipoCambio] ([Codigo], [CodMoneda], [Fecha], [Monto]) VALUES (1, N'0009002', CAST(N'2015-08-03 06:43:36.640' AS DateTime), CAST(3.1950 AS Decimal(8, 4)))
INSERT [TesoreriaFinanzas].[TipoCambio] ([Codigo], [CodMoneda], [Fecha], [Monto]) VALUES (2, N'0009003', CAST(N'2015-08-03 06:43:36.647' AS DateTime), CAST(3.5013 AS Decimal(8, 4)))
SET IDENTITY_INSERT [TesoreriaFinanzas].[TipoCambio] OFF
ALTER TABLE [ControlPatrimonial].[AsignacionBienMueble]  WITH CHECK ADD FOREIGN KEY([IdBienMueble])
REFERENCES [ControlPatrimonial].[BienMueble] ([IdBienMueble])
GO
ALTER TABLE [ControlPatrimonial].[AsignacionBienMueble]  WITH CHECK ADD FOREIGN KEY([IdSolicitudAsignacion])
REFERENCES [ControlPatrimonial].[SolicitudAsignacionBienMueble] ([IdSolicitudAsignacion])
GO
ALTER TABLE [ControlPatrimonial].[AsignacionBienMueble]  WITH CHECK ADD FOREIGN KEY([IdUsuarioTrabajador])
REFERENCES [ControlPatrimonial].[UsuarioTrabajador] ([IdUsuarioTrabajador])
GO
ALTER TABLE [ControlPatrimonial].[BienMueble]  WITH CHECK ADD FOREIGN KEY([IdEstado])
REFERENCES [ControlPatrimonial].[Estado] ([IdEstado])
GO
ALTER TABLE [ControlPatrimonial].[SolicitudAsignacionBienMueble]  WITH CHECK ADD FOREIGN KEY([IdArea])
REFERENCES [General].[Area] ([IdArea])
GO
ALTER TABLE [ControlPatrimonial].[SolicitudAsignacionBienMueble]  WITH CHECK ADD FOREIGN KEY([IdEstado])
REFERENCES [ControlPatrimonial].[Estado] ([IdEstado])
GO
ALTER TABLE [ControlPatrimonial].[UsuarioTrabajador]  WITH CHECK ADD FOREIGN KEY([IdArea])
REFERENCES [General].[Area] ([IdArea])
GO
ALTER TABLE [ControlPatrimonial].[UsuarioTrabajador]  WITH CHECK ADD FOREIGN KEY([IdCargo])
REFERENCES [General].[Cargo] ([IdCargo])
GO
ALTER TABLE [ControlPatrimonial].[UsuarioTrabajador]  WITH CHECK ADD FOREIGN KEY([IdEstado])
REFERENCES [ControlPatrimonial].[Estado] ([IdEstado])
GO
ALTER TABLE [General].[Multitabla]  WITH CHECK ADD FOREIGN KEY([IdGrupo])
REFERENCES [General].[GrupoTabla] ([IdGrupo])
GO
ALTER TABLE [TesoreriaFinanzas].[Contribuyente]  WITH CHECK ADD FOREIGN KEY([CodTipoDocumento])
REFERENCES [General].[Multitabla] ([IdMultitabla])
GO
ALTER TABLE [TesoreriaFinanzas].[MovimientoCajaChica]  WITH CHECK ADD FOREIGN KEY([CodOrigenMovimiento])
REFERENCES [General].[Multitabla] ([IdMultitabla])
GO
ALTER TABLE [TesoreriaFinanzas].[MovimientoCajaChica]  WITH CHECK ADD FOREIGN KEY([CodTipoMovimiento])
REFERENCES [General].[Multitabla] ([IdMultitabla])
GO
ALTER TABLE [TesoreriaFinanzas].[PagoServicio]  WITH CHECK ADD FOREIGN KEY([CodEstadoPago])
REFERENCES [General].[Multitabla] ([IdMultitabla])
GO
ALTER TABLE [TesoreriaFinanzas].[PagoServicio]  WITH CHECK ADD FOREIGN KEY([CodFormaPago])
REFERENCES [TesoreriaFinanzas].[FormaPago] ([Codigo])
GO
ALTER TABLE [TesoreriaFinanzas].[PagoServicio]  WITH CHECK ADD FOREIGN KEY([CodMonedaPago])
REFERENCES [General].[Multitabla] ([IdMultitabla])
GO
ALTER TABLE [TesoreriaFinanzas].[PagoServicio]  WITH CHECK ADD FOREIGN KEY([CodTipoCambio])
REFERENCES [TesoreriaFinanzas].[TipoCambio] ([Codigo])
GO
ALTER TABLE [TesoreriaFinanzas].[PagoServicio]  WITH CHECK ADD FOREIGN KEY([NumSolicitudPago])
REFERENCES [TesoreriaFinanzas].[SolicitudPagoServicio] ([NumSolicitudPago])
GO
ALTER TABLE [TesoreriaFinanzas].[ReciboProvisional]  WITH CHECK ADD FOREIGN KEY([CodConceptoRecibo])
REFERENCES [TesoreriaFinanzas].[ConceptoRecibo] ([Codigo])
GO
ALTER TABLE [TesoreriaFinanzas].[ReciboProvisional]  WITH CHECK ADD FOREIGN KEY([CodEstado])
REFERENCES [General].[Multitabla] ([IdMultitabla])
GO
ALTER TABLE [TesoreriaFinanzas].[ReciboProvisional]  WITH CHECK ADD FOREIGN KEY([CodTrabajador])
REFERENCES [ControlPatrimonial].[UsuarioTrabajador] ([IdUsuarioTrabajador])
GO
ALTER TABLE [TesoreriaFinanzas].[SolicitudPagoServicio]  WITH CHECK ADD FOREIGN KEY([CodContribuyente])
REFERENCES [TesoreriaFinanzas].[Contribuyente] ([CodContribuyente])
GO
ALTER TABLE [TesoreriaFinanzas].[SolicitudPagoServicio]  WITH CHECK ADD FOREIGN KEY([CodConceptoPago])
REFERENCES [TesoreriaFinanzas].[ConceptoPago] ([Codigo])
GO
ALTER TABLE [TesoreriaFinanzas].[SolicitudPagoServicio]  WITH CHECK ADD FOREIGN KEY([CodEstadoSolicitud])
REFERENCES [General].[Multitabla] ([IdMultitabla])
GO
ALTER TABLE [TesoreriaFinanzas].[TipoCambio]  WITH CHECK ADD FOREIGN KEY([CodMoneda])
REFERENCES [General].[Multitabla] ([IdMultitabla])
GO
ALTER TABLE [Transparencia].[Expediente]  WITH CHECK ADD FOREIGN KEY([NumeroSolicitud])
REFERENCES [Transparencia].[SolicitudInformacionMunicipal] ([NumeroSolicitud])
GO
ALTER TABLE [Transparencia].[Expediente]  WITH CHECK ADD FOREIGN KEY([Tipo_Expediente])
REFERENCES [General].[Multitabla] ([IdMultitabla])
GO
ALTER TABLE [Transparencia].[SolicitudInformacionMunicipal]  WITH CHECK ADD FOREIGN KEY([Estado])
REFERENCES [General].[Multitabla] ([IdMultitabla])
GO
ALTER TABLE [Transparencia].[SolicitudInformacionMunicipal]  WITH CHECK ADD FOREIGN KEY([IdUsuarioTrabajador])
REFERENCES [ControlPatrimonial].[UsuarioTrabajador] ([IdUsuarioTrabajador])
GO
ALTER TABLE [Transparencia].[SolicitudInformacionMunicipal]  WITH CHECK ADD FOREIGN KEY([TipoDocumento])
REFERENCES [General].[Multitabla] ([IdMultitabla])
GO
USE [master]
GO
ALTER DATABASE [UPC_MUNI] SET  READ_WRITE 
GO
