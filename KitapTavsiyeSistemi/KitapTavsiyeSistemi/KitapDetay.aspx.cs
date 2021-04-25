using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;

public partial class KitapDetay : System.Web.UI.Page
{
    SqlConnection baglan = new SqlConnection("Data Source=DESKTOP-6SJ94PD\\SQLEXPRESS02;Initial Catalog=KitapTavsiye;Integrated Security=True");
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Convert.ToBoolean(Session["giris"]) != true)
        {
            Response.Redirect("GirisSayfası.aspx");
        }
        else
        {

            SqlCommand komut = new SqlCommand("select  *from KitapTanım1 where İsmi=('" + Session["Kitapİsmi"] + "')  ", baglan);
            DataSet Kitapİsmi = new DataSet();
            SqlDataAdapter adaptor = new SqlDataAdapter(komut);
            baglan.Open();
            adaptor.Fill(Kitapİsmi);
            baglan.Close();
            GridView1.DataSource = Kitapİsmi.Tables[0];
            GridView1.DataBind();
           
            SqlCommand komut2 = new SqlCommand("select Resim from KitapTanım1 where İsmi=('"+Session["Kitapİsmi"]+"')",baglan);
            DataSet resim = new DataSet();
            SqlDataAdapter ad = new SqlDataAdapter(komut2);
            baglan.Open();
            ad.Fill(resim);
            baglan.Close();
            GridView2.DataSource = resim.Tables[0];
            GridView2.DataBind();
            GridView2.Visible = false;
            Image1.ImageUrl ="/Resimler/"+ GridView2.Rows[0].Cells[0].Text;
            




        }
    }



    protected void Button1_Click(object sender, EventArgs e)
    {
        RadioButton1.Visible = true;
        RadioButton2.Visible = true;
        TextBox1.Visible = true;
        TextBox2.Visible = true;
        Label1.Visible = true;
        Label2.Visible = true;
        Label3.Visible = true;   
        DropDownList1.Visible = true;
        Button2.Visible = true;
        Label4.Visible = true;
        TextBox4.Visible = true;
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        if(RadioButton1.Checked)
        {
            
            baglan.Open();
            SqlCommand komut = new SqlCommand("insert into KitapOkunma(KullanıcıId,KitapId) values(@kullanıcııd,@kitapıd)", baglan);
            komut.Parameters.AddWithValue("@kullanıcııd",Convert.ToInt32( Session["KullanıcıId"]));
            komut.Parameters.AddWithValue("@kitapıd", Convert.ToInt32(Session["KitapId"]));
            komut.ExecuteNonQuery();
            baglan.Close();
            baglan.Open();
            SqlCommand komut11 = new SqlCommand("select count(*) from KitapOkunma where KitapId=('" + Convert.ToInt32(Session["KitapId"])+ "')", baglan);
            
            int OkunmaSayısı = Convert.ToInt32( komut11.ExecuteScalar());
            komut11.ExecuteNonQuery();
            
            baglan.Close();
            baglan.Open();
            
            SqlCommand komut8 = new SqlCommand("update KitapTanım1 set OkunmaSayısı=('"+OkunmaSayısı+"') where ID=('" + Convert.ToInt32(Session["KitapId"]) + "')", baglan);
            
            komut8.ExecuteNonQuery();
            baglan.Close();
        }
        baglan.Open();
        SqlCommand komut2 = new SqlCommand("insert into Kitapİnceleme1(KullanıcıId,KitapId,İnceleme) values(@kullanıcııd,@kitapıd,@inceleme)", baglan);
        komut2.Parameters.AddWithValue("@kullanıcııd", Convert.ToInt32 (Session["KullanıcıId"]));
        komut2.Parameters.AddWithValue("@kitapıd", Convert.ToInt32( Session["KitapId"]));
        komut2.Parameters.AddWithValue("@inceleme", TextBox1.Text);
        komut2.ExecuteNonQuery();
        baglan.Close();
        baglan.Open();
        SqlCommand komut3 = new SqlCommand("insert into KitapAlıntı1(KullanıcıId,KitapId,SayfaNo,Cümle) values(@kullanıcııd,@kitapıd,@sayfano,@cümle)", baglan);
        komut3.Parameters.AddWithValue("@kullanıcııd", Convert.ToInt32(Session["KullanıcıId"]));
        komut3.Parameters.AddWithValue("@kitapıd", Convert.ToInt32(Session["KitapId"]));
        komut3.Parameters.AddWithValue("@sayfano", TextBox4.Text);
        komut3.Parameters.AddWithValue("@cümle", TextBox2.Text);
        komut3.ExecuteNonQuery();
        baglan.Close();
        baglan.Open();
        SqlCommand komut4 = new SqlCommand("insert into KitapPuan(KullanıcıId,KitapId,Puan) values(@kullanıcııd,@kitapıd,@puan)",baglan);
        komut4.Parameters.AddWithValue("@kullanıcııd", Convert.ToInt32(Session["KullanıcıId"]));
        komut4.Parameters.AddWithValue("@kitapıd", Convert.ToInt32(Session["KitapId"]));
        komut4.Parameters.AddWithValue("@puan", DropDownList1.Text);
        komut4.ExecuteNonQuery();
        baglan.Close();
        /* baglan.Open();
         SqlCommand komut7 = new SqlCommand("select count(*) from KitapPuan where KitapId=('" + Convert.ToInt32(Session["KitapId"]) + "')", baglan);
         int KayıtSayısı = Convert.ToInt32(komut7.ExecuteScalar());
         komut7.ExecuteNonQuery();
         TextBox5.Text = KayıtSayısı.ToString();
         baglan.Close();
         baglan.Open();
         SqlCommand komut5 = new SqlCommand("select sum(Puan) as 'Ortalama', KitapId from KitapPuan where KitapId=('"+Convert.ToInt32( Session["KitapId"])+ "') group by KitapId", baglan);
         SqlDataReader oku = komut5.ExecuteReader();
         int toplam=0,i;
         for( i=0;oku.Read();i++)
         {
             toplam = Convert.ToInt32(oku["Ortalama"]);
         }
         float ortalama = (float)toplam / (float)KayıtSayısı;       
         baglan.Close();*/
        float ortalama=0;
        baglan.Open();
        SqlCommand komut9 = new SqlCommand("select AVG(Puan) as 'ort' from KitapPuan where KitapId=('" + Session["KitapId"] + "')",baglan);
        SqlDataReader oku = komut9.ExecuteReader();
        while(oku.Read())
        {
            ortalama = Convert.ToInt32(oku["ort"]);
        }
        baglan.Close();
        baglan.Open();
        SqlCommand komut6 = new SqlCommand("update KitapTanım1 set OrtalamaPuanı=('"+ortalama+"') where ID=('"+Convert.ToInt32( Session["KitapId"])+"') ",baglan);
        komut6.ExecuteNonQuery();
        baglan.Close();
        Label5.Text = "Kitap kaydı BAŞARILI";
        

        



    }
}