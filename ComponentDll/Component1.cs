using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FileSystem.FileSystem;
using System.IO;

namespace ComponentDll
{
    public partial class Component1 : Component
    {
        public readonly int InstanceID;
        private static int NextInstanceID = 0;
        private static long ClassInstanceCount = 0;

        public Component1()
        {
            InitializeComponent();

            Console.WriteLine("Create instance");

            InstanceID = NextInstanceID++;
            ClassInstanceCount++;
        }

        public Component1(IContainer container)
        {
            container.Add(this);

            InitializeComponent();

            Console.WriteLine("Create instance");

            setup();
        }

        ~Component1()
        {
            ClassInstanceCount--;
        }

        public static long InstanceCount
        {
            get
            {
                return ClassInstanceCount;
            }
        }

        private void setup()
        {

        }
       
    }

    public partial class CustomGrid : DataGridView
    {
        private static void log(string info)
        {
            MessageBox.Show(info);
        }
       
        public string CurrentPath { get; set; }

        public CustomGrid()
        {
            InitializeComponent();
            setup();
        }

        private void InitializeComponent()
        {
            this.Height = 27;
            this.Width = 128;
        }

        private void setup()
        {
            this.AllowUserToAddRows = true;
          
            addColumns();

            this.CellClick += CustomGrid_CellClick;

            setupList("D:\\");
        }

        public void setupList(string pathToFolder)
        {
            CurrentPath = pathToFolder;

            this.Rows.Clear();
            this.Refresh();

            MyFileSystem filesystem = new MyFileSystem();
            filesystem.log = log;
            var list = filesystem.getListItems(pathToFolder);

            this.Rows.Add("...", "", "", "");

            for (int i = 0; i < list.Count; ++i)
            {
                if (Directory.Exists(CurrentPath + "\\" + list[i]))
                {
                    this.Rows.Add(list[i], "REMOVE", "INFO", "Open");
                }
                else
                {
                    this.Rows.Add(list[i], "REMOVE", "INFO", "Open");
                }
            }

        }

        public void createFolder(string name)
        {
            Directory.CreateDirectory(CurrentPath + "\\" + name);
        }

        private void CustomGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            MyFileSystem filesystem = new MyFileSystem();

            try
            {

                if (e.RowIndex == 0)
                {
                    if (!String.IsNullOrEmpty(CurrentPath))
                    {
                        try
                        {
                            setupList(filesystem.getParentObject(CurrentPath));
                        }
                        catch
                        {

                        }
                    }
                    return;
                }

                if (Directory.Exists(CurrentPath + "\\" + this.Rows[e.RowIndex].Cells[0].Value) && e.ColumnIndex == 2)
                {
                    MessageBox.Show(filesystem.getInfoObject(CurrentPath + "\\" + this.Rows[e.RowIndex].Cells[0].Value));
                    return;
                }

                if (Directory.Exists(CurrentPath + "\\" + this.Rows[e.RowIndex].Cells[0].Value) && e.ColumnIndex == 1) // remove
                {
                    DialogResult dialogResult = MessageBox.Show("Sure remove this file permanently?", "Remove file", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        Directory.Delete(CurrentPath + "\\" + this.Rows[e.RowIndex].Cells[0].Value);
                       
                            setupList(CurrentPath);

                    }
                    else if (dialogResult == DialogResult.No)
                    {
                    }
                }
                else  if (e.ColumnIndex == 2) // getInfo
                {
                    MessageBox.Show(filesystem.getInfoObject(CurrentPath + "\\" + this.Rows[e.RowIndex].Cells[0].Value));
                }

                if (Directory.Exists(CurrentPath + "\\" + this.Rows[e.RowIndex].Cells[0].Value))
                {
                    setupList(CurrentPath + "\\" + this.Rows[e.RowIndex].Cells[0].Value);
                    return;
                }

                //else if (e.ColumnIndex == 3) // open
                //{

                //}
            }
            catch (Exception ex)
            {
                try
                {
                    setupList(filesystem.getParentObject(CurrentPath));

                }
                catch
                {

                }


                MessageBox.Show(ex.Message);
            }
        }

        private void addColumns()
        {
            var column1 = new DataGridViewColumn();
            column1.HeaderText = "Name";
            column1.Width = 300;
            column1.ReadOnly = true;
            column1.Name = "name";
            column1.CellTemplate = new DataGridViewTextBoxCell();

            var column4 = new DataGridViewColumn();
            column4.CellTemplate = new DataGridViewTextBoxCell();
            column4.Width = 60;

            var column5 = new DataGridViewColumn();
            column5.CellTemplate = new DataGridViewTextBoxCell();
            column5.Width = 40;

            var column6 = new DataGridViewColumn();
            column6.CellTemplate = new DataGridViewTextBoxCell();
            column6.Width = 40;

            this.Columns.Add(column1);
            this.Columns.Add(column4);
            this.Columns.Add(column5);
            this.Columns.Add(column6);

        }
    }
}
