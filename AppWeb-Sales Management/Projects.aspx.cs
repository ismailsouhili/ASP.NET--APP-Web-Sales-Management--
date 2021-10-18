using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace AppWeb_Sales_Management
{
    public partial class Projects : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Userid"] == null)
            {
                Response.Redirect("Login.aspx");
            }

            LibraryDb.SelectCommand = "SELECT [ProjId],[ProjectName],dbo.fn_getUserName([ProjectManager]) as [ProjectManager],CONVERT(CHAR(23),CONVERT(DATETIME,timestamp,101),121) as timestamp,[Amount],[Revenue],[Description],[status],CONVERT(CHAR(23),CONVERT(DATETIME,LaunchDate,101),121) as [LaunchDate],[Duration],[ContactName],[ContactMobile],[Notes] FROM [dbo].[Project_Table]  Where [ProjectManager]='" + Session["UserId"].ToString() + "' ORDER BY[ProjectName]";

        }

        protected void LibraryDb_Selecting(object sender, SqlDataSourceSelectingEventArgs e)
        {

        }
    }
}