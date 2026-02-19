using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;

namespace Proyecto_Final_GrupoD
{
    public partial class Categories : Form
    {
        string connectionString = @"Server=LAPTOP-RB0EJSQ6\SQLEXPRESS;Database=Northwind;User ID=sa;Password=Muraya**2050;";
        private byte[] currentImageBytes;

        public Categories()
        {
            InitializeComponent();
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

        private void btnLoadImage_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Imágenes|*.bmp;*.jpg;*.jpeg;*.png;*.gif";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    Image img = Image.FromFile(ofd.FileName);
                    pbImage.Image = img;
                    currentImageBytes = ImageToByteArray(img); // Guarda imagen en bytes
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


        private void btnInsert_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Categories (CategoryName, Description, Picture) VALUES (@name, @desc, @pic)";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@name", txtCategoryName.Text);
                cmd.Parameters.AddWithValue("@desc", txtDescription.Text);
                cmd.Parameters.AddWithValue("@pic", ImageToByteArray(pbImage.Image));

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("Categoría insertada correctamente.");
                LoadData();
            }
        }


        private void btnUpdate_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "UPDATE Categories SET CategoryName=@name, Description=@desc, Picture=@pic WHERE CategoryID=@id";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@id", txtCategoryID.Text);
                cmd.Parameters.AddWithValue("@name", txtCategoryName.Text);
                cmd.Parameters.AddWithValue("@desc", txtDescription.Text);
                cmd.Parameters.AddWithValue("@pic", ImageToByteArray(pbImage.Image));

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("Categoría actualizada correctamente.");
                LoadData();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM Categories WHERE CategoryID=@id";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@id", txtCategoryID.Text);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("Categoría eliminada correctamente.");
                LoadData();
            }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Categories";
                SqlDataAdapter da = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvCategories.DataSource = dt;
            }
        }


        private void dgvCategories_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvCategories.Rows[e.RowIndex];
                txtCategoryID.Text = row.Cells["CategoryID"].Value.ToString();
                txtCategoryName.Text = row.Cells["CategoryName"].Value.ToString();
                txtDescription.Text = row.Cells["Description"].Value.ToString();

                // Aquí la llamada es correcta, pues el método ByteArrayToImage
                // ya limpia el encabezado.
                pbImage.Image = ByteArrayToImage(row.Cells["Picture"].Value as byte[]);
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            // Limpia los TextBox
            txtCategoryID.Clear();
            txtCategoryName.Clear();
            txtDescription.Clear();

            // Limpia el PictureBox
            pbImage.Image = null; // o puedes usar pbImage.Image = Properties.Resources.DefaultImage;
        }
    }
}
