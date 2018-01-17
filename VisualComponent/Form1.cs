using ComponentDll;
using FileSystem.FileSystem;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VisualComponent
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            setup();
        }

        private void setup()
        {
            this.Text = "FileSystem";
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            using (Form form = new Form())
            {
                form.Text = "dynamic add filesystem gui";
                form.Size = new Size(505, 350);

                CustomGrid newCustomGrid = new CustomGrid();
                newCustomGrid.Size = form.Size;

                form.Controls.Add(newCustomGrid);

                form.ShowDialog();
            }
        }

        private void addFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.customGrid1.createFolder(textBox1.Text);
            this.customGrid1.setupList(this.customGrid1.CurrentPath);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void customGrid1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
