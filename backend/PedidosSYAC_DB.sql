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
select * from Estados
select * from Productos
select * from Pedidos
select * from ProductosXPedido

insert into Clientes (Identificacion,Nombre,Direccion)Values(123456789,'HAKU','DIR')
insert into Productos (Nombre,Cantidad,ValorUnitario)Values('Jabon',2,10)
insert into Productos (Nombre,Cantidad,ValorUnitario)Values('Shampo',2,30)
insert into Pedidos (Id_cliente,Id_Estado,ValorTotal)Values(1,1,80)
insert into ProductosXPedido (Id_pedido,Id_producto,Cantidad,ValorPorCantidad)Values(1,1,2,20)
insert into ProductosXPedido (Id_pedido,Id_producto,Cantidad,ValorPorCantidad)Values(1,2,2,60)



