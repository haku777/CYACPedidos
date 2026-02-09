Create database PedidosSYAC

use PedidosSYAC

CREATE TABLE Clientes (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Identificacion INT NOT NULL,
    Nombre NVARCHAR(100) NOT NULL,
    Direccion NVARCHAR(255)
);

CREATE TABLE Productos (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Nombre NVARCHAR(100) NOT NULL,
    Cantidad INT,
    valorUnitario INT
);

CREATE TABLE Estados (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Estado NVARCHAR(100) NOT NULL
);


CREATE TABLE Pedidos (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Id_Cliente INT,
    Id_Estado INT,
    ValorTotal INT,
    FechaPedido DATETIME DEFAULT GETDATE(),

    CONSTRAINT FK_Pedido_Usuario FOREIGN KEY (Id_Cliente) 
        REFERENCES Clientes(Id),
        
    CONSTRAINT FK_Pedido_Estado FOREIGN KEY (Id_Estado) 
        REFERENCES Estados(Id)
);

CREATE TABLE ProdutosXPedidos (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Id_Pedido INT,
    Id_Producto INT, 
    Cantidad INT,
    ValorPorCantidad INT,

    CONSTRAINT FK_ProdutoXPedido_Pedido FOREIGN KEY (Id_Pedido) 
        REFERENCES Pedidos(Id),

    CONSTRAINT FK_ProdutoXPedido_Usuario FOREIGN KEY (Id_Cliente) 
        REFERENCES Clientes(Id),

    CONSTRAINT FK_ProdutoXPedido_Producto FOREIGN KEY (Id_Producto) 
        REFERENCES Productos(Id)
);

select * from Clientes
select * from Productos
select * from Estados
select * from Pedidos
