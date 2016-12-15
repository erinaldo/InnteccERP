using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using BusinessObjects;
using BusinessObjects.Entities;
using DataObjects.Dao.Core;
using ServiceStack.OrmLite;
using Utilities;

namespace DataObjects
{
	public class MantenimientoDao : Dao<Mantenimiento>, IMantenimientoDao
	{
	    
        public bool GuardarMantenimiento(TipoMantenimiento tipoMantenimiento, Mantenimiento entidadCab, List<Mantenimientoimagen> entidadDetList, string rutaArchivosServidor)
	    {
            using (var db = OrmLiteHelper.DbFactory.Open())
            {
                using (IDbTransaction trans = db.OpenTransaction(IsolationLevel.ReadCommitted))
                {
                    switch (tipoMantenimiento)
                    {
                        case TipoMantenimiento.Nuevo:
                            db.Save(entidadCab);
                            if (entidadCab.Idmantenimiento > 0)
                            {
                                var tipocp = db.SingleById<Tipocp>(entidadCab.Idtipocp);
                                if (tipocp.Numeracionauto)
                                {
                                    db.Update<Tipocp>(new { Numerocorrelativocp = Convert.ToInt32(entidadCab.Numeromantenimiento) + 1 }, p => p.Idtipocp == tipocp.Idtipocp);
                                }
                            }
                            break;
                        case TipoMantenimiento.Modificar:
                            db.Update(entidadCab);
                            break;
                    }

                    if (entidadCab.Idmantenimiento > 0)
                    {
                        foreach (var item in entidadDetList)
                        {
                            Mantenimientoimagen mantenimientoimagen = new Mantenimientoimagen();

                            mantenimientoimagen.Idmantenimientoimagen = item.Idmantenimientoimagen;
                            mantenimientoimagen.Idmantenimiento = entidadCab.Idmantenimiento;
                            mantenimientoimagen.Nombrearchivo = item.Nombrearchivo;
                            mantenimientoimagen.Comentario = item.Comentario;
                            mantenimientoimagen.Numeroitem = item.Numeroitem;
                            mantenimientoimagen.RutaArchivo = item.RutaArchivo;
         

                            //Nuevo
                            if (item.Idmantenimientoimagen == 0 && item.DataEntityState != DataEntityState.Deleted)
                            {
                                db.Save(mantenimientoimagen);
                                item.Idmantenimientoimagen = mantenimientoimagen.Idmantenimientoimagen;

                                if (item.Idmantenimientoimagen > 0)
                                {
                                    string fileName = Path.GetFileName(mantenimientoimagen.RutaArchivo);
                                    string sourcePath = Path.GetDirectoryName(mantenimientoimagen.RutaArchivo);
                                    string targetPath = Path.Combine(rutaArchivosServidor, ConstantesGlobales.RutaArchivoEquipoMaquinaria, entidadCab.Idmantenimiento.ToString());

                                    if (!Directory.Exists(targetPath))
                                    {
                                        Directory.CreateDirectory(targetPath);
                                    }
                                    // Use Path class to manipulate file and directory paths.
                                    if (fileName != null && sourcePath != null)
                                    {
                                        string sourceFile = Path.Combine(sourcePath, fileName);
                                        string fileExtension = Path.GetExtension(sourceFile);
                                        string destFile = Path.Combine(targetPath, string.Format("{0}{1}", item.Idmantenimientoimagen, fileExtension));
                                        if (Directory.Exists(targetPath))
                                        {
                                            File.Copy(sourceFile, destFile, true);                                            
                                        }
                                    }
                                }
                            }

                            //Modificar
                            if (item.Idmantenimientoimagen > 0 && item.DataEntityState == DataEntityState.Modified)
                            {
                                db.Update(mantenimientoimagen);


                                string fileName = Path.GetFileName(item.RutaArchivo);
                                string sourcePath = Path.GetDirectoryName(item.RutaArchivo);
                                string targetPath = Path.Combine(rutaArchivosServidor, ConstantesGlobales.RutaArchivoEquipoMaquinaria, entidadCab.Idmantenimiento.ToString());

                                //Solo si selecciono un archivo a reemplazar
                                if (fileName != null && sourcePath != null)
                                {
                                    //Borrar los archivos antes de reemplazar el archivo cuando se modificia
                                    string[] archivosTemp = Directory.GetFiles(targetPath, item.Idmantenimientoimagen + ".*");
                                    foreach (string archivo in archivosTemp)
                                    {
                                        try
                                        {
                                            if (File.Exists(archivo))                                            
                                                File.Delete(archivo);                                            
                                        }
                                        catch (Exception ex)
                                        {
                                            Console.WriteLine(ex.Message);
                                        }

                                    }
                                    if (!Directory.Exists(targetPath))
                                    {
                                        Directory.CreateDirectory(targetPath);
                                    }

                                    string sourceFile = Path.Combine(sourcePath, fileName);
                                    string fileExtension = Path.GetExtension(sourceFile);
                                    string destFile = Path.Combine(targetPath, string.Format("{0}{1}", item.Idmantenimientoimagen, fileExtension));

                                    if (Directory.Exists(targetPath))
                                    {
                                        File.Copy(sourceFile, destFile, true);
                                    }
                                }
                            }

                            //Eliminar
                            if (item.Idmantenimientoimagen > 0 && item.DataEntityState == DataEntityState.Deleted)
                            {
                                db.DeleteById<Mantenimientoimagen>(item.Idmantenimientoimagen);

                                string fileName = item.Idmantenimientoimagen + Path.GetExtension(item.Nombrearchivo);
                                string sourcePath = Path.Combine(rutaArchivosServidor, ConstantesGlobales.RutaArchivoEquipoMaquinaria, entidadCab.Idmantenimiento.ToString());

                                // Eliminar archivo
                                if (sourcePath != null)
                                {
                                    string sourceFile = Path.Combine(sourcePath, fileName);
                                    
                                    if (File.Exists(sourceFile))
                                    {
                                        File.Delete(sourceFile);
                                    }
                                }
                            }
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
                        foreach (var item in entidadDetList.Where(x => x.DataEntityState != DataEntityState.Deleted))
                        {
                            item.Numeroitem = numeroItem;
                            Mantenimientoimagen mantenimientoimagen = new Mantenimientoimagen
                            {
                                Numeroitem = item.Numeroitem,
                                Idmantenimientoimagen = item.Idmantenimientoimagen
                            };
                            db.Update<Mantenimientoimagen>(new { mantenimientoimagen.Numeroitem },
                                p => p.Idmantenimientoimagen == mantenimientoimagen.Idmantenimientoimagen);
                            numeroItem++;
                        }
                    }

                    trans.Commit();
                    return true;
                }
            }	        
	    }
	}
}
