CREATE DATABASE SISTEMALIBRERIADB
GO


USE SISTEMALIBRERIADB
GO

-- Tabla de Usuarios
CREATE TABLE [dbo].[Usuario](
    [Id_Usuario] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,
    [Nombre] [varchar](50) NOT NULL,
    [Clave] [varchar](50) NOT NULL,
    [Rol] [varchar](50) NOT NULL
)
GO

-- Tabla de Permisos
CREATE TABLE [dbo].[Permiso](
    [Id_permiso] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,
    [Id_Usuario] [int] NULL FOREIGN KEY REFERENCES [Usuario]([Id_Usuario]),
    [NombrePantalla] [varchar](50) NULL
)
GO

-- Tabla de Negocio
CREATE TABLE [dbo].[Negocio](
    [Id_Negocio] [int] NOT NULL PRIMARY KEY,
    [Nombre] [varchar](100) NULL,
    [RUC] [varchar](150) NULL,
    [Direccion] [varchar](200) NULL,
    [Logo] [varbinary](max) NULL
)
GO

-- Tabla de Categorías
CREATE TABLE [dbo].[Categoria](
    [Id_Categoria] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,
    [Nombre] [varchar](50) NOT NULL,
    [Descripcion] [varchar](200) NULL
)
GO

-- Tabla de Subcategorías
CREATE TABLE [dbo].[SubCategoria](
    [Id_SubCat] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,
    [Nombre] [varchar](50) NOT NULL,
    [Id_Categoria] [int] NULL FOREIGN KEY REFERENCES [Categoria]([Id_Categoria])
)
GO

-- Tabla de Artículos
CREATE TABLE [dbo].[Articulo](
    [Id_Articulo] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,
    [Nombre] [varchar](60) NOT NULL
)
GO

-- Tabla de Marcas
CREATE TABLE [dbo].[Marca](
    [Id_Marca] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,
    [Nombre] [varchar](30) NOT NULL
)
GO

-- Tabla de Colores
CREATE TABLE [dbo].[Color](
    [Id_Color] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,
    [Nombre] [varchar](30) NULL
)
GO

-- Tabla de Unidades de Medida
CREATE TABLE [dbo].[UnidadMedida](
    [Id_Unidad] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,
    [Nombre] [varchar](40) NOT NULL
)
GO

-- Tabla de Presentaciones
CREATE TABLE [dbo].[Presentacion](
    [Id_Presentacion] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,
    [Nombre] [varchar](60) NOT NULL,
    [Cantidad] [decimal](10, 2) NOT NULL,
    [Id_Unidad] [int] NULL FOREIGN KEY REFERENCES [UnidadMedida]([Id_Unidad]),
    [FactorUnidad] [varchar](50) NULL
)
GO

-- Tabla de Productos
CREATE TABLE [dbo].[Producto](
    [Id_Producto] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,
    [Id_Articulo] [int] NULL FOREIGN KEY REFERENCES [Articulo]([Id_Articulo]),
    [Id_Marca] [int] NULL FOREIGN KEY REFERENCES [Marca]([Id_Marca]),
    [Id_Color] [int] NULL FOREIGN KEY REFERENCES [Color]([Id_Color]),
    [Id_SubCat] [int] NULL FOREIGN KEY REFERENCES [SubCategoria]([Id_SubCat]),
    [Id_Presentacion] [int] NULL FOREIGN KEY REFERENCES [Presentacion]([Id_Presentacion]),
    [Descripcion] [text] NULL
)
GO

-- Tabla de Proveedores
CREATE TABLE [dbo].[Proveedor](
    [Id_Proveedor] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,
    [Nombre] [varchar](50) NULL,
    [Apellido] [varchar](50) NULL,
    [Telefono] [varchar](10) NULL,
    [Correo] [varchar](35) NULL
)
GO

-- Tabla de Compras
CREATE TABLE [dbo].[Compra](
    [Id_Compra] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,
    [Fecha] [datetime] NULL DEFAULT (getdate()),
    [Id_Usuario] [int] NULL FOREIGN KEY REFERENCES [Usuario]([Id_Usuario]),
    [Id_Proveedor] [int] NULL FOREIGN KEY REFERENCES [Proveedor]([Id_Proveedor]),
    [Total] [decimal](10, 2) NULL,
    [Numcompra] [varchar](500) NULL
)
GO

-- Tabla de Detalles de Compra
CREATE TABLE [dbo].[DetalleCompra](
    [Id_DetalleCompra] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,
    [Id_Compra] [int] NULL FOREIGN KEY REFERENCES [Compra]([Id_Compra]),
    [Id_Producto] [int] NULL FOREIGN KEY REFERENCES [Producto]([Id_Producto]),
    [Catidad] [decimal](10, 2) NULL,
    [PrecioUnitario] [decimal](10, 2) NULL,
    [SubTotal] [decimal](10, 2) NULL
)
GO

-- Tabla de Stock
CREATE TABLE [dbo].[Stock](
    [Id_Stock] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,
    [Id_Producto] [int] NULL FOREIGN KEY REFERENCES [Producto]([Id_Producto]),
    [Id_Proveedor] [int] NULL FOREIGN KEY REFERENCES [Proveedor]([Id_Proveedor]),
    [CantidadBase] [int] NOT NULL DEFAULT ((0)),
    [PrecioC] [decimal](10, 2) NULL,
    [PrecioV] [decimal](10, 2) NULL,
    [Id_DetalleCompra] [int] NULL FOREIGN KEY REFERENCES [DetalleCompra]([Id_DetalleCompra])
)
GO

-- Tabla de Bajas de Inventario
CREATE TABLE [dbo].[BajaInventario](
    [Id_Baja] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,
    [Cantidad] [decimal](10, 2) NOT NULL,
    [Motivo] [varchar](50) NOT NULL,
    [Fecha] [datetime] NULL DEFAULT (getdate()),
    [Id_Producto] [int] NULL FOREIGN KEY REFERENCES [Producto]([Id_Producto])
)
GO

-- Tabla de Ventas
CREATE TABLE [dbo].[Venta](
    [Id_Venta] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,
    [Fecha] [datetime] NULL DEFAULT (getdate()),
    [Id_Usuario] [int] NULL FOREIGN KEY REFERENCES [Usuario]([Id_Usuario]),
    [Total] [decimal](18, 2) NULL,
    [NumVenta] [varchar](500) NULL,
    [Descuento] [decimal](18, 2) NULL
)
GO

-- Tabla de Detalles de Venta
CREATE TABLE [dbo].[DetalleVenta](
    [Id_DetalleVenta] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,
    [Id_Venta] [int] NULL FOREIGN KEY REFERENCES [Venta]([Id_Venta]),
    [Id_Producto] [int] NULL FOREIGN KEY REFERENCES [Producto]([Id_Producto]),
    [Catidad] [int] NULL DEFAULT ((0)),
    [PrecioUnitario] [decimal](10, 2) NULL,
    [SubTotal] [decimal](10, 2) NULL
)
GO

-- Tabla de Atributos
CREATE TABLE [dbo].[Atributo](
    [Id_Atributo] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,
    [Nombre] [varchar](50) NULL
)
GO

-- Tabla de Valores de Atributos
CREATE TABLE [dbo].[AtributoValor](
    [Id_Valor] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,
    [Id_Atributo] [int] NULL FOREIGN KEY REFERENCES [Atributo]([Id_Atributo]),
    [valorTexto] [varchar](50) NULL
)
GO

-- Tabla de Relación Producto-Valor
CREATE TABLE [dbo].[ProductoValor](
    [Id_Producto] [int] NULL FOREIGN KEY REFERENCES [Producto]([Id_Producto]),
    [Id_Valor] [int] NULL FOREIGN KEY REFERENCES [AtributoValor]([Id_Valor])
)
GO

/*
-- Tipos de tabla definidos por el usuario
CREATE TYPE [dbo].[EDETALLECOMPRA] AS TABLE(
    [Id_Producto] [int] NULL,
    [Cantidad] [int] NULL,
    [PrecioUnitario] [decimal](18, 2) NULL,
    [SubTotal] [decimal](18, 2) NULL
)
GO

CREATE TYPE [dbo].[EDetalleVenta_Nuevo] AS TABLE(
    [Id_Producto] [int] NULL,
    [Cantidad] [int] NULL,
    [PrecioUnitario] [decimal](18, 2) NULL,
    [SubTotal] [decimal](18, 2) NULL
)
GO

*/

