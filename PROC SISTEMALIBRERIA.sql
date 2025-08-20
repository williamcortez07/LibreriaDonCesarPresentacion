Use DBSistemaLibreriaDonCesar;

--PROCEDIMIENTO PARA CREAR UN NUEVO USUARIO, SE VALIDA QUE UN USUARIO NO TENGA EL MISMO NOMBRE YA QUE PUEDE CAUSAR CONFUSIÓN
-- SI EN LA EMPRESA TRABAJA DOS O MAS USUARIOS CON EL MISMO NOMBRE PERO CARGOS DIFERENTES ES MEJOR DEFINIR DISTITOS NOMBRES DE USUARIOS
CREATE PROC PS_REGISTRARUSUARIO(
@Nombre varchar (50),
@Clave varchar (80),
@Rol varchar (80),

@Id_UsuarioResultado int output,
@Mensaje varchar (500) output

)
as 

begin

set @Id_UsuarioResultado = 0
set @Mensaje = ''

   if not exists (select * from Usuario where Nombre = @Nombre)
    begin
   insert into Usuario(Nombre,Clave,Rol)values 
                     (@Nombre,@Clave,@Rol)
     set @Id_UsuarioResultado = SCOPE_IDENTITY()

  end
  else 
    set @Mensaje = 'Para evitar confuciones, por favor cambie el Nombre'
end


go


-- PROCEDIMIENTO ALMACENADO PARA EDITAR LOS DATOS UN USUARIO
CREATE PROC PS_EDITARUSUARIO(
@Id_Usuario int ,
@Nombre varchar (100),
@Clave varchar (80),
@Rol varchar (80),

@Respuesta bit output,
@Mensaje varchar (500) output

)
as 

begin

set @Respuesta = 0
set @Mensaje = ''

if not exists (select * from Usuario where Nombre = @Nombre and Id_Usuario != @Id_Usuario)
begin
UPDATE Usuario SET 
Nombre =  @Nombre,
Clave = @Clave,
Rol = @Rol

WHERE Id_Usuario = @Id_Usuario

set @Respuesta = 1

end
else 
set @Mensaje = 'Para evitar confuciones, por favor cambie el Nombre'


end

go


--PROCEDIMIENTO PARA ELIMINAR USUARIOS

CREATE PROC PS_ELIMINARUSUARIO(
@Id_Usuario int,

@Respuesta int output,
@Mensaje varchar (500) output

)
as 

begin

set @Respuesta = 0
set @Mensaje = ''
declare @paso bit = 1


IF EXISTS (SELECT * FROM Compra C
            INNER JOIN Usuario U ON U.Id_Usuario = C.Id_Usuario
			WHERE U.Id_Usuario = @Id_Usuario
			)
			BEGIN
			set @paso = 0
			set @Respuesta = 0
            set @Mensaje = @Mensaje + 'No puede eliminar al usuario ya que se encuentra registrado en una compra \n'

			END


IF EXISTS (SELECT * FROM Venta V
            INNER JOIN Usuario U ON U.Id_Usuario = V.Id_Usuario
			WHERE U.Id_Usuario = @Id_Usuario
			)
			BEGIN
			set @paso = 0
			set @Respuesta = 0
set @Mensaje = @Mensaje + 'No puede eliminar al usuario ya que se encuentra registrado en una venta \n'

			END


			IF(@paso = 1)

			BEGIN 
			DELETE FROM Usuario WHERE Id_Usuario = @Id_Usuario
			SET @Respuesta = 1

			END

END

 

 go


--PROCEDIMIENTO ALMACENADO PARA REGISTRAR UN ARTÍCULO

CREATE PROC PS_REGISTRARARTICULO(
@Nombre varchar (80),
@Id_ArticuloResultado int output,
@Mensaje varchar (500) output

)
as 

begin

set @Id_ArticuloResultado = 0
set @Mensaje = ''

   if not exists (select * from Articulo where Nombre = @Nombre)
    begin
   insert into Articulo(Nombre)values 
                     (@Nombre)
     set @Id_ArticuloResultado = SCOPE_IDENTITY()

  end
  else 
    set @Mensaje = 'Para evitar confuciones, por favor cambie el Nombre'
end


go

--PROCEDIMIENTO PARA EDITAR UN ARTÍCULO

CREATE PROC PS_EDITARARTICULO(
@Id_Articulo int ,
@Nombre varchar (80),
@Respuesta bit output,
@Mensaje varchar (500) output

)
as 

begin

set @Respuesta = 0
set @Mensaje = ''

if not exists (select * from Articulo where Nombre = @Nombre and Id_Articulo != @Id_Articulo)
begin
UPDATE Articulo SET 
Nombre =  @Nombre


WHERE Id_Articulo = @Id_Articulo

set @Respuesta = 1

end
else 
set @Mensaje = 'Para evitar confuciones, por favor cambie el Nombre'


end

go


--PROCEDIMIENTO PARA ELIMINAR ARTÍCULOS

Create PROC PS_ELIMINARARTICULO(
@Id_Articulo int,
@Respuesta int output,
@Mensaje varchar (500) output

)
as 

begin

set @Respuesta = 0
set @Mensaje = ''
declare @paso bit = 1


IF EXISTS (SELECT * FROM Producto P
            INNER JOIN Articulo A ON A.Id_Articulo = P.Id_Articulo
			WHERE A.Id_Articulo = @Id_Articulo
			)
			BEGIN
			set @paso = 0
			set @Respuesta = 0
            set @Mensaje = @Mensaje + 'No puede eliminar el artículo porque ya se encuentra registrado como un "PRODUCTO" \n'

			END

			IF(@paso = 1)

			BEGIN 
			DELETE FROM Articulo WHERE Id_Articulo = @Id_Articulo
			SET @Respuesta = 1

			END
END

 

 go



 --PROCEDIMIENTO ALMACENADO PARA REGISTRAR UN PROVEEDOR

CREATE PROC PS_REGISTRARPROVEEDOR(
@Nombre varchar (80),
@Apellido varchar (80),
@Telefono varchar (14), -- por lo general serian 13 pero doy un caracter mas por si en el futuro cambia algo (+505 84532072)
@Correo varchar (50),
@Id_ProveedorResultado int output,
@Mensaje varchar (500) output

)
as 

begin

set @Id_ProveedorResultado = 0
set @Mensaje = ''

   if not exists (select * from Proveedor where Nombre = @Nombre AND Apellido = @Apellido)
    begin
   insert into Proveedor(Nombre, Apellido, Telefono, Correo)values 
                     (@Nombre, @Apellido, @Telefono, @Correo)
     set @Id_ProveedorResultado = SCOPE_IDENTITY()

  end
  else 
    set @Mensaje = 'El proveedor ya se encuentra registrado'
end


go

--PROCEDIMIENTO PARA EDITAR UN PROVEEDOR

CREATE PROC PS_EDITARPROVEEDOR(
@Id_Proveedor int ,
@Nombre varchar (80),
@Apellido varchar (80),
@Telefono varchar (14), 
@Correo varchar (50),
@Respuesta bit output,
@Mensaje varchar (500) output

)
as 

begin

set @Respuesta = 0
set @Mensaje = ''

if not exists (select * from Proveedor where Nombre = @Nombre and Apellido = @Apellido)
begin
UPDATE Proveedor SET 
Nombre =  @Nombre,
Apellido =  @Apellido ,
Telefono= @Telefono,
Correo = @Correo


WHERE Id_Proveedor = @Id_Proveedor
set @Respuesta = 1
end
else 
set @Mensaje = 'El proveedor ya se encuentra registrado'
end

go


--PROCEDIMIENTO PARA ELIMINAR PROVEEDOR

Create PROC PS_ELIMINARPROVEEDOR(
@Id_Proveedor int,
@Respuesta int output,
@Mensaje varchar (500) output
)
as 

begin

set @Respuesta = 0
set @Mensaje = ''
declare @paso bit = 1


IF EXISTS (SELECT * FROM Compra C
            INNER JOIN Proveedor P ON P.Id_Proveedor = C.Id_Proveedor
			WHERE P.Id_Proveedor = @Id_Proveedor
			)
			BEGIN
			set @paso = 0
			set @Respuesta = 0
            set @Mensaje = @Mensaje + 'No puede eliminar el Proveedor porque se encuentra registrado en una Compra \n'

			END
			
IF EXISTS (SELECT * FROM Stock S
            INNER JOIN Proveedor P ON P.Id_Proveedor = S.Id_Proveedor
			WHERE P.Id_Proveedor = @Id_Proveedor
			)
			BEGIN
			set @paso = 0
			set @Respuesta = 0
            set @Mensaje = @Mensaje + 'No puede eliminar el Proveedor porque se encuentra registrado en stock \n'
			END

			IF(@paso = 1)

			BEGIN 
			DELETE FROM Proveedor WHERE Id_Proveedor = @Id_Proveedor
			SET @Respuesta = 1

			END
END
 go


 ---- desde aqui empesar a ejecutar

 --PROCEDIMIENTO ALMACENADO PARA REGISTRAR UN ATRIBUTO
 
  CREATE PROC PS_REGISTRARATRIBUTO(
@Nombre varchar (80),
@Id_AtributoResultado int output,
@Mensaje varchar (500) output

)
as 

begin

set @Id_AtributoResultado = 0
set @Mensaje = ''

   if not exists (select * from Atributo where Nombre = @Nombre)
    begin
   insert into Atributo(Nombre)values 
                     (@Nombre)
     set @Id_AtributoResultado = SCOPE_IDENTITY()

  end
  else 
    set @Mensaje = 'este Nombre ya se encuentra registrado'
end


go

--PROCEDIMIENTO PARA EDITAR UN ATRIBUTO

CREATE PROC PS_EDITARATRIBUTO(
@Id_Atributo int ,
@Nombre varchar (80),
@Respuesta bit output,
@Mensaje varchar (500) output

)
as 

begin

set @Respuesta = 0
set @Mensaje = ''

if not exists (select * from Atributo where Nombre = @Nombre)
begin
UPDATE Atributo SET 
Nombre =  @Nombre


WHERE Id_Atributo = @Id_Atributo

set @Respuesta = 1

end
else 
set @Mensaje = 'Este Nombre ya se encuentra registrado'


end

go

--PROCEDIMIENTO PARA ELIMINAR UN ATRIBUTO

CREATE PROC PS_ELIMINARATRIBUTO
(
    @Id_Atributo   INT,
    @Respuesta     INT OUTPUT,
    @Mensaje       VARCHAR(500) OUTPUT
)
AS
BEGIN
    SET @Respuesta = 0
    SET @Mensaje = ''
    DECLARE @paso BIT = 1

    -- Verificar si existe un producto relacionado con el atributo
    IF EXISTS (
        SELECT 1 
        FROM ProductoValor PV
        INNER JOIN AtributoValor AV ON PV.Id_Valor = AV.Id_Valor
        WHERE AV.Id_Atributo = @Id_Atributo
    )
    BEGIN
        SET @paso = 0
        SET @Respuesta = 0
        SET @Mensaje = 'No puede eliminar el atributo, hay productos relacionados con él.'
    END

    -- Si no hay productos relacionados, proceder con la eliminación
    IF (@paso = 1)
    BEGIN
        BEGIN TRY
            DELETE FROM Atributo 
            WHERE Id_Atributo = @Id_Atributo
            SET @Respuesta = 1
            SET @Mensaje = 'Atributo eliminado exitosamente.'
        END TRY
        BEGIN CATCH
            SET @Respuesta = 0
            SET @Mensaje = 'Error al eliminar el atributo: ' + ERROR_MESSAGE()
        END CATCH
    END
END
GO

 --PROCEDIMIENTO ALMACENADO PARA REGISTRAR UN COLOR
 
  CREATE PROC PS_REGISTRARCOLOR(
@Nombre varchar (80),
@Id_ColorResultado int output,
@Mensaje varchar (500) output

)
as 

begin

set @Id_ColorResultado = 0
set @Mensaje = ''

   if not exists (select * from Color where Nombre = @Nombre)
    begin
   insert into Color (Nombre)values 
                     (@Nombre)
     set @Id_ColorResultado = SCOPE_IDENTITY()

  end
  else 
    set @Mensaje = 'este Nombre ya se encuentra registrado'
end
select * from Marca

go

--PROCEDIMIENTO PARA EDITAR UN COLOR

CREATE PROC PS_EDITARCOLOR(
@Id_Color  int ,
@Nombre varchar (80),
@Respuesta bit output,
@Mensaje varchar (500) output

)
as 

begin

set @Respuesta = 0
set @Mensaje = ''

if not exists (select * from Color where Nombre = @Nombre)
begin
UPDATE Color  SET 
Nombre =  @Nombre


WHERE Id_Color  = @Id_Color 

set @Respuesta = 1

end
else 
set @Mensaje = 'Este Nombre ya se encuentra registrado'


end

go


--PROCEDIMIENTO PARA ELIMINAR COLORES

Create PROC PS_ELIMINARCOLOR(
@Id_Color    int,

@Respuesta int output,
@Mensaje varchar (500) output

)
as 

begin

set @Respuesta = 0
set @Mensaje = ''
declare @paso bit = 1


IF EXISTS (SELECT * FROM Producto P
            INNER JOIN Color C ON C.Id_Color = P.Id_Color
			WHERE C.Id_Color = @Id_Color
			)
			BEGIN
			set @paso = 0
			set @Respuesta = 0
            set @Mensaje = @Mensaje + 'No puede eliminar el Color, porque esta relacionado con un producto" \n'

			END

			IF(@paso = 1)

			BEGIN 
			DELETE FROM Color WHERE Id_Color = @Id_Color
			SET @Respuesta = 1

			END

END

 

 go


 --PROCEDIMIENTO ALMACENADO PARA REGISTRAR UNA MARCA
 
  CREATE PROC PS_REGISTRARMARCA(
@Nombre varchar (80),
@Id_MarcaResultado int output,
@Mensaje varchar (500) output

)
as 

begin

set @Id_MarcaResultado = 0
set @Mensaje = ''

   if not exists (select * from Marca where Nombre = @Nombre)
    begin
   insert into  Marca (Nombre)values 
                     (@Nombre)
     set @Id_MarcaResultado = SCOPE_IDENTITY()

  end
  else 
    set @Mensaje = 'este Nombre ya se encuentra registrado'
end


go

--PROCEDIMIENTO PARA EDITAR MARCA

CREATE PROC PS_EDITARMARCA(
@Id_Marca  int ,
@Nombre varchar (80),
@Respuesta bit output,
@Mensaje varchar (500) output

)
as 

begin

set @Respuesta = 0
set @Mensaje = ''

if not exists (select * from Marca where Nombre = @Nombre)
begin
UPDATE Marca  SET 
Nombre =  @Nombre
WHERE Id_Marca  = @Id_Marca 
set @Respuesta = 1

end
else 
set @Mensaje = 'Este Nombre ya se encuentra registrado'


end

go


--PROCEDIMIENTO PARA ELIMINAR MARCA

CREATE PROC PS_ELIMINARMARCA(
@Id_Marca    int,
@Respuesta int output,
@Mensaje varchar (500) output

)
as 

begin

set @Respuesta = 0
set @Mensaje = ''
declare @paso bit = 1


IF EXISTS (SELECT * FROM Producto P
            INNER JOIN Marca M ON M.Id_Marca = P.Id_Marca
			WHERE M.Id_Marca = @Id_Marca
			)
			BEGIN
			set @paso = 0
			set @Respuesta = 0
            set @Mensaje = @Mensaje + 'No puede eliminar la Marca, porque esta relacionado con un producto" \n'
			END
			IF(@paso = 1)
			BEGIN 
			DELETE FROM Marca WHERE Id_Marca = @Id_Marca 
			SET @Respuesta = 1

			END

END

 

 go


-- PROCEDIMIENTO ALMACENADO PARA REGISTRAR UNA CATEGORIA

 CREATE PROC PS_REGISTRARCATEGORIA(
@Nombre varchar (80),
@Descripcion varchar(200),
@Id_CategoriaResultado int output,
@Mensaje varchar (500) output

)
as 

begin

set @Id_CategoriaResultado = 0
set @Mensaje = ''

   if not exists (select * from Categoria where Nombre = @Nombre)
    begin
   insert into  Categoria (Nombre,Descripcion)values 
                     (@Nombre, @Descripcion)
     set @Id_CategoriaResultado = SCOPE_IDENTITY()

  end
  else 
    set @Mensaje = 'esta Categoria  ya se encuentra registrada'
end


go

--PROCEDIMIENTO PARA EDITAR CATEGORIA

CREATE PROC PS_EDITARCATEGORIA(
@Id_Categoria  int ,
@Nombre varchar (80),
@Descripcion Varchar (200),
@Respuesta bit output,
@Mensaje varchar (500) output

)
as 

begin

set @Respuesta = 0
set @Mensaje = ''

if not exists (select * from Categoria where Nombre = @Nombre AND Descripcion = @Descripcion)
begin
UPDATE Categoria  SET 
Nombre =  @Nombre,
Descripcion = @Descripcion
WHERE Id_Categoria  = @Id_Categoria 

set @Respuesta = 1

end
else 
set @Mensaje = 'Esta Categoria ya se encuentra registrada'


end

go


--PROCEDIMIENTO PARA ELIMINAR CATEGORIA

Create PROC PS_ELIMINARCATEGORIA(
@Id_Categoria int,
@Respuesta int output,
@Mensaje varchar (500) output

)
as 

begin

set @Respuesta = 0
set @Mensaje = ''
declare @paso bit = 1


IF EXISTS (SELECT * FROM SubCategoria SC
            INNER JOIN Categoria C ON C.Id_Categoria = SC.Id_Categoria
			WHERE C.Id_Categoria = @Id_Categoria
			)
			BEGIN
			set @paso = 0
			set @Respuesta = 0
            set @Mensaje = @Mensaje + 'No se puede eliminar la categoria, existen relaciones con ella" \n'
			END
			IF(@paso = 1)
			BEGIN 
			DELETE FROM Categoria WHERE Id_Categoria = @Id_Categoria 
			SET @Respuesta = 1
			END
END

 go



-- PROCEDIMIENTO ALMACENADO PARA REGISTRAR UNA SUBCATEGORIA

CREATE PROC PS_REGISTRARSUBCATEGORIA(
@Nombre varchar (80),
@Id_categoria int,

@Id_Resultado int output,
@Mensaje varchar (500) output

)
as 

begin

set @Id_Resultado = 0
set @Mensaje = ''

   if not exists (select * from SubCategoria where Nombre = @Nombre and Id_Categoria = @Id_categoria)
    begin
   insert into  SubCategoria (Nombre,Id_Categoria)values 
                     (@Nombre, @Id_categoria)
     set @Id_Resultado = SCOPE_IDENTITY()

  end
  else 
    set @Mensaje = 'esta SubCategoria  ya se encuentra registrada'
end


go

--PROCEDIMIENTO PARA EDITAR SUBCATEGORIA

Create PROC PS_EDITARSUBCATEGORIA(
@Id_SubCat  int ,
@Nombre varchar (80),
@Id_Categoria  int ,
@Respuesta bit output,
@Mensaje varchar (500) output

)
as 

begin
set @Respuesta = 0
set @Mensaje = ''

if not exists (select * from SubCategoria where Nombre = @Nombre and Id_Categoria = @Id_Categoria)
begin
UPDATE SubCategoria  SET 
Nombre =  @Nombre,
Id_Categoria = @Id_Categoria
WHERE Id_SubCat  = @Id_SubCat 

set @Respuesta = 1

end
else 
set @Mensaje = 'Esta SubCategoria ya se encuentra registrada'


end

go


--PROCEDIMIENTO PARA ELIMINAR SUBCATEGORIA

CREATE PROC PS_ELIMINARSUBCATEGORIA(
@Id_SubCat int,

@Respuesta int output,
@Mensaje varchar (500) output

)
as 

begin

set @Respuesta = 0
set @Mensaje = ''
declare @paso bit = 1


IF EXISTS (SELECT * FROM Producto P
            INNER JOIN SubCategoria SC ON SC.Id_SubCat = p.Id_SubCat
			WHERE SC.Id_SubCat = @Id_SubCat
			)
			BEGIN
			set @paso = 0
			set @Respuesta = 0
            set @Mensaje = @Mensaje + 'No se puede eliminar la subcategoria, existen relaciones con productos" \n'

			END

			IF(@paso = 1)

			BEGIN 
			DELETE FROM SubCategoria WHERE Id_SubCat = @Id_SubCat
			SET @Respuesta = 1

			END

END

 go


--PROCEDIMIENTO ALMACENDO PARA REGISTRAR  PRODUCTOS
---------------------------------------------------------------- 
Create PROC PS_REGISTRARPRODUCTO(
@Id_Articulo int,
@Id_Marca int,
@Id_Color int,
@Id_SubCat int,
@Id_Presentacion int,
@Descripcion varchar(100),
@Id_Resultado int output,
@Mensaje varchar (500) output

)
as 

begin

set @Id_Resultado = 0
set @Mensaje = ''

   if not exists (select * from Producto where Id_Articulo = @Id_Articulo and Id_Marca = @Id_Marca and Id_Color = @Id_Color and Id_SubCat = @Id_SubCat and Id_Presentacion = @Id_Presentacion)
    begin
   insert into Producto(Id_Articulo, Id_Marca, Id_Color, Id_SubCat, Id_Presentacion, Descripcion)values 
                     (@Id_Articulo, @Id_Marca, @Id_Color, @Id_SubCat, @Id_Presentacion, @Descripcion)
     set @Id_Resultado = SCOPE_IDENTITY()
insert into Stock(Id_Producto, CantidadBase,PrecioC, PrecioV) values
                  (@Id_Resultado, 0, 0, 0)   
  end
  else 
    set @Mensaje = 'este Producto  ya se encuentra registrado'
end
go
---------------------------------------------------------------
----------------------------------------------------------------
-----------------------------------------------------------------
------------------------------------------------------------------

--PROCEDIMIENTO PARA EDITAR PRODUCTOS

Create PROC PS_EDITARPRODUCTO(
@Id_Producto int,
@Id_Articulo int,
@Id_Marca int,
@Id_Color int,
@Id_SubCat int,
@Id_Presentacion int,
@Descripcion varchar(100),
@Respuesta bit output,
@Mensaje varchar (500) output

)
as 

begin
set @Respuesta = 0
set @Mensaje = ''

if not exists (select * from Producto where Id_Articulo = @Id_Articulo and Id_Marca = @Id_Marca and Id_Color = @Id_Color and Id_SubCat = @Id_SubCat and Id_Presentacion = @Id_Presentacion and Id_Producto != @Id_Producto)
begin
UPDATE Producto  SET 
Id_Articulo = @Id_Articulo,
Id_Marca = @Id_Marca,
Id_Color = @Id_Color,
Id_SubCat = @Id_SubCat,
Id_Presentacion = @Id_Presentacion,
Descripcion = @Descripcion


WHERE Id_Producto  = @Id_Producto 

set @Respuesta = 1

end
else 
set @Mensaje = 'Este producto ya se encuentra registrado'


end

go

-- PROCEDIMEINTO ALMACENADO PARA ELIMINAR PRODUCTOS
Alter PROC PS_ELIMINARPRODUCTO(
@Id_Producto int,
@Respuesta int output,
@Mensaje varchar (500) output
)
as 

begin

set @Respuesta = 0
set @Mensaje = ''
declare @paso bit = 1


IF EXISTS (SELECT * FROM DetalleCompra dc
            INNER JOIN Producto p ON p.Id_Producto = dc.Id_Producto
			WHERE p.Id_Producto = @Id_Producto
			)
			BEGIN
			set @paso = 0
			set @Respuesta = 0
            set @Mensaje = @Mensaje + 'No se puede eliminar el producto, porque esta relacionado con una compra " \n'

			END

IF EXISTS (SELECT * FROM DetalleVenta dv
            INNER JOIN Producto p ON p.Id_Producto = dv.Id_Producto
			WHERE p.Id_Producto = @Id_Producto
			)
			BEGIN
			set @paso = 0
			set @Respuesta = 0
            set @Mensaje = @Mensaje + 'No se puede eliminar el producto, porque esta relacionado con una venta " \n'

			END
/*
IF EXISTS (SELECT * FROM Stock st
            INNER JOIN Producto p ON p.Id_Producto = st.Id_Producto
			WHERE p.Id_Producto = @Id_Producto
			)
			BEGIN
			set @paso = 0
			set @Respuesta = 0
            set @Mensaje = @Mensaje + 'No se puede eliminar el producto, porque esta relacionado con Stock " \n'

			END
*/
IF EXISTS (SELECT * FROM BajaInventario bi
            INNER JOIN Producto p ON p.Id_Producto = bi.Id_Producto
			WHERE p.Id_Producto = @Id_Producto
			)
			BEGIN
			set @paso = 0
			set @Respuesta = 0
            set @Mensaje = @Mensaje + 'No se puede eliminar el producto, porque esta relacionado con una baja " \n'

			END




			IF(@paso = 1)
			BEGIN 
			DELETE FROM Producto WHERE Id_Producto = @Id_Producto
			SET @Respuesta = 1

			END

END

 go


--PROCEDIMIENTO ALMACENADO PARA REGISTRAR LAS UNIDADES DE MEDIDAS
 
  CREATE PROC PS_REGISTRARUNIDAD(
@Nombre varchar (80),
@Id_Resultado int output,
@Mensaje varchar (500) output

)
as 

begin

set @Id_Resultado = 0
set @Mensaje = ''

   if not exists (select * from UnidadMedida where Nombre = @Nombre)
    begin
   insert into UnidadMedida(Nombre)values 
                           (@Nombre)
     set @Id_Resultado = SCOPE_IDENTITY()

  end
  else 
    set @Mensaje = 'este Nombre ya se encuentra registrado'
end


go

--PROCEDIMIENTO PARA EDITAR UNA UNIDADMEDIDA

CREATE PROC PS_EDITARUNIDAD(
@Id_Unidad int ,
@Nombre varchar (80),
@Respuesta bit output,
@Mensaje varchar (500) output

)
as 

begin

set @Respuesta = 0
set @Mensaje = ''

if not exists (select * from UnidadMedida where Nombre = @Nombre)
begin
UPDATE UnidadMedida SET 
Nombre =  @Nombre


WHERE Id_Unidad = @Id_Unidad

set @Respuesta = 1

end
else 
set @Mensaje = 'Este Nombre ya se encuentra registrado'


end

go

--PROCEDIMIENTO PARA ELIMINAR UNA UNIDAD MEDIDA

CREATE PROC PS_ELIMINARUNIDAD(
@Id_Unidad int,

@Respuesta int output,
@Mensaje varchar (500) output

)
as 

begin

set @Respuesta = 0
set @Mensaje = ''
declare @paso bit = 1


IF EXISTS (SELECT * FROM Presentacion P
            INNER JOIN UnidadMedida um ON um.Id_Unidad = p.Id_Unidad
			WHERE um.Id_Unidad = @Id_Unidad
			)
			BEGIN
			set @paso = 0
			set @Respuesta = 0
            set @Mensaje = @Mensaje + 'No se puede eliminar esta Unidad,porque esta relacionado a una presentación" \n'

			END

			IF(@paso = 1)

			BEGIN 
			DELETE FROM UnidadMedida WHERE Id_Unidad = @Id_Unidad 
			SET @Respuesta = 1

			END

END

 go


 --PROCEDIMIENTO ALMACENADO PARA REGISTRAR UNA PRESENTACIÓN

CREATE PROC PS_REGISTRARPRESENTACION(
@Nombre varchar (80),
@Cantidad decimal (10,2),
@Id_Unidad int, 
@FactorUnidad varchar (50),
@Id_Resultado int output,
@Mensaje varchar (500) output

)
as 

begin

set @Id_Resultado = 0
set @Mensaje = ''

   if not exists (select * from Presentacion where Nombre = @Nombre AND Cantidad = @Cantidad And Id_Unidad = @Id_Unidad)
    begin
   insert into Presentacion(Nombre, Cantidad, Id_Unidad, FactorUnidad)values 
                     (@Nombre, @Cantidad, @Id_Unidad, @FactorUnidad)
     set @Id_Resultado = SCOPE_IDENTITY()

  end
  else 
    set @Mensaje = 'Esta Presentación ya se encuentra registrada'
end


go

--PROCEDIMIENTO PARA EDITAR UNA PRESENTACIÓN

CREATE PROC PS_EDITARPRESENTACION(
@Id_Presentacion int,
@Nombre varchar (80),
@Cantidad decimal (10,2),
@Id_Unidad int, 
@FactorUnidad varchar (50),
@Respuesta bit output,
@Mensaje varchar (500) output

)
as 

begin

set @Respuesta = 0
set @Mensaje = ''

if not exists (select * from Presentacion where Nombre = @Nombre AND Cantidad = @Cantidad And Id_Unidad = @Id_Unidad)
begin
UPDATE Presentacion SET 
Nombre =  @Nombre,
Cantidad =  @Cantidad ,
Id_Unidad= @Id_Unidad,
FactorUnidad = @FactorUnidad

WHERE Id_Presentacion = @Id_Presentacion

set @Respuesta = 1

end
else 
set @Mensaje = 'Esta presentación ya se encuentra registrada'


end

go


--PROCEDIMIENTO PARA ELIMINAR PRESENTACIÓN

Create PROC PS_ELIMINARPRESENTACION(
@Id_Presentacion int,
@Respuesta int output,
@Mensaje varchar (500) output

)
as 

begin

set @Respuesta = 0
set @Mensaje = ''
declare @paso bit = 1


IF EXISTS (SELECT * FROM Producto pro
            INNER JOIN Presentacion P ON P.Id_Presentacion = pro.Id_Presentacion
			WHERE P.Id_Presentacion = @Id_Presentacion
			)
			BEGIN
			set @paso = 0
			set @Respuesta = 0
            set @Mensaje = @Mensaje + 'No puede eliminar la presentación porque se encuentra registrado en un producto \n'

			END

			IF(@paso = 1)

			BEGIN 
			DELETE FROM Presentacion WHERE Id_Presentacion = @Id_Presentacion
			SET @Respuesta = 1

			END 
END
 go

--PROCEDIMEINTO ALMACENADO PARA REGISTRAR UNA BAJA

Alter PROC PS_REGISTRARBAJA(
    @Cantidad int,
    @Motivo nvarchar(255),
    @Id_Producto int,
    @Id_Resultado int output,
    @Mensaje varchar(500) output
)
AS
BEGIN
    SET @Id_Resultado = 0
    SET @Mensaje = ''

    -- Validar si hay suficiente stock
    IF EXISTS (SELECT 1 FROM Stock WHERE Id_Producto = @Id_Producto AND CantidadBase >= @Cantidad)
    BEGIN
        INSERT INTO BajaInventario (Cantidad, Motivo, Id_Producto)
        VALUES (@Cantidad, @Motivo, @Id_Producto)

        SET @Id_Resultado = SCOPE_IDENTITY()

        UPDATE Stock
        SET CantidadBase = CantidadBase - @Cantidad
        WHERE Id_Producto = @Id_Producto
    END
    ELSE
    BEGIN
        SET @Mensaje = 'No hay suficiente stock para realizar la baja'
    END
END
GO

--PROCEDIMIENTO ALMACENADO PARA EDITAR UNA BAJA
Create PROC PS_EDITARBAJA(
    @Id_Baja int,
    @Cantidad int,
    @Motivo nvarchar(255),
    @Id_Producto int,
    @Respuesta bit OUTPUT,
    @Mensaje varchar(500) OUTPUT
)
AS
BEGIN
    SET @Respuesta = 0
    SET @Mensaje = ''

    -- Buscar la baja actual
    DECLARE @CantidadAnterior int

    SELECT @CantidadAnterior = Cantidad
    FROM BajaInventario
    WHERE Id_Baja = @Id_Baja AND Id_Producto = @Id_Producto

    IF @CantidadAnterior IS NULL
    BEGIN
        SET @Mensaje = 'No se encontró la baja para el producto indicado'
        RETURN
    END

    -- Calcular la diferencia
    DECLARE @Diferencia int = @Cantidad - @CantidadAnterior

    -- Verificar si se puede aplicar la diferencia al stock
    IF EXISTS (
        SELECT 1 FROM Stock
        WHERE Id_Producto = @Id_Producto AND CantidadBase >= @Diferencia * CASE WHEN @Diferencia > 0 THEN 1 ELSE 0 END
    )
    BEGIN
        -- Actualizar baja
        UPDATE BajaInventario
        SET Cantidad = @Cantidad,
            Motivo = @Motivo
        WHERE Id_Baja = @Id_Baja AND Id_Producto = @Id_Producto

        -- Ajustar el stock
        UPDATE Stock
        SET CantidadBase = CantidadBase - @Diferencia
        WHERE Id_Producto = @Id_Producto

        SET @Respuesta = 1
        SET @Mensaje = 'Baja actualizada correctamente'
    END
    ELSE
    BEGIN
        SET @Mensaje = 'No hay suficiente stock para aplicar el cambio'
    END
END
GO


--PROCEDIMIENTO ALMACENADO PARA ELIMINAR UNA BAJA-- LA LOGICA SERIA QUE SI SE ELIMINA
--UNA BAJA EL PRODUCTO DEBE DE VOVER AL STOCK 

CREATE PROC PS_ELIMINARBAJA(
    @Id_Baja int,
    @Respuesta int OUTPUT,
    @Mensaje varchar(500) OUTPUT
)
AS
BEGIN
    SET @Respuesta = 0
    SET @Mensaje = ''
    DECLARE @paso bit = 1

    -- Verificamos que exista la baja
    IF EXISTS (
        SELECT * FROM BajaInventario WHERE Id_Baja = @Id_Baja
    )
    BEGIN
        -- Recuperamos los datos necesarios
        DECLARE @Id_Producto int
        DECLARE @Cantidad int

        SELECT @Id_Producto = Id_Producto,
               @Cantidad = Cantidad
        FROM BajaInventario
        WHERE Id_Baja = @Id_Baja

        -- Revertimos el descuento en el stock
        UPDATE Stock
        SET CantidadBase = CantidadBase + @Cantidad
        WHERE Id_Producto = @Id_Producto

        -- Eliminamos la baja
        DELETE FROM BajaInventario
        WHERE Id_Baja = @Id_Baja

        SET @Respuesta = 1
        SET @Mensaje = 'Baja eliminada correctamente y stock restaurado'
    END
    ELSE
    BEGIN
        SET @paso = 0
        SET @Mensaje = 'No se encontró la baja que desea eliminar'
    END
END
GO



/*PROCESO PARA REGISTRAR UNA COMPRA */

CREATE TYPE [dbo].[EDETALLECOMPRA] AS TABLE(
[Id_Producto] int NULL,
[Cantidad] int NULL,
[PrecioUnitario] decimal(18,2) NULL,
[SubTotal] decimal (18,2)NULL
)


Go

Create PROCEDURE SP_REGISTRARCOMPRA(
    @Id_Usuario int,
    @Id_Proveedor int,
    @Total decimal (10,2),
    @Numcompra VARCHAR(500),
    @DetalleCompra [EDETALLECOMPRA] READONLY, 
    @Respuesta BIT OUTPUT,
    @Mensaje VARCHAR(500) OUTPUT
)
AS
BEGIN 
    BEGIN TRY 
        DECLARE @Id_Compra INT = 0
        SET @Respuesta = 1
        SET @Mensaje = ''

        BEGIN TRANSACTION registro

        -- 1. Insertar la compra
        INSERT INTO Compra (Id_Usuario, Id_Proveedor, Total, Numcompra)
        VALUES (@Id_Usuario, @Id_Proveedor, @Total, @Numcompra)
        SET @Id_Compra = SCOPE_IDENTITY()

        -- 2. Insertar los detalles de la compra
        INSERT INTO DetalleCompra(Id_Compra, Id_Producto, Catidad, PrecioUnitario, SubTotal)
        SELECT @Id_Compra, Id_Producto, Cantidad, PrecioUnitario, SubTotal 
        FROM @DetalleCompra

        -- 3. Actualizar el Stock
        -- Utilizar MERGE para insertar si no existe, actualizar si existe
        MERGE Stock AS target
        USING (SELECT Id_Producto, Cantidad, PrecioUnitario FROM @DetalleCompra) AS source
        ON target.Id_Producto = source.Id_Producto
        WHEN MATCHED THEN
            UPDATE SET 
                target.CantidadBase = target.CantidadBase + source.Cantidad,
                target.PrecioC = source.PrecioUnitario
               
        WHEN NOT MATCHED THEN
            INSERT (Id_Producto, CantidadBase, PrecioC)
            VALUES (source.Id_Producto, source.Cantidad, source.PrecioUnitario);

        COMMIT TRANSACTION registro

    END TRY
    BEGIN CATCH
        SET @Respuesta = 0
        SET @Mensaje = ERROR_MESSAGE()
        ROLLBACK TRANSACTION registro
    END CATCH
END
GO


-- Proceso para registrar una venta

CREATE TYPE [dbo].[EDetalleVenta_Nuevo] AS TABLE(
    [Id_Producto] int NULL,
    [Cantidad] int NULL,
    [PrecioUnitario] decimal(18,2) NULL,
    [SubTotal] decimal(18,2) NULL
);
GO




Create PROC REGISTRARVENTA(  
    @Id_Usuario int,
    @Total decimal (18,2),
    @Detalleventa [EDetalleVenta_Nuevo] readonly,
    @NumVenta  varchar(500),
    @Descuento decimal (18,2),
    @Respuesta bit OUTPUT,
    @Mensaje varchar(500) OUTPUT
)
AS
BEGIN 
    BEGIN TRY
        DECLARE @id_Venta int = 0
        SET @Respuesta = 1
        SET @Mensaje = ''

        BEGIN TRANSACTION registro

        -- 1. Insertar la venta
        INSERT INTO Venta(Id_Usuario, Total, NumVenta, Descuento)
        VALUES (@Id_Usuario, @Total, @NumVenta, @Descuento)

        SET @id_Venta = SCOPE_IDENTITY()

        -- 2. Insertar los detalles de la venta
        INSERT INTO DetalleVenta(Id_Venta, Id_Producto, Catidad, PrecioUnitario, SubTotal)
        SELECT  @id_Venta, Id_Producto, Cantidad, PrecioUnitario, SubTotal
        FROM @Detalleventa 

        -- 3. Actualizar el Stock (reducir la cantidad vendida)
        UPDATE Stock
        SET CantidadBase = CantidadBase - dv.Cantidad
        FROM Stock s
        INNER JOIN @Detalleventa dv ON s.Id_Producto = dv.Id_Producto;

        -- 4. Actualizar el PrecioV en Stock usando MERGE
        MERGE Stock AS target
        USING (SELECT Id_Producto, PrecioUnitario FROM @Detalleventa) AS source
        ON target.Id_Producto = source.Id_Producto
        WHEN MATCHED THEN
            UPDATE SET
                target.PrecioV = source.PrecioUnitario; -- Actualizamos PrecioV con el PrecioUnitario de la venta


        COMMIT TRANSACTION registro

    END TRY
    BEGIN CATCH
        SET @Respuesta = 0
        SET @Mensaje = ERROR_MESSAGE()
        ROLLBACK TRANSACTION registro
    END CATCH
END
GO







----------------------------------------------------------------------------------


CREATE PROCEDURE ObtenerStockDisponible
    @Id_Producto INT
AS
BEGIN
    SET NOCOUNT ON;
    -- Selecciona la cantidad disponible (base) del producto, mostrando también el id y proveedor si quieres
    SELECT 
        Id_Stock,
        Id_Producto,
        Id_Proveedor,
        CantidadBase AS StockDisponible
    FROM Stock
    WHERE Id_Producto = @Id_Producto;
END



---------------------------------------

Create Proc SP_ReporteCompras(
@Fechainicio varchar(10),
@FechaFin Varchar(10),
@Id_Proveedor int 
)
as 
begin
SET DATEFORMAT dmy;
 
select 
Convert (Char(10), c.Fecha,103)[fecharegistro], c.Numcompra, c.Total,
u.Nombre[Usuario],
p.Nombre[NomProveedor] , p.Apellido[ApeProveedor],
a.Nombre[NomProducto],st.PrecioC,st.PrecioV,dc.Catidad, dc.SubTotal,
ca.Nombre[nomSubCategoria],
co.Nombre[NomColor],
ma.Nombre[NomMarca]
 from Compra c
inner join Usuario u on u.Id_Usuario = c.Id_Usuario
inner join Proveedor p on p.Id_Proveedor = c.Id_Proveedor
inner join DetalleCompra dc on dc.Id_Compra = c.Id_Compra
inner join Producto po on po.Id_Producto = dc.Id_Producto
inner join Articulo a on a.Id_Articulo = po.Id_Articulo
inner join SubCategoria ca on ca.Id_SubCat = po.Id_SubCat
inner join Color co on co.Id_Color = po.Id_Color
inner join Marca ma on ma.Id_Marca = po.Id_Marca
inner join Stock st on st.Id_Producto = po.Id_Producto
where CONVERT(date, c.Fecha) between @Fechainicio and @FechaFin
and p.Id_Proveedor = iif(@Id_Proveedor =0, p.Id_Proveedor,@Id_Proveedor)
end


-------------------------------------------------------------------------------------

Create Proc SP_ReporteVentas(
@Fechainicio varchar(10),
@FechaFin Varchar(10)
)
as 
begin
SET DATEFORMAT dmy;
 
select 
Convert (Char(10), v.Fecha,103)[fecharegistro], v.NumVenta, v.Total,
u.Nombre[Usuario],
a.Nombre[NomProducto],st.PrecioC,st.PrecioV,dv.Catidad, dv.SubTotal,
ca.Nombre[nomSubCategoria],
co.Nombre[NomColor],
ma.Nombre[NomMarca]
 from Venta v
inner join Usuario u on u.Id_Usuario = v.Id_Usuario
inner join DetalleVenta dv on dv.Id_Venta = v.Id_Venta
inner join Producto po on po.Id_Producto = dv.Id_Producto
inner join Articulo a on a.Id_Articulo = po.Id_Articulo
inner join SubCategoria ca on ca.Id_SubCat = po.Id_SubCat
inner join Color co on co.Id_Color = po.Id_Color
inner join Marca ma on ma.Id_Marca = po.Id_Marca
inner join Stock st on st.Id_Producto = po.Id_Producto
where CONVERT(date, v.Fecha) between @Fechainicio and @FechaFin
end

