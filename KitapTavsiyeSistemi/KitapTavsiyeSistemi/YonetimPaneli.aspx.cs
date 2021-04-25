using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;

public partial class YonetimPaneli : System.Web.UI.Page
{
    SqlConnection baglan = new SqlConnection("Data Source=DESKTOP-6SJ94PD\\SQLEXPRESS02;Initial Catalog=KitapTavsiye;Integrated Security=True");
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Convert.ToBoolean(Session["YöneticiGiriş"]) != true)
        {
            Response.Redirect("GirisSayfası.aspx");
        }

    }

    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {

    }

    protected void Button1_Click(object sender, EventArgs e)
    {


        string uzanti = "";
        string resimadi = "";
        if (FileUpload1.HasFile)
        {
            uzanti = Path.GetExtension(FileUpload1.PostedFile.FileName);
            resimadi = (TextBox2.Text) + "_urunresim_" + DateTime.Now.Day + uzanti;
            FileUpload1.SaveAs(Server.MapPath("/Resimler/sahte" + uzanti));

            int Donusturme = 640;

            Bitmap bmp = new Bitmap(Server.MapPath("/Resimler/sahte" + uzanti));
            using (Bitmap OrjinalResim = bmp)
            {
                double ResYukseklik = OrjinalResim.Height;
                double ResGenislik = OrjinalResim.Width;
                double oran = 0;

                if (ResGenislik >= Donusturme)
                {
                    oran = ResGenislik / ResYukseklik;
                    ResGenislik = Donusturme;
                    ResYukseklik = Donusturme / oran;

                    Size yenidegerler = new Size(Convert.ToInt32(ResGenislik), Convert.ToInt32(ResYukseklik));
                    Bitmap yeniresim = new Bitmap(OrjinalResim, yenidegerler);
                    yeniresim.Save(Server.MapPath("/Resimler/" + resimadi));

                    yeniresim.Dispose();
                    OrjinalResim.Dispose();
                    bmp.Dispose();


                }
                else
                {
                    FileUpload1.SaveAs(Server.MapPath("/Resimler/" + resimadi));
                }
            }
            FileInfo figecici = new FileInfo(Server.MapPath("~/Resimler/sahte" + uzanti));
            figecici.Delete();


            baglan.Open();
            SqlCommand komut = new SqlCommand("insert into KitapTanım1(İsmi,Yazar,YayınEvi,TanıtımBilgisi,Resim) values('" + TextBox1.Text.ToString() + "','" + TextBox2.Text.ToString() + "','" + TextBox3.Text.ToString() + "','" + TextBox4.Text.ToString() +  "','"+resimadi+"')", baglan);
            komut.ExecuteNonQuery();
            baglan.Close();
          // baglan.Open();
        /*    SqlCommand komut2 = new SqlCommand("insert into YazarTanım1(Ad,Soyad) values('" + TextBox1.Text.ToString() + "','" + TextBox2.Text.ToString() + "')", baglan);
            komut2.ExecuteNonQuery();
            baglan.Close();*/

           /* baglan.Open();
            SqlCommand komut33 = new SqlCommand("insert into YazarTanım1(Ad,Soyad,Kitaplar) values(@ad,@soyad,@kitaplar) ", baglan);
            komut33.Parameters.AddWithValue("@ad", TextBox2.Text);
            komut33.Parameters.AddWithValue("@soyad", TextBox6.Text);
           // komut33.Parameters.AddWithValue("@dt", tarih);
            komut33.Parameters.AddWithValue("@kitaplar", TextBox1.Text);
            komut33.ExecuteNonQuery();
            baglan.Close();*/


        }
    }
    string tarih = "";
    protected void Calendar1_SelectionChanged(object sender, EventArgs e)
    {
        DateTime dt = Calendar1.SelectedDate;
        tarih = dt.ToString();
       // TextBox7.Text = tarih;
        baglan.Open();
        SqlCommand komut33 = new SqlCommand("insert into YazarTanım1(Ad,Soyad,Kitaplar,DogumTarih) values(@ad,@soyad,@kitaplar,@dt) ", baglan);
        komut33.Parameters.AddWithValue("@ad", TextBox2.Text);
        komut33.Parameters.AddWithValue("@soyad", TextBox6.Text);
         komut33.Parameters.AddWithValue("@dt", tarih);
        komut33.Parameters.AddWithValue("@kitaplar", TextBox1.Text);
        komut33.ExecuteNonQuery();
        baglan.Close();
        Label11.Text = "Dogum tarihi başarıyla eklendi...";

        //TextBox7.Text = tarih;

    }
}