using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NotePad
{
    public partial class Frm_notepad : Form
    {
        string path;
        public Frm_notepad()
        {
            InitializeComponent();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            path = string.Empty;
            richTextBox.Clear();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog() { Filter = "Text Documents |*.txt",ValidateNames = true, Multiselect = false})
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                   try { 
                            using (StreamReader sr =  new StreamReader(ofd.FileName))
                            {
                                path = ofd.FileName;
                                Task<string> text = sr.ReadToEndAsync();
                                richTextBox.Text = text.Result;
                            }
                       }
                       catch (Exception ex)
                       {
                           MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                       }
                }
            }

        }

        private async void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(path))
            {
                using (SaveFileDialog sfd = new SaveFileDialog() {Filter =  "Text Documents |*.txt", ValidateNames = true })
                {
                    if (sfd.ShowDialog()==DialogResult.OK)
                    {
                        try {
                            path = sfd.FileName;
                                using (StreamWriter sw = new StreamWriter(sfd.FileName))
                                {
                                    await sw.WriteLineAsync(richTextBox.Text);
                                }
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                    }
                }
            }
            else
            {
                try { 
                        using (StreamWriter sw=new StreamWriter(path) )
                        {
                            await sw.WriteLineAsync(richTextBox.Text);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
            }
        }

        private async void saveASToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog sfd = new SaveFileDialog() { Filter = "Text Documents |*.txt", ValidateNames = true })
            {
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        using (StreamWriter sw = new StreamWriter(sfd.FileName))
                        {
                            await sw.WriteLineAsync(richTextBox.Text);
                        }
                    }catch(Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (Frm_About frm = new Frm_About())
            {
                frm.ShowDialog();
            }

        }




    }
}
