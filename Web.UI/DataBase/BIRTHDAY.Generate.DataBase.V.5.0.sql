-- CREACION DE BASE DE DATOS
CREATE database BIRTHDATA
GO

USE BIRTHDATA
GO

-- CREACION DE ESQUEMAS
CREATE SCHEMA Perfil
GO

CREATE SCHEMA Muro
GO

-- CREACION DE TABLAS

-- TABLE: CategoriaUsuario
-- Almacena datos para el nivel de acceso en el Aplicativo ejemplo (Usuario Invitado/ Administrador)
CREATE TABLE Perfil.CategoriaUsuario(
	id int IDENTITY(1,1) PRIMARY KEY,
	gls_categoria varchar(200) NOT NULL,
	estado char(1) NULL,
	aud_usr_ingreso varchar(24) NULL,
	aud_fec_ingreso datetime NULL,
	aud_usr_modificacion varchar(24) NULL,
	aud_fec_modificacion datetime NULL)
GO

-- TABLE: Usuario
-- Almacena la lista de Usuarios que ingresaran al aplicativo
CREATE TABLE Perfil.Usuario(
	id int IDENTITY(1,1) PRIMARY KEY,
	gls_nombre varchar(20) NULL,
	gls_ape_paterno varchar(30) NULL,
	gls_ape_materno varchar(30) NULL,
	correo varchar(50) NULL,
	anexo numeric(18, 0) NULL,
	fec_nacimiento datetime NULL,
	gls_usuario varchar(24) NULL,
	clave text NULL,
	idcargo int NULL,
	idarea int NULL,
	idempresa int NULL,
	idcategoria int NULL,
	guid_user varchar(128) NULL,
	estado char(1) NULL,
	aud_usr_ingreso varchar(24) NULL,
	aud_fec_ingreso datetime NULL,
	aud_usr_modificacion varchar(24) NULL,
	aud_fec_modificacion datetime NULL)

-- TABLE: Empresa
-- Almacena datos de las diferentes empresas que pueda pertenecer el colaborador(Usuario) ya que en una empresa puede haber gente outsourcing (externa)
CREATE TABLE Perfil.Empresa(
	id int IDENTITY(1,1) PRIMARY KEY,
	gls_empresa varchar(200) NOT NULL,
	estado char(1) NULL,
	aud_usr_ingreso varchar(24) NULL,
	aud_fec_ingreso datetime NULL,
	aud_usr_modificacion varchar(24) NULL,
	aud_fec_modificacion datetime NULL)
GO

-- TABLE: Area
-- Almacena datos de las diferentes areas que pueda pertenecer el colaborador(Usuario)
CREATE TABLE Perfil.Area(
	id int IDENTITY(1,1) PRIMARY KEY,
	gls_area varchar(200) NOT NULL,
	estado char(1) NULL,
	aud_usr_ingreso varchar(24) NULL,
	aud_fec_ingreso datetime NULL,
	aud_usr_modificacion varchar(24) NULL,
	aud_fec_modificacion datetime NULL)
GO

-- TABLE: Cargo
-- Almacena datos de las diferentes cargos que pueda tener el colaborador(Usuario)
CREATE TABLE Perfil.Cargo(
	id int IDENTITY(1,1) PRIMARY KEY,
	gls_Cargo varchar(200) NOT NULL,
	estado char(1) NULL,
	aud_usr_ingreso varchar(24) NULL,
	aud_fec_ingreso datetime NULL,
	aud_usr_modificacion varchar(24) NULL,
	aud_fec_modificacion datetime NULL)
GO

-- TABLE: Mensajes
-- Almacena mensajes/saludos que se envien los colaboradores (usuarios)
CREATE TABLE Muro.Mensajes(
	id int IDENTITY(1,1) PRIMARY KEY,
	idusuariopara int NULL,
	idusuariode int NULL,
	gls_mensaje varchar(300) NULL,
	estado char(1) NULL,
	aud_usr_ingreso varchar(24) NULL,
	aud_fec_ingreso datetime NULL,
	aud_usr_modificacion varchar(24) NULL,
	aud_fec_modificacion datetime NULL)
GO

-- TABLE: Organizacion
-- Almacena la lista de responsables para coordinar quien se encargara del evento para un especifico dia (cumpleaños de un usuario en especifico)
CREATE TABLE Muro.Organizacion(
	id int IDENTITY(1,1) PRIMARY KEY,
	idusuario int NULL,
	idusuariorganiza int NULL,
	anio numeric(18, 0) NULL,
	estado char(1) NULL,
	aud_usr_ingreso varchar(24) NULL,
	aud_fec_ingreso datetime NULL,
	aud_usr_modificacion varchar(24) NULL,
	aud_fec_modificacion datetime NULL)
GO

-- CREACION DE RELACIONES (LLAVES FORANEAS)

--RELACION Usuario Categoria
ALTER TABLE Perfil.Usuario
ADD CONSTRAINT FK_Usuario_Categoria FOREIGN KEY (idcategoria)
	REFERENCES Perfil.CategoriaUsuario (id);
GO

--RELACION Usuario Cargo
ALTER TABLE Perfil.Usuario
ADD CONSTRAINT FK_Usuario_Cargo FOREIGN KEY (idcargo)
	REFERENCES Perfil.Cargo (id);
GO

--RELACION Usuario Empresa
ALTER TABLE Perfil.Usuario
ADD CONSTRAINT FK_Usuario_Empresa FOREIGN KEY (idempresa)
	REFERENCES Perfil.Empresa (id);
GO

--RELACION Usuario Area
ALTER TABLE Perfil.Usuario
ADD CONSTRAINT FK_Usuario_Area FOREIGN KEY (idarea)
	REFERENCES Perfil.Area (id);
GO

--RELACION Organizacion Usuario
ALTER TABLE Muro.Organizacion
ADD CONSTRAINT FK_Organizacion_Usuario FOREIGN KEY (idusuario)
	REFERENCES Perfil.Usuario (id);
GO

--RELACION Mensaje Usuario
ALTER TABLE Muro.Mensajes
ADD CONSTRAINT FK_Mensaje_Usuario FOREIGN KEY (idusuariopara)
	REFERENCES Perfil.Usuario (id);
GO

-- CREACION DE REGISTROS MODELOS

insert into Perfil.CategoriaUsuario(gls_categoria,estado,aud_usr_ingreso,aud_fec_ingreso) values('ADMINISTRADOR','1','vyucra',getdate())
insert into Perfil.CategoriaUsuario(gls_categoria,estado,aud_usr_ingreso,aud_fec_ingreso) values('INVITADO','1','vyucra',getdate())

GO

insert into Perfil.Area(gls_area, estado, aud_usr_ingreso, aud_fec_ingreso, aud_usr_modificacion, aud_fec_modificacion) values ('AREA INDEFINIDA', '1', 'vyucra', '2016-03-03 17:27:17', NULL, NULL)
insert into Perfil.Area(gls_area, estado, aud_usr_ingreso, aud_fec_ingreso, aud_usr_modificacion, aud_fec_modificacion) values ('OPERACIONES', '1', 'vyucra', '2016-03-03 17:27:17', NULL, NULL)
insert into Perfil.Area(gls_area, estado, aud_usr_ingreso, aud_fec_ingreso, aud_usr_modificacion, aud_fec_modificacion) values ('TECNOLOGIA DE LA INFORMACION', '1', 'vyucra', '2016-03-03 17:27:17', NULL, NULL)

GO



insert into Perfil.Cargo(gls_Cargo,estado,aud_usr_ingreso,aud_fec_ingreso) values ('ANALISTA DE QA','1','vyucra',getdate())
insert into Perfil.Cargo(gls_Cargo,estado,aud_usr_ingreso,aud_fec_ingreso) values ('ANALISTA DE SISTEMAS','1','vyucra',getdate())
insert into Perfil.Cargo(gls_Cargo,estado,aud_usr_ingreso,aud_fec_ingreso) values ('ANALISTA DE SOPORTE','1','vyucra',getdate())
insert into Perfil.Cargo(gls_Cargo,estado,aud_usr_ingreso,aud_fec_ingreso) values ('ANALISTA FUNCIONAL','1','vyucra',getdate())
insert into Perfil.Cargo(gls_Cargo,estado,aud_usr_ingreso,aud_fec_ingreso) values ('ASISTENTE DE MARKETING','1','vyucra',getdate())
insert into Perfil.Cargo(gls_Cargo,estado,aud_usr_ingreso,aud_fec_ingreso) values ('ASISTENTE DE MASIVOS Y COLECTIVOS','1','vyucra',getdate())
insert into Perfil.Cargo(gls_Cargo,estado,aud_usr_ingreso,aud_fec_ingreso) values ('GERENTE DE SISTEMAS','1','vyucra',getdate())
insert into Perfil.Cargo(gls_Cargo,estado,aud_usr_ingreso,aud_fec_ingreso) values ('JEFE DE DESARROLLO','1','vyucra',getdate())
insert into Perfil.Cargo(gls_Cargo,estado,aud_usr_ingreso,aud_fec_ingreso) values ('JEFE DE SOPORTE AL NEGOCIO','1','vyucra',getdate())
insert into Perfil.Cargo(gls_Cargo,estado,aud_usr_ingreso,aud_fec_ingreso) values ('OPERADOR DE SOPORTE','1','vyucra',getdate())

GO

insert into Perfil.Empresa(gls_empresa,estado,aud_usr_ingreso,aud_fec_ingreso) values('INTERNO','1','vyucra',getdate())
insert into Perfil.Empresa(gls_empresa,estado,aud_usr_ingreso,aud_fec_ingreso) values('EXTERNO','1','vyucra',getdate())

GO

-- GENERATE STORE PROCEDURE

-- exec Perfil.SP_GetUsuario 15
-- exec Muro.SP_ALLCumpleanios 2016

/********************************************************************************
Tabla : Muro.SP_ALLCumpleanios
Descripcion: Obtener lista de cumpleanios por ANIO
Creado Por: Victor Yucra
Fecha Creacion: 11/03/2016
********************************************************************************/
create procedure Muro.SP_Cumpleanios_Select
	@anio int
as
begin

	select 
		 mo.id
		,mo.idusuario
		,(pu.gls_nombre + ' ' + pu.gls_ape_paterno) as Cumpleaniero
		,mo.idusuariorganiza
		,(pd.gls_nombre + ' ' + pd.gls_ape_paterno) as organizador
		,mo.anio
		,mo.estado
	from Muro.Organizacion mo
	left join Perfil.Usuario pu on pu.id = mo.idusuario
	left join Perfil.Usuario pd on pd.id = mo.idusuariorganiza
	where anio = @anio

end
GO


/********************************************************************************
Tabla : Perfil.Usuario
Descripcion: Selecciona usuarios de la tabla Perfil.Usuario
Creado Por: Victor Yucra
Fecha Creacion: 11/03/2016
********************************************************************************/
create procedure Perfil.SP_Usuario_Obtener
	@guid_user varchar(128)
as
begin
	select
		 id
		,gls_nombre
		,gls_ape_paterno
		,gls_ape_materno
		,correo
		,anexo
		,fec_nacimiento
		,gls_usuario
		,idcargo
		,idarea
		,idempresa
		,idcategoria
		,estado
	from Perfil.Usuario
	where guid_user = @guid_user;
end
GO

/********************************************************************************
Tabla : Perfil.Usuario
Descripcion: Inserta usuarios en la tabla Perfil.Usuario
Creado Por: Victor Yucra
Fecha Creacion: 11/03/2016
********************************************************************************/
create procedure Perfil.SP_Insert_Usuario
	@gls_nombre varchar(20) = NULL,
	@gls_ape_paterno varchar(30) = NULL,
	@gls_ape_materno varchar(30) = NULL,
	@anexo numeric(18, 0) = NULL,
	@gls_usuario varchar(24) = NULL,
	@fec_nacimiento datetime = NULL,
	@correo varchar(100) = NULL,
	@idcargo int = NULL,
	@idarea int = NULL,
	@idempresa int = NULL,
	@idcategoria int = NULL,
	@guid_user varchar(128) = NULL,
	@estado char(1) = NULL,
	@aud_usr_ingreso varchar(24) = NULL
as
begin
	insert into Perfil.Usuario (gls_nombre,gls_ape_paterno,gls_ape_materno,anexo,gls_usuario,fec_nacimiento,correo,idcargo,idarea,idempresa,idcategoria,guid_user,estado,aud_usr_ingreso,aud_fec_ingreso)
	values (@gls_nombre,@gls_ape_paterno,@gls_ape_materno,@anexo,@gls_usuario,@fec_nacimiento,@correo,@idcargo,@idarea,@idempresa,@idcategoria,@guid_user,@estado,@aud_usr_ingreso,getdate())
end
GO

/********************************************************************************
Tabla : Perfil.Usuario
Descripcion: Actualiza usuarios en la tabla Perfil.Usuario
Creado Por: Victor Yucra
Fecha Creacion: 17/03/2016
********************************************************************************/
create procedure Perfil.SP_Update_Usuario
	@gls_nombre varchar(20) = NULL,
	@gls_ape_paterno varchar(30) = NULL,
	@gls_ape_materno varchar(30) = NULL,
	@anexo numeric(18, 0) = NULL,
	@gls_usuario varchar(24) = NULL,
	@fec_nacimiento datetime = NULL,
	@correo varchar(100) = NULL,
	@idcargo int = NULL,
	@idarea int = NULL,
	@guid_user varchar(128)
as
begin
	update Perfil.Usuario
	set  gls_nombre = @gls_nombre
		,gls_ape_paterno = @gls_ape_paterno
		,gls_ape_materno = @gls_ape_materno
		,anexo = @anexo
		,gls_usuario = @gls_usuario
		,fec_nacimiento = @fec_nacimiento
		,correo = @correo
		,idcargo = @idcargo
		,idarea = @idarea
		,idempresa = 1
		,idcategoria = 1
		,aud_fec_modificacion = getdate()
	where guid_user = @guid_user
end
GO

/********************************************************************************
Tabla : Muro.Area
Descripcion: Obtiene todos los areas registrados
Creado Por: Victor Yucra
Fecha Creacion: 11/03/2016
********************************************************************************/
create procedure Perfil.SP_Area_Select
as
begin
	select id, gls_area, estado from Perfil.Area  order by gls_area asc
end
GO

/********************************************************************************
Tabla : Perfil.Cargo
Descripcion: Obtiene todos los Cargos registrados
Creado Por: Victor Yucra
Fecha Creacion: 11/03/2016
********************************************************************************/
create procedure Perfil.SP_Cargo_Select
as
begin
	select id, gls_Cargo, estado from Perfil.Cargo  order by gls_Cargo asc
end
GO

/********************************************************************************
Tabla : Perfil.CategoriaUsuario
Descripcion: Obtiene todos los CategoriaUsuario registrados
Creado Por: Victor Yucra
Fecha Creacion: 11/03/2016
********************************************************************************/
create procedure Perfil.SP_CategoriaUsuario_Select
as
begin
	select id, gls_categoria, estado from Perfil.CategoriaUsuario order by gls_categoria asc
end
GO

/********************************************************************************
Tabla : Perfil.Empresa
Descripcion: Obtiene todas las Empresas registrados
Creado Por: Victor Yucra
Fecha Creacion: 11/03/2016
********************************************************************************/
create procedure Perfil.SP_Empresa_Select
as
begin
	select id, gls_empresa, estado from Perfil.Empresa order by id asc
end
GO

/********************************************************************************
Tabla : Perfil.Cargo
Descripcion: Obtiene un Cargo en especifico
Creado Por: Victor Yucra
Fecha Creacion: 28/03/2016
********************************************************************************/
create procedure Perfil.SP_Cargo_Obtener
	@id int
as
begin
	select id, gls_Cargo, estado from Perfil.Cargo where id = @id
end
GO

/********************************************************************************
Tabla : Perfil. Usuario / Cargo / Area
Descripcion: Obtiene todos los cumpleanios del dia registrados
Creado Por: Victor Yucra
Fecha Creacion: 31/03/2016
********************************************************************************/
CREATE procedure [Perfil].[SP_cumpleanios_Select]
	@fecha datetime = null
as
begin
	select
		 u.id
		,u.gls_nombre
		,u.gls_ape_paterno
		,c.gls_Cargo
		,a.gls_area
		,u.gls_usuario
	from Perfil.Usuario u
	left join Perfil.Cargo c on c.id = u.idcargo
	left join Perfil.Area a on a.id = u.idarea
end
GO
