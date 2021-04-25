using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class TavsiyeSistemi : System.Web.UI.Page
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
            // baglan.Open();
            if (!IsPostBack)
            {


                SqlCommand komut2 = new SqlCommand("select KullanıcıId,KitapId from KitapOkunma where KullanıcıId=('" + Session["KullanıcıId"] + "')", baglan);
                DataSet Kullanıcı = new DataSet();
                SqlDataAdapter adaptor = new SqlDataAdapter(komut2);
                baglan.Open();
                adaptor.Fill(Kullanıcı);
                baglan.Close();
                GridView7.DataSource = Kullanıcı.Tables[0];
                GridView7.DataBind();

                //  baglan.Open();
                /* SqlCommand komut11 = new SqlCommand("select count(*) from KitapOkunma where KitapId=('" + Convert.ToInt32(Session["KitapId"]) + "')", baglan);
                 int OkunmaSayısı = Convert.ToInt32(komut11.ExecuteScalar());
                 komut11.ExecuteNonQuery();

                 baglan.Close();*/



                SqlCommand komut = new SqlCommand("select  KullanıcıId,KitapId from KitapOkunma where KullanıcıId!=('" + Session["KullanıcıId"] + "') ", baglan);
                DataSet Kullanıcılar = new DataSet();
                SqlDataAdapter adaptor2 = new SqlDataAdapter(komut);
                baglan.Open();
                adaptor2.Fill(Kullanıcılar);
                baglan.Close();
                GridView6.DataSource = Kullanıcılar.Tables[0];
                GridView6.DataBind();

                /* int k1,k2;
                 k1 = GridView7.SelectedIndex;
                 GridViewRow sıra = GridView7.Rows[k1];
                 k2 = GridView6.SelectedIndex;
                 GridViewRow sıra2 = GridView6.Rows[k2];*/


                int okunmasayısı = 1, b = 0;
                string[] dizi = new string[12];

                for (int i = 0; i < GridView7.Rows.Count; i++)
                {
                    for (int j = 0; j < GridView6.Rows.Count; j++)
                    {
                        b++;
                        if ((GridView7.Rows[i].Cells[2].Text) == (GridView6.Rows[j].Cells[2].Text))
                        {
                            // bunu unutMAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA
                            
                            baglan.Open();
                            SqlCommand komut3 = new SqlCommand("insert into OrtakKitaplar1(OkudugumKitaplarId,OrtakKullanıcıId,OrtakKitapSayısı) values(@ad,@soyad,@ots)", baglan);
                            komut3.Parameters.AddWithValue("@ad", GridView7.Rows[i].Cells[2].Text);
                            komut3.Parameters.AddWithValue("@soyad", GridView6.Rows[j].Cells[1].Text);
                            komut3.Parameters.AddWithValue("@ots", okunmasayısı);
                            komut3.ExecuteNonQuery();
                            baglan.Close();
                            TextBox4.Text = okunmasayısı.ToString();
                            okunmasayısı++;
                           
                        }
                        else if((GridView7.Rows[i].Cells[2].Text!=GridView6.Rows[j].Cells[2].Text))
                        {
                            //grid 6 nın textini alacan
                            /* int k = 0;
                             dizi[k]=GridView6.Rows[j].Cells[2].Text;
                             k++;*/
                            //delete from OrtakOlmayan from OrtakOlmayan u1 inner join (select max(Oneri1)Oneri1 from OrtakOlmayan group by Oneri1) u2 on u1.Oneri1=u2.Oneri1 where u2.Oneri1
                            //delete OrtakOlmayan from KitapOkunma inner join OrtakOlmayan on  KitapOkunma.KullanıcıId=1 and KitapOkunma.KitapId=OrtakOlmayan.Oneri1
                            baglan.Open();
                            SqlCommand komut88 = new SqlCommand("insert into OrtakOlmayan(Oneri1) values('" + GridView6.Rows[j].Cells[2].Text + "')", baglan);
                            komut88.ExecuteNonQuery();
                            baglan.Close();



                        }

                    }
                }
                //TextBox4.Text = dizi[0];
                SqlCommand komut55 = new SqlCommand("select distinct  İsmi as 'KİTAP ÖNERİ' from OrtakOlmayan inner join KitapTanım1 on OrtakOlmayan.Oneri1=KitapTanım1.ID ", baglan);
                DataSet OrtakOlmayan = new DataSet();
                SqlDataAdapter adaptor33 = new SqlDataAdapter(komut55);
                baglan.Open();
                adaptor33.Fill(OrtakOlmayan);
                baglan.Close();
                GridView12.DataSource = OrtakOlmayan.Tables[0];
                GridView12.DataBind();

                SqlCommand komut5 = new SqlCommand("select Adı as 'KULLANICI',İsmi as 'KİTAPLARIM'  from KullanıcıKayıt inner join OrtakKitaplar1 on KullanıcıKayıt.ID=OrtakKitaplar1.OrtakKullanıcıId inner join KitapTanım1 on Kitaptanım1.ID=Ortakkitaplar1.OkudugumKitaplarId ", baglan);
                DataSet OrtakTablo = new DataSet();
                SqlDataAdapter adaptor22 = new SqlDataAdapter(komut5);
                baglan.Open();
                adaptor22.Fill(OrtakTablo);
                baglan.Close();
                GridView8.DataSource = OrtakTablo.Tables[0];
                GridView8.DataBind();


                SqlCommand komut21 = new SqlCommand("select Resim from KullanıcıKayıt where ID=('"+Session["KullanıcıId"]+"') ", baglan);
                DataSet OrtakTablo21 = new DataSet();
                SqlDataAdapter adaptor223 = new SqlDataAdapter(komut21);
                baglan.Open();
                adaptor223.Fill(OrtakTablo21);
                baglan.Close();
                GridView16.DataSource = OrtakTablo21.Tables[0];
                GridView16.DataBind();
                Session["KullanıcıResim"]= GridView16.Rows[0].Cells[0].Text;
               /* int secilim123;
                secilim123 = GridView16.SelectedIndex;
                GridViewRow row3 = GridView16.Rows[secilim123];
                Session["KullanıcıResim"] = row3.Cells[0].Text;*/
               // Session["Kitapİsmi"] = row.Cells[2].Text;
              //  Response.Redirect("KitapDetay.aspx");

                //--------------------------------------------------------------------------------------------------------------------
                SqlCommand komut66 = new SqlCommand("select KullanıcıId, KitapId, Puan from KitapPuan where KullanıcıId=('" + Session["KullanıcıId"] + "')", baglan);
                DataSet Tavsiye2 = new DataSet();
                SqlDataAdapter adaptor66 = new SqlDataAdapter(komut66);
                baglan.Open();
                adaptor66.Fill(Tavsiye2);
                baglan.Close();
                GridView9.DataSource = Tavsiye2.Tables[0];
                GridView9.DataBind();

                SqlCommand komut211 = new SqlCommand("select KullanıcıId, KitapId, Puan from KitapPuan where KullanıcıId!=('" + Session["KullanıcıId"] + "')", baglan);
                DataSet Tavsiye22 = new DataSet();
                SqlDataAdapter adaptor211 = new SqlDataAdapter(komut211);
                baglan.Open();
                adaptor211.Fill(Tavsiye22);
                baglan.Close();
                GridView10.DataSource = Tavsiye22.Tables[0];
                GridView10.DataBind();
               // string[] dizi = new string[3];
                for (int i = 0; i < GridView9.Rows.Count; i++)
                {
                    for (int j = 0; j < GridView10.Rows.Count; j++)
                    {
                        if (GridView9.Rows[i].Cells[1].Text == GridView10.Rows[j].Cells[1].Text && GridView9.Rows[i].Cells[2].Text == GridView10.Rows[j].Cells[2].Text)
                        {

                            baglan.Open();
                            SqlCommand komut3 = new SqlCommand("insert into OrtakPuan(KitapId,Puan) values(@kitapıd,@puan) ", baglan);
                            komut3.Parameters.AddWithValue("@kitapıd", GridView9.Rows[i].Cells[1].Text);
                            komut3.Parameters.AddWithValue("@puan", GridView9.Rows[i].Cells[2].Text);
                            komut3.ExecuteNonQuery();
                            baglan.Close();


                            //BURAYA BAKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKK

                            /*DataTable dt = new DataTable();
                            dt.Columns.AddRange(new DataColumn[1] { 
                                    new DataColumn("Ad", typeof(string)) });

                            for(int İ=0;i< GridView11.Rows.Count+1; i++)
                            {
                                dt.Rows.Add(GridView9.Rows[i].Cells[1].Text);

                            }

                            //dt.Rows.Add( "Amerika");

                            GridView11.DataSource = dt;
                            GridView11.DataBind();*/
                            /*  int k = 0;
                              dizi[k]= GridView9.Rows[i].Cells[1].Text;
                              k++;

                               DataTable dt = new DataTable();
                               DataColumn dcol = new DataColumn("Puan", typeof(System.Int32));
                              // dcol.AutoIncrement = true;

                               dt.Columns.Add(dcol);

                               dcol = new DataColumn("KitapId", typeof(System.String));
                              //dcol=new DataColumn("asd")
                               dt.Columns.Add(dcol);

                               for (int nIndex = 0; nIndex < GridView11.Rows.Count+1; nIndex++)
                               {
                                   DataRow drow = dt.NewRow();
                                  drow["Puan"]= GridView9.Rows[i].Cells[2].Text;
                                  drow["KitapId"] = GridView9.Rows[i].Cells[1].Text;
                                   dt.Rows.Add(drow);
                                //   nIndex = 0;

                               }

                               GridView11.DataSource = dt;
                               GridView11.DataBind();*/
                            /* DataTable tablo = new DataTable();// tablo oluşturduk
                             tablo.Columns.Add("isim"); // colon ismi isim
                             DataRow row = tablo.NewRow();
                             row["isim"] = GridView9.Rows[i].Cells[1].Text;
                             tablo.Rows.Add(row);
                             GridView11.DataSource = tablo;
                             GridView11.DataBind();*/
                        }
                        else if(GridView9.Rows[i].Cells[1].Text != GridView10.Rows[j].Cells[1].Text)
                        {
                            baglan.Open();
                            SqlCommand komut77 = new SqlCommand("insert into OrtakOlmayan2(Oneri2) values('" + GridView10.Rows[j].Cells[1].Text + "')", baglan);
                            komut77.ExecuteNonQuery();
                            baglan.Close();
                        }
                    }
                }
                //buraya BAKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKK
                SqlCommand komut57 = new SqlCommand("select distinct  İsmi from OrtakOlmayan2 inner join KitapTanım1 on OrtakOlmayan2.Oneri2=KitapTanım1.ID ", baglan);
                DataSet OrtakOlmayan2 = new DataSet();


                SqlDataAdapter adaptor37 = new SqlDataAdapter(komut57);
                baglan.Open();
                adaptor37.Fill(OrtakOlmayan2);
                baglan.Close();
                GridView12.DataSource = OrtakOlmayan2.Tables[0];
                GridView12.DataBind();

                SqlCommand komut4 = new SqlCommand("select İsmi as 'KİTAP İSMİ' ,Adı as 'KULLANICI' from OrtakPuan inner join KitapTanım1 on OrtakPuan.KitapId=KitapTanım1.ID inner join KitapPuan on KitapPuan.Puan=OrtakPuan.Puan and KitapPuan.KitapId=OrtakPuan.KitapId inner join KullanıcıKayıt on KullanıcıKayıt.ID=KitapPuan.KullanıcıId", baglan);
                DataSet OrtakPuan = new DataSet();
                SqlDataAdapter adaptor3 = new SqlDataAdapter(komut4);
                baglan.Open();
                adaptor3.Fill(OrtakPuan);
                baglan.Close();
                GridView11.DataSource = OrtakPuan.Tables[0];
                GridView11.DataBind();


            }

        }
      
        SqlCommand komut0 = new SqlCommand("select Adı as 'GÖNDEREN',Başlık,Mesaj from Mesajlar inner join KullanıcıKayıt on KullanıcıKayıt.ID=Mesajlar.GönderenId where GidenId=('" + Session["KullanıcıId"] + "')", baglan);
        DataSet veri = new DataSet();
        SqlDataAdapter ad = new SqlDataAdapter(komut0);
        baglan.Open();
        ad.Fill(veri);
        baglan.Close();
        GridView15.DataSource = veri.Tables[0];
        GridView15.DataBind();
        
      /*  if (Session["Kullanıcıİsmi"] == "mehmet")
        {
            TextBox4.Text = "aliiiii";
        }*/
        /*GridView15.Visible = false;
        int secilim111;
        secilim111 = GridView15.SelectedIndex;
        GridViewRow row1 = GridView15.Rows[secilim111];
        Session["veri"] = row1.Cells[2].Text;*/

        /*  if (Session["veri"]==Session["KullanıcıId"])
          {
              GridView15.Visible = true;
          }*/






    }
   
    protected void Button1_Click1(object sender, EventArgs e)
    {
        // baglan.Open();
        string ad = TextBox1.Text.Trim();
        SqlCommand komut = new SqlCommand("select ID,İsmi from KitapTanım1 where İsmi=('"+ad+"') ", baglan);
         DataSet Kitapİsmi = new DataSet();
         SqlDataAdapter adaptor = new SqlDataAdapter(komut);
         baglan.Open();
         adaptor.Fill(Kitapİsmi);
         baglan.Close();
         GridView2.DataSource = Kitapİsmi.Tables[0];
         
         GridView2.DataBind();
        GridView2.Visible = true;
        GridView3.Visible = false;
        GridView4.Visible = false;
        GridView5.Visible = false;
        GridView6.Visible = false;
        GridView7.Visible = false;
       // GridView8.Visible = false;
        GridView9.Visible = false;
        

    }

    protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        string ad = TextBox1.Text.Trim();
        baglan.Open();
        SqlCommand komut = new SqlCommand("select ID from KitapTanım1 where İsmi=('" + ad + "')", baglan);
        SqlDataReader oku = komut.ExecuteReader();
        while(oku.Read())
        {
            Session["KitapId"] = oku["ID"];
        }
        baglan.Close();
        Session["Kitapİsmi"] = TextBox1.Text;
       
        

    }
    protected void GridView2_SelectedIndexChanged(object sender, EventArgs e)
    {
        int secilim;
        secilim = GridView2.SelectedIndex;
        GridViewRow row = GridView2.Rows[secilim];
        Session["KitapId"] = row.Cells[1].Text;
        Session["Kitapİsmi"] = row.Cells[2].Text;
        Response.Redirect("KitapDetay.aspx");

    }

    protected void Button3_Click(object sender, EventArgs e)
    {
        string ad = TextBox3.Text.Trim();
        SqlCommand komut = new SqlCommand("select ID,Ad from YazarTanım1 where Ad=('" + ad + "') ", baglan);
        DataSet Yazarİsmi = new DataSet();
        SqlDataAdapter adaptor = new SqlDataAdapter(komut);
        baglan.Open();
        adaptor.Fill(Yazarİsmi);
        baglan.Close();
        GridView3.DataSource = Yazarİsmi.Tables[0];

        GridView3.DataBind();
        GridView2.Visible = false;
        GridView3.Visible = true;
        GridView4.Visible = false;
        GridView5.Visible = false;
        GridView6.Visible = false;
        GridView7.Visible = false;
      //  GridView8.Visible = false;
        GridView9.Visible = false;


    }

    protected void GridView3_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        string ad = TextBox3.Text.Trim();
        baglan.Open();
        SqlCommand komut = new SqlCommand("select ID from YazarTanım1 where Ad=('" + ad + "')", baglan);
        SqlDataReader oku = komut.ExecuteReader();
        while (oku.Read())
        {
            Session["YazarId"] = oku["ID"];
        }
        baglan.Close();
        Session["Yazarİsmi"] = TextBox3.Text;

        

    }
    protected void GridView3_SelectedIndexChanged(object sender, EventArgs e)
    {
        int secilim;
        secilim = GridView3.SelectedIndex;
        GridViewRow row = GridView3.Rows[secilim];
        Session["Yazarİsmi"] = row.Cells[2].Text;
        Response.Redirect("YazarDetay.aspx");
    }

    protected void Button4_Click(object sender, EventArgs e)
    {
        SqlCommand komut = new SqlCommand("select  ID,İsmi,Yazar,OkunmaSayısı from KitapTanım1 order by OkunmaSayısı desc ", baglan);
        DataSet sırala = new DataSet();
        SqlDataAdapter adaptor = new SqlDataAdapter(komut);
        baglan.Open();
        adaptor.Fill(sırala);
        baglan.Close();
        GridView4.DataSource = sırala.Tables[0];
        GridView4.DataBind();
        GridView2.Visible = false;
        GridView3.Visible = false;
        GridView4.Visible = true;
        GridView5.Visible = false;
        GridView6.Visible = false;
        GridView7.Visible = false;
       // GridView8.Visible = false;
        GridView9.Visible = false;


    }

    protected void GridView4_SelectedIndexChanged(object sender, EventArgs e)
    {

        int secili;
        secili = GridView4.SelectedIndex;
        GridViewRow row = GridView4.Rows[secili];
        Session["KitapId"] = row.Cells[1].Text;
        Session["Kitapİsmi"] = row.Cells[2].Text;
        Response.Redirect("KitapDetay.aspx");

    }



    protected void Button5_Click(object sender, EventArgs e)
    {
        SqlCommand komut = new SqlCommand("select  ID,İsmi,Yazar,OrtalamaPuanı from KitapTanım1 order by OrtalamaPuanı desc ", baglan);
        DataSet sırala = new DataSet();
        SqlDataAdapter adaptor = new SqlDataAdapter(komut);
        baglan.Open();
        adaptor.Fill(sırala);
        baglan.Close();
        GridView5.DataSource = sırala.Tables[0];
        GridView5.DataBind();
        GridView2.Visible = false;
        GridView3.Visible = false;
        GridView4.Visible = false;
        GridView5.Visible = true;
        GridView6.Visible = false;
        GridView7.Visible = false;
      //  GridView8.Visible = false;
        GridView9.Visible = false;


    }
    protected void GridView5_SelectedIndexChanged(object sender, EventArgs e)
    {
        int secilim1;
      //  GridView7.Visible = true;
        secilim1 = GridView5.SelectedIndex;
        GridViewRow row = GridView5.Rows[secilim1];
        Session["KitapId"] = row.Cells[1].Text;
        Session["Kitapİsmi"] = row.Cells[2].Text;
        Response.Redirect("KitapDetay.aspx");
    }


    protected void Button6_Click(object sender, EventArgs e)
    {
        //YAZAAR ID Yİ AYARLAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA
        GridView6.Visible = true;
        SqlCommand komut = new SqlCommand("select  ID,Yazar,OkunmaSayısı from KitapTanım1 order by OkunmaSayısı desc ", baglan);
        DataSet sırala = new DataSet();
        SqlDataAdapter adaptor = new SqlDataAdapter(komut);
        baglan.Open();
        adaptor.Fill(sırala);
        baglan.Close();
        GridView6.DataSource = sırala.Tables[0];
        GridView6.DataBind();
        GridView2.Visible = false;
        GridView3.Visible = false;
        GridView4.Visible = false;
        GridView5.Visible = false;
        GridView6.Visible = true;
        GridView7.Visible = false;
      //  GridView8.Visible = false;
        GridView9.Visible = false;

    }

    protected void GridView6_SelectedIndexChanged(object sender, EventArgs e)
    {
        int secilim;
        GridView7.Visible = true;
        secilim = GridView6.SelectedIndex;
        GridViewRow row = GridView6.Rows[secilim];
        Session["KitapId"] = row.Cells[1].Text;
        Session["Yazarİsmi"] = row.Cells[2].Text;
       // TextBox4.Text = Session["Yazarİsmi"].ToString();
        SqlCommand komut = new SqlCommand("select İsmi from KitapTanım1 where Yazar=('"+Session["Yazarİsmi"].ToString().Trim()+"')", baglan);

        DataSet sırala = new DataSet();
        SqlDataAdapter adaptor = new SqlDataAdapter(komut);
        baglan.Open();
        adaptor.Fill(sırala);
        baglan.Close();
        GridView7.DataSource = sırala.Tables[0];
        GridView7.DataBind();

    }

    protected void GridView6_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        //KİTAP EKLEYİNCE YAZAR TANIM TABLOSUNADA VERİ GİDECEK
       /* SqlCommand komut = new SqlCommand("select Kitaplar from YazarTanım1 where ID='1'", baglan);
       
        DataSet sırala = new DataSet();
        SqlDataAdapter adaptor = new SqlDataAdapter(komut);
        baglan.Open();
        adaptor.Fill(sırala);
        baglan.Close();
        GridView6.DataSource = sırala.Tables[0];
        GridView6.DataBind();*/
    }

    protected void GridView7_SelectedIndexChanged(object sender, EventArgs e)
    {
        int secilim;
        secilim = GridView7.SelectedIndex;
        GridViewRow row = GridView7.Rows[secilim];
        Session["Kitapİsmi"] = row.Cells[1].Text;
        //TextBox4.Text= row.Cells[1].Text;
        Response.Redirect("KitapDetay.aspx");
    }
    /* protected void GridView6_SelectedIndexChanged(object sender, EventArgs e)
     {
         int secilim;
         secilim = GridView6.SelectedIndex;
         GridViewRow row = GridView6.Rows[secilim];
         Session["Yazarİsmi"] = row.Cells[2].Text;
         // TextBox4.Text = Session["Yazarİsmi"].ToString();
         SqlCommand komut = new SqlCommand("select Kitaplar from YazarTanım1 where Ad=('" + Session["Yazarİsmi"].ToString().Trim() + "')", baglan);

         DataSet sırala = new DataSet();
         SqlDataAdapter adaptor = new SqlDataAdapter(komut);
         baglan.Open();
         adaptor.Fill(sırala);
         baglan.Close();
         GridView7.DataSource = sırala.Tables[0];
         GridView7.DataBind();

     }*/





    protected void Button7_Click(object sender, EventArgs e)
    {

    }

    protected void Button8_Click(object sender, EventArgs e)
    {
        baglan.Open();
        SqlCommand komut = new SqlCommand("delete from OrtakKitaplar1", baglan);
        komut.ExecuteNonQuery();
        SqlCommand komut2 = new SqlCommand("delete from OrtakPuan", baglan);
        komut2.ExecuteNonQuery();
        SqlCommand komut3 = new SqlCommand("delete from OrtakOlmayan", baglan);
        baglan.Close();
        Response.Redirect("GirisSayfası.aspx");
    }



    protected void Button2_Click(object sender, EventArgs e)
    {

        string ad = TextBox2.Text.Trim();
        SqlCommand komut = new SqlCommand("select Adı,Soyadı,Resim from KullanıcıKayıt where Adı=('" + ad + "') ", baglan);
        DataSet Kullanıcıİsmi = new DataSet();
        SqlDataAdapter adaptor = new SqlDataAdapter(komut);
        baglan.Open();
        adaptor.Fill(Kullanıcıİsmi);
        baglan.Close();
        GridView14.DataSource = Kullanıcıİsmi.Tables[0];
        GridView14.DataBind();

        GridView2.Visible = false;
        GridView3.Visible = false;
        GridView4.Visible = false;
        GridView5.Visible = false;
        GridView6.Visible = false;
        GridView7.Visible = false;
        // GridView8.Visible = false;
        GridView9.Visible = false;

    }

    protected void GridView14_SelectedIndexChanged(object sender, EventArgs e)
    {
        int secilim1;
        secilim1 = GridView14.SelectedIndex;
        GridViewRow row = GridView14.Rows[secilim1];
        Session["Kullanıcıİsmi"] = row.Cells[1].Text;
        Session["KullanıcıResim"] = row.Cells[3].Text;
        Response.Redirect("KullanıcıProfil.aspx");
        // TextBox4.Text = Session["Kullanıcıİsim"].ToString();
    }

    protected void GridView15_SelectedIndexChanged(object sender, EventArgs e)
    {

        int secilim;
        secilim = GridView15.SelectedIndex;
        GridViewRow row = GridView15.Rows[secilim];
        Session["Kullanıcıİsmi"] = row.Cells[1].Text;
        // TextBox4.Text = Session["Kullanıcıİsmi"].ToString();

        Response.Redirect("KullanıcıProfil.aspx");

    }
    






} 