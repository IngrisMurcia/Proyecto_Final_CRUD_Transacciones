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
    public partial class Customers : Form
    {
        string connectionString = @"Server=LAPTOP-RB0EJSQ6\SQLEXPRESS;Database=Northwind;User ID=sa;Password=Muraya**2050;";

        public Customers()
        {
            InitializeComponent();
            CargarCombos();
        }

        private void CargarCombos()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                // Llenar cmbContactTitle
                SqlDataAdapter daTitles = new SqlDataAdapter("SELECT DISTINCT ContactTitle FROM Customers", con);
                DataTable dtTitles = new DataTable();
                daTitles.Fill(dtTitles);
                foreach (DataRow row in dtTitles.Rows)
                {
                    if (row["ContactTitle"] != DBNull.Value)
                    {
                        cmbContactTitle.Items.Add(row["ContactTitle"].ToString());
                    }
                }

                // Llenar cmbCountry
                SqlDataAdapter daCountries = new SqlDataAdapter("SELECT DISTINCT Country FROM Customers", con);
                DataTable dtCountries = new DataTable();
                daCountries.Fill(dtCountries);
                foreach (DataRow row in dtCountries.Rows)
                {
                    if (row["Country"] != DBNull.Value)
                    {
                        cmbCountry.Items.Add(row["Country"].ToString());
                    }
                }
            }
        }

        private void CargarClientes()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT CustomerID, CompanyName, ContactName, ContactTitle, Address, City, Region, PostalCode, Country, Phone, Fax FROM Customers", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvCustomers.DataSource = dt;
            }
        }

        private void Customers_Load(object sender, EventArgs e)
        {
            CargarClientes();
        }

        private void btInsert_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = @"INSERT INTO Customers (CustomerID, CompanyName, ContactName, ContactTitle, Address, City, Region, PostalCode, Country, Phone, Fax)
                                 VALUES (@CustomerID, @CompanyName, @ContactName, @ContactTitle, @Address, @City, @Region, @PostalCode, @Country, @Phone, @Fax)";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@CustomerID", txtCustomerID.Text);
                cmd.Parameters.AddWithValue("@CompanyName", txtCompanyName.Text);
                cmd.Parameters.AddWithValue("@ContactName", txtContactName.Text);
                cmd.Parameters.AddWithValue("@ContactTitle", cmbContactTitle.Text);
                cmd.Parameters.AddWithValue("@Address", txtAddress.Text);
                cmd.Parameters.AddWithValue("@City", txtCity.Text);
                cmd.Parameters.AddWithValue("@Region", (object)txtRegion.Text ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@PostalCode", (object)txtPostalCode.Text ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Country", cmbCountry.Text);
                cmd.Parameters.AddWithValue("@Phone", txtPhone.Text);
                cmd.Parameters.AddWithValue("@Fax", (object)txtFax.Text ?? DBNull.Value);

                try
                {
                    con.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Cliente insertado correctamente.");
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Error al insertar el cliente: " + ex.Message);
                }
            }
            CargarClientes();
            btLimpiar_Click(sender, e);
        }

        private void btActualizar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCustomerID.Text))
            {
                MessageBox.Show("Seleccione un cliente para actualizar.");
                return;
            }

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = @"UPDATE Customers SET   
                                 CompanyName=@CompanyName, ContactName=@ContactName, ContactTitle=@ContactTitle, 
                                 Address=@Address, City=@City, Region=@Region, PostalCode=@PostalCode, 
                                 Country=@Country, Phone=@Phone, Fax=@Fax
                                 WHERE CustomerID=@CustomerID";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@CustomerID", txtCustomerID.Text);
                cmd.Parameters.AddWithValue("@CompanyName", txtCompanyName.Text);
                cmd.Parameters.AddWithValue("@ContactName", txtContactName.Text);
                cmd.Parameters.AddWithValue("@ContactTitle", cmbContactTitle.Text);
                cmd.Parameters.AddWithValue("@Address", txtAddress.Text);
                cmd.Parameters.AddWithValue("@City", txtCity.Text);
                cmd.Parameters.AddWithValue("@Region", (object)txtRegion.Text ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@PostalCode", (object)txtPostalCode.Text ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Country", cmbCountry.Text);
                cmd.Parameters.AddWithValue("@Phone", txtPhone.Text);
                cmd.Parameters.AddWithValue("@Fax", (object)txtFax.Text ?? DBNull.Value);

                try
                {
                    con.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Cliente actualizado correctamente.");
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Error al actualizar el cliente: " + ex.Message);
                }
            }
            CargarClientes();
            btLimpiar_Click(sender, e);
        }

        private void btEliminar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCustomerID.Text))
            {
                MessageBox.Show("Seleccione un cliente para eliminar.");
                return;
            }

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("DELETE FROM Customers WHERE CustomerID=@CustomerID", con);
                cmd.Parameters.AddWithValue("@CustomerID", txtCustomerID.Text);

                try
                {
                    con.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Cliente eliminado correctamente.");
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Error al eliminar el cliente: " + ex.Message);
                }
            }
            CargarClientes();
            btLimpiar_Click(sender, e);
        }

        private void btLimpiar_Click(object sender, EventArgs e)
        {
            txtCustomerID.Clear();
            txtCompanyName.Clear();
            txtContactName.Clear();
            cmbContactTitle.SelectedIndex = -1;
            txtAddress.Clear();
            txtCity.Clear();
            txtRegion.Clear();
            txtPostalCode.Clear();
            cmbCountry.SelectedIndex = -1;
            txtPhone.Clear();
            txtFax.Clear();
        }

        private void dgvCustomers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow fila = dgvCustomers.Rows[e.RowIndex];

                txtCustomerID.Text = fila.Cells["CustomerID"].Value.ToString();
                txtCompanyName.Text = fila.Cells["CompanyName"].Value.ToString();
                txtContactName.Text = fila.Cells["ContactName"].Value.ToString();
                cmbContactTitle.Text = fila.Cells["ContactTitle"].Value.ToString();
                txtAddress.Text = fila.Cells["Address"].Value.ToString();
                txtCity.Text = fila.Cells["City"].Value.ToString();

                // Manejar valores DBNull para los campos opcionales
                txtRegion.Text = fila.Cells["Region"].Value?.ToString() ?? string.Empty;
                txtPostalCode.Text = fila.Cells["PostalCode"].Value?.ToString() ?? string.Empty;
                txtPhone.Text = fila.Cells["Phone"].Value?.ToString() ?? string.Empty;
                txtFax.Text = fila.Cells["Fax"].Value?.ToString() ?? string.Empty;

                cmbCountry.Text = fila.Cells["Country"].Value.ToString();
            }
        }
    }
}
