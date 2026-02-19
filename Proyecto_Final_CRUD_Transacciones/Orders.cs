using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_Final_GrupoD
{
    public partial class Orders : Form
    {
        string connectionString = @"Server=LAPTOP-RB0EJSQ6\SQLEXPRESS;Database=Northwind;User ID=sa;Password=Muraya**2050;";
        DataTable dtDetalles = new DataTable();

        public Orders()
        {
            InitializeComponent();
            CargarCombos();
            ConfigurarTablaDetalles();
        }

        private void CargarCombos()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                // Customers
                SqlDataAdapter daCust = new SqlDataAdapter("SELECT CustomerID, CompanyName FROM Customers", con);
                DataTable dtCust = new DataTable();
                daCust.Fill(dtCust);
                cmbCustomerID.DataSource = dtCust;
                cmbCustomerID.DisplayMember = "CompanyName";
                cmbCustomerID.ValueMember = "CustomerID";

                // Employees
                SqlDataAdapter daEmp = new SqlDataAdapter("SELECT EmployeeID, (FirstName + ' ' + LastName) AS Nombre FROM Employees", con);
                DataTable dtEmp = new DataTable();
                daEmp.Fill(dtEmp);
                cmbEmployeeID.DataSource = dtEmp;
                cmbEmployeeID.DisplayMember = "Nombre";
                cmbEmployeeID.ValueMember = "EmployeeID";

                // Shippers
                SqlDataAdapter daShip = new SqlDataAdapter("SELECT ShipperID, CompanyName FROM Shippers", con);
                DataTable dtShip = new DataTable();
                daShip.Fill(dtShip);
                cmbShipVia.DataSource = dtShip;
                cmbShipVia.DisplayMember = "CompanyName";
                cmbShipVia.ValueMember = "ShipperID";

                // Products
                SqlDataAdapter daProd = new SqlDataAdapter("SELECT ProductID, ProductName, UnitPrice FROM Products", con);
                DataTable dtProd = new DataTable();
                daProd.Fill(dtProd);
                cmbProductName.DataSource = dtProd;
                cmbProductName.DisplayMember = "ProductName";
                cmbProductName.ValueMember = "ProductID";

                // Evento para poner precio
                cmbProductName.SelectedIndexChanged += (s, e) =>
                {
                    if (cmbProductName.SelectedValue is int)
                    {
                        DataRowView drv = (DataRowView)cmbProductName.SelectedItem;
                        txtProductID.Text = drv["ProductID"].ToString();
                        txtUnitPrice.Text = drv["UnitPrice"].ToString();
                    }
                };
            }
        }

        private void ConfigurarTablaDetalles()
        {
            dtDetalles.Columns.Add("ProductID", typeof(int));
            dtDetalles.Columns.Add("ProductName", typeof(string));
            dtDetalles.Columns.Add("UnitPrice", typeof(decimal));
            dtDetalles.Columns.Add("Quantity", typeof(int));
            dtDetalles.Columns.Add("Discount", typeof(decimal));
            dtDetalles.Columns.Add("Subtotal", typeof(decimal));

            dgvOrders.DataSource = dtDetalles;
        }

        private void btInsert_Click(object sender, EventArgs e)
        {
            decimal unitPrice = decimal.Parse(txtUnitPrice.Text);
            int quantity = int.Parse(txtQuantity.Text);
            decimal discount = string.IsNullOrEmpty(txtDiscount.Text) ? 0 : decimal.Parse(txtDiscount.Text);

            decimal subtotal = unitPrice * quantity * (1 - discount);
            txtSubtotal.Text = subtotal.ToString("F2");

            dtDetalles.Rows.Add(
                int.Parse(txtProductID.Text),
                cmbProductName.Text,
                unitPrice,
                quantity,
                discount,
                subtotal
            );
        }

        private void btDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtOrderID.Text)) return;

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlTransaction trans = con.BeginTransaction();

                try
                {
                    SqlCommand cmdDelDetails = new SqlCommand("DELETE FROM [Order Details] WHERE OrderID = @OrderID", con, trans);
                    cmdDelDetails.Parameters.AddWithValue("@OrderID", txtOrderID.Text);
                    cmdDelDetails.ExecuteNonQuery();

                    SqlCommand cmdDelOrder = new SqlCommand("DELETE FROM Orders WHERE OrderID = @OrderID", con, trans);
                    cmdDelOrder.Parameters.AddWithValue("@OrderID", txtOrderID.Text);
                    cmdDelOrder.ExecuteNonQuery();

                    trans.Commit();
                    MessageBox.Show("Orden eliminada.");
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void btActualizar_Click(object sender, EventArgs e)
        {
            //if (dgvOrders.SelectedRows.Count > 0)
            if (dgvOrders.CurrentRow != null)
            {
                //int index = dgvOrders.SelectedRows[0].Index;
                int index = dgvOrders.CurrentRow.Index;

                decimal unitPrice = decimal.Parse(txtUnitPrice.Text);
                int quantity = int.Parse(txtQuantity.Text);
                decimal discount = string.IsNullOrEmpty(txtDiscount.Text) ? 0 : decimal.Parse(txtDiscount.Text);
                decimal subtotal = unitPrice * quantity * (1 - discount);

                dtDetalles.Rows[index]["ProductID"] = int.Parse(txtProductID.Text);
                dtDetalles.Rows[index]["ProductName"] = cmbProductName.Text;
                dtDetalles.Rows[index]["UnitPrice"] = unitPrice;
                dtDetalles.Rows[index]["Quantity"] = quantity;
                dtDetalles.Rows[index]["Discount"] = discount;
                dtDetalles.Rows[index]["Subtotal"] = subtotal;

                txtSubtotal.Text = subtotal.ToString("F2");

                MessageBox.Show("Producto actualizado en la orden.");
            }
            else
            {
                MessageBox.Show("Seleccione un producto para actualizar.");
            }
        }

        private void btEliminar_Click(object sender, EventArgs e)
        {
            if (dgvOrders.SelectedRows.Count > 0)
            {
                int index = dgvOrders.SelectedRows[0].Index;
                dtDetalles.Rows.RemoveAt(index);
                MessageBox.Show("Producto eliminado de la orden.");
            }
            else
            {
                MessageBox.Show("Seleccione un producto para eliminar.");
            }
        }

        private void dgvOrders_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvOrders.Rows[e.RowIndex].Cells["ProductID"].Value != null)
            {
                txtProductID.Text = dgvOrders.Rows[e.RowIndex].Cells["ProductID"].Value.ToString();
                cmbProductName.Text = dgvOrders.Rows[e.RowIndex].Cells["ProductName"].Value.ToString();
                txtUnitPrice.Text = dgvOrders.Rows[e.RowIndex].Cells["UnitPrice"].Value.ToString();
                txtQuantity.Text = dgvOrders.Rows[e.RowIndex].Cells["Quantity"].Value.ToString();
                txtDiscount.Text = dgvOrders.Rows[e.RowIndex].Cells["Discount"].Value.ToString();
                txtSubtotal.Text = dgvOrders.Rows[e.RowIndex].Cells["Subtotal"].Value.ToString();
            }
        }

        private void btLimpiar_Click_1(object sender, EventArgs e)
        {
            dtDetalles.Clear();
            txtProductID.Clear();
            cmbProductName.SelectedIndex = -1;
            txtUnitPrice.Clear();
            txtQuantity.Clear();
            txtDiscount.Clear();
            txtSubtotal.Clear();
        }

    }
}
