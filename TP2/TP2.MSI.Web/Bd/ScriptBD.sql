
create database UPC_MUNI

go

use UPC_MUNI

go


create schema Transparencia

go

create table Transparencia.SolicitudInformacionMunicipal(NumeroSolicitud bigint identity(1,1) primary key,
														 FechaSolicitud datetime,
														 NombresSolicitante varchar(100),
														 ApellidoPaternoSolicitante varchar(100),
														 ApellidoMaternoSolicitante varchar(100)
														 )

create table Transparencia.Expediente(NumeroExpediente bigint identity(1,1) primary key ,
									  FechaExpediente datetime,
									  NumeroSolicitud bigint foreign key references Transparencia.SolicitudInformacionMunicipal(NumeroSolicitud),
									  Observaciones varchar(400),
									  Especificaciones_Tecnicar varchar(400),
									  Estado int
									  )


go

create schema General

go

create table General.GrupoTabla (IdGrupo varchar(4) primary key,
						         NombreGrupo varchar(100),
						         Estado int)

go

create table General.Multitabla (IdMultitabla varchar(7) primary key,
								 IdGrupo varchar(4) foreign key references General.GrupoTabla(IdGrupo),
								 NombreValor varchar(150),
								 DescripcionLarga varchar(100),
								 Estado int)

go


insert into General.GrupoTabla values('0001','Tipo de Documento',1)

insert into General.Multitabla values('0001001','0001','DNI','Documento Nacional de Identidad',1)
go
insert into General.Multitabla values('0001002','0001','RUC','Registro unico del Contribuyente',1)
go
insert into General.Multitabla values('0001003','0001','CARNET DE EXTRANJERÍA','Carnet de Extranjeria',1)
go


