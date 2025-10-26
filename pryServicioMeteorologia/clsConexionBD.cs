using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pryServicioMeteorologia
{
    internal class clsConexionBD
    {
        SqlConnection coneccionBaseDatos;
        string cadenaConexion = "Server=localhost;Database=Meteorologia;Trusted_Connection=True;";
        SqlCommand comandoBaseDatos;
        OleDbDataReader lectorDataReader;
        public string nombreBaseDeDatos;
        public void ConectarBD()
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(cadenaConexion))
                {
                    conexion.Open();
                    MessageBox.Show("Conectado correctamente a la base de datos: " + conexion.Database);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al conectar: " + ex.Message);
            }
        }

        public void CargarTreeView(TreeView treeView)
        {
            if (treeView == null) return;
            treeView.Nodes.Clear();

            try
            {
                using (SqlConnection conexion = new SqlConnection(cadenaConexion))
                {
                    conexion.Open();

                    string sqlProvincias = "SELECT id_provincia, nombre_provincia FROM Provincias ORDER BY nombre_provincia";
                    SqlCommand cmdProv = new SqlCommand(sqlProvincias, conexion);
                    SqlDataReader drProv = cmdProv.ExecuteReader();

                    Dictionary<int, TreeNode> dictProvincias = new Dictionary<int, TreeNode>();

                    while (drProv.Read())
                    {
                        int idProvincia = Convert.ToInt32(drProv["id_provincia"]);
                        string nombreProvincia = drProv["nombre_provincia"].ToString();

                        TreeNode nodoProvincia = new TreeNode(nombreProvincia)
                        {
                            Tag = new { Tipo = "Provincia", Id = idProvincia }
                        };

                        treeView.Nodes.Add(nodoProvincia);
                        dictProvincias.Add(idProvincia, nodoProvincia);
                    }

                    drProv.Close();

                    string sqlLocalidades = "SELECT id_localidad, id_provincia, nombre_localidad FROM Localidades ORDER BY id_provincia, nombre_localidad";
                    SqlCommand cmdLoc = new SqlCommand(sqlLocalidades, conexion);
                    SqlDataReader drLoc = cmdLoc.ExecuteReader();

                    while (drLoc.Read())
                    {
                        int idLocalidad = Convert.ToInt32(drLoc["id_localidad"]);
                        int idProvincia = Convert.ToInt32(drLoc["id_provincia"]);
                        string nombreLocalidad = drLoc["nombre_localidad"].ToString();

                        if (dictProvincias.ContainsKey(idProvincia))
                        {
                            TreeNode nodoLocalidad = new TreeNode(nombreLocalidad)
                            {
                                Tag = new { Tipo = "Localidad", Id = idLocalidad }
                            };
                            dictProvincias[idProvincia].Nodes.Add(nodoLocalidad);
                        }
                    }

                    drLoc.Close();
                    conexion.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar provincias/localidades: " + ex.Message);
            }
        }

        public void CargarTemperaturas(TreeView treeView, ListView listView, Guna2DateTimePicker dtpFecha)
        {
            if (treeView == null || listView == null || dtpFecha == null) return;

            treeView.AfterSelect += (sender, e) =>
            {
                TreeNode nodo = e.Node;
                if (nodo == null) return;

                listView.Items.Clear();
                listView.Columns.Clear();
                listView.View = View.Details;
                listView.FullRowSelect = true;
                listView.GridLines = true;

                listView.Columns.Add("Localidad", 180);
                listView.Columns.Add("Temp. Mínima", 100);
                listView.Columns.Add("Temp. Máxima", 100);

                DateTime fecha = dtpFecha.Value.Date;

                try
                {
                    using (SqlConnection conexion = new SqlConnection(cadenaConexion))
                    {
                        conexion.Open();

                        string sql = "";
                        SqlCommand cmd = new SqlCommand();
                        cmd.Connection = conexion;

                        var tag = nodo.Tag;
                        if (tag == null) return;

                        var tipoProp = tag.GetType().GetProperty("Tipo");
                        var idProp = tag.GetType().GetProperty("Id");
                        string tipo = tipoProp.GetValue(tag).ToString();
                        int id = (int)idProp.GetValue(tag);

                        if (tipo == "Provincia")
                        {
                            sql = @"SELECT L.nombre_localidad AS Localidad, T.temp_min, T.temp_max
                                    FROM Localidades L
                                    LEFT JOIN Temperaturas T 
                                    ON L.id_localidad = T.id_localidad AND T.fecha = @fecha
                                    WHERE L.id_provincia = @idProv
                                    ORDER BY L.nombre_localidad";
                            cmd.Parameters.AddWithValue("@idProv", id);
                        }
                        else
                        {
                            sql = @"SELECT L.nombre_localidad AS Localidad, T.temp_min, T.temp_max
                                    FROM Localidades L
                                    LEFT JOIN Temperaturas T 
                                    ON L.id_localidad = T.id_localidad AND T.fecha = @fecha
                                    WHERE L.id_localidad = @idLoc";
                            cmd.Parameters.AddWithValue("@idLoc", id);
                        }

                        cmd.Parameters.AddWithValue("@fecha", fecha);
                        cmd.CommandText = sql;

                        SqlDataReader dr = cmd.ExecuteReader();
                        bool hayDatos = false;

                        while (dr.Read())
                        {
                            hayDatos = true;
                            string localidad = dr["Localidad"].ToString();
                            string tMin = dr["temp_min"] != DBNull.Value ? dr["temp_min"].ToString() : "-";
                            string tMax = dr["temp_max"] != DBNull.Value ? dr["temp_max"].ToString() : "-";

                            ListViewItem item = new ListViewItem(localidad);
                            item.SubItems.Add(tMin);
                            item.SubItems.Add(tMax);
                            listView.Items.Add(item);
                        }

                        dr.Close();

                        if (!hayDatos)
                        {
                            MessageBox.Show("No hay datos de temperatura para la selección actual.");
                        }

                        conexion.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar temperaturas: " + ex.Message);
                }
            };
        }

        public void ActualizarStatusStrip(TreeView treeView, ToolStripStatusLabel lblEstado)
        {
            if (treeView == null || lblEstado == null) return;

            treeView.AfterSelect += (sender, e) =>
            {
                string provincia = "-";
                string localidad = "-";

                if (e.Node != null)
                {
                    if (e.Node.Parent == null)
                        provincia = e.Node.Text;
                    else
                    {
                        localidad = e.Node.Text;
                        provincia = e.Node.Parent.Text;
                    }
                }

                lblEstado.Text = $"Provincia: {provincia} | Localidad: {localidad}";
            };
        }
    }
}
