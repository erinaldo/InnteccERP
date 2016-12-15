using System.Collections.Generic;
using System.Data;
using System.Linq;
using BusinessObjects;
using BusinessObjects.Entities;
using DataObjects.Dao.Core;
using ServiceStack.OrmLite;

namespace DataObjects
{
	public class CpcompraDao : Dao<Cpcompra>, ICpcompraDao
	{
	    public bool GuardarCpCompra(TipoMantenimiento tipoMantenimiento, Cpcompra entidadCab, List<VwCpcompradet> entidadDetList, List<VwEntradaalmacendet>  vwEntradaalmacendetListOrigen)
	    {
            using (var db = OrmLiteHelper.DbFactory.Open())
            {
                using (IDbTransaction trans = db.OpenTransaction(IsolationLevel.ReadCommitted))
                {
                    switch (tipoMantenimiento)
                    {
                        case TipoMantenimiento.Nuevo:
                            db.Save(entidadCab);
                            break;
                        case TipoMantenimiento.Modificar:
                            db.Update(entidadCab);
                            break;
                    }

                    if (entidadCab.Idcpcompra > 0)
                    {
                        foreach (var item in entidadDetList)
                        {
                            Cpcompradet cpcompradet = new Cpcompradet();

                            cpcompradet.Idcpcompradet = item.Idcpcompradet;
                            cpcompradet.Idcpcompra = entidadCab.Idcpcompra;
			                cpcompradet.Numeroitem = item.Numeroitem;
			                cpcompradet.Idarticulo = item.Idarticulo;
			                cpcompradet.Cantidad = item.Cantidad;
			                cpcompradet.Idunidadmedida = item.Idunidadmedida;
			                cpcompradet.Idimpuesto = item.Idimpuesto;
			                cpcompradet.Preciounitario = item.Preciounitario;
			                cpcompradet.Especificacion = item.Especificacion;
			                cpcompradet.Descuento1 = item.Descuento1;
			                cpcompradet.Descuento2 = item.Descuento2;
			                cpcompradet.Descuento3 = item.Descuento3;
			                cpcompradet.Descuento4 = item.Descuento4;
			                cpcompradet.Preciounitarioneto = item.Preciounitarioneto;
			                cpcompradet.Importetotal = item.Importetotal;
			                cpcompradet.Idcentrodecosto = item.Idcentrodecosto;
			                cpcompradet.Porcentajepercepcion = item.Porcentajepercepcion;
			                cpcompradet.Idarea = item.Idarea;
                            cpcompradet.Idproyecto = item.Idproyecto;
                            cpcompradet.Idordencompradet = item.Idordencompradet;
                            cpcompradet.Pesounitario = item.Pesounitario;
                            cpcompradet.Pesototal = item.Pesototal;
                            cpcompradet.Costounitario = item.Costounitario;
                            cpcompradet.Descuentoproveedorcosto = item.Descuentoproveedorcosto;
                            cpcompradet.Idtipoafectacionigv = item.Idtipoafectacionigv;
                            cpcompradet.Idordenserviciodet = item.Idordenserviciodet;
                            cpcompradet.Calcularitem = item.Calcularitem;

                            cpcompradet.Createdby = item.Createdby;
                            cpcompradet.Creationdate = item.Creationdate;
                            cpcompradet.Modifiedby = item.Modifiedby;
                            cpcompradet.Lastmodified = item.Lastmodified;
                            //Nuevo
                            if (item.Idcpcompradet  == 0 && item.DataEntityState != DataEntityState.Deleted)
                            {
                                db.Save(cpcompradet);
                                item.Idcpcompradet = cpcompradet.Idcpcompradet;
                            }

                            //Modificar
                            if (item.Idcpcompradet > 0 && item.DataEntityState == DataEntityState.Modified)
                            {
                                db.Update(cpcompradet);
                            }

                            //Eliminar
                            if (item.Idcpcompradet > 0 && item.DataEntityState == DataEntityState.Deleted)
                            {
                                db.DeleteById<Cpcompradet>(item.Idcpcompradet );
                            }
                        }

                        //Grabar referencia de entradas de almacen

                        if (vwEntradaalmacendetListOrigen != null)
                        {
                            foreach (var item in vwEntradaalmacendetListOrigen)
                            {
                                Entradaalmacendetitemcpcompradet entradaalmacendetitemcpcompradet = new Entradaalmacendetitemcpcompradet();
                                entradaalmacendetitemcpcompradet.Identradaalmacendet = item.Identradaalmacendet;
                                entradaalmacendetitemcpcompradet.Cantidadimportada = item.Cantidad;
                                entradaalmacendetitemcpcompradet.Idcpcompra = entidadCab.Idcpcompra;
                                db.Save(entradaalmacendetitemcpcompradet);
                            }
                        }

                        //Verificar si hubo cambios en el orden de items
                        int cntNoOrden = 0;         
                        int nItemInicial = 0;
                        foreach (var item in entidadDetList.Where(x => x.DataEntityState != DataEntityState.Deleted))
                        {
                            if (nItemInicial + 1 != item.Numeroitem)
                            {
                                cntNoOrden++;
                            }
                            nItemInicial = item.Numeroitem;
                        }

                        if (cntNoOrden > 0)
                        {
                            int numeroItem = 1;
                            //Reenumerar y actualizar solo el nro de item
                            foreach (var item in entidadDetList.Where(x => x.DataEntityState != DataEntityState.Deleted)
                                )
                            {
                                item.Numeroitem = numeroItem;
                                Cpcompradet cpcompradet = new Cpcompradet
                                {
                                    Numeroitem = item.Numeroitem,
                                    Idcpcompradet = item.Idcpcompradet
                                };
                                db.Update<Cpcompradet>(new {cpcompradet.Numeroitem},
                                    p => p.Idcpcompradet == cpcompradet.Idcpcompradet);
                                numeroItem++;
                            }
                        }
                    }
                    trans.Commit();
                    return true;
                }
            }
	    }

	    public string SiguienteNumeroCpCompraPorProveedor(int idTipoCp, int idProveedor, string numeroserie)
	    {
            using (var db = OrmLiteHelper.DbFactory.Open())
            {
                var sgteCodigo = db.SqlScalar<int>(string.Format(@"SELECT Max(cast(numerocpcompra as integer)) FROM {0} 
                where idtipocp = {1} and idproveedor = {2} and seriecpcompra = '{3}'", NameRelation, idTipoCp, idProveedor, numeroserie)) + 1;
                return sgteCodigo.ToString("D8");
            }
	    }

	    public bool CpCompraTieneReferenciasRendicionCajaChica(int idTipoCp, int idProveedor, string numeroserie, string numero)
	    {
            using (var db = OrmLiteHelper.DbFactory.Open())
            {
                int cantidadReferencias = db.SqlScalar<int>(string.Format(@"SELECT count(idrendicioncajachicadet) FROM finanzas.rendicioncajachicadet 
                where idtipocp = {0} and idsocionegocio = {1} and serietipocp = '{2}' and numerotipocp = '{3}'", idTipoCp, idProveedor, numeroserie, numero));
                return cantidadReferencias >0;
            }  
	    }
	}
}
