UPDATE
  ventas.articulolistaprecio
SET
  preciolista = a.costounisoles
FROM almacen.inventariostock a
WHeRE a.idarticulo = articulolistaprecio.idarticulo
AND idlistaprecio = 7;


UPDATE
  ventas.articulolistaprecio
SET
  preciolista = a.costounidolares
FROM almacen.inventariostock a
WHeRE a.idarticulo = articulolistaprecio.idarticulo
AND idlistaprecio = 8

