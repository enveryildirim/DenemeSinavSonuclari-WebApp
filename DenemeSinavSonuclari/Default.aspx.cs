using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DenemeSinavSonuclari
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DropDownList1.Items.Clear();
            VeriTabanlariniYukle();
            DropDownList1.SelectedIndex = 0;
           

        }
        void HTMLYukle(DataSet ds,string ono)
        {
            DataRow r=null, r_puan = null;
            DataRow[] r_konu = null;
            try
            {
                 r = ds.Tables["Net"].Select("ONO=" + ono)[0];
                 r_puan = ds.Tables["Puan"].Select("OTONO=" + r["OTONO"].ToString())[0];
                 r_konu = ds.Tables["Konu"].Select("ONO=" + ono);
                 Repeater1.DataSource = r_konu.CopyToDataTable();
                 Repeater1.DataBind();
            }
            catch (Exception ex)
            {
                 if(ex is IndexOutOfRangeException)
                {
                    if (!ClientScript.IsStartupScriptRegistered("alert"))
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Öğrenci No Kayıtlı Değil !!!');", true);
                        TextBox1.Text = "";
                    }
                }
                else 
                    Hata.Bildir(ex);

                 return;
            }
            
      
            //doğrular
            tr_d.InnerText = r["B1_TUR_D"].ToString();
            tar_d.InnerText = r["B1_TAR_D"].ToString();
            cog_d.InnerText = r["B1_COG_D"].ToString();
            fel_d.InnerText = r["B1_FEL_D"].ToString();

            cbr_d.InnerText = r["B1_CEB_D"].ToString();
            //geo_d.InnerText = r["B1_GEO_D"].ToString();

            fiz_d.InnerText = r["B1_FIZ_D"].ToString();
            kim_d.InnerText = r["B1_KIM_D"].ToString();
            biy_d.InnerText = r["B1_BIY_D"].ToString();

            //yanlışlar
            tr_y.InnerText = r["B1_TUR_Y"].ToString();
            tar_y.InnerText = r["B1_TAR_Y"].ToString();
            cog_y.InnerText = r["B1_COG_Y"].ToString();
            fel_y.InnerText = r["B1_FEL_Y"].ToString();

            cbr_y.InnerText = r["B1_CEB_Y"].ToString();
           // geo_y.InnerText = r["B1_GEO_Y"].ToString();

            fiz_y.InnerText = r["B1_FIZ_Y"].ToString();
            kim_y.InnerText = r["B1_KIM_Y"].ToString();
            biy_y.InnerText = r["B1_BIY_Y"].ToString();
            
            //netler
            tr_n.InnerText = r["B1_TUR_N"].ToString();
            tar_n.InnerText = r["B1_TAR_N"].ToString();
            cog_n.InnerText = r["B1_COG_N"].ToString();
            fel_n.InnerText = r["B1_FEL_N"].ToString();

            cbr_n.InnerText = r["B1_CEB_N"].ToString();
           // geo_n.InnerText = r["B1_GEO_N"].ToString();

            fiz_n.InnerText = r["B1_FIZ_N"].ToString();
            kim_n.InnerText = r["B1_KIM_N"].ToString();
            biy_n.InnerText = r["B1_BIY_N"].ToString();

            //toplam netler
            tplm_n.InnerText = r["TOPNET"].ToString();

            //Cevaplar

            tr_dc.InnerText = r["TUR1DC"].ToString();
            tr_oc.InnerText = r["TUR1OC"].ToString();

            mat_dc.InnerText = r["MAT1DC"].ToString();
            mat_oc.InnerText = r["MAT1OC"].ToString();

            fen_dc.InnerText = r["FEN1DC"].ToString();
            fen_oc.InnerText = r["FEN1OC"].ToString();

            sos_dc.InnerText = r["SOS1DC"].ToString();
            sos_oc.InnerText = r["SOS1OC"].ToString();

            //puanlar

            ygs1.InnerText = r_puan["YGS12P"].ToString();
            ygs3.InnerText = r_puan["YGS34P"].ToString();
            ygs5.InnerText = r_puan["YGS56P"].ToString();
            
            //konular

            //Açıklamalar
            no.InnerText = r["ONO"].ToString();
            ad.InnerText = r["ADI"].ToString();
            sinif.InnerText = r["SINIFI"].ToString();
            kitacik.InnerText = r["KITAPCIK"].ToString();
            tarih.InnerText = r["TARIHI"].ToString();
            aciklama.InnerText = r["ACIKLAMA"].ToString();

        }
        DataSet VeriYukle(string db,string no)
        {
            try
            {
                DataSet ds = new DataSet(db);
                DataTable dt_net = new DataTable("Net");
                DataTable dt_puan = new DataTable("Puan");
                DataTable dt_konu = new DataTable("Konu");
                if(Cache[db]==null)
                {

                
                   /* string sorgu = "select ONO,ADI,SINIFI," +
                        "B1_FIZ_D,B1_KIM_D,B1_BIY_D,B1_CEB_D,B1_GEO_D,B1_TUR_D,B1_TAR_D,B1_COG_D,B1_FEL_D," +
                        "B1_FIZ_Y,B1_KIM_Y,B1_BIY_Y,B1_CEB_Y,B1_GEO_Y,B1_TUR_Y,B1_TAR_Y,B1_COG_Y,B1_FEL_Y," +
                        "B1_FIZ_N,B1_KIM_N,B1_BIY_N,B1_CEB_N,B1_GEO_N,B1_TUR_N,B1_TAR_N,B1_COG_N,B1_FEL_N," +
                        "TUR1DC,MAT1DC,FEN1DC,SOS1DC," +
                        "TUR1OC,MAT1OC,FEN1OC,SOS1OC," +
                        "TOPNET,KITAPCIK,TARIHI,ACIKLAMA"
                        + " from TBLDETAY where ONO=@no";*/

                    string sorgu2 = "select  ONO,OTONO,ADI,SINIFI," +
                        "B1_FIZ_D,B1_KIM_D,B1_BIY_D,B1_CEB_D,B1_GEO_D,B1_TUR_D,B1_TAR_D,B1_COG_D,B1_FEL_D," +
                        "B1_FIZ_Y,B1_KIM_Y,B1_BIY_Y,B1_CEB_Y,B1_GEO_Y,B1_TUR_Y,B1_TAR_Y,B1_COG_Y,B1_FEL_Y," +
                        "B1_FIZ_N,B1_KIM_N,B1_BIY_N,B1_CEB_N,B1_GEO_N,B1_TUR_N,B1_TAR_N,B1_COG_N,B1_FEL_N," +
                        "TUR1DC,MAT1DC,FEN1DC,SOS1DC," +
                        "TUR1OC,MAT1OC,FEN1OC,SOS1OC," +
                        "TOPNET,KITAPCIK,TARIHI,ACIKLAMA" +
                        "  from TBLDETAY";
                    string path = @"App_Data/" + db + "/SINAVLAR.mdb";
                    OleDbConnection baglan = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0; Data Source=" + Server.MapPath(path));
                    OleDbCommand cmd_net = new OleDbCommand(sorgu2, baglan);
                    //cmd.Parameters.AddWithValue("@no",no);
                    OleDbDataAdapter adap = new OleDbDataAdapter(cmd_net);
                    adap.Fill(dt_net);
                    ds.Tables.Add(dt_net);

                    //puanlar
                    string sorgu_puan = "select OTONO,YGS12P,YGS34P,YGS56P from TBLYATAY";
                    OleDbCommand cmd_puan = new OleDbCommand(sorgu_puan,baglan);
                    //cmd_puan.Parameters.AddWithValue("@otono", ds.Tables["Net"].Select("ONO=" + no)[0]["OTONO"].ToString());
                    OleDbDataAdapter adap_puan = new OleDbDataAdapter(cmd_puan);
                    adap_puan.Fill(dt_puan);
                    ds.Tables.Add(dt_puan);

                    //konular
                    string sorgu_konu = "select ONO,DERS,KONU,D,Y,S from NTC order by DERS DESC ";
                    OleDbCommand cmd_konu = new OleDbCommand(sorgu_konu, baglan);
                    //cmd_puan.Parameters.AddWithValue("@otono", ds.Tables["Net"].Select("ONO=" + no)[0]["OTONO"].ToString());
                    OleDbDataAdapter adap_konu = new OleDbDataAdapter(cmd_konu);
                    adap_konu.Fill(dt_konu);
                    ds.Tables.Add(dt_konu);


                    //Cache.Insert(db, dt, null, DateTime.Now.AddMinutes(1), System.Web.Caching.Cache.NoSlidingExpiration);
                    Cache.Insert(db, ds, null, System.Web.Caching.Cache.NoAbsoluteExpiration, TimeSpan.FromMinutes(30));
                }
                else
                {
                    ds = (DataSet)Cache[db];
                }

               
              
                return ds;
                //GridView1.DataSource = dt;
                //GridView1.DataBind();
              
               

            }
            catch (Exception ex)
            {
                Hata.Bildir(ex);
                return null;
            }
            
                
        }
        void VeriTabanlariniYukle()
        {
            YeniVeritabaniYukle();
            string[] paths = Directory.GetDirectories(Server.MapPath("App_Data"));
            foreach (var item in paths)
            {
                string a = item.Split('\\')[item.Split('\\').Length - 1];
                string snvno = a.Substring(0, 2);
                string bol = a.Substring(2);
                string yazi=string.Format("{0}.Sınıf-{1}.Deneme Sınavı",snvno,bol);
                DropDownList1.Items.Add(new ListItem(){Value=a,Text=yazi});
            }
           
           
        }
        void YeniVeritabaniYukle() 
        {
            bool durum = Convert.ToBoolean(Application["Durum"]);
            if (durum)
            {
                string[] paths = Directory.GetDirectories(Server.MapPath("Temp"));
                if (paths.Length != 0)
                {
                    foreach (var item in paths)
                    {
                        if (File.Exists(item + "\\SINAVLAR.MDB"))
                        {
                            string a = item.Split('\\')[item.Split('\\').Length - 1];
                            Directory.Move(item, Server.MapPath("App_Data/" + a));
                        }
                        else
                        {
                            Exception ex= new Exception("Dosya Hatası eksik dosya //temp ");
                            Hata.Bildir(ex);
                        }
                            
                    }
                }
            }
            else
            {
                string tarih = Application["SonTarih"].ToString();
                if (tarih == "")
                {
                    Application["Durum"] = true;
                }
                else
                {
                    if (DateTime.Parse(tarih).AddMinutes(5) < DateTime.Now)
                        Application["Durum"] = true;
                }
            }
           
        }
        private bool regexgiris(string gelenveri)
        {
            string desen = @"[0-9]";
            Match eslesme = Regex.Match(gelenveri, desen, RegexOptions.IgnoreCase);
            return eslesme.Success;

            
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            
            string deger = TextBox1.Text.Trim();
            if(deger!=""&&regexgiris(deger))
                  HTMLYukle(VeriYukle(DropDownList1.SelectedItem.Value, deger),deger);
            else
            {
                if (!ClientScript.IsStartupScriptRegistered("alert"))
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Öğrenci No Giriniz!!');", true);
                    TextBox1.Text = "";
                    TextBox1.Focus();
                }
            }
        
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}