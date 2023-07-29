using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Convert_To_Binary_Form
{
    public partial class Form1 : Form
    {
        private string connectionString = "Your_Database_Connection_String";
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            if(dlg.ShowDialog()==DialogResult.OK)
            {
                txtFileName.Text = Path.GetFileName(dlg.FileName);
                txtFilePath.Text = dlg.FileName;
                txtExtension.Text = Path.GetExtension(dlg.FileName);
                txtFileSize.Text = new FileInfo(dlg.FileName).Length.ToString();
            }
            
        }

        private void dgvDocuments_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            var selectedRow = dgvDocuments.SelectedRows;
            foreach (var row  in selectedRow)
            {
                int id = (int) ((DataGridViewRow)row).Cells[0].Value;
                OpenFile(id);
            }
        }

        private void OpenFile(int id)
        {
            using (SqlConnection connection = GetConnection())
            {
                
                string query =
                    "SELECT FileName,DataFile,Extension FROM ContentData WHERE DataID=@id";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.Add("@id", SqlDbType.Int).Value=id;
                 
                connection.Open();
                var reader = command.ExecuteReader();
                if (reader.Read())
                {
                    var name = reader["FileName"].ToString();
                    var data = (byte[])reader["DataFile"];
                    var extn = reader["Extension"].ToString();
                    var newFileName = name.Replace(extn, DateTime.Now.ToString("ddMMyyyyhhmmss")) + extn;
                    File.WriteAllBytes(newFileName,data);
                    System.Diagnostics.Process.Start(newFileName);
                }

            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(txtFileName.Text)&& !string.IsNullOrEmpty(txtFilePath.Text)
                &&!string.IsNullOrEmpty(txtExtension.Text)&& !string.IsNullOrEmpty(txtFileSize.Text)&&
                !string.IsNullOrEmpty(txtContentType.Text)&& !string.IsNullOrEmpty(txtContentID.Text)&&
                !string.IsNullOrEmpty(txtCategoryID.Text))
            {
                using (Stream stream = File.OpenRead(txtFilePath.Text))
                {
                    byte[] fileData = new byte[stream.Length];
                    stream.Read(fileData, 0, fileData.Length);
                    using (SqlConnection connection = GetConnection())
                    {
                        SqlCommand command = new SqlCommand("INSERT INTO ContentData (FileName,DataFile,FilePath,Extension,FileSize,ContentType,ContentID,CategoryID)" +
                                                            "VALUES(@FileName,@DataFile,@FilePath,@Extension,@FileSize,@ContentType,@ContentID,@CategoryID)", connection);
                        command.Parameters.Add("@FileName", SqlDbType.VarChar, 100).Value = txtFileName.Text;
                        command.Parameters.Add("Datafile", SqlDbType.VarBinary, -1).Value = fileData;
                        command.Parameters.Add("@FilePath", SqlDbType.VarChar, 255).Value = txtFilePath.Text;
                        command.Parameters.Add("@Extension", SqlDbType.VarChar, 20).Value = txtExtension.Text;
                        command.Parameters.Add("@FileSize", SqlDbType.VarChar, 50).Value = txtFileSize.Text;
                        command.Parameters.Add("@ContentType", SqlDbType.VarChar, 50).Value = txtContentType.Text;
                        command.Parameters.Add("@ContentID", SqlDbType.Int).Value = int.Parse(txtContentID.Text);
                        command.Parameters.Add("@CategoryID", SqlDbType.Int).Value = int.Parse(txtCategoryID.Text);

                        connection.Open();
                        command.ExecuteNonQuery();
                        connection.Close();

                        MessageBox.Show("Data saved successfully!");
                    }
                }
            }
            else
            {
                MessageBox.Show("Please fill in all the fields.");
            }
            

        }
     

        private SqlConnection GetConnection()
        {
            return new SqlConnection(@"Data Source=MADDY;Database=Content_Management_System;Integrated Security=true;");
        }

        private void txtFilePath_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtContentType_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtCategoryID_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
            throw new System.NotImplementedException();
        }


        private void label6_Click(object sender, EventArgs e)
        {
            throw new System.NotImplementedException();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            using (SqlConnection connection=GetConnection())
            {
                string query = "SELECT DataID,FileName,FilePath,Extension,FileSize,ContentType,ContentID,CategoryID FROM ContentData";
                SqlDataAdapter adapter = new SqlDataAdapter(query,connection);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    dgvDocuments.DataSource = dt;
                }

            }
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
