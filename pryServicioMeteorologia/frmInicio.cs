using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pryServicioMeteorologia
{
    public partial class frmInicio : Form
    {
        private clsConexionBD conexion;
        public frmInicio()
        {
            InitializeComponent();
        }

        private void frmInicio_Load(object sender, EventArgs e)
        {
            conexion = new clsConexionBD();
            conexion.ConectarBD();
            conexion.CargarTreeView(tvwUbicaciones);
            conexion.CargarTemperaturas(tvwUbicaciones, lvwTemperaturas, dtpFecha);
            conexion.ActualizarStatusStrip(tvwUbicaciones, lblEstado);
        }
    }
}
