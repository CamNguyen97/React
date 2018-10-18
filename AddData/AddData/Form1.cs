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

namespace AddData
{
    public partial class Form1 : Form
    {
        private String folderImage = null;
        private String nameImage = null;
        public Form1()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Object objStatus = cmbStatus.SelectedValue;
            //string constr = Properties.Settings.Default.connect;
            string constr = Properties.Settings.Default.connectLocal;
            using (SqlConnection conn = new SqlConnection(constr))
            {
                string sql = "INSERT INTO Items VALUES('"+ nameImage +"', "+ status +")";
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                folderImage = null;
                nameImage = null;
            }
            if (MessageBox.Show("Success", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                pictureBox1.Image = null;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            // image filters  
            open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";
            if (open.ShowDialog() == DialogResult.OK)
            {
                // display image in picture box  
                pictureBox1.Image = new Bitmap(open.FileName);
                // image file path  
                folderImage = open.FileName;
                nameImage = Path.GetFileName(folderImage).Split('\\').LastOrDefault(); ;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cmbStatus.Items.Add(new { Text = "Sale", Value = 1 });
            cmbStatus.Items.Add(new { Text = "Reject", Value = 2 });
            cmbStatus.Items.Add(new { Text = "Waiting", Value = 3 });
            cmbStatus.DisplayMember = "Text";
            cmbStatus.ValueMember = "Value";
        }
    }
}
