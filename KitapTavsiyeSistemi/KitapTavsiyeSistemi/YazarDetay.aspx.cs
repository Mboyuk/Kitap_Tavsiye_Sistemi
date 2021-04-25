using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class YazarDetay : System.Web.UI.Page
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
        
            SqlCommand komut = new SqlCommand("select  *from YazarTanım1 where ID=('" + Session["YazarId"] + "')  ", baglan);
            DataSet Yazarİsmi = new DataSet();
            SqlDataAdapter adaptor = new SqlDataAdapter(komut);
            baglan.Open();
            adaptor.Fill(Yazarİsmi);
            baglan.Close();
            GridView1.DataSource = Yazarİsmi.Tables[0];
            GridView1.DataBind();
        }
    }

    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        bool sonuc = false;
        baglan.Open();
        SqlCommand komut = new SqlCommand("select Kitaplar from YazarTanım1 where ID=('"+Session["YazarId"]+"')", baglan);
        SqlDataReader oku = komut.ExecuteReader();
        while(oku.Read())
        {
            Session["Kitapİsmi"] = oku["Kitaplar"].ToString().Trim();
        }
        baglan.Close();
        baglan.Open();
        SqlCommand komut2 = new SqlCommand("select *from KitapTanım1 where İsmi=('" + Session["Kitapİsmi"] + "')", baglan);
        SqlDataReader oku2 = komut2.ExecuteReader();
        while (oku2.Read())
        {
            if (Session["Kitapİsmi"].ToString()==oku2["İsmi"].ToString().Trim())
            {
                sonuc = true;
            }
        }
        baglan.Close();
        if (sonuc == true)
        {
            Response.Redirect("KitapDetay.aspx");

        }
        else
            Response.Redirect("YazarDetay.aspx");
      
       

    }
}