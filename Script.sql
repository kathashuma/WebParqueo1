USE [dbMeca]
GO
/****** Object:  Table [dbo].[Ajustes]    Script Date: 27/11/2022 18:58:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ajustes](
	[ID_Ajustes] [int] IDENTITY(1,1) NOT NULL,
	[NombreParqueo] [varchar](50) NULL,
	[CantidadParqueo] [varchar](50) NULL,
 CONSTRAINT [PK_Ajustes] PRIMARY KEY CLUSTERED 
(
	[ID_Ajustes] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cliente]    Script Date: 27/11/2022 18:58:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cliente](
	[ID_Cliente] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NULL,
	[Apellidos] [varchar](50) NULL,
	[Telefono] [varchar](50) NULL,
	[Correo] [varchar](50) NULL,
 CONSTRAINT [PK_dbo.Cliente] PRIMARY KEY CLUSTERED 
(
	[ID_Cliente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ControlGeneral]    Script Date: 27/11/2022 18:58:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ControlGeneral](
	[ID_Control] [int] IDENTITY(1,1) NOT NULL,
	[Fecha] [date] NULL,
	[Hora] [varchar](50) NULL,
	[Placa] [varchar](50) NULL,
	[Tipo] [varchar](50) NULL,
	[Usuario] [varchar](50) NULL,
	[Estado] [varchar](50) NULL,
 CONSTRAINT [PK_ControlGeneral] PRIMARY KEY CLUSTERED 
(
	[ID_Control] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuarios]    Script Date: 27/11/2022 18:58:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuarios](
	[ID_Usuario] [int] IDENTITY(1,1) NOT NULL,
	[Usuario] [varchar](50) NULL,
	[Clave] [varchar](50) NULL,
	[NivelUsuario] [int] NULL,
 CONSTRAINT [PK_Usuarios] PRIMARY KEY CLUSTERED 
(
	[ID_Usuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Vehiculo]    Script Date: 27/11/2022 18:58:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Vehiculo](
	[ID_Vehiculo] [int] NOT NULL,
	[TipoVehiculo] [varchar](50) NULL,
	[Marca] [varchar](50) NULL,
	[Modelo] [varchar](50) NULL,
	[Linea] [varchar](50) NULL,
	[Color] [varchar](50) NULL,
	[Placa] [varchar](50) NULL,
	[Observaciones] [varchar](max) NULL,
 CONSTRAINT [PK_Vehiculo] PRIMARY KEY CLUSTERED 
(
	[ID_Vehiculo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[SP_EditarAjustes]    Script Date: 27/11/2022 18:58:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_EditarAjustes]
(
@ID_Ajustes int,
@NombreParqueo varchar(50),
@CantidadParqueo varchar(50)
)
AS
BEGIN
update Ajustes set NombreParqueo=@NombreParqueo, CantidadParqueo=@CantidadParqueo
where ID_Ajustes=@ID_Ajustes;
END
GO
/****** Object:  StoredProcedure [dbo].[SP_EditarCliente]    Script Date: 27/11/2022 18:58:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_EditarCliente]
(
@ID_Cliente int,
@Nombre varchar(50),
@Apellidos varchar(50),
@Telefono varchar(50),
@Correo varchar(50)
)
AS
BEGIN
update Cliente set Nombre=@Nombre, Apellidos=@Apellidos, Telefono=@Telefono, Correo=@Correo
where ID_Cliente=@ID_Cliente;
END
GO
/****** Object:  StoredProcedure [dbo].[SP_EditarControlGeneral]    Script Date: 27/11/2022 18:58:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_EditarControlGeneral]
(
@ID_Control int,
@Placa varchar(50),
@Tipo varchar(50)
)
AS
BEGIN
update ControlGeneral set Placa=@Placa, Tipo=@Tipo
where ID_Control=@ID_Control;
END
GO
/****** Object:  StoredProcedure [dbo].[SP_EditarUsuarios]    Script Date: 27/11/2022 18:58:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROCEDURE [dbo].[SP_EditarUsuarios]
(
@ID_Usuario int,
@Usuario varchar(50),
@Clave varchar(50),
@NivelUsuario int
)
AS
BEGIN
update Usuarios set Usuario=@Usuario, Clave=@Clave, NivelUsuario=@NivelUsuario
where ID_Usuario=@ID_Usuario;
END
GO
/****** Object:  StoredProcedure [dbo].[SP_EliminarAjustes]    Script Date: 27/11/2022 18:58:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[SP_EliminarAjustes]
(
@ID_Ajustes int
)
AS
BEGIN
delete from Ajustes 
where ID_Ajustes=@ID_Ajustes;
END
GO
/****** Object:  StoredProcedure [dbo].[SP_EliminarCliente]    Script Date: 27/11/2022 18:58:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_EliminarCliente]
(
@ID_Cliente int
)
AS
BEGIN
delete from Cliente 
where ID_Cliente=@ID_Cliente;
END
GO
/****** Object:  StoredProcedure [dbo].[SP_EliminarControlGeneral]    Script Date: 27/11/2022 18:58:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_EliminarControlGeneral]
(
@ID_Control int
)
AS
BEGIN
delete from ControlGeneral 
where ID_Control=@ID_Control;
END
GO
/****** Object:  StoredProcedure [dbo].[SP_EliminarUsuarios]    Script Date: 27/11/2022 18:58:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_EliminarUsuarios]
(
@ID_Usuario int
)
AS
BEGIN
delete from Usuarios 
where ID_Usuario=@ID_Usuario;
END
GO
/****** Object:  StoredProcedure [dbo].[SP_ListarAjustes]    Script Date: 27/11/2022 18:58:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[SP_ListarAjustes]

AS
BEGIN
select ID_Ajustes, NombreParqueo, CantidadParqueo from Ajustes

END
GO
/****** Object:  StoredProcedure [dbo].[SP_ListarCliente]    Script Date: 27/11/2022 18:58:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_ListarCliente]

AS
BEGIN
select ID_Cliente, Nombre, Apellidos, Telefono, Correo from Cliente

END
GO
/****** Object:  StoredProcedure [dbo].[SP_ListarControlGeneral]    Script Date: 27/11/2022 18:58:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[SP_ListarControlGeneral]

AS
BEGIN
select ID_Control, Fecha, Hora, Placa, Tipo, Usuario, Estado from ControlGeneral

END
GO
/****** Object:  StoredProcedure [dbo].[SP_ListarUsuarios]    Script Date: 27/11/2022 18:58:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_ListarUsuarios]

AS
BEGIN
select ID_Usuario, Usuario, Clave, NivelUsuario from Usuarios

END
GO
/****** Object:  StoredProcedure [dbo].[SP_RegistrarAjustes]    Script Date: 27/11/2022 18:58:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROCEDURE [dbo].[SP_RegistrarAjustes]
(
@NombreParqueo varchar(50),
@CantidadParqueo varchar(50)
)
AS
BEGIN
insert into Ajustes (NombreParqueo, CantidadParqueo)
values(@NombreParqueo, @CantidadParqueo)
END
GO
/****** Object:  StoredProcedure [dbo].[SP_RegistrarCliente]    Script Date: 27/11/2022 18:58:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_RegistrarCliente]
(
@Nombre varchar(50),
@Apellidos varchar(50),
@Telefono varchar(50),
@Correo varchar(50)
)
AS
BEGIN
insert into Cliente (Nombre, Apellidos, Telefono, Correo)
values(@Nombre, @Apellidos, @Telefono, @Correo)
END
GO
/****** Object:  StoredProcedure [dbo].[SP_RegistrarControl]    Script Date: 27/11/2022 18:58:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROCEDURE [dbo].[SP_RegistrarControl]
(
@Fecha date,
@Hora varchar(50),
@Placa varchar(50),
@Tipo varchar(50),
@Usuario varchar(50),
@Estado varchar(50)
)
AS
BEGIN
insert into ControlGeneral (Fecha, Hora, Placa, Tipo, Usuario, Estado)
values(@Fecha, @Hora, @Placa, @Tipo, @Usuario, @Estado)
END
GO
/****** Object:  StoredProcedure [dbo].[SP_RegistrarUsuarios]    Script Date: 27/11/2022 18:58:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_RegistrarUsuarios]
(
@Usuario varchar(50),
@Clave varchar(50),
@NivelUsuario int
)
AS
BEGIN
insert into Usuarios (Usuario, Clave, NivelUsuario)
values(@Usuario, @Clave, @NivelUsuario)
END
GO
/****** Object:  StoredProcedure [dbo].[SP_VerificaUsuario]    Script Date: 27/11/2022 18:58:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROC [dbo].[SP_VerificaUsuario]
@Usuario varchar(100),
@Clave varchar(max)
as
Begin
   If(exists(Select * from Usuarios where Usuario = @Usuario and Clave=@Clave))
       select ID_Usuario from Usuarios where Usuario = @Usuario and Clave=@Clave
	   else
	   select '0'
End
GO
