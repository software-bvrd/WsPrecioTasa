using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Globalization;
using System.Data;
using System.Collections;
using System.IO;
//using WsPrecioTasa.ws.CalcularPrecioTasaEquivalenteCompletedEventArgs;
using WsPrecioTasa.ws1;


namespace wsPrecioTasaEquivalente
{


    public partial class wsPrecioTasaEquivalente : System.Web.UI.Page
    {


        protected void Page_Load(object sender, EventArgs e)
        {
            /*
            if (!IsPostBack)
            {
                txtFechaConcertacion.Value = DateTime.Now.ToString("yyyyMMdd", System.Globalization.CultureInfo.GetCultureInfo("en-US")).ToString();
                txtHoraConcertacion.Value = DateTime.Now.ToString("HH:mm:ss", System.Globalization.CultureInfo.GetCultureInfo("en-US")).ToString();

            }*/
        }

        protected void BtnCalcular_Click(object sender, EventArgs e)
        { 
            IWSCalculoPrecioTasaEquivalente xx = new WSCalculoPrecioTasaEquivalenteClient();;
            var response = xx.CalcularPrecioTasaEquivalente(new CalcularPrecioTasaEquivalenteRequest
            { 
                oCalculoPrecioTasa = new TCalculoPrecioTasa
                {
                    ColaRespuesta = "0",
                    TipoCalculo = 1,
                    TimeOut = 0,
                    Mercado = "D",
                    TipoIdTitulo = "T", //Clase
                    IdTitulo = "00667",
                    TipoDeNegociacion = "2",
                    PlazoDeIda = 7,
                    PlazoDeVuelta = 0,
                    PrecioOTasa = 100.1,
                    Cantidad = 770000,
                    Moneda = "D",
                    EnteLiquidador = "1",
                    FechaDeProceso = Convert.ToDateTime("2019-06-06"), //DateTime.Now.ToLocalTime();
                                                                       // DateTime? TNE_FechaDeEmision = null;
                                                                       //CalculoPrecioTasa.TNE_FechaDeEmision = DateTime.Now.ToLocalTime();
                                                                       //DateTime? TNE_FechaDeVencimiento = null;
                                                                       //CalculoPrecioTasa.TNE_FechaDeVencimiento = DateTime.Now.ToLocalTime();
                                                                       //CalculoPrecioTasa.TNE_PeriodicidadDePago = "";
                                                                       //CalculoPrecioTasa.TNE_ModalidadDePago = "";
                                                                       //CalculoPrecioTasa.TNE_PeriodicidadDeReinversion = "";
                                                                       //CalculoPrecioTasa.TNE_ModalidadDeReinversion = "";
                    TNE_TasaFacial = 0,
                    TNE_Premio = 0
                }

            } );
            txtCodigo.Value = response.@return.Codigo.ToString();
            txtMoneda.Value = response.Moneda.ToString();
            txtPrecioTasa.Value =  response.PrecioTasaEquivalente.ToString();
            
        }

    }

}