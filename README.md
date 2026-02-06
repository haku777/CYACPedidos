
#Aplicacion web de pedidos

> codigo BackeEnd c# apiREST para ver y solicitar pedidos de productos por cliente
#Se utiliza codigo de proyecto base apiREST, empleando practicas de:
- [x]MVC
- [x]POO
- [x]SOLID
- [x]XUNIT

###Nota: aun fatal agretar la tabla pedido y su funcionamiento

> codigo frontend Angular (Inconcluso) //nota actualizable
        -En proceso...

> codigo sql tablas (Cliente, Producto, Pedido)
#la creacion de las tablas sera mediante EF Migrador y SQL backup
    Tablas:

Cliente
- [x]Id, Nombre, Direccion

Producto
- [x]Id , NombreProducto, Cantidad, ValorUnitario

Pedido
- []Id, CodigoProducto, Cantidad, Id_Cliente(llave Foranea)


![Servicios expuesto](img/1.PNG)
![EF base de datos](img/2.PNG)