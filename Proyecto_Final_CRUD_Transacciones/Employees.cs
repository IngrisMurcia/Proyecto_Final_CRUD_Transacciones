using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;

namespace Proyecto_Final_GrupoD
{
    public partial class Employees : Form
    {
        string connectionString = @"Server=LAPTOP-RB0EJSQ6\SQLEXPRESS;Database=Northwind;User ID=sa;Password=Muraya**2050;";
        private byte[] currentImageBytes;

        public Employees()
        {
            InitializeComponent();
            CargarCombos();
        }

        private byte[] ImageToByteArray(Image img)
        {
            if (img == null) return null;

            // Crea una nueva imagen a partir de la original para estandarizar el formato de píxel.
            using (Bitmap bmp = new Bitmap(img))
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    // Guarda la nueva imagen en formato Jpeg.
                    bmp.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                    return ms.ToArray();
                }
            }
        }

        private Image ByteArrayToImage(byte[] data)
        {
            if (data == null || data.Length == 0) return null;
            byte[] cleanData = StripOleHeader(data);

            using (MemoryStream ms = new MemoryStream(cleanData))
            {
                try
                {
                    return Image.FromStream(ms);
                }
                catch (ArgumentException)
                {
                    // Si la conversión falla después de StripOleHeader,
                    // intenta de nuevo con los datos originales.
                    using (MemoryStream originalMs = new MemoryStream(data))
                    {
                        return Image.FromStream(originalMs);
                    }
                }
            }
        }

        private byte[] StripOleHeader(byte[] oleBytes)
        {
            for (int i = 0; i < oleBytes.Length - 1; i++)
            {
                if (oleBytes[i] == 0x42 && oleBytes[i + 1] == 0x4D) // 'BM' BMP header
                {
                    byte[] bmp = new byte[oleBytes.Length - i];
                    Array.Copy(oleBytes, i, bmp, 0, bmp.Length);
                    return bmp;
                }
            }
            return oleBytes;
        }

        private void CargarCombos()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                // Titles 
                cmbTitle.Items.AddRange(new string[] {
                    "Sales Representative", "Vice President, Sales", "Sales Manager", "Inside Sales Coordinator"
                });

                // Courtesy Titles 
                cmbTitleOfCourtesy.Items.AddRange(new string[] {
                    "Mr.", "Ms.", "Mrs.", "Dr."
                });

                // ReportsTo (Jefes) 
                SqlDataAdapter da = new SqlDataAdapter("SELECT EmployeeID, FirstName + ' ' + LastName AS FullName FROM Employees", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                cmbReportsTo.DataSource = dt;
                cmbReportsTo.DisplayMember = "FullName";
                cmbReportsTo.ValueMember = "EmployeeID";
            }
        }

        private void CargarEmpleados()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter(
                    "SELECT * FROM Employees", con); // Trae todos los campos 
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvEmployees.DataSource = dt;
            }
        }

        private void btCargar_Click(object sender, EventArgs e)
        {
            CargarEmpleados();
        }

        private void btInsert_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = @"INSERT INTO Employees  
(LastName, FirstName, Title, TitleOfCourtesy, BirthDate, HireDate, Address, City, Region, PostalCode, Country, HomePhone, Extension, Notes, ReportsTo, Photo) 
VALUES (@LastName, @FirstName, @Title, @TitleOfCourtesy, @BirthDate, @HireDate, @Address, @City, @Region, @PostalCode, @Country, @HomePhone, @Extension, @Notes, @ReportsTo, @Photo)";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@LastName", txtLastName.Text);
                cmd.Parameters.AddWithValue("@FirstName", txtFirstName.Text);
                cmd.Parameters.AddWithValue("@Title", cmbTitle.Text);
                cmd.Parameters.AddWithValue("@TitleOfCourtesy", cmbTitleOfCourtesy.Text);
                cmd.Parameters.AddWithValue("@BirthDate", dtpBirthDate.Value);
                cmd.Parameters.AddWithValue("@HireDate", dtpHireDate.Value);
                cmd.Parameters.AddWithValue("@Address", txtAddress.Text);
                cmd.Parameters.AddWithValue("@City", txtCity.Text);
                cmd.Parameters.AddWithValue("@Region", txtRegion.Text);
                cmd.Parameters.AddWithValue("@PostalCode", txtPostalCode.Text);
                cmd.Parameters.AddWithValue("@Country", txtCountry.Text);
                cmd.Parameters.AddWithValue("@HomePhone", txtHomePhone.Text);
                cmd.Parameters.AddWithValue("@Extension", txtExtension.Text);
                cmd.Parameters.AddWithValue("@Notes", txtNotes.Text);
                cmd.Parameters.AddWithValue("@ReportsTo", cmbReportsTo.SelectedValue);
                cmd.Parameters.AddWithValue("@Photo", currentImageBytes ?? (object)DBNull.Value);

                con.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Empleado insertado correctamente.");
            }
            CargarEmpleados();
        }

        private void btActualizar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtEmployeeID.Text))
            {
                MessageBox.Show("Seleccione un empleado para actualizar.");
                return;
            }

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = @"UPDATE Employees SET  
LastName=@LastName, FirstName=@FirstName, Title=@Title, TitleOfCourtesy=@TitleOfCourtesy,  
BirthDate=@BirthDate, HireDate=@HireDate, Address=@Address, City=@City, Region=@Region, PostalCode=@PostalCode,  
Country=@Country, HomePhone=@HomePhone, Extension=@Extension, Notes=@Notes, ReportsTo=@ReportsTo, Photo=@Photo
WHERE EmployeeID=@EmployeeID";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@EmployeeID", txtEmployeeID.Text);
                cmd.Parameters.AddWithValue("@LastName", txtLastName.Text);
                cmd.Parameters.AddWithValue("@FirstName", txtFirstName.Text);
                cmd.Parameters.AddWithValue("@Title", cmbTitle.Text);
                cmd.Parameters.AddWithValue("@TitleOfCourtesy", cmbTitleOfCourtesy.Text);
                cmd.Parameters.AddWithValue("@BirthDate", dtpBirthDate.Value);
                cmd.Parameters.AddWithValue("@HireDate", dtpHireDate.Value);
                cmd.Parameters.AddWithValue("@Address", txtAddress.Text);
                cmd.Parameters.AddWithValue("@City", txtCity.Text);
                cmd.Parameters.AddWithValue("@Region", txtRegion.Text);
                cmd.Parameters.AddWithValue("@PostalCode", txtPostalCode.Text);
                cmd.Parameters.AddWithValue("@Country", txtCountry.Text);
                cmd.Parameters.AddWithValue("@HomePhone", txtHomePhone.Text);
                cmd.Parameters.AddWithValue("@Extension", txtExtension.Text);
                cmd.Parameters.AddWithValue("@Notes", txtNotes.Text);
                cmd.Parameters.AddWithValue("@ReportsTo", cmbReportsTo.SelectedValue);
                cmd.Parameters.AddWithValue("@Photo", currentImageBytes ?? (object)DBNull.Value);

                con.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Empleado actualizado correctamente.");
            }
            CargarEmpleados();
        }

        private void btEliminar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtEmployeeID.Text))
            {
                MessageBox.Show("Seleccione un empleado para eliminar.");
                return;
            }

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("DELETE FROM Employees WHERE EmployeeID=@EmployeeID", con);
                cmd.Parameters.AddWithValue("@EmployeeID", txtEmployeeID.Text);
                con.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Empleado eliminado correctamente.");
            }
            CargarEmpleados();
        }



        private void btLimpiar_Click(object sender, EventArgs e)
        {
            txtEmployeeID.Clear();
            txtLastName.Clear();
            txtFirstName.Clear();
            txtAddress.Clear();
            txtCity.Clear();
            txtRegion.Clear();
            txtPostalCode.Clear();
            txtCountry.Clear();
            txtHomePhone.Clear();
            txtExtension.Clear();
            txtNotes.Clear();

            cmbTitle.SelectedIndex = -1;
            cmbTitleOfCourtesy.SelectedIndex = -1;
            cmbReportsTo.SelectedIndex = -1;

            dtpBirthDate.Value = DateTime.Now;
            dtpHireDate.Value = DateTime.Now;

        }

        private void dgvEmployees_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvEmployees.Rows[e.RowIndex].Cells["EmployeeID"].Value != null)
            {
                DataGridViewRow fila = dgvEmployees.Rows[e.RowIndex];

                txtEmployeeID.Text = fila.Cells["EmployeeID"].Value.ToString();
                txtLastName.Text = fila.Cells["LastName"].Value.ToString();
                txtFirstName.Text = fila.Cells["FirstName"].Value.ToString();
                cmbTitle.Text = fila.Cells["Title"].Value.ToString();
                cmbTitleOfCourtesy.Text = fila.Cells["TitleOfCourtesy"].Value.ToString();

                if (fila.Cells["BirthDate"].Value != DBNull.Value)
                    dtpBirthDate.Value = Convert.ToDateTime(fila.Cells["BirthDate"].Value);

                if (fila.Cells["HireDate"].Value != DBNull.Value)
                    dtpHireDate.Value = Convert.ToDateTime(fila.Cells["HireDate"].Value);

                txtAddress.Text = fila.Cells["Address"].Value.ToString();
                txtCity.Text = fila.Cells["City"].Value.ToString();
                txtRegion.Text = fila.Cells["Region"].Value.ToString();
                txtPostalCode.Text = fila.Cells["PostalCode"].Value.ToString();
                txtCountry.Text = fila.Cells["Country"].Value.ToString();
                txtHomePhone.Text = fila.Cells["HomePhone"].Value.ToString();
                txtExtension.Text = fila.Cells["Extension"].Value.ToString();
                txtNotes.Text = fila.Cells["Notes"].Value.ToString();

                if (fila.Cells["ReportsTo"].Value != DBNull.Value)
                    cmbReportsTo.SelectedValue = Convert.ToInt32(fila.Cells["ReportsTo"].Value);
                else
                    cmbReportsTo.SelectedIndex = -1;
                if (fila.Cells["Photo"].Value != DBNull.Value)
                {
                    pbImage.Image = ByteArrayToImage((byte[])fila.Cells["Photo"].Value);
                    currentImageBytes = (byte[])fila.Cells["Photo"].Value;
                }
                else
                {
                    pbImage.Image = null;
                    currentImageBytes = null;
                }
            }
        }

        private void btSubirFoto_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Imágenes|*.bmp;*.jpg;*.jpeg;*.png;*.gif";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    Image img = Image.FromFile(ofd.FileName);
                    pbImage.Image = img;
                    currentImageBytes = ImageToByteArray(img);
                }
            }
        }
    }
}
