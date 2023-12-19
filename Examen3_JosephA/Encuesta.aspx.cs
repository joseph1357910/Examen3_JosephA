using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Examen3_JosephA
{
    public partial class Encuesta : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void txtNombre_TextChanged(object sender, EventArgs e)
        {

        }

        protected void txtEdad_TextChanged(object sender, EventArgs e)
        {

        }

        protected void txtCorreo_TextChanged(object sender, EventArgs e)
        {

        }

        protected void ddlPartido_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        protected void GuardarEncuesta_Click(object sender, EventArgs e)
        {
            string nombre = txtNombre.Text;
            int edad;

            if (!int.TryParse(txtEdad.Text, out edad))
            {
                MostrarMensaje("La edad debe ser un número válido.");
                return;
            }

            string correo = txtCorreo.Text;
            string partido = ddlPartido.SelectedValue;

            
            if (edad < 18 || edad > 50)
            {
                MostrarMensaje("La edad debe estar entre 18 y 50 años.");
                return;
            }

            
            InsertarEncuesta(nombre, edad, correo, partido);

            
            Server.Transfer("~/Reporte.aspx?encuestaGuardada=true", true);
        }
        private void InsertarEncuesta(string nombre, int edad, string correo, string partido)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["JosephA"].ConnectionString;

            
            Console.WriteLine("ConnectionString: " + connectionString);

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string queryInsertPartido = "INSERT INTO PartidosPoliticos (Nombre_Partido) VALUES (@Partido)";
                string queryInsertEncuesta = "INSERT INTO Encuestas (Nombre_Participante, Edad, Correo_Electronico, ID_Partido) " +
                                             "VALUES (@Nombre, @Edad, @Correo, @ID_Partido)";

                int idPartido = 0;

                using (SqlCommand cmd = new SqlCommand(queryInsertPartido, con))
                {
                    cmd.Parameters.AddWithValue("@Partido", partido);

                    con.Open();
                    cmd.ExecuteNonQuery();

                    
                    cmd.CommandText = "SELECT SCOPE_IDENTITY()";
                    idPartido = Convert.ToInt32(cmd.ExecuteScalar());
                }

                using (SqlCommand cmd = new SqlCommand(queryInsertEncuesta, con))
                {
                    cmd.Parameters.AddWithValue("@Nombre", nombre);
                    cmd.Parameters.AddWithValue("@Edad", edad);
                    cmd.Parameters.AddWithValue("@Correo", correo);
                    cmd.Parameters.AddWithValue("@ID_Partido", idPartido);

                    try
                    {
                        con.Open();
                        cmd.ExecuteNonQuery();
                        MostrarMensaje("Encuesta guardada exitosamente.");
                    }
                    catch (Exception ex)
                    {
                        MostrarMensaje("Error al guardar la encuesta. Detalles: " + ex.Message);
                    }
                }
            }
        }
        private void MostrarMensaje(string mensaje)
        {
            
            ScriptManager.RegisterStartupScript(this, this.GetType(), "script", $"alert('{mensaje}');", true);
        }
    }
}