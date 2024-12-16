

use master 
go
create database HELADERIA_DB
go
use HELADERIA_DB
go



CREATE TABLE Categorias(
    IdCategoria INT PRIMARY KEY IDENTITY(1,1), 
    Nombre VARCHAR(50) NOT NULL            
);


CREATE TABLE Clientes (
    IdCliente INT PRIMARY KEY IDENTITY(1,1),
    Nombre VARCHAR(50) NOT NULL,              
    Apellido VARCHAR(50) NOT NULL,            
    Dni VARCHAR(20) UNIQUE NOT NULL,          
    Email VARCHAR(100),                       
    Ciudad VARCHAR(50)                        
);


CREATE TABLE DetalleCompras (
    FechaCompra DATETIME NOT NULL DEFAULT GETDATE(), 
    IdCompra INT IDENTITY(1,1) PRIMARY KEY,       
    IdProveedor INT NOT NULL,                    
    IdProducto INT NOT NULL,                     
    Cantidad INT NOT NULL,                         
    PrecioUnitario DECIMAL(10, 2) NOT NULL,        
    TotalCompra AS (Cantidad * PrecioUnitario) PERSISTED
);



CREATE TABLE DetalleVentas (
    IdVenta INT PRIMARY KEY IDENTITY(1,1),
    FechaVenta DATETIME NOT NULL,
    IdEmpleado INT NOT NULL,
    IdCliente INT NOT NULL,
    IdProducto INT NOT NULL,
    Cantidad DECIMAL(10,3) NOT NULL,
    PrecioUnitario DECIMAL(10,2) NOT NULL,
    TotalVenta AS (Cantidad * PrecioUnitario),
    Sabores INT NOT NULL,
    IdDetalleVenta INT NOT NULL
);

CREATE TABLE Empleados (
    IdEmpleado INT PRIMARY KEY IDENTITY(1,1),
    Usuario VARCHAR(50) UNIQUE NOT NULL,
    Nombre VARCHAR(50) NOT NULL,             
    Apellido VARCHAR(50) NOT NULL,           
    Dni VARCHAR(20) UNIQUE NOT NULL,                              
);


CREATE TABLE Imagenes(
	Id INT IDENTITY(1,1) not null,
	IdProducto INT not null,
	ImagenUrl VARCHAR(1000) not null
);


CREATE TABLE Marcas (
    IdMarca INT PRIMARY KEY IDENTITY(1,1), 
    Nombre VARCHAR(50) NOT NULL            
);

CREATE TABLE Productos (
    IdProducto INT PRIMARY KEY IDENTITY(1,1),  
    Codigo VARCHAR(50) NOT NULL,               
    Nombre VARCHAR(100) NOT NULL,              
    Precio DECIMAL(10,2) NOT NULL,             
    Descripcion VARCHAR(255),                            
    IdMarca INT NOT NULL,                      
    IdProveedor INT NOT NULL,
    Categoria INT NOT NULL

);


CREATE TABLE Proveedores (
    IdProveedor INT PRIMARY KEY IDENTITY(1,1),  
    Nombre VARCHAR(50) NOT NULL,                
    Email VARCHAR(100),                         
    Dni VARCHAR(20) UNIQUE NOT NULL,      
    Ciudad VARCHAR(50),  
    Telefono VARCHAR(15), 
);




CREATE TABLE Stock (
    IdInventario INT IDENTITY(1,1) PRIMARY KEY,
    IdProducto INT NOT NULL,                   
    Cantidad INT NOT NULL,                     
    FechaActualizacion DATETIME NOT NULL DEFAULT GETDATE(),
    CONSTRAINT FK_Inventario_Productos FOREIGN KEY (IdProducto) REFERENCES Productos(IdProducto)
);







CREATE TRIGGER ActualizarStockDespuesDeVenta
ON DetalleVentas
AFTER INSERT
AS
BEGIN
    SET NOCOUNT ON;

    -- Restar del stock la cantidad vendida
    UPDATE Stock
    SET Cantidad = Stock.Cantidad - i.Cantidad,
        FechaActualizacion = GETDATE()
    FROM Stock
    INNER JOIN inserted i ON Stock.IdProducto = i.IdProducto;

    -- Verificar que el stock no quede en negativo
    UPDATE Stock
    SET Cantidad = 0
    WHERE Cantidad < 0;
END;



CREATE TRIGGER ActualizarStockDespuesDeCompra
ON DetalleCompras
AFTER INSERT
AS
BEGIN
    SET NOCOUNT ON;

    -- Insertar en Stock si el producto no existe
    INSERT INTO Stock (IdProducto, Cantidad, FechaActualizacion)
    SELECT i.IdProducto, i.Cantidad, GETDATE()
    FROM inserted i
    WHERE NOT EXISTS (
        SELECT 1 FROM Stock s WHERE s.IdProducto = i.IdProducto
    );

    -- Actualizar el stock si el producto ya existe
    UPDATE Stock
    SET Cantidad = Stock.Cantidad + i.Cantidad,
        FechaActualizacion = GETDATE()
    FROM Stock
    INNER JOIN inserted i ON Stock.IdProducto = i.IdProducto;
END;


USE [HELADERIA_DB]
GO
/****** Object:  Trigger [dbo].[ValidarStock]    Script Date: 15/12/2024 21:08:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER TRIGGER [dbo].[ValidarStock]
ON [dbo].[DetalleVentas]
INSTEAD OF INSERT
AS
BEGIN
    SET NOCOUNT ON;

    IF EXISTS (
        SELECT 1
        FROM INSERTED i
        INNER JOIN Stock s ON i.IdProducto = s.IdProducto
        WHERE i.Cantidad > s.Cantidad
    )
    BEGIN

        RAISERROR('Stock insuficiente para realizar la venta.', 16, 1);
        ROLLBACK TRANSACTION;
        RETURN;
    END

  
    INSERT INTO DetalleVentas (IdDetalleVenta, FechaVenta, IdCliente, IdEmpleado, IdProducto, Sabores, Cantidad, PrecioUnitario)
    SELECT IdDetalleVenta, FechaVenta, IdCliente, IdEmpleado, IdProducto, Sabores, Cantidad, PrecioUnitario
    FROM INSERTED;

END;








INSERT INTO Clientes (Nombre, Apellido, Dni, Email, Ciudad)
VALUES 
('Juan', 'Pérez', '12345678', 'juan.perez@gmail.com', 'Buenos Aires'),
('Maria', 'Gonzalez', '87654321', 'maria.gonzalez@gmail.com', 'Córdoba');



INSERT INTO Empleados (Nombre, Apellido, Dni, Usuario)
VALUES 
('Carlos', 'López', '23456789', 'clopez'),
('Ana', 'Martínez', '98765432', 'amartinez');



INSERT INTO Marcas (Nombre)
VALUES 
('Freddo'),
('Grido'),
('Rapanui');

INSERT INTO Categoria (Nombre)
VALUES 
('Potes'),
('Helado'),
('Cucurucho'),
('Palito');



INSERT INTO Proveedores (Nombre, Email, Dni, Ciudad, Telefono)
VALUES 
('Proveedor A', 'contacto@proveedora.com', '34567890', 'Mendoza', 1167679898),
('Proveedor B', 'ventas@proveedorb.com', '65432109', 'La Plata', 1149925893),
('Diego Helado', 'diego@helados.com', '42023124', 'Flores', 1149434343);



INSERT INTO Productos (Codigo, Nombre, Precio, Descripcion, IdMarca, IdProveedor, Categoria)
VALUES 
('P001', '1Kg', 20000.00, '1 Kilo', 1, 2, 1),
('P002', '2Kg', 35000.00, '2 Kilos', 2, 1, 1),
('P003', '1/4Kg', 5000.00, '1/4Kg', 3, 2, 3),
('P004', '500g', 10000.00, '500g', 3, 1, 3),
('VAN', 'Vainilla', 0.00, 'Vainilla', 5, 3, 2),
('FRA', 'Fresa', 0.00, 'Fresa', 5, 3, 2),
('DUL', 'Dulce de Leche', 0.00, 'Dulce De Leche', 5, 3, 2),
('CHO', 'Chocolate', 0.00, 'Chocolate', 5, 3, 2);


INSERT INTO Imagenes (IdProducto, ImagenUrl)
VALUES 
(1, 'https://chio.com.ar/tienda/pehuajo/134-home_default/helado-artesanal-x-kilo.jpg'),
(4, 'https://http2.mlstatic.com/D_836707-MLA79992300581_102024-C.jpg'),
(5, 'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRpEafRUl_NYQaT6zkKklW75VcsCg3oXgXqlw&s'),
(8, 'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSousK1_gqcYqTjMIoXSTRRN6hkRywiYd_fTA&s');









