using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SifreKoruma : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Convert.ToBoolean(Session["giris"]) != true)

            Response.Redirect("GirisSayfası.aspx");
        else
            Response.Redirect("TavsiyeSistemi.aspx");
    }
}