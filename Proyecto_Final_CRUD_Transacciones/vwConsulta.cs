using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_Final_GrupoD
{
    public partial class vwConsulta : Form
    {
        public vwConsulta()
        {
            InitializeComponent();
        }

        private void vwConsulta_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'northwindDataSet1.AñosCompras' Puede moverla o quitarla según sea necesario.
            this.añosComprasTableAdapter.Fill(this.northwindDataSet1.AñosCompras);
            // TODO: esta línea de código carga datos en la tabla 'northwindDataSet.vwComprasAñoCliente' Puede moverla o quitarla según sea necesario.
            this.vwComprasAñoClienteTableAdapter.Fill(this.northwindDataSet.vwComprasAñoCliente);

        }

        private void btAño_Click(object sender, EventArgs e)
        {
            this.vwComprasAñoClienteTableAdapter.FillByYear(this.northwindDataSet.vwComprasAñoCliente, Convert.ToInt16(cmbAños.SelectedValue));
            cmbAños.SelectedIndex = -1;
        }

        private void btTodos_Click(object sender, EventArgs e)
        {
            this.vwComprasAñoClienteTableAdapter.Fill(this.northwindDataSet.vwComprasAñoCliente);
        }

        private void btLimpiar_Click(object sender, EventArgs e)
        {
            this.northwindDataSet.vwComprasAñoCliente.Rows.Clear();
        }
    }
}
