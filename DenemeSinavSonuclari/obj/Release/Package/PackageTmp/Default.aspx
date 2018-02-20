<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="DenemeSinavSonuclari.Default" MaintainScrollPositionOnPostback="true" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Deneme Sınav Sonucları</title>
    <meta charset="utf-8">
    <!--Seo işlemleri-->
    <meta name="title" content="Lokman Hekim" />
    <meta name="description" content="Lokman hekim öğrencilerinin Deneme Sınavı Sonuçları" />
    <meta name="keywords" content="Deneme Sınavı , lokman hekim, sağlık meslek" />
    <meta name="copyright" content="(c) 2016" />
    <!--seo bitiş-->
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <link href="Content/bootstrap.css" rel="stylesheet" />
    <link href="Content/bootstrap-theme.css" rel="stylesheet" />
    <style>
        .cevap{
            letter-spacing: 5px;
        }
    </style>
    <script src="Scripts/jquery-1.9.1.js"></script>
    <script src="Scripts/bootstrap.js"></script>
    
    <script type="text/javascript">

        function yazdirDiv(divName) {
            var printContents = document.getElementById(divName).innerHTML;
            var originalContents = document.body.innerHTML;
            
            document.body.innerHTML = printContents;

            window.print();

            document.body.innerHTML = originalContents;
        }

        function yazdir()
        {
	        window.print();
        }

        function sedeceSayi(evt) {
            evt = (evt) ? evt : window.event
            var charCode = (evt.which) ? evt.which : evt.keyCode
            if (charCode > 31 && (charCode < 48 || charCode > 57)) {
                return false
            }
            return true
        }

        $(document).ready(function () {
            $('#<%= TextBox1.ClientID %>').focus();
        });
        
</script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="container">
        <!--Bilgi Girişi-->
       
       
              <table class="table table-hover">
        <thead>
          <tr>
              <th>Sınav</th>
              <th>No</th>
              <th>Göster</th>
              <th>Yazdır</th>
          </tr>
        </thead>
        <tbody>
          <tr class="success">
        
              <td><asp:DropDownList ID="DropDownList1" runat="server" CssClass="form-control" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged"></asp:DropDownList></td>
              <td> <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control" onKeyPress="return sedeceSayi(event)" MaxLength="5"></asp:TextBox></td>
              <td> <asp:Button ID="Button1" runat="server" Text="Goster" CssClass="btn btn-primary" OnClick="Button1_Click" /></td>
              <td><input type="button" value="Sayfayı yazdır" class="btn btn-primary"  onClick="yazdirDiv('div_yazilacak')"/></td>
          </tr>
   
        </tbody>
      </table>
          
          <div id="div_yazilacak">

                 <!--Bilgiler-->
                
                  <table class="table table-hover">
            <thead>
              <tr>
                  <th>No</th>
                  <th>AD SOYAD</th>
                  <th>SINIFI</th>
                  <th>KİTAPÇIK</th>
                  <th>TARİH</th>
                  <th>AÇIKLAMA</th>
        
              </tr>
            </thead>
            <tbody>
              <tr class="success">
        
                  <td><div id="no" runat="server"></div></td>
                  <td><div id="ad" runat="server"></div></td>
                  <td><div id="sinif" runat="server"></div></td>
                  <td><div id="kitacik" runat="server"></div></td>
                  <td><div id="tarih" runat="server"></div></td>
                  <td><div id="aciklama" runat="server"></div></td>
 
              </tr>
            </tbody>
          </table>
                
                <!--Netler-->
             <div class="table-responsive">
                  <table class="table table-hover">
            <thead>
              <tr>
                  <th>#</th>
                  <th>Türkçe</th>
                  <th>Tarih</th>
                  <th>Coğrafya</th>
                  <th>Felsefe</th>

                  <th>Matematik</th>
                

                  <th>Fizik</th>
                  <th>Kimya</th>
                  <th>Biyoloji</th>
              </tr>
            </thead>
            <tbody>
              <tr class="success">
                <td>Doğru</td>
                  <td><div id="tr_d" runat="server"></div></td>
                  <td><div id="tar_d" runat="server"></div></td>
                  <td><div id="cog_d" runat="server"></div></td>
                  <td><div id="fel_d" runat="server"></div></td>

                  <td><div id="cbr_d" runat="server"></div></td>
                 

                  <td><div id="fiz_d" runat="server"></div></td>
                  <td><div id="kim_d" runat="server"></div></td>
                  <td><div id="biy_d" runat="server"></div></td>

              </tr>
              <tr class="danger">
               <td>Yanlış</td>
                  <td><div id="tr_y" runat="server"></div></td>
                  <td><div id="tar_y" runat="server"></div></td>
                  <td><div id="cog_y" runat="server"></div></td>
                  <td><div id="fel_y" runat="server"></div></td>

                  <td><div id="cbr_y" runat="server"></div></td>
                 

                  <td><div id="fiz_y" runat="server"></div></td>
                  <td><div id="kim_y" runat="server"></div></td>
                  <td><div id="biy_y" runat="server"></div></td>
              </tr>
              <tr class="info">
                <td>Net</td>
                  <td><div id="tr_n" runat="server"></div></td>
                  <td><div id="tar_n" runat="server"></div></td>
                  <td><div id="cog_n" runat="server"></div></td>
                  <td><div id="fel_n" runat="server"></div></td>

                  <td><div id="cbr_n" runat="server"></div></td>
                 

                  <td><div id="fiz_n" runat="server"></div></td>
                  <td><div id="kim_n" runat="server"></div></td>
                  <td><div id="biy_n" runat="server"></div></td>
              </tr>
                <tr class="active">
                <td>Toplam Net</td>
                  <td><div id="tplm_n" runat="server"></div></td>
                    <td></td>
                     <td></td>
                     <td></td>
                     <td></td>
                     <td></td>
                     <td></td>
                     <td></td>
                    
                     

              </tr>
            </tbody>
          </table>
                </div>

                 <!--Netler-->
             <div class="table-responsive">
                  <table class="table table-hover">
            <thead>
              <tr>
                  <th>#</th>
                  <th>YGS-1</th>
                  <th>YGS-2</th>
                  <th>YGS-3</th>
                  <th>YGS-4</th>
                  <th>YGS-5</th>
                  <th>YGS-6</th>
              </tr>
            </thead>
            <tbody>
              <tr class="success">
                <td></td>
                  <td><div id="ygs1" runat="server"></div></td>
                  <td><div id="ygs2" runat="server"></div></td>
                  <td><div id="ygs3" runat="server"></div></td>
                  <td><div id="ygs4" runat="server"></div></td>
                  <td><div id="ygs5" runat="server"></div></td>
                  <td><div id="ygs6" runat="server"></div></td>

              </tr>
              
            </tbody>
          </table>
                </div>

                 <!--Cevaplar-->
                <div class="table-responsive">
                  <table class="table table-hover">
            <thead>
              <tr>
                  <th>#</th>
                  <th>Cevap Anahtarları</th>
              </tr>
            </thead>
            <tbody>
              <tr class="success">
                <td>Türkçe Cevap Anahtarı</td>
                  <td><div id="tr_dc" runat="server" class="cevap"></div></td>
                  
              </tr>
                <tr class="success">
                <td>Öğrencinin Cevabı</td>
                  <td><div id="tr_oc" runat="server" class="cevap"></div></td>
              </tr>
              <tr class="success">
               <td>Matematik Cevap Anahtarı</td>
                  <td><div id="mat_dc" runat="server" class="cevap"></div></td>
              </tr>
                <tr class="success">
                <td>Öğrencinin Cevabı</td>
                 <td><div id="mat_oc" runat="server" class="cevap"></div></td>
              </tr>

              <tr class="success">
                <td>Fen Cevap Anahtarı</td>
                  <td><div id="fen_dc" runat="server" class="cevap"></div></td>
                
         
              </tr>
                 <tr class="success">
                <td>Öğrencinin Cevabı</td>
                 <td><div id="fen_oc" runat="server" class="cevap"></div></td>
              </tr>

                <tr class="success">
                <td>Sosyal Cevap Anahtarı</td>
                  <td><div id="sos_dc" runat="server" class="cevap"></div></td>
                  
              </tr>
                    <tr class="success">
                <td>Öğrencinin Cevabı</td>
                <td><div id="sos_oc" runat="server" class="cevap"></div></td>
              </tr>
            </tbody>
          </table>
                </div>
              <div class="table-responsive">
              <!--Soruların konuları-->
              <asp:Repeater ID="Repeater1" runat="server">
            <HeaderTemplate>
                <table class="table table-hover" >
                     <thead>
                    <tr>
                        <th>
                            DERS
                        </th>
                        <th>
                            KONU
                        </th>
                        <th>
                            DOĞRU
                        </th>
                        <th>
                            YANLIŞ
                        </th>
                        <th>
                            SORU SAYISI
                        </th>
                    </tr>
                     </thead>
            </HeaderTemplate>
            <ItemTemplate>
                <tr class="success">
                    <td>
                    <%#DataBinder.Eval(Container.DataItem,"DERS") %>
                        
                    </td>
                    <td>
                        <%#DataBinder.Eval(Container.DataItem, "KONU")%>
                    </td>
                    <td>
                        <%#DataBinder.Eval(Container.DataItem, "D")%>
                    </td>
                    <td>
                        <%#DataBinder.Eval(Container.DataItem, "Y")%>
                    </td>
                    <td>
                        <%#DataBinder.Eval(Container.DataItem, "S")%>
                    </td>
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                 </tbody>
                </table>
            </FooterTemplate>
        </asp:Repeater>
    </div>





        </div>
       </div>
       
       
    </form>
</body>
</html>
