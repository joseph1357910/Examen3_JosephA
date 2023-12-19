using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Examen3_JosephA
{
    public partial class Reporte : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                
                if (Request.QueryString["encuestaGuardada"] != null && Request.QueryString["encuestaGuardada"] == "true")
                {
                    
                    LlenarGridView();
                }
            }
        }

        protected void gvEncuestas_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        private void LlenarGridView()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["JosephA"].ConnectionString;

            
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                
                string query = "SELECT Nombre_Participante, Edad, Correo_Electronico, Nombre_Partido FROM Encuestas " +
                               "INNER JOIN PartidosPoliticos ON Encuestas.ID_Partido = PartidosPoliticos.ID_Partido";

                
                using (SqlDataAdapter adapter = new SqlDataAdapter(query, con))
                {
                    DataTable dataTable = new DataTable();

                    
                    con.Open();
                    adapter.Fill(dataTable);

                    
                    gvReporte.DataSource = dataTable;
                    gvReporte.DataBind();
                }
            }
        }
    }
}    