using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using HtmlAgilityPack;

namespace Utilities
{
    public class TipoCambioSunat
    {
        //private const string Url = "http://www.sunat.gob.pe/cl-at-ittipcam/tcS01Alias?_mes={0}&_anho={1}";
        private const string Url = "http://www.sunat.gob.pe/cl-at-ittipcam/tcS01Alias?mesElegido={0}&anioElegido={1}&mes={0}&anho={1}";

        private string _dia = "01";
        private string _mes = "01";
        private string _anho = "1995";
        private string _html = string.Empty;

        private double _compra;
        private double _venta;

        #region "Propiedades"

        public string Dia
        {
            get { return _dia; }
            set { _dia = value; }
        }

        public string Mes
        {
            get { return _mes; }
            set { _mes = value; }
        }

        public string Anho
        {
            get { return _anho; }
            set { _anho = value; }
        }

        public double Compra
        {
            get { return _compra; }
            set { _compra = value; }
        }

        public double Venta
        {
            get { return _venta; }
            set { _venta = value; }
        }

        #endregion

        #region "Metodos Privados"

        private DataTable ObtenerDatos()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Dia", typeof(String));
            dt.Columns.Add("Compra", typeof(String));
            dt.Columns.Add("Venta", typeof(String));

            string urlcomplete = string.Format(Url, _mes, _anho);
            _html = new WebClient().DownloadString(urlcomplete);

            HtmlDocument document = new HtmlDocument();
            document.LoadHtml(_html);

            HtmlNodeCollection nodesTr = document.DocumentNode.SelectNodes("//table[@class='class=\"form-table\"']//tr");
            if (nodesTr != null)
            {

                int iNumFila = 0;
                foreach (HtmlNode node in nodesTr)
                {
                    if (iNumFila > 0)
                    {
                        int iNumColumna = 0;
                        DataRow dr = dt.NewRow();
                        foreach (HtmlNode subNode in node.Elements("td"))
                        {

                            if (iNumColumna == 0) dr = dt.NewRow();

                            string sValue = subNode.InnerHtml.Trim();
                            sValue = System.Text.RegularExpressions.Regex.Replace(sValue, "<.*?>", " ");
                            dr[iNumColumna] = sValue.Trim();

                            iNumColumna++;

                            if (iNumColumna == 3)
                            {
                                dt.Rows.Add(dr);
                                iNumColumna = 0;
                            }
                        }
                    }
                    iNumFila++;
                }

                dt.AcceptChanges();
            }

            return dt;
        }

        #endregion

        #region "Metodos Publicos"

        public bool ObtenerPorFecha(int day, int month, int year)
        {
            _dia = day.ToString("00");
            _mes = month.ToString("00");
            _anho = year.ToString("0000");

            return ObtenerPorFecha();
        }

        public bool ObtenerPorFecha()
        {
            try
            {
                bool respuesta = false;

                string diaNumero = int.Parse(Dia).ToString();
                DataTable dt = ObtenerDatos();

                string sCompra = (from DataRow dr in dt.AsEnumerable()
                                  where Convert.ToString(dr["Dia"]) == diaNumero
                                  select Convert.ToString(dr["Compra"])).FirstOrDefault();
                string sVenta = (from DataRow dr in dt.AsEnumerable()
                                 where Convert.ToString(dr["Dia"]) == diaNumero
                                 select Convert.ToString(dr["Venta"])).FirstOrDefault();

                if (sCompra != null && sCompra.Trim().Length > 0)
                {
                    _compra = double.Parse(sCompra);
                    respuesta = true;
                }


                if (sVenta != null && sVenta.Trim().Length > 0)
                {
                    _venta = double.Parse(sVenta);
                    respuesta = true;
                }

                return respuesta;

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public List<TipoCambioSunat> ObtenerPorMes(int month, int year)
        {
            _mes = month.ToString("00");
            _anho = year.ToString("0000");

            return ObtenerPorMes();
        }

        public List<TipoCambioSunat> ObtenerPorMes()
        {
            try
            {

                List<TipoCambioSunat> lstTc = new List<TipoCambioSunat>();

                DataTable dt = ObtenerDatos();
                foreach (DataRow dr in dt.Rows)
                {
                    string diaNumero = int.Parse(dr["Dia"].ToString()).ToString("00");
                    TipoCambioSunat objTc = new TipoCambioSunat()
                    {
                        Dia = diaNumero,
                        Mes = Mes,
                        Anho = Anho,
                        Compra = double.Parse(dr["Compra"].ToString()),
                        Venta = double.Parse(dr["Venta"].ToString())
                    };
                    lstTc.Add(objTc);
                }

                return lstTc;

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        #endregion

    }
}
