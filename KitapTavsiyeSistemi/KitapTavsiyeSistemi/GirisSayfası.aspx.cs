using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Drawing;
public partial class GirisSayfası : System.Web.UI.Page
{
    SqlConnection baglan = new SqlConnection("Data Source=DESKTOP-6SJ94PD\\SQLEXPRESS02;Initial Catalog=KitapTavsiye;Integrated Security=True");

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        baglan.Open();
        SqlCommand komut123 = new SqlCommand("select *from Bilgiler", baglan);
        SqlDataReader oku = komut123.ExecuteReader();
        while (oku.Read())
        {
            if ((TextBox1.Text == oku["KullaniciAdi"].ToString().Trim()) && (TextBox2.Text == oku["Sifre"].ToString().Trim()))
            {
                Session["YöneticiGiriş"] = true;
                Response.Redirect("YonetimPaneli.aspx");
                
            }
        }
        baglan.Close();

    }

    protected void TextBox8_TextChanged(object sender, EventArgs e)
    {

    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        baglan.Open();
        SqlCommand komut = new SqlCommand("select *from KullanıcıKayıt", baglan);
        SqlDataReader oku = komut.ExecuteReader();
        while (oku.Read())
        {
            if ((TextBox3.Text == oku["Adı"].ToString().Trim()) && (TextBox8.Text == oku["Sifre"].ToString().Trim()))
            {
                Session["giris"] = true;
                Session["Kullanıcıİsim"] = TextBox3.Text;
                Session["KullanıcıId"] = oku["ID"];
                Response.Redirect("SifreKoruma.aspx");
            }

        }
        baglan.Close();

    }
    string uzanti = "";
    string resimadi = "";
    protected void Button3_Click(object sender, EventArgs e)
    {
       



                 if (FileUpload1.HasFile)
                  {
                      uzanti = Path.GetExtension(FileUpload1.PostedFile.FileName);
                       resimadi = (TextBox4.Text) + "_urunresim_" + DateTime.Now.Day + uzanti;
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
                          string cinsiyet = "";
                          if (RadioButton1.Checked)
                           {
                              cinsiyet = "Kadın";
                           }
                           else
                          cinsiyet = "Erkek";

                      baglan.Open();
                      SqlCommand komut = new SqlCommand("insert into KullanıcıKayıt(Adı,Soyadı,numara,Sifre,Resim,Cinsiyet) values(@adı,@soyadı,@numara,@sifre,@resim,@cs) ", baglan);
                      komut.Parameters.AddWithValue("@adı", TextBox4.Text);
                      komut.Parameters.AddWithValue("@soyadı", TextBox5.Text);
                      komut.Parameters.AddWithValue("@numara", TextBox6.Text);
                      komut.Parameters.AddWithValue("@sifre", TextBox7.Text);
                      komut.Parameters.AddWithValue("@resim", resimadi);
                      komut.Parameters.AddWithValue("@cs", cinsiyet);
                      
                      komut.ExecuteNonQuery();
                      baglan.Close();
                      Label13.Text = "Ekleme Başarılı";


                  }


        //    }
        }
    }



