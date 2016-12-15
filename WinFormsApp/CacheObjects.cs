using System.Collections.Generic;
using ActionService;
using BusinessObjects.Entities;

namespace WinFormsApp
{
    internal class CacheObjects
    {
        private static Service _service;
        private static List<VwUbigeo> _ubigeoList;       
        private static List<Tipodocentidad> _tipodocentidadlist;
        private static List<SexoPersona> _sexoPersonaList;
        private static List<DiaSemana> _diaSemanaList;

        private static List<TurnoValorizacion> _turnoValorizacionList;
        private static List<Tipomoneda> _tipomonedaList;
        private static List<Tipomediopago> _tipomediopagoList;
        private static List<Estadosocionegocio> _estadosocionegocioList;
        private static List<Tipogarantia> _tipogarantiaList;

        private static List<Tipocondicion> _tipocondicionList;
        private static long _tipocondicionInicial;

        private static List<Tipocppago> _tipocppagoList;
        private static long _tipocppagoInicial;

        private static List<Impuesto> _impuestoList;
        private static List<Prioridad> _prioridadList;
        private static List<Estadopago> _estadopagoList;
        private static List<Estadoreq> _estadoreqList;
        private static List<Tiposocio> _tiposocioList;
        private static List<Tipoafectacionigv> _tipoafectacionigvList;
        private static List<Tipoarticulo> _tipoaarticuloList;
        private static List<Tiporegistroorden> _tiporegistroordenList;
        private static List<Tipogestionarticulo> _tipogestionarticuloList;
        private static List<Estadoarticulo> _estadoarticuloList;
        private static List<Pais> _paisList;
        private static List<Diaferiado> _diaferiadoList;

        private static List<VwEquipo> _vwEquipoList;
        private static long _vwEquipoInicial;

        private static List<Proyecto> _proyectoList;
        private static long _proyectoInicial;

        private static List<VwProyecto> _vwProyectoList;
        private static long _vwProyectoInicial;

        private static List<VwSucursal> _vwSucursalsList;
        private static long _vwSucursalInicial;

        private static List<VwTipocp> _vwTipocpList;
        private static long _vwTipocpInicial;

        private static List<VwCptooperacion> _vwCptooperacionList;
        private static long _vwCptooperacionInicial;

        private static List<VwEmpleado> _vwEmpleadoList;
        private static long _vwEmpleadoInicial;

        private static List<Tipolista> _tipolistaList;
        private static long _tipolistaInicial;

        private static List<VwArea> _vwAreaList;
        private static long _vwAreaInicial;

        private static List<VwEmpleadoarea> _vwEmpleadoareaList;
        private static long _vwEmpleadoareaInicial;

        private static List<VwEmpleadoareaproyecto> _vwEmpleadoareaproyectoList;
        private static long _vwEmpleadoareaproyectoInicial;

        private static List<VwCentrodecosto> _vwCentrodecostoList;
        private static long _vwCentrodecostoInicial;

        private static List<Centrodecosto> _centrodecostoList;
        private static long _centrodecostoInicial;

        private static List<VwSocionegocio>  _vwSocionegocioList;
        private static long _vwSocionegocioInicial;

        private static List<VwSocionegocioproyecto> _vwSocionegocioproyectoList;
        private static long _vwSocionegocioproyectoInicial;

        private static List<Unidadmedida> _unidadmedidaList;
        private static long _unidadmedidaInicial;

        private static List<Articuloclasificacion> _articuloclasificacionList;
        private static long _articuloclasificacionInicial;

        private static List<Marca> _marcaList;
        private static long _marcaInicial;

        private static List<Impuestoisc> _impuestoiscList;
        private static long _impuestoiscInicial;

        private static List<Cuentacontable> _cuentacontableList;
        private static long _cuentacontableInicial;

        private static List<Elementogasto> _elementogastoList;
        private static long _elementogastoInicial;

        private static List<Clasificacionequipo> _clasificacionequipoList;
        private static long _clasificacionequipoInicial;

        private static List<Almacen> _almacenList;

        private static List<VwAlmacen> _vwAlmacenList;

        private static List<VwPeriodo> _vwPeriodoList;
        private static long _vwPeriodoInicial;

        private static List<Categoriasocionegocio> _categoriasocionegocioList;
        private static long _categoriasocionegocioInicial;

        private static List<Grupoeconomico> _grupoeconomicoList;
        private static long _grupoeconomicoInicial;

        private static List<Rubronegocio> _rubronegocioList;
        private static long _rubronegocioInicial;

        private static List<Zona> _zonaList;
        private static long _zonaInicial;

        private static List<Entidadfinanciera> _entidadfinancieraList;
        private static long _entidadfinancieraInicial;

        public CacheObjects()
        {
            _service = new Service();
        }
        public void Inicializar()
        {
            _ubigeoList = _service.GetAllVwUbigeo("nombredepartamento,nombreprovincia,nombredistrito");
            _tipodocentidadlist = _service.GetAllTipodocentidad("Nombretipodocentidad");
            _tipomonedaList = _service.GetAllTipomoneda("codigotipomoneda");
            _tipomediopagoList = _service.GetAllTipomediopago("nombremediopago");
            _estadosocionegocioList = _service.GetAllEstadosocionegocio("idestadosocionegocio");
            _tipogarantiaList = _service.GetAllTipogarantia("nombretipogarantia");    

            _sexoPersonaList = CargarSexoPersona();
            _diaSemanaList = CargarDiaSemana();
            _turnoValorizacionList = CargarTurnoValorizacion();

            _tipocondicionList = _service.GetAllTipocondicion("codigocondicion");
            _tipocondicionInicial = _tipocondicionList.Count;

            _tipocppagoList = _service.GetAllTipocppago("codigotipocppago");
            _impuestoList = _service.GetAllImpuesto("nombreimpuesto");
            _prioridadList = _service.GetAllPrioridad("codigoprioridad");
            _estadopagoList = _service.GetAllEstadopago("idestadopago");
            _estadoreqList = _service.GetAllEstadoreq("idestadoreq");
            _tiposocioList = _service.GetAllTiposocio("idtiposocio");
            _tipoafectacionigvList = _service.GetAllTipoafectacionigv("codigotipoafectacionigv");
            _tipoaarticuloList = _service.GetAllTipoarticulo("idtipoarticulo");
            _tiporegistroordenList = _service.GetAllTiporegistroorden("idtiporegistroorden");
            _tipogestionarticuloList = _service.GetAllTipogestionarticulo("nombretipogestionarticulo");
            _estadoarticuloList = _service.GetAllEstadoarticulo("idestadoarticulo");
            _paisList = _service.GetAllPais("nombrepais");
            _diaferiadoList = _service.GetAllDiaferiado("fechaferiado");

            _vwEquipoList = _service.GetAllVwEquipo("codigoequipo");
            _vwEquipoInicial = _vwEquipoList.Count;

            _proyectoList = _service.GetAllProyecto("nombreproyecto");
            _proyectoInicial = _proyectoList.Count;

            _vwProyectoList = _service.GetAllVwProyecto("nombreproyecto");
            _vwProyectoInicial = _vwProyectoList.Count;

            _vwSucursalsList = _service.GetAllVwSucursal("Nombresucursal");
            _vwSucursalInicial = _vwSucursalsList.Count;

            _vwTipocpList = _service.GetAllVwTipocp("nombretipocp");
            _vwTipocpInicial = _vwTipocpList.Count;

            _vwCptooperacionList = _service.GetAllVwCptooperacion("nombrecptooperacion");
            _vwCptooperacionInicial = _vwCptooperacionList.Count;

            _vwEmpleadoList = _service.GetAllVwEmpleado("Razonsocial");
            _vwEmpleadoInicial = _vwEmpleadoList.Count;

            _tipolistaList = _service.GetAllTipolista("Nombretipolista");
            _tipolistaInicial = _tipolistaList.Count;

            _vwAreaList = _service.GetAllVwArea("Nombrearea");
            _vwAreaInicial = _vwAreaList.Count;

            _vwEmpleadoareaList = _service.GetAllVwEmpleadoarea("Nombrearea");
            _vwEmpleadoareaInicial = _vwEmpleadoareaList.Count;

            _vwEmpleadoareaproyectoList = _service.GetAllVwEmpleadoareaproyecto("Nombreempleado,Nombrearea");
            _vwEmpleadoareaproyectoInicial = _vwEmpleadoareaproyectoList.Count;

            _vwCentrodecostoList = _service.GetAllVwCentrodecosto("codigocentrodecosto");
            _vwCentrodecostoInicial = _vwCentrodecostoList.Count;

            _centrodecostoList = _service.GetAllCentrodecosto("codigocentrodecosto");
            _centrodecostoInicial = _centrodecostoList.Count;

            _vwSocionegocioList = _service.GetAllVwSocionegocio("razonsocial");
            _vwSocionegocioInicial = _vwSocionegocioList.Count;


            _vwSocionegocioproyectoList = _service.GetAllVwSocionegocioproyecto("Nombreproyecto");
            _vwSocionegocioproyectoInicial = _vwSocionegocioproyectoList.Count;

            _articuloclasificacionList = _service.GetAllArticuloclasificacion("Nombreclasificacion");
            _articuloclasificacionInicial = _articuloclasificacionList.Count;

            _marcaList = _service.GetAllMarca("nombremarca");
            _marcaInicial = _marcaList.Count;

            _impuestoiscList = _service.GetAllImpuestoisc("Nombreimpuestoisc");
            _impuestoiscInicial = _impuestoiscList.Count;

            _cuentacontableList = _service.GetAllCuentacontable("codigocuenta");
            _cuentacontableInicial = _cuentacontableList.Count;

            _elementogastoList = _service.GetAllElementogasto("codigoelementogasto");
            _elementogastoInicial = _elementogastoList.Count;

            _clasificacionequipoList = _service.GetAllClasificacionequipo("Nombreclasificacionequipo");
            _clasificacionequipoInicial = _clasificacionequipoList.Count;

            _almacenList = _service.GetAllAlmacen("nombrealmacen");

            _vwAlmacenList = _service.GetAllVwAlmacen("nombrealmacen");

            _vwPeriodoList = _service.GetAllVwPeriodo("periodo");
            _vwPeriodoInicial = _vwPeriodoList.Count;

            _categoriasocionegocioList = _service.GetAllCategoriasocionegocio("nombrecategoriasocionegoio");
            _categoriasocionegocioInicial = _categoriasocionegocioList.Count;

            _grupoeconomicoList = _service.GetAllGrupoeconomico("nombregrupoeconomico");
            _grupoeconomicoInicial = _grupoeconomicoList.Count;

            _rubronegocioList = _service.GetAllRubronegocio("nombrerubronegocio");
            _rubronegocioInicial = _rubronegocioList.Count;

            _zonaList = _service.GetAllZona("nombrezona");
            _zonaInicial = _zonaList.Count;

            _entidadfinancieraList = _service.GetAllEntidadfinanciera("identfinaciera");
            _entidadfinancieraInicial = _entidadfinancieraList.Count;

        }
        public static List<VwUbigeo> UbigeoList
        {
            get { return _ubigeoList; }
        }
        public static List<Tipodocentidad> TipodocentidadList
        {
            get { return _tipodocentidadlist; }
        }
        public static List<Tipomoneda> TipomonedaList
        {
            get { return _tipomonedaList; }
        }
        public static List<Tipomediopago> TipomediopagoList
        {
            get { return _tipomediopagoList; }
        }
        public static List<Estadosocionegocio> EstadosocionegocioList
        {
            get { return _estadosocionegocioList; }
        }

        public static List<Tipogarantia> TipogarantiaList
        {
            get { return _tipogarantiaList; }
        }
        public static List<Tipocondicion> TipocondicionList
        {
            get
            {               
                if (_tipocondicionInicial != _service.CountTipocondicion())
                {
                    _tipocondicionList = _service.GetAllTipocondicion("codigocondicion");
                    _tipocondicionInicial = _tipocondicionList.Count;
                }               
                return _tipocondicionList;
            }
        }
        public static List<SexoPersona> SexoPersonaList
        {
            get { return _sexoPersonaList; }
        }

        public static List<DiaSemana> DiaSemanaList
        {
            get { return _diaSemanaList; }
        }

        public static List<TurnoValorizacion> TurnoValorizacionList
        {
            get { return _turnoValorizacionList; }
        }
        public static List<Tipocppago> TipocppagoList
        {
            get
            {
                if (_tipocppagoInicial != _service.CountTipocppago())
                {
                    _tipocppagoList = _service.GetAllTipocppago("codigotipocppago");
                    _tipocppagoInicial = _tipocppagoList.Count;
                }
                return _tipocppagoList;
            }
        }
        public static List<Impuesto> ImpuestoList
        {
            get { return _impuestoList; }
        }
        public static List<Prioridad> PrioridadList
        {
            get { return _prioridadList; }
        }
        public static List<Estadopago> EstadopagoList
        {
            get { return _estadopagoList; }
        }
        public static List<Estadoreq> EstadoreqList
        {
            get { return _estadoreqList; }
        }
        public static List<Tiposocio> TiposocioList
        {
            get { return _tiposocioList; }
        }
        public static List<Tipoafectacionigv> TipoafectacionigvList
        {
            get { return _tipoafectacionigvList; }
        }
        public static List<Tipoarticulo> TipoarticuloList
        {
            get { return _tipoaarticuloList; }
        }
        public static List<Tiporegistroorden> TiporegistroordenList
        {
            get { return _tiporegistroordenList; }
        }

        public static List<Tipogestionarticulo> TipogestionarticuloList
        {
            get { return _tipogestionarticuloList; }
        }

        public static List<Estadoarticulo> EstadoarticuloList
        {
            get { return _estadoarticuloList; }
        }

        public static List<Pais> PaisList
        {
            get { return _paisList; }
        }

        public static List<Diaferiado> DiaferiadoList
        {
            get { return _diaferiadoList; }
        }


        public static List<VwEquipo> VwEquipoList
        {
            get
            {
                if (_vwEquipoInicial != _service.CountEquipo())
                {
                    _vwEquipoList = _service.GetAllVwEquipo("codigoequipo");
                    _vwEquipoInicial = _vwEquipoList.Count;
                }
                return _vwEquipoList;
            }
        }

        public static List<Proyecto> ProyectoList
        {
            get
            {
                if (_proyectoInicial != _service.CountProyecto())
                {
                    _proyectoList = _service.GetAllProyecto("nombreproyecto");
                    _proyectoInicial = _proyectoList.Count;
                }
                return _proyectoList;
            }
        }
        public static List<VwProyecto> VwProyectoList
        {
            get
            {
                if (_vwProyectoInicial != _service.CountProyecto())
                {
                    _vwProyectoList = _service.GetAllVwProyecto("nombreproyecto");
                    _vwProyectoInicial = _vwProyectoList.Count;
                }
                return _vwProyectoList;
            }
        }
        public static List<VwSucursal> VwSucursalList
        {
            get
            {
                if (_vwSucursalInicial != _service.CountSucursal())
                {
                    _vwSucursalsList = _service.GetAllVwSucursal("Nombresucursal");
                    _vwSucursalInicial = _vwSucursalsList.Count;
                }
                return _vwSucursalsList;
            }
        }
        public static List<VwTipocp> VwTipocpList
        {
            get
            {
                if (_vwTipocpInicial != _service.CountTipocp())
                {
                    _vwTipocpList = _service.GetAllVwTipocp("nombretipocp");
                    _vwTipocpInicial = _vwTipocpList.Count;
                }
                return _vwTipocpList;
            }
        }
        public static List<VwCptooperacion> VwCptooperacionList
        {
            get
            {
                if (_vwCptooperacionInicial != _service.CountCptooperacion())
                {
                    _vwCptooperacionList = _service.GetAllVwCptooperacion("nombrecptooperacion");
                    _vwCptooperacionInicial = _vwCptooperacionList.Count;
                }

                return _vwCptooperacionList;
            }
        }
        public static List<VwEmpleado> VwEmpleadoList
        {
            get
            {
                if (_vwEmpleadoInicial != _service.CountEmpleado())
                {
                    _vwEmpleadoList = _service.GetAllVwEmpleado("Razonsocial");
                    _vwEmpleadoInicial = _vwEmpleadoList.Count;
                }

                return _vwEmpleadoList;
            }
        }
        public static List<Tipolista> TipolistaList
        {
            get
            {
                if (_tipolistaInicial != _service.CountTipolista())
                {
                    _tipolistaList = _service.GetAllTipolista("Nombretipolista");
                    _tipolistaInicial = _tipolistaList.Count;
                }


                return _tipolistaList;
            }
        }
        public static List<VwArea> VwAreaList
        {
            get
            {
                if (_vwAreaInicial != _service.CountArea())
                {
                    _vwAreaList = _service.GetAllVwArea("Nombrearea");
                    _vwAreaInicial = _vwAreaList.Count;
                }

                return _vwAreaList;
            }
        }
        public static List<VwEmpleadoarea> VwEmpleadoareaList
        {
            get
            {
                if (_vwEmpleadoareaInicial != _service.CountEmpleadoarea())
                {
                    _vwEmpleadoareaList = _service.GetAllVwEmpleadoarea("Nombrearea");
                    _vwEmpleadoareaInicial = _vwEmpleadoareaList.Count;
                }
                return _vwEmpleadoareaList;
            }
        }
        public static List<VwEmpleadoareaproyecto> VwEmpleadoareaproyectoList
        {
            get
            {
                if (_vwEmpleadoareaproyectoInicial != _service.CountEmpleadoareaproyecto())
                {
                    _vwEmpleadoareaproyectoList = _service.GetAllVwEmpleadoareaproyecto("Nombreempleado,Nombrearea");
                    _vwEmpleadoareaproyectoInicial = _vwEmpleadoareaproyectoList.Count;
                }
                return _vwEmpleadoareaproyectoList;
            }
        }
        public static List<VwCentrodecosto> VwCentrodecostoList
        {
            get
            {
                if (_vwCentrodecostoInicial != _service.CountCentrodecosto())
                {
                    _vwCentrodecostoList = _service.GetAllVwCentrodecosto("codigocentrodecosto");
                    _vwCentrodecostoInicial = _vwCentrodecostoList.Count;
                }

                return _vwCentrodecostoList;
            }
        }
        public static List<Centrodecosto> CentrodecostoList
        {
            get
            {
                if (_centrodecostoInicial != _service.CountCentrodecosto())
                {
                    _centrodecostoList = _service.GetAllCentrodecosto("codigocentrodecosto");
                    _centrodecostoInicial = _centrodecostoList.Count;
                }

                return _centrodecostoList;
            }
        }
        public static List<VwSocionegocio> VwSocionegocioList
        {
            get
            {
                if (_vwSocionegocioInicial != _service.CountSocionegocio())
                {
                    _vwSocionegocioList = _service.GetAllVwSocionegocio("razonsocial");
                    _vwSocionegocioInicial = _vwSocionegocioList.Count;
                }
                return _vwSocionegocioList;                
            }
        }

        public static List<VwSocionegocioproyecto> VwSocionegocioproyectoList
        {
            get
            {
                if (_vwSocionegocioproyectoInicial != _service.CountSocionegocioproyecto())
                {
                    _vwSocionegocioproyectoList = _service.GetAllVwSocionegocioproyecto("Nombreproyecto");
                    _vwSocionegocioproyectoInicial = _vwSocionegocioproyectoList.Count;
                }
                return _vwSocionegocioproyectoList;
            }
        }

        public static List<Unidadmedida> UnidadmedidaList
        {
            get
            {
                if (_unidadmedidaInicial != _service.CountUnidadmedida())
                {
                    _unidadmedidaList = _service.GetAllUnidadmedida("nombreunidadmedida");
                    _unidadmedidaInicial = _unidadmedidaList.Count;
                }

                return _unidadmedidaList;
            }
        }
        private List<SexoPersona> CargarSexoPersona()
        {
            return new List<SexoPersona>
                {
                    new SexoPersona
                    {
                        TipoSexo = "M",
                        DescripcionTipoSexo = "MASCULINO"
                    },
                    new SexoPersona
                    {
                        TipoSexo = "F",
                        DescripcionTipoSexo = "FEMENINO"
                    }
                    ,
                    new SexoPersona
                    {
                        TipoSexo = "N",
                        DescripcionTipoSexo = "NINGUNO"
                    }
                };
        }

        private List<DiaSemana> CargarDiaSemana()
        {
            return new List<DiaSemana>
                {
                    new DiaSemana
                    {
                        IdDiaSemana = 0,
                        NombreDiaSemana = "NINGUNO"
                    },

                    new DiaSemana
                    {
                        IdDiaSemana = 1,
                        NombreDiaSemana = "DOMINGO"
                    },
                    new DiaSemana
                    {
                        IdDiaSemana = 2,
                        NombreDiaSemana = "LUNES"
                    },
                    new DiaSemana
                    {
                        IdDiaSemana = 3,
                        NombreDiaSemana = "MARTES"
                    },
                    new DiaSemana
                    {
                        IdDiaSemana = 4,
                        NombreDiaSemana = "MIERCOLES"
                    },
                    new DiaSemana
                    {
                        IdDiaSemana = 5,
                        NombreDiaSemana = "JUEVES"
                    },
                    new DiaSemana
                    {
                        IdDiaSemana = 6,
                        NombreDiaSemana = "VIERNES"
                    },
                    new DiaSemana
                    {
                        IdDiaSemana = 7,
                        NombreDiaSemana = "SABADO"
                    },

                };
        }
        private List<TurnoValorizacion> CargarTurnoValorizacion()
        {
            return new List<TurnoValorizacion>
            {
                new TurnoValorizacion
                {
                    Turno = "D",
                    DescripcionTurno = "DIA"
                },
                new TurnoValorizacion
                {
                    Turno = "N",
                    DescripcionTurno = "NOCHE"
                }

            };
        }

        public static List<Articuloclasificacion> ArticuloclasificacionList
        {
            get
            {
                if (_articuloclasificacionInicial != _service.CountArticuloclasificacion())                
                {
                    _articuloclasificacionList = _service.GetAllArticuloclasificacion("Nombreclasificacion");
                    _articuloclasificacionInicial = _articuloclasificacionList.Count;
                }
                return _articuloclasificacionList;
            }
        }

        public static List<Marca> MarcaList
        {
            get
            {
                if (_marcaInicial != _service.CountMarca())
                {
                    _marcaList = _service.GetAllMarca("nombremarca");
                    _marcaInicial = _marcaList.Count;
                }
                return _marcaList;
            }
        }

        public static List<Impuestoisc> ImpuestoiscList
        {
            get
            {
                if (_impuestoiscInicial != _service.CountImpuestoisc())
                {
                    _impuestoiscList = _service.GetAllImpuestoisc("Nombreimpuestoisc");
                    _impuestoiscInicial = _impuestoiscList.Count;
                }
                return _impuestoiscList;
            }
        }

        public static List<Cuentacontable> CuentacontableList
        {

            get
            {
                if (_cuentacontableInicial != _service.CountCuentacontable())
                {
                    _cuentacontableList = _service.GetAllCuentacontable("codigocuenta");
                    _cuentacontableInicial = _cuentacontableList.Count;
                }
                return _cuentacontableList;
            }
        }

        public static List<Elementogasto> ElementogastoList
        {
            get
            {
                if (_elementogastoInicial != _service.CountElementogasto())
                {
                    _elementogastoList = _service.GetAllElementogasto("codigoelementogasto");
                    _elementogastoInicial = _elementogastoList.Count;
                }
                return _elementogastoList;
            }
        }

        public static List<Clasificacionequipo> ClasificacionequipoList
        {
            get
            {
                if (_clasificacionequipoInicial != _service.CountClasificacionequipo())
                {
                    _clasificacionequipoList = _service.GetAllClasificacionequipo("Nombreclasificacionequipo");
                    _clasificacionequipoInicial = _clasificacionequipoList.Count;
                }
                return _clasificacionequipoList;
            }
        }

        public static List<Almacen> AlmacenList
        {
            get { return _almacenList; }
        }

        public static List<VwAlmacen> VwAlmacenList
        {
            get { return _vwAlmacenList; }
        }

        public static List<VwPeriodo> VwPeriodoList
        {
            get
            {
                if (_vwPeriodoInicial != _service.CountPeriodo())
                {
                    _vwPeriodoList = _service.GetAllVwPeriodo("periodo");
                    _vwPeriodoInicial = _vwPeriodoList.Count;
                }
                return _vwPeriodoList;
            }
        }

        public static List<Categoriasocionegocio> CategoriasocionegocioList
        {
            get
            {
                if (_categoriasocionegocioInicial != _service.CountCategoriasocionegocio())
                {
                    _categoriasocionegocioList = _service.GetAllCategoriasocionegocio("nombrecategoriasocionegoio");
                    _categoriasocionegocioInicial = _categoriasocionegocioList.Count;
                }
                return _categoriasocionegocioList;
            }
        }

        public static List<Grupoeconomico> GrupoeconomicoList
        {
            get
            {
                if (_grupoeconomicoInicial != _service.CountGrupoeconomico())
                {
                    _grupoeconomicoList = _service.GetAllGrupoeconomico("Grupoeconomico");
                    _grupoeconomicoInicial = _grupoeconomicoList.Count;
                }
                return _grupoeconomicoList;
            }
        }

        public static List<Rubronegocio> RubronegocioList
        {
            get
            {
                if (_rubronegocioInicial != _service.CountRubronegocio())
                {
                    _rubronegocioList = _service.GetAllRubronegocio("nombrerubronegocio");
                    _rubronegocioInicial = _rubronegocioList.Count;
                }
                return _rubronegocioList;
            }
        }

        public static List<Zona> ZonaList
        {
            get
            {
                if (_zonaInicial != _service.CountZona())
                {
                    _zonaList = _service.GetAllZona("nombrezona");
                    _zonaInicial = _zonaList.Count;
                }
                return _zonaList;
            }
        }

        public static List<Entidadfinanciera> EntidadfinancieraList
        {
            get
            {
                if (_entidadfinancieraInicial != _service.CountEntidadfinanciera())
                {
                    _entidadfinancieraList = _service.GetAllEntidadfinanciera("identfinaciera");
                    _entidadfinancieraInicial = _entidadfinancieraList.Count;
                }
                return _entidadfinancieraList;
            }
        }
    }
}