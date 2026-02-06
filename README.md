
#Aplicacion web de pedidos

> codigo BackeEnd c# apiREST para ver y solicitar pedidos de productos por cliente
#Se utiliza codigo de proyecto base apiREST, empleando practicas de:
- [x] MVC
- [x] POO
- [x] SOLID
- [x] XUNIT

> :information_source: aun fatal agretar la tabla pedido y su funcionamiento

> codigo frontend Angular (Inconcluso) //nota actualizable
        -En proceso...

> codigo sql tablas (Cliente, Producto, Pedido)
> :warning: la creacion de las tablas sera mediante EF Migrador y SQL backup(EF emitio que no puede confiar el el certificado ssl)
    Tablas:

Cliente
- [x] Id, Nombre, Direccion

Producto
- [x] Id , NombreProducto, Cantidad, ValorUnitario

Pedido
- [ ] Id, CodigoProducto, Cantidad, Id_Cliente(llave Foranea)


![Servicios expuesto](img/1.png)
![EF base de datos](img/2.png)