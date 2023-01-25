using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DataTableSample
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LabelNumBoliger.Text = GetNumOfBoliger().ToString();//hvorfor ToString her?
        }

        /// <summary>
        /// Teller hvor mange boliger det er i tabellen Bolig. Returnerer kun et tall. Er det OK å ha en slik metode i her?
        /// </summary>
        private int GetNumOfBoliger()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["BoligEier"].ConnectionString;
            DataTable dt = new DataTable();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT count(bid) from Bolig", conn);
                cmd.CommandType = CommandType.Text;
                int num = (Int32)cmd.ExecuteScalar();//returner den første raden og den første kolonnen. sjekk i sql manager. Unboxing eksempel.

                conn.Close();
                return num;
            }
        }

        protected void ButtonSearchByPhone_Click(object sender, EventArgs e)
        {
            //her kommer db-metoden
            //bind til gridview
            //GridViewBoligEiere.DataSource=datatable
            //GridViewBoligEiere.DataBind();

            //kalle på metoden i DBLayer
            DBLayer layer = new DBLayer();
            GridViewBoligEiere.DataSource=layer.GetBoligAndOwnersByTelefon(TextBoxSearchByPhone.Text);
            GridViewBoligEiere.DataBind();
        }

        protected void ButtonSearchMail_Click(object sender, EventArgs e)
        {
            DBLayer layer = new DBLayer();
            GridViewBoligEiere.DataSource = layer.GetBoligAndOwnersByMail(TextBoxMail.Text);
            GridViewBoligEiere.DataBind();
        }


        protected void ButtonShowAllBoliger_Click(object sender, EventArgs e)
        {
            DBLayer dbl=new DBLayer();
            GridViewBoligEiere.DataSource = dbl.GetAllBoligs();
            GridViewBoligEiere.DataBind();
        }


        private DataTable GetAllBoligs()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["BoligEier"].ConnectionString;
            DataTable dt = new DataTable();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Bolig", conn);
                cmd.CommandType = CommandType.Text;

                SqlDataReader reader = cmd.ExecuteReader();

                dt.Load(reader);

                reader.Close();
                conn.Close();
            }
                return dt;
        }
    }
}