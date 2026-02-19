using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Proyecto_Final_GrupoD
{
    public partial class Productos : Form
    {
        string connectionString = @"Server=LAPTOP-RB0EJSQ6\SQLEXPRESS;Database=Northwind;User ID=sa;Password=Muraya**2050;";

        public Productos()
        {
            InitializeComponent();
            CargarCombos();
        }

        private void CargarCombos()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                // Suppliers
                SqlDataAdapter daSup = new SqlDataAdapter("SELECT SupplierID, CompanyName FROM Suppliers", con);
                DataTable dtSup = new DataTable();
                daSup.Fill(dtSup);
                cmbSupplierID.DataSource = dtSup;
                cmbSupplierID.DisplayMember = "CompanyName";
                cmbSupplierID.ValueMember = "SupplierID";

                // Categories
                SqlDataAdapter daCat = new SqlDataAdapter("SELECT CategoryID, CategoryName FROM Categories", con);
                DataTable dtCat = new DataTable();
                daCat.Fill(dtCat);
                cmbCategoryID.DataSource = dtCat;
                cmbCategoryID.DisplayMember = "CategoryName";
                cmbCategoryID.ValueMember = "CategoryID";
            }
        }

        private void btLoad_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                string query = @"
                    SELECT p.ProductID, p.ProductName, c.CategoryName, p.UnitsInStock
                    FROM Products p
                    INNER JOIN Categories c ON p.CategoryID = c.CategoryID";

                SqlDataAdapter da = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dgvProductos.DataSource = dt;
            }
        }
        private void btInsert_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(@"
                    INSERT INTO Products (ProductName, SupplierID, CategoryID, QuantityPerUnit, UnitPrice, UnitsInStock, UnitsOnOrder, ReorderLevel)
                    VALUES (@ProductName, @SupplierID, @CategoryID, @QuantityPerUnit, @UnitPrice, @UnitsInStock, @UnitsOnOrder, @ReorderLevel)", con);

                cmd.Parameters.AddWithValue("@ProductName", txtProductName.Text);
                cmd.Parameters.AddWithValue("@SupplierID", cmbSupplierID.SelectedValue);
                cmd.Parameters.AddWithValue("@CategoryID", cmbCategoryID.SelectedValue);
                cmd.Parameters.AddWithValue("@QuantityPerUnit", txtQuantityPerUnit.Text);
                cmd.Parameters.AddWithValue("@UnitPrice", decimal.Parse(txtUnitPrice.Text));
                cmd.Parameters.AddWithValue("@UnitsInStock", short.Parse(txtUnitsInStock.Text));
                cmd.Parameters.AddWithValue("@UnitsOnOrder", short.Parse(txtUnitsOnOrder.Text));
                cmd.Parameters.AddWithValue("@ReorderLevel", short.Parse(txtReorderLevel.Text));

                cmd.ExecuteNonQuery();
                MessageBox.Show("Producto insertado correctamente.");
            }
            btLoad_Click(sender, e);
        }

        private void btUpdate_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(@"
                    UPDATE Products
                    SET ProductName=@ProductName, SupplierID=@SupplierID, CategoryID=@CategoryID, 
                        QuantityPerUnit=@QuantityPerUnit, UnitPrice=@UnitPrice, UnitsInStock=@UnitsInStock,
                        UnitsOnOrder=@UnitsOnOrder, ReorderLevel=@ReorderLevel
                    WHERE ProductID=@ProductID", con);

                cmd.Parameters.AddWithValue("@ProductID", txtProductID.Text);
                cmd.Parameters.AddWithValue("@ProductName", txtProductName.Text);
                cmd.Parameters.AddWithValue("@SupplierID", cmbSupplierID.SelectedValue);
                cmd.Parameters.AddWithValue("@CategoryID", cmbCategoryID.SelectedValue);
                cmd.Parameters.AddWithValue("@QuantityPerUnit", txtQuantityPerUnit.Text);
                cmd.Parameters.AddWithValue("@UnitPrice", decimal.Parse(txtUnitPrice.Text));
                cmd.Parameters.AddWithValue("@UnitsInStock", short.Parse(txtUnitsInStock.Text));
                cmd.Parameters.AddWithValue("@UnitsOnOrder", short.Parse(txtUnitsOnOrder.Text));
                cmd.Parameters.AddWithValue("@ReorderLevel", short.Parse(txtReorderLevel.Text));

                cmd.ExecuteNonQuery();
                MessageBox.Show("Producto actualizado correctamente.");
            }
            btLoad_Click(sender, e);
        }

        private void btDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtProductID.Text))
            {
                MessageBox.Show("Seleccione un producto primero.");
                return;
            }

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("DELETE FROM Products WHERE ProductID = @ProductID", con);
                cmd.Parameters.AddWithValue("@ProductID", txtProductID.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Producto eliminado correctamente.");
            }
            btLoad_Click(sender, e);
        }

        private void dgvProductos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                txtProductID.Text = dgvProductos.Rows[e.RowIndex].Cells["ProductID"].Value.ToString();
                txtProductName.Text = dgvProductos.Rows[e.RowIndex].Cells["ProductName"].Value.ToString();
                txtUnitsInStock.Text = dgvProductos.Rows[e.RowIndex].Cells["UnitsInStock"].Value.ToString();
                cmbCategoryID.Text = dgvProductos.Rows[e.RowIndex].Cells["CategoryName"].Value.ToString();
            }
        }
    }
}
