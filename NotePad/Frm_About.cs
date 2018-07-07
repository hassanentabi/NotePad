using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NotePad
{
    public partial class Frm_About : Form
    {
        public Frm_About()
        {
            InitializeComponent();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Frm_About_Load(object sender, EventArgs e)
        {
            lblProductName.Text = string.Format("Product name : {0}", Application.ProductName);
            lblProducVersion.Text = string.Format("Version: {0}", Application.ProductVersion);
            lblCopyright.Text = "Copyright ©  2017 by ";
        }


    }
}
