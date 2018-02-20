using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace DenemeSinavSonuclari
{
    /// <summary>
    /// Summary description for DosyaYukle
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class DosyaYukle : System.Web.Services.WebService
    {

        [WebMethod]
        public int SistemiAyarla()
        {
            try
            {
                Application["Durum"] = false;
                Application["SonTarih"] = DateTime.Now;
                return 1;
            }
            catch (Exception ex)
            {
                Hata.Bildir(ex);
                return 0;
            }
            
        }

        [WebMethod]
        public int SistemiSifirla()
        {
            try
            {
                Application["Durum"] = true;
                return 1;
            }
            catch (Exception ex)
            {
                Hata.Bildir(ex);
                return 0;
            }
            
        }
    }
}
