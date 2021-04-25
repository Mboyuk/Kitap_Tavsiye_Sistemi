using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.IO;

public partial class KullanıcıProfil : System.Web.UI.Page
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

            if(!IsPostBack)
            {


                  SqlCommand komut = new SqlCommand("select distinct Adı,Soyadı,Cinsiyet,İsmi as 'Kitap' from KitapOkunma inner join KullanıcıKayıt on KitapOkunma.KullanıcıId=KullanıcıKayıt.ID inner join KitapTanım1 on KitapTanım1.ID=KitapOkunma.KitapId inner join KitapPuan on KullanıcıKayıt.ID=KitapPuan.KullanıcıId inner join Kitapİnceleme1 on KullanıcıKayıt.ID=Kitapİnceleme1.KullanıcıId inner join KitapAlıntı1 on KullanıcıKayıt.ID=KitapAlıntı1.KullanıcıId where Adı=('"+Session["Kullanıcıİsmi"]+"')", baglan);
                
                  DataSet Kullanıcı = new DataSet();
                  SqlDataAdapter adaptor = new SqlDataAdapter(komut);
                  baglan.Open();
                  adaptor.Fill(Kullanıcı);
                  baglan.Close();
                  GridView1.DataSource = Kullanıcı.Tables[0];
                  GridView1.DataBind();


                SqlCommand komut2 = new SqlCommand("select distinct Adı,Cümle from KitapOkunma inner join KullanıcıKayıt on KitapOkunma.KullanıcıId=KullanıcıKayıt.ID inner join KitapTanım1 on KitapTanım1.ID=KitapOkunma.KitapId inner join KitapPuan on KullanıcıKayıt.ID=KitapPuan.KullanıcıId inner join Kitapİnceleme1 on KullanıcıKayıt.ID=Kitapİnceleme1.KullanıcıId inner join KitapAlıntı1 on KullanıcıKayıt.ID=KitapAlıntı1.KullanıcıId where Adı=('" + Session["Kullanıcıİsmi"] + "')", baglan);

                DataSet Kullanıcı2 = new DataSet();
                SqlDataAdapter adaptor2 = new SqlDataAdapter(komut2);
                baglan.Open();
                adaptor2.Fill(Kullanıcı2);
                baglan.Close();
                GridView4.DataSource = Kullanıcı2.Tables[0];
                GridView4.DataBind();

                SqlCommand komut44 = new SqlCommand("select distinct Adı,Kitapİnceleme1.İnceleme from KitapOkunma inner join KullanıcıKayıt on KitapOkunma.KullanıcıId=KullanıcıKayıt.ID inner join KitapTanım1 on KitapTanım1.ID=KitapOkunma.KitapId inner join KitapPuan on KullanıcıKayıt.ID=KitapPuan.KullanıcıId inner join Kitapİnceleme1 on KullanıcıKayıt.ID=Kitapİnceleme1.KullanıcıId inner join KitapAlıntı1 on KullanıcıKayıt.ID=KitapAlıntı1.KullanıcıId where Adı=('" + Session["Kullanıcıİsmi"] + "')", baglan);

                DataSet Kullanıcı44 = new DataSet();
                SqlDataAdapter adaptor44 = new SqlDataAdapter(komut44);
                baglan.Open();
                adaptor44.Fill(Kullanıcı44);
                baglan.Close();
                GridView5.DataSource = Kullanıcı44.Tables[0];
                GridView5.DataBind();

               // Image1.ImageUrl = "/Resimler/" + GridView3.Rows[0].Cells[0].Text;
                 SqlCommand komut22 = new SqlCommand("select Resim from KullanıcıKayıt where Adı=('" + Session["Kullanıcıİsmi"] + "')", baglan);
                 DataSet resim = new DataSet();
                 SqlDataAdapter ad = new SqlDataAdapter(komut22);
                 baglan.Open();
                 ad.Fill(resim);
                 GridView3.DataSource = resim.Tables[0];
                 GridView3.DataBind();
                 GridView3.Visible = false;
                Image1.ImageUrl = "/Resimler/" + Session["KullanıcıResim"].ToString();

                
                //  TextBox4.Text   = "~/ Resimler / " + GridView3.Rows[0].Cells[0].Text;



            }
        }

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        string Giden = TextBox1.Text;
        //baglan.Open();
        SqlCommand komut2 = new SqlCommand("select ID from KullanıcıKayıt where Adı=('" + Giden + "')", baglan);
        DataSet Kullanıcı00 = new DataSet();
        SqlDataAdapter adaptor = new SqlDataAdapter(komut2);
        baglan.Open();
        adaptor.Fill(Kullanıcı00);
        baglan.Close();
        GridView2.DataSource = Kullanıcı00.Tables[0];
        GridView2.DataBind();

        int ID =Convert.ToInt32(GridView2.Rows[0].Cells[0].Text);

        baglan.Open();
        SqlCommand komut = new SqlCommand("insert into Mesajlar(GönderenId,GidenId,Başlık,Mesaj) values(@gond,@giden,@baslık,@mesaj)", baglan);

        komut.Parameters.AddWithValue("@gond", Session["KullanıcıId"]);
        komut.Parameters.AddWithValue("@giden",ID);
        komut.Parameters.AddWithValue("@baslık", TextBox2.Text);
        komut.Parameters.AddWithValue("@mesaj", TextBox3.Text);
        komut.ExecuteNonQuery();
        baglan.Close();
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        baglan.Open();
        SqlCommand komu87 = new SqlCommand("delete from Mesajlar where GidenId=('" + Session["KullanıcıId"] + "')", baglan);
        komu87.ExecuteNonQuery();
        baglan.Close();
    }

    protected void GridView3_SelectedIndexChanged(object sender, EventArgs e)
    {
        int secilim1;
        secilim1 = GridView3.SelectedIndex;
        GridViewRow row = GridView3.Rows[secilim1];
        Session["Kullanıcıİsmi"] = row.Cells[1].Text;
        SqlCommand komut22 = new SqlCommand("select Resim from KullanıcıKayıt where Adı=('" + Session["Kullanıcıİsmi"] + "')", baglan);
        DataSet resim = new DataSet();
        SqlDataAdapter ad = new SqlDataAdapter(komut22);
        baglan.Open();
        ad.Fill(resim);
        GridView3.DataSource = resim.Tables[0];
        GridView3.DataBind();
        Image1.ImageUrl = "/Resimler/" + GridView3.Rows[0].Cells[0].Text;
        // GridView3.Visible = false;


        Response.Redirect("KullanıcıProfil.aspx");
    }
}