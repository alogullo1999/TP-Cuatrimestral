

use master 
go
create database HELADERIA_DB
go
use HELADERIA_DB
go


CREATE TABLE Clientes (
    IdCliente INT PRIMARY KEY IDENTITY(1,1),
    Nombre VARCHAR(50) NOT NULL,              
    Apellido VARCHAR(50) NOT NULL,            
    Dni VARCHAR(20) UNIQUE NOT NULL,          
    Email VARCHAR(100),                       
    Ciudad VARCHAR(50)                        
);


CREATE TABLE Empleados (
    IdEmpleado INT PRIMARY KEY IDENTITY(1,1),
	Usuario VARCHAR(50) UNIQUE NOT NULL,
    Nombre VARCHAR(50) NOT NULL,             
    Apellido VARCHAR(50) NOT NULL,           
    Dni VARCHAR(20) UNIQUE NOT NULL,                              
);


CREATE TABLE Proveedores (
    IdProveedor INT PRIMARY KEY IDENTITY(1,1),  
    Nombre VARCHAR(50) NOT NULL,                
    Email VARCHAR(100),                         
    Dni VARCHAR(20) UNIQUE NOT NULL,      
	Entrega INT NOT NULL, 


);



create table Imagenes(
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
    Cantidad DECIMAL(10,3) NOT NULL,           
    IdMarca INT NOT NULL,                      
	IdProveedor INT NOT NULL,

);



CREATE TABLE DetalleVentas (
    IdVenta INT PRIMARY KEY IDENTITY(1,1),    
    FechaVenta DATETIME NOT NULL,             
    Estado VARCHAR(20) NOT NULL,              
    IdEmpleado INT NOT NULL,                  
    IdCliente INT NOT NULL,                   
    IdProducto INT NOT NULL,                       
    PrecioUnitario DECIMAL(10,2) NOT NULL,    
    TotalVenta AS (Cantidad * PrecioUnitario),
    Sabores INT NOT NULL,
 
);

CREATE TABLE Stock (
    IdInventario INT IDENTITY(1,1) PRIMARY KEY,
    IdProducto INT NOT NULL,                   
    Cantidad INT NOT NULL,                     
    FechaActualizacion DATETIME NOT NULL DEFAULT GETDATE(),
    CONSTRAINT FK_Inventario_Productos FOREIGN KEY (IdProducto) REFERENCES Productos(IdProducto)
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

CREATE TABLE Categorias(
    IdCategoria INT PRIMARY KEY IDENTITY(1,1), 
    Nombre VARCHAR(50) NOT NULL            
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


INSERT INTO Proveedores (Nombre, Email, Dni, Ciudad)
VALUES 
('Proveedor A', 'contacto@proveedora.com', '34567890', 'Mendoza'),
('Proveedor B', 'ventas@proveedorb.com', '65432109', 'La Plata');








INSERT INTO Vouchers (CodigoVoucher, IdCliente, FechaCanje, IdProducto)
VALUES 
('VCH1234', 1, '2024-10-25 10:30:00', 1),
('VCH5678', 2, '2024-10-25 12:15:00', 2);



INSERT INTO DetalleVentas (FechaVenta, Estado, IdEmpleado, IdCliente, IdProducto, Cantidad, PrecioUnitario)
VALUES 
('2024-10-25 14:00:00', 'En curso', 1, 1, 1, 1.500, 45000.50),
('2024-10-25 15:30:00', 'En curso', 2, 2, 2, 0.800, 75000.99);




