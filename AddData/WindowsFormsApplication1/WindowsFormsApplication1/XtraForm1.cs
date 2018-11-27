using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using WindowsFormsApplication1.model;
using System.IO;

namespace WindowsFormsApplication1
{
	public partial class XtraForm1 : DevExpress.XtraEditors.XtraForm
	{
		private static string Name;
		public XtraForm1()
		{
			InitializeComponent();
		}

		private void simpleButton1_Click(object sender, EventArgs e)
		{
			try
			{
				OpenFileDialog open = new OpenFileDialog();
				open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";
				if (open.ShowDialog() == DialogResult.OK)
				{
					string result;
					Bitmap bit = new Bitmap(open.FileName);
					result = Path.GetFileName(open.FileName);
					Name = result;
					pictureBox1.Image = bit;
				}
			}
			catch (Exception)
			{
				throw new ApplicationException("Failed loading image");
			}
		}

		private void simpleButton2_Click(object sender, EventArgs e)
		{
			ReactAPIEntities db = new ReactAPIEntities();
			Item item = new Item();
			item.name = Name;
			item.status = 1;
			db.Items.Add(item);
			db.SaveChanges();
			pictureBox1.Image = null;
		}
	}
}