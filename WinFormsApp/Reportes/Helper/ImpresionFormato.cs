using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Windows.Forms;
using ActionService;
using BusinessObjects.Entities;
using DbNetLink.Data;
using DevExpress.XtraEditors;
using DevExpress.XtraReports.UI;
using FastReport;
using Utilities;

namespace WinFormsApp
{
    public class ImpresionFormato
    {
        static readonly IService Service = new Service();

        static readonly HelperDb HelperDb = new HelperDb();
        public static List<VwSucursal> VwSucursalList { get; set; }
        public ImpresionFormato()
        {
            if (VwSucursalList == null)
            {
                VwSucursalList = Service.GetAllVwSucursal(x => x.Idsucursal == SessionApp.SucursalSel.Idsucursal);
            }            
        }
        public void FormatoRequerimiento(Requerimiento requerimiento)
        {

            var tipocp = Service.GetTipocp(x => x.Idtipocp == requerimiento.Idtipocp);
            const string nameRelation = "compras.vwrequerimientoimpresion";
            string whereList = string.Format("idrequerimiento = {0} and aprobado = '1'", requerimiento.Idrequerimiento);
            const string ordersList = "numeroitem";
            const string fieldsList = "*";
            DataTable dt = HelperDb.SqlConsulta(nameRelation, whereList, ordersList, fieldsList);
            if (string.IsNullOrEmpty(tipocp.Nombrereporte))
            {
                XtraMessageBox.Show("No se asignó un formato de impresión", "Atención", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
                return;
            }
            Report report = new Report();
            string nameReporte = FilesHelper.FindingFileName(Application.StartupPath, string.Format("Reportes\\Compras\\{0}", tipocp.Nombrereporte.Trim()));
            report.Load(nameReporte);
            report.RegisterData(dt, "Requerimiento");
            report.RegisterData(VwSucursalList, "emp");
            ReportHelper1 reportHelper1 = new ReportHelper1(report);
            reportHelper1.ShowDialog();
        }
        public void FormatoOrdenDeCompra(Ordencompra ordencompra)
        {
            var tipocp = Service.GetTipocp(x => x.Idtipocp == ordencompra.Idtipocp);

            const string nameRelation = "compras.vwordencompraimpresion";
            string whereList = string.Format("idordencompra = {0} and calcularitem = '1'", ordencompra.Idordencompra);
            const string ordersList = "numeroitem";
            const string fieldsList = "*";

            DataTable dt = HelperDb.SqlConsulta(nameRelation, whereList, ordersList, fieldsList);

            if (string.IsNullOrEmpty(tipocp.Nombrereporte))
            {
                XtraMessageBox.Show("No se asignó un formato de impresión", "Atención", MessageBoxButtons.OK,
                MessageBoxIcon.Exclamation);
                return;
            }

            var report = new Report();
            string nameReporte = FilesHelper.FindingFileName(Application.StartupPath, string.Format("Reportes\\Compras\\{0}", tipocp.Nombrereporte.Trim()));

            report.Load(nameReporte);
            report.RegisterData(dt, "oc");
            report.RegisterData(VwSucursalList, "emp");

            ReportHelper1 reportHelper1 = new ReportHelper1(report);
            reportHelper1.ShowDialog();
        }
        public void FormatoOrdenDeServicio(Ordenservicio ordenservicio)
        {
            var tipocp = Service.GetTipocp(x => x.Idtipocp == ordenservicio.Idtipocp);

            const string nameRelation = "compras.vwordenservicioimpresion";
            string whereList = string.Format("idordenservicio = {0}", ordenservicio.Idordenservicio);
            const string ordersList = "numeroitem";
            const string fieldsList = "*";

            DataTable dt = HelperDb.SqlConsulta(nameRelation, whereList, ordersList, fieldsList);

            if (string.IsNullOrEmpty(tipocp.Nombrereporte))
            {
                XtraMessageBox.Show("No se asignó un formato de impresión", "Atención", MessageBoxButtons.OK,
                MessageBoxIcon.Exclamation);
                return;
            }

            var report = new Report();
            string nameReporte = FilesHelper.FindingFileName(Application.StartupPath, string.Format("Reportes\\Compras\\{0}", tipocp.Nombrereporte.Trim()));

            report.Load(nameReporte);
            report.RegisterData(dt, "oc");
            report.RegisterData(VwSucursalList, "emp");

            ReportHelper1 reportHelper1 = new ReportHelper1(report);
            reportHelper1.ShowDialog();
        }
        public void FormatoCotizacionCliente(int idcotizacioncliente)
        {
            Cotizacioncliente cotizacioncliente = Service.GetCotizacioncliente(idcotizacioncliente);
            var tipocp = Service.GetTipocp(x => x.Idtipocp == cotizacioncliente.Idtipocp);
            const string nameRelation = "ventas.vwcotizacionclienteimpresion";
            string whereList = string.Format("idcotizacioncliente = {0}", cotizacioncliente.Idcotizacioncliente);
            const string ordersList = "numeroitem";
            const string fieldsList = "*";

            DataTable dt = HelperDb.SqlConsulta(nameRelation, whereList, ordersList, fieldsList);

            if (string.IsNullOrEmpty(tipocp.Nombrereporte))
            {
                XtraMessageBox.Show("No se asignó un formato de impresión", "Atención", MessageBoxButtons.OK,
                MessageBoxIcon.Exclamation);
                return;
            }

            var report = new Report();
            string nameReporte = FilesHelper.FindingFileName(Application.StartupPath, string.Format("Reportes\\Ventas\\{0}", tipocp.Nombrereporte.Trim()));

            report.Load(nameReporte);
            report.RegisterData(dt, "cot");
            report.RegisterData(VwSucursalList, "emp");
            ReportHelper1 reportHelper1 = new ReportHelper1(report);
            reportHelper1.ShowDialog();


        }
        public void FormatoCpVenta(Cpventa cpventa)
        {
            Tipocp tipocp = Service.GetTipocp(x => x.Idtipocp == cpventa.Idtipocp);

            const string nameRelation = "ventas.vwcpventaimpresion";
            string whereList = string.Format("idcpventa = {0}", cpventa.Idcpventa);
            const string ordersList = "numeroitem";
            const string fieldsList = "*";

            DataTable dt = HelperDb.SqlConsulta(nameRelation, whereList, ordersList, fieldsList);
            dt.TableName = "cp";

            if (string.IsNullOrEmpty(tipocp.Nombrereporte))
            {
                XtraMessageBox.Show("No se asignó un formato de impresión", "Atención", MessageBoxButtons.OK,
                MessageBoxIcon.Exclamation);
                return;
            }

            VwCpventa vwCpventa = Service.GetVwCpventa(cpventa.Idcpventa);
            
            //ImporteLetras
            string importeDocumentoLetra = string.Format("{0} {1}", UtilityReport.ToNumberLetters(cpventa.Totaldocumento.ToString(CultureInfo.InvariantCulture)), vwCpventa.Nombretipomoneda);

            string nameReporte = FilesHelper.FindingFileName(Application.StartupPath, string.Format("Reportes\\Ventas\\{0}", tipocp.Nombrereporte.Trim()));

            switch (tipocp.Tiporeporteador)
            {
                case 0: //FastReport
                    Report fastReport = new Report();

                    fastReport.Load(nameReporte);
                    fastReport.RegisterData(dt, "cp");
                    fastReport.RegisterData(VwSucursalList, "emp");
                    fastReport.SetParameterValue("ImporteDocLetras", importeDocumentoLetra);

                    ReportHelper1 reportHelper1 = new ReportHelper1(fastReport);
                    reportHelper1.ShowDialog();

                    break;
                case 1: //XtraReport

                    //XtraReport xtraReport = new XtraReport { DataSource = dt };
                    //xtraReport.LoadLayout(nameReporte);
                    //xtraReport.parameters["TotalDocumentoLetra"].Value = importeDocLetras;
                    //xtraReport.RequestParameters = false;
                    //xtraReport.ShowPreviewDialog();

                   //Parametros
                    object[] parametrosReporte = {
                    importeDocumentoLetra
                    };

                    ReportHelper2 reportHelper2 = new ReportHelper2(nameReporte, dt, parametrosReporte,"ComprobanteVenta");
                    reportHelper2.ShowDialog();

                    //XRDesignFormEx xRDesignFormEx = new XRDesignFormEx();
                    //xRDesignFormEx.OpenReport(report);
                    //xRDesignFormEx.DesignPanel.FileName = nameReporte;
                    //xRDesignFormEx.ShowDialog();

                    break;
            }
        }
        public void FormatoCpVentaImpresora(int idCpVenta)
        {
            const string nameRelation = "ventas.vwcpventaimpresion";
            string whereList = string.Format("idcpventa = {0}", idCpVenta);
            const string ordersList = "numeroitem";
            const string fieldsList = "*";

            DataTable dtCpVenta = HelperDb.SqlConsulta(nameRelation, whereList, ordersList, fieldsList);
            dtCpVenta.TableName = "cp";

            DataRow row = dtCpVenta.Rows[0];
            
            string nombreArchivoReporte = row["nombrereporte"].ToString();
            decimal totalDocumento = Convert.ToDecimal(row["totaldocumento"]);
            string nombreTipoMoneda = row["nombretipomoneda"].ToString();
            string nombreReporte = string.Format("{0} {1}-{2}", row["nombretipoformato"].ToString().Trim(), row["seriecpventa"].ToString().Trim(), row["numerocpventa"].ToString().Trim());

            if (string.IsNullOrEmpty(nombreArchivoReporte))
            {
                XtraMessageBox.Show("No se asignó un formato de impresión", "Atención", MessageBoxButtons.OK,
                MessageBoxIcon.Exclamation);
                return;
            }

            string importeDocumentoLetra = string.Format("{0} {1}", UtilityReport.ToNumberLetters(totalDocumento.ToString(CultureInfo.InvariantCulture)), nombreTipoMoneda);
            string nombreArchivoImpresion = FilesHelper.FindingFileName(Application.StartupPath, string.Format("Reportes\\Ventas\\{0}", nombreArchivoReporte));

            object[] parametrosReporte = {
                    importeDocumentoLetra
                    };

            XtraReportCustom report = PrepareReport(dtCpVenta, parametrosReporte, nombreArchivoImpresion, nombreReporte);
            report.PrintDialog();
        }
        private XtraReportCustom PrepareReport(DataTable dataSource, object[] parameters, string fileName, string nameReport)
        {
            XtraReportCustom report = new XtraReportCustom
            {
                DataSource = dataSource,
                DisplayName = string.IsNullOrEmpty(nameReport) ? "Reporte" : nameReport,
                Name = nameReport,
                NameDocument = nameReport
            };
            report.LoadLayout(fileName);

            //Asignar parametros
            if (report.Parameters != null && parameters != null)
            {
                for (var i = 0; i < report.Parameters.Count; i++)
                {
                    report.Parameters[i].Value = parameters[i];
                }
            }
            report.RequestParameters = false;
            report.ShowPrintMarginsWarning = false;
            return report;
        }
        public void FormatoCotizacionPrv(Cotizacionprv cotizacionprv)
        {
            var tipocp = Service.GetTipocp(x => x.Idtipocp == cotizacionprv.Idtipocp);

            const string nameRelation = "compras.vwcotizacionprvimpresion";
            string whereList = string.Format("idcotizacionprv = {0}", cotizacionprv.Idcotizacionprv);
            const string ordersList = "numeroitem";
            const string fieldsList = "*";

            DataTable dt = HelperDb.SqlConsulta(nameRelation, whereList, ordersList, fieldsList);

            if (string.IsNullOrEmpty(tipocp.Nombrereporte))
            {
                XtraMessageBox.Show("No se asignó un formato de impresión", "Atención", MessageBoxButtons.OK,
                MessageBoxIcon.Exclamation);
                return;
            }

            var report = new Report();


            string nameReporte = FilesHelper.FindingFileName(Application.StartupPath, string.Format("Reportes\\Compras\\{0}", tipocp.Nombrereporte.Trim()));
            report.Load(nameReporte);
            report.RegisterData(dt, "ctp");
            report.RegisterData(VwSucursalList, "emp");

            ReportHelper1 reportHelper1 = new ReportHelper1(report);
            reportHelper1.ShowDialog();
        }
        public void FormatoValorizacion(Valorizacion valorizacion)
        {

            List<VwValorizacionegreso> vwValorizacionegresoList =
                      Service.GetAllVwValorizacionegreso(x => x.Idvalorizacion == valorizacion.Idvalorizacion);

            var tipocp = Service.GetTipocp(x => x.Idtipocp == valorizacion.Idtipocp);

            const string nameRelation = "maquinaria.vwvalorizacionimpresion";
            string whereList = string.Format("idvalorizacion = {0}", valorizacion.Idvalorizacion);
            const string ordersList = "numeroitem";
            const string fieldsList = "*";

            DataTable dt = HelperDb.SqlConsulta(nameRelation, whereList, ordersList, fieldsList);

            if (string.IsNullOrEmpty(tipocp.Nombrereporte))
            {
                XtraMessageBox.Show("No se asignó un formato de impresión", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            Report report = new Report();


            string nameReporte = FilesHelper.FindingFileName(Application.StartupPath, string.Format("Reportes\\Ventas\\{0}", tipocp.Nombrereporte.Trim()));
            report.Load(nameReporte);
            report.RegisterData(dt, "valorizacion");


            report.RegisterData(vwValorizacionegresoList, "valorizaegreso");
            report.RegisterData(VwSucursalList, "emp");

            ReportHelper1 reportHelper1 = new ReportHelper1(report);
            reportHelper1.ShowDialog();
        }
        public void FormatoValorizacionProveedor(Valorizacionproveedor valorizacion)
        {

            List<VwValorizacionegresoproveedor> vwValorizacionegresoList =
                      Service.GetAllVwValorizacionegresoproveedor(x => x.Idvalorizacionproveedor == valorizacion.Idvalorizacionproveedor);

            var tipocp = Service.GetTipocp(x => x.Idtipocp == valorizacion.Idtipocp);

            const string nameRelation = "maquinaria.vwvalorizacionproveedorimpresion";
            string whereList = string.Format("idvalorizacionproveedor = {0}", valorizacion.Idvalorizacionproveedor);
            const string ordersList = "numeroitem";
            const string fieldsList = "*";

            DataTable dt = HelperDb.SqlConsulta(nameRelation, whereList, ordersList, fieldsList);

            if (string.IsNullOrEmpty(tipocp.Nombrereporte))
            {
                XtraMessageBox.Show("No se asignó un formato de impresión", "Atención", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
                return;
            }

            Report report = new Report();


            string nameReporte = FilesHelper.FindingFileName(Application.StartupPath, string.Format("Reportes\\Ventas\\{0}", tipocp.Nombrereporte.Trim()));
            report.Load(nameReporte);
            report.RegisterData(dt, "valorizacion");
            report.RegisterData(vwValorizacionegresoList, "valorizaegreso");
            report.RegisterData(VwSucursalList, "emp");

            ReportHelper1 reportHelper1 = new ReportHelper1(report);
            reportHelper1.ShowDialog();
        }
        public void FormatoCuadroComparativoPrv(Cuadrocomparativo cuadrocomparativoPrv)
        {
            Tipocp tipocp = Service.GetTipocp(x => x.Idtipocp == cuadrocomparativoPrv.Idtipocp);

            string nameRelation;
            string whereList;
            string ordersList;
            string fieldsList;

            //Obtener datable de cuadro comparativo
            nameRelation = "compras.vwcuadrocomparativo";
            whereList = string.Format("idcuadrocomparativo = {0}", cuadrocomparativoPrv.Idcuadrocomparativo);
            ordersList = string.Empty;
            fieldsList = "*";
            DataTable dtCcCab = HelperDb.SqlConsulta(nameRelation, whereList, ordersList, fieldsList);
            //

            //Obtener datable de cuadro comparativo proveedores
            nameRelation = "compras.vwcuadrocomparativoprv";
            whereList = string.Format("idcuadrocomparativo = {0}", cuadrocomparativoPrv.Idcuadrocomparativo);
            ordersList = "idcuadrocomparativoprv";
            fieldsList = "*";
            DataTable dtCcPrv = HelperDb.SqlConsulta(nameRelation, whereList, ordersList, fieldsList);
            //

            //Obtener datatale de cuadro comparativo articulo
            nameRelation = "compras.vwcuadrocomparativoarticulo";
            whereList = string.Format("idcuadrocomparativo = {0}", cuadrocomparativoPrv.Idcuadrocomparativo);
            ordersList = "numeroitem";
            fieldsList = "*";
            DataTable dtCcItems = HelperDb.SqlConsulta(nameRelation, whereList, ordersList, fieldsList);
            //

            //Obtener datatale de cuadro comparativo articulo aux
            nameRelation = "compras.vwcuadrocomparativoarticulo";
            whereList = string.Format(@"idcuadrocomparativo = {0} GROUP BY 
                         idproyecto,
                         codigoproyecto,
                         nombreproyecto,
                         numeroitem,
                         idarticulo,
                         codigoarticulo,
                         nombrearticulo,
                         especificacion,
                         abrunidadmedida,
                         nombremarca,
                         cantidad,
                         idcotizacionprvdet",
                        cuadrocomparativoPrv.Idcuadrocomparativo);
            ordersList = "idcotizacionprvdet";
            fieldsList = @"idproyecto,codigoproyecto,nombreproyecto,numeroitem,
                         idarticulo,codigoarticulo,nombrearticulo,especificacion, abrunidadmedida,
                         nombremarca,cantidad,idcotizacionprvdet";
            DataTable dtCcItemsAgrupado = HelperDb.SqlConsulta(nameRelation, whereList, ordersList, fieldsList);
            //

            DataTable dtCc = new DataTable();

            dtCc.Columns.Add("idcuadrocomparativo", typeof(int));
            dtCc.Columns.Add("serienumerocc", typeof(string));
            dtCc.Columns.Add("fechaemisioncc", typeof(DateTime));
            dtCc.Columns.Add("serienumerocotizacion", typeof(string));
            dtCc.Columns.Add("fechacotizacion", typeof(DateTime));

            dtCc.Columns.Add("idproyecto", typeof(int));
            dtCc.Columns.Add("codigoproyecto", typeof(string));
            dtCc.Columns.Add("nombreproyecto", typeof(string));

            dtCc.Columns.Add("ccanulado", typeof(bool));
            dtCc.Columns.Add("observacioncc", typeof(string));
            dtCc.Columns.Add("idcotizacionprvdet", typeof(int));

            dtCc.Columns.Add("numeroitem", typeof(int));
            dtCc.Columns.Add("idarticulo", typeof(int));
            dtCc.Columns.Add("codigoarticulo", typeof(string));
            dtCc.Columns.Add("nombrearticulo", typeof(string));
            dtCc.Columns.Add("itemespecificacion", typeof(string));
            dtCc.Columns.Add("abrunidadmedida", typeof(string));
            dtCc.Columns.Add("nombremarca", typeof(string));
            dtCc.Columns.Add("cantidad", typeof(decimal));

            dtCc.Columns.Add("ruc1", typeof(string));
            dtCc.Columns.Add("nombreprv1", typeof(string));
            dtCc.Columns.Add("ciudadprv1", typeof(string));
            dtCc.Columns.Add("telefonoprv1", typeof(string));
            dtCc.Columns.Add("celularprv1", typeof(string));
            dtCc.Columns.Add("preciounitarionetoprv1", typeof(decimal));
            dtCc.Columns.Add("justificacionprv1", typeof(string));
            dtCc.Columns.Add("buenapro1", typeof(bool));

            dtCc.Columns.Add("ruc2", typeof(string));
            dtCc.Columns.Add("nombreprv2", typeof(string));
            dtCc.Columns.Add("ciudadprv2", typeof(string));
            dtCc.Columns.Add("telefonoprv2", typeof(string));
            dtCc.Columns.Add("celularprv2", typeof(string));
            dtCc.Columns.Add("preciounitarionetoprv2", typeof(decimal));
            dtCc.Columns.Add("justificacionprv2", typeof(string));
            dtCc.Columns.Add("buenapro2", typeof(bool));

            dtCc.Columns.Add("ruc3", typeof(string));
            dtCc.Columns.Add("nombreprv3", typeof(string));
            dtCc.Columns.Add("ciudadprv3", typeof(string));
            dtCc.Columns.Add("telefonoprv3", typeof(string));
            dtCc.Columns.Add("celularprv3", typeof(string));
            dtCc.Columns.Add("preciounitarionetoprv3", typeof(decimal));
            dtCc.Columns.Add("justificacionprv3", typeof(string));
            dtCc.Columns.Add("buenapro3", typeof(bool));

            dtCc.Columns.Add("ruc4", typeof(string));
            dtCc.Columns.Add("nombreprv4", typeof(string));
            dtCc.Columns.Add("ciudadprv4", typeof(string));
            dtCc.Columns.Add("telefonoprv4", typeof(string));
            dtCc.Columns.Add("celularprv4", typeof(string));
            dtCc.Columns.Add("preciounitarionetoprv4", typeof(decimal));
            dtCc.Columns.Add("justificacionprv4", typeof(string));
            dtCc.Columns.Add("buenapro4", typeof(bool));

            dtCc.Columns.Add("ruc5", typeof(string));
            dtCc.Columns.Add("nombreprv5", typeof(string));
            dtCc.Columns.Add("ciudadprv5", typeof(string));
            dtCc.Columns.Add("telefonoprv5", typeof(string));
            dtCc.Columns.Add("celularprv5", typeof(string));
            dtCc.Columns.Add("preciounitarionetoprv5", typeof(decimal));
            dtCc.Columns.Add("justificacionprv5", typeof(string));
            dtCc.Columns.Add("buenapro5", typeof(bool));

            //Variables
            DataRow drCcSel = dtCcCab.Rows[0];

            foreach (DataRow item in dtCcItemsAgrupado.Rows)
            {
                DataRow row = dtCc.NewRow();
                row["idcuadrocomparativo"] = drCcSel["idcuadrocomparativo"];
                row["serienumerocc"] = drCcSel["serienumerocc"];
                row["fechaemisioncc"] = drCcSel["fechaemision"];
                row["serienumerocotizacion"] = drCcSel["serienumerocotizacion"];
                row["fechacotizacion"] = drCcSel["fechacotizacion"];

                row["idproyecto"] = item["idproyecto"];
                row["codigoproyecto"] = item["codigoproyecto"];
                row["nombreproyecto"] = item["nombreproyecto"];

                row["ccanulado"] = drCcSel["anulado"];
                row["observacioncc"] = drCcSel["observacion"];

                row["idcotizacionprvdet"] = item["idcotizacionprvdet"];
                row["numeroitem"] = item["numeroitem"];
                row["idarticulo"] = item["idarticulo"];
                row["codigoarticulo"] = item["codigoarticulo"];
                row["nombrearticulo"] = item["nombrearticulo"];
                row["itemespecificacion"] = item["especificacion"];
                row["abrunidadmedida"] = item["abrunidadmedida"];
                row["nombremarca"] = item["nombremarca"];
                row["cantidad"] = item["cantidad"];

                dtCc.Rows.Add(row);
            }

            for (int i = 0; i < 7; i++)
            {
                DataRow drPrv = dtCcPrv.Rows[i];

                foreach (DataRow drItem in dtCcItems.Rows)
                {
                    if ((int)drItem["idcuadrocomparativoprv"] == (int)drPrv["idcuadrocomparativoprv"])
                    {
                        foreach (DataRow drCc in dtCc.Rows)
                        {
                            if ((int)drItem["idproyecto"] == (int)drCc["idproyecto"] &&
                                (int)drItem["idarticulo"] == (int)drCc["idarticulo"] &&
                                (int)drItem["idcotizacionprvdet"] == (int)drCc["idcotizacionprvdet"])
                            {
                                string columna1 = string.Format("{0}", i + 1);
                                string columna2 = string.Format("{0}", i + 1);
                                string columna3 = string.Format("{0}", i + 1);
                                string columna4 = string.Format("{0}", i + 1);
                                string columna5 = string.Format("{0}", i + 1);
                                string columna6 = string.Format("{0}", i + 1);
                                string columna7 = string.Format("{0}", i + 1);
                                string columna8 = string.Format("{0}", i + 1);

                                drCc["ruc" + columna1] = drPrv["nrodocentidad"];
                                drCc["nombreprv" + columna2] = drPrv["nombresocionegocio"];
                                drCc["ciudadprv" + columna3] = drPrv["nombreprovinciaprv"];
                                drCc["telefonoprv" + columna4] = drPrv["telefonoprv"];
                                drCc["celularprv" + columna5] = drPrv["movilprv"];
                                drCc["preciounitarionetoprv" + columna6] = drItem["preciounitarioneto"];
                                drCc["justificacionprv" + columna7] = drItem["justificacion"];
                                drCc["buenapro" + columna8] = drItem["buenapro"];

                            }
                        }


                    }
                }

                if (i == dtCcPrv.Rows.Count - 1)
                {
                    i = 8;
                }
            }

            if (string.IsNullOrEmpty(tipocp.Nombrereporte))
            {
                XtraMessageBox.Show("No se asignó un formato de impresión", "Atención", MessageBoxButtons.OK,
                MessageBoxIcon.Exclamation);
                return;
            }

            var report = new Report();
            string nameReporte = FilesHelper.FindingFileName(Application.StartupPath, string.Format("Reportes\\Compras\\{0}", tipocp.Nombrereporte.Trim()));
            report.Load(nameReporte);
            report.RegisterData(dtCc, "cc");
            report.RegisterData(VwSucursalList, "emp");
            ReportHelper1 reportHelper1 = new ReportHelper1(report);
            reportHelper1.ShowDialog();

        }
        public void FormatoValeSalida(Salidaalmacen salidaalmacen)
        {
            var tipocp = Service.GetTipocp(x => x.Idtipocp == salidaalmacen.Idtipocp);

            const string nameRelation = "almacen.vwsalidaalmacenimpresion";
            string whereList = string.Format("idsalidaalmacen = {0}", salidaalmacen.Idsalidaalmacen);
            const string ordersList = "numeroitem";
            const string fieldsList = "*";

            DataTable dt = HelperDb.SqlConsulta(nameRelation, whereList, ordersList, fieldsList);

            if (string.IsNullOrEmpty(tipocp.Nombrereporte))
            {
                XtraMessageBox.Show("No se asignó un formato de impresión", "Atención", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
                return;
            }

            Report report = new Report();

            string nameReporte = FilesHelper.FindingFileName(Application.StartupPath, string.Format("Reportes\\Almacen\\{0}", tipocp.Nombrereporte.Trim()));
            report.Load(nameReporte);
            report.RegisterData(dt, "valesalida");
            report.RegisterData(VwSucursalList, "emp");
            ReportHelper1 reportHelper1 = new ReportHelper1(report);
            reportHelper1.ShowDialog();
        }
        public void FormatoGuiaRemision(Guiaremision guiaremision)
        {
            var tipocp = Service.GetTipocp(x => x.Idtipocp == guiaremision.Idtipocp);

            const string nameRelation = "almacen.vwguiaremisionimpresion";
            string whereList = string.Format("idguiaremision = {0}", guiaremision.Idguiaremision);
            const string ordersList = "numeroitem";
            const string fieldsList = "*";

            DataTable dt = HelperDb.SqlConsulta(nameRelation, whereList, ordersList, fieldsList);
            dt.TableName = "gui";

            if (string.IsNullOrEmpty(tipocp.Nombrereporte))
            {
                XtraMessageBox.Show("No se asignó un formato de impresión", "Atención", MessageBoxButtons.OK,
                MessageBoxIcon.Exclamation);
                return;
            }

            //ImporteLetras
            string importeDocumentoLetra = UtilityReport.ToNumberLetters(guiaremision.Totaldocumento.ToString(CultureInfo.InvariantCulture));
            string nameReporte = FilesHelper.FindingFileName(Application.StartupPath, string.Format("Reportes\\almacen\\{0}", tipocp.Nombrereporte.Trim()));

            switch (tipocp.Tiporeporteador)
            {
                case 0: //FastReport
                    Report fastReport = new Report();

                    fastReport.Load(nameReporte);
                    fastReport.RegisterData(dt, "gui");
                    fastReport.RegisterData(VwSucursalList, "emp");
                    fastReport.SetParameterValue("ImporteDocLetras", importeDocumentoLetra);

                    ReportHelper1 reportHelper1 = new ReportHelper1(fastReport);
                    reportHelper1.ShowDialog();

                    break;
                case 1: //XtraReport

                    //XtraReport xtraReport = new XtraReport { DataSource = dt };
                    //xtraReport.LoadLayout(nameReporte);

                    //Parametros
                    object[] parametrosReporte = {
                        importeDocumentoLetra
                    };



                    ReportHelper2 reportHelper2 = new ReportHelper2(nameReporte, dt, parametrosReporte, "Guia");
                    reportHelper2.ShowDialog();
                    break;
            }

            //Report report = new Report();
            //string nameReporte = FilesHelper.FindingFileName(Application.StartupPath, string.Format("Reportes\\Almacen\\{0}", tipocp.Nombrereporte.Trim()));
            //report.Load(nameReporte);
            //report.RegisterData(dt, "guiaremision");
            //report.RegisterData(VwSucursalList, "emp");
            //ReportHelper1 reportHelper1 = new ReportHelper1(report);
            //reportHelper1.ShowDialog();
        }
        public void VistaPreviaNotaCreditoCliente(Notacreditocli notacreditocliMnt)
        {
            Tipocp tipocp = Service.GetTipocp(x => x.Idtipocp == notacreditocliMnt.Idtipocp);

            const string nameRelation = "ventas.vwnotacreditocliimpresion";
            string whereList = string.Format("idnotacreditocli = {0}", notacreditocliMnt.Idnotacreditocli);
            const string ordersList = "numeroitem";
            const string fieldsList = "*";

            DataTable dt = HelperDb.SqlConsulta(nameRelation, whereList, ordersList, fieldsList);
            dt.TableName = "cp";

            if (string.IsNullOrEmpty(tipocp.Nombrereporte))
            {
                XtraMessageBox.Show("No se asignó un formato de impresión", "Atención", MessageBoxButtons.OK,
                MessageBoxIcon.Exclamation);
                return;
            }

            //ImporteLetras
            string importeDocumentoLetra = UtilityReport.ToNumberLetters(notacreditocliMnt.Totaldocumento.ToString(CultureInfo.InvariantCulture));
            string nameReporte = FilesHelper.FindingFileName(Application.StartupPath, string.Format("Reportes\\Ventas\\{0}", tipocp.Nombrereporte.Trim()));

            switch (tipocp.Tiporeporteador)
            {
                case 0: //FastReport
                    Report fastReport = new Report();

                    fastReport.Load(nameReporte);
                    fastReport.RegisterData(dt, "cp");
                    fastReport.RegisterData(VwSucursalList, "emp");
                    fastReport.SetParameterValue("ImporteDocLetras", importeDocumentoLetra);

                    ReportHelper1 reportHelper1 = new ReportHelper1(fastReport);
                    reportHelper1.ShowDialog();

                    break;
                case 1: //XtraReport

                    //XtraReport xtraReport = new XtraReport { DataSource = dt };
                    //xtraReport.LoadLayout(nameReporte);

                    //Parametros
                    object[] parametrosReporte = {
                        importeDocumentoLetra
                    };

                    ReportHelper2 reportHelper2 = new ReportHelper2(nameReporte, dt, parametrosReporte, "NotaCreditoCliente");
                    reportHelper2.ShowDialog();
                    break;
            }

        }
        public void FormatoRendicionCajaChica(Rendicioncajachica rendicioncajachica)
        {
            var tipocp = Service.GetTipocp(x => x.Idtipocp == rendicioncajachica.Idtipocp);

            const string nameRelation = "finanzas.vwrendicioncajachicaimpresion";
            string whereList = string.Format("idrendicioncajachica = {0}", rendicioncajachica.Idrendicioncajachica);
            const string ordersList = "numeroitem";
            const string fieldsList = "*";

            DataTable dt = HelperDb.SqlConsulta(nameRelation, whereList, ordersList, fieldsList);

            if (string.IsNullOrEmpty(tipocp.Nombrereporte))
            {
                XtraMessageBox.Show("No se asignó un formato de impresión", "Atención", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
                return;
            }

            Report report = new Report();

            string nameReporte = FilesHelper.FindingFileName(Application.StartupPath, string.Format("Reportes\\Finanzas\\{0}", tipocp.Nombrereporte.Trim()));
            report.Load(nameReporte);
            report.RegisterData(dt, "rdcch");
            report.RegisterData(VwSucursalList, "emp");
            ReportHelper1 reportHelper1 = new ReportHelper1(report);
            reportHelper1.ShowDialog();
        }
        public void FormatoReciboEgreso(Recibocajaegreso recibocajaegreso)
        {
            var tipocp = Service.GetTipocp(x => x.Idtipocp == recibocajaegreso.Idtipocp);

            const string nameRelation = "finanzas.vwrecibocajaegresoimpresion";
            string whereList = string.Format("idrecibocajaegreso = {0}", recibocajaegreso.Idrecibocajaegreso);
            const string ordersList = "numeroitem";
            const string fieldsList = "*";

            DataTable dt = HelperDb.SqlConsulta(nameRelation, whereList, ordersList, fieldsList);

            if (string.IsNullOrEmpty(tipocp.Nombrereporte))
            {
                XtraMessageBox.Show("No se asignó un formato de impresión", "Atención", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
                return;
            }

            Report report = new Report();

            string nameReporte = FilesHelper.FindingFileName(Application.StartupPath, string.Format("Reportes\\Finanzas\\{0}", tipocp.Nombrereporte.Trim()));
            report.Load(nameReporte);
            report.RegisterData(dt, "re");
            report.RegisterData(VwSucursalList, "emp");
            ReportHelper1 reportHelper1 = new ReportHelper1(report);
            reportHelper1.ShowDialog();
        }
        public void FormatoElementoDesgasteDanio(Valorizacion valorizacion)
        {
            const string nameRelation = "maquinaria.vwvalorizacion";
            string whereList = string.Format("idvalorizacion = {0}", valorizacion.Idvalorizacion);
            const string ordersList = "idvalorizacion";
            const string fieldsList = "*";

            DataTable dt = HelperDb.SqlConsulta(nameRelation, whereList, ordersList, fieldsList);
            DataTable dtDet = HelperDb.SqlConsulta("maquinaria.vwvalorizaciondanioelementoimp", string.Format("idvalorizacion = {0}", valorizacion.Idvalorizacion), "idarticulogrupo", "*");
            DataTable eddCab = HelperDb.SqlConsulta("maquinaria.vwvalorizaciondanioelemento", string.Format("idvalorizacion = {0}", valorizacion.Idvalorizacion), "idvalorizaciondanioelemento", "*");

            Report report = new Report();


            string nameReporte = FilesHelper.FindingFileName(Application.StartupPath, string.Format("Reportes\\Ventas\\{0}", "elementodesgastedanio.frx"));
            report.Load(nameReporte);
            report.RegisterData(dt, "valorizacion");
            report.RegisterData(dtDet, "edd");
            report.RegisterData(eddCab, "eddc");
            report.RegisterData(VwSucursalList, "emp");

            ReportHelper1 reportHelper1 = new ReportHelper1(report);
            reportHelper1.ShowDialog();
        }

        public void FormatoCierreCaja(Cierrecaja cierrecaja)
        {


            const string nameRelation = "caja.vwcierrecajaimpresion";
            string whereList = string.Format("idcierrecaja = {0}", cierrecaja.Idcierrecaja);
            const string ordersList = "idmediopago";
            const string fieldsList = "*";

            DataSet dsRecibo = new DataSet
            {
                DataSetName = "reciboresumen"
            };


            DataTable dtEmpresa = HelperDb.SqlConsulta("inntecc.vwsucursal", string.Format("idsucursal = {0}", SessionApp.SucursalSel.Idsucursal), null, "*");
            DataTable dt = HelperDb.SqlConsulta(nameRelation, whereList, ordersList, fieldsList);

            DataTable dtRecibo = dt.Copy();
            dtRecibo.TableName = "reciboresumen";

            DataTable dtEmpresaSel = dtEmpresa.Copy();
            dtEmpresaSel.TableName = "empresa";

            dsRecibo.Tables.Add(dtRecibo);
            dsRecibo.Tables.Add(dtEmpresaSel);

            string nameReporte = FilesHelper.FindingFileName(Application.StartupPath, "Reportes\\Finanzas\\reciboresumen.repx");

            ReportHelper3 reportHelper3 = new ReportHelper3(nameReporte, dsRecibo,null,"reciboresumen");
            reportHelper3.ShowDialog();


        }

        public void FormatoCierreCajaDetalle(Cierrecaja cierrecaja)
        {
            const string nameRelation = "finanzas.vwreciboingresoegresodet";
            string whereList = string.Format("fechapago = '{0:yyyy-MM-dd}'", cierrecaja.Fechacierre);
            const string ordersList = "fechapago";
            const string fieldsList = "*";

            DataSet dsRecibo = new DataSet
            {
                DataSetName = "dsie"
            };


            DataTable dtEmpresa = HelperDb.SqlConsulta("inntecc.vwsucursal", string.Format("idsucursal = {0}", SessionApp.SucursalSel.Idsucursal), null, "*");
            DataTable dt = HelperDb.SqlConsulta(nameRelation, whereList, ordersList, fieldsList);

            DataTable dtRecibo = dt.Copy();
            dtRecibo.TableName = "rd";

            DataTable dtEmpresaSel = dtEmpresa.Copy();
            dtEmpresaSel.TableName = "empresa";

            dsRecibo.Tables.Add(dtRecibo);
            dsRecibo.Tables.Add(dtEmpresaSel);

            string nameReporte = FilesHelper.FindingFileName(Application.StartupPath, "Reportes\\Finanzas\\reciboingresoegresodet.repx");

            ReportHelper3 reportHelper3 = new ReportHelper3(nameReporte, dsRecibo, null, "ingresoegresodetallado");
            reportHelper3.ShowDialog();
        }
    }
}