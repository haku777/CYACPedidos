Create database PedidosSYAC

use PedidosSYAC

CREATE TABLE Usuarios (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Nombre NVARCHAR(100) NOT NULL,
    Direccion NVARCHAR(255)
);

CREATE TABLE Producto (
    Id INT PRIMARY KEY IDENTITY(1,1),
    NombreProducto NVARCHAR(100) NOT NULL,
    Cantidad INT,
    valorUnitario INT
);

CREATE TABLE Pedido (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Id_Producto INT, 
    Id_Cliente INT,
    Total INT,

    CONSTRAINT FK_Pedido_Usuario FOREIGN KEY (Id_Cliente) 
        REFERENCES Usuarios(Id),
        
    CONSTRAINT FK_Pedido_Producto FOREIGN KEY (Id_Producto) 
        REFERENCES Producto(Id)
);
