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

namespace FileOperationsApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnCreateFolder_Click(object sender, EventArgs e)
        {
            try
            {
                string path = @"D:\DotNet-10AMBatch";
                if (Directory.Exists(path))
                {
                    MessageBox.Show("Folder already exists");
                }
                else
                {
                    Directory.CreateDirectory(path);
                    MessageBox.Show("Folder created successfully");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnCreateFile_Click(object sender, EventArgs e)
        {
            try
            {
                string path = @"D:\DotNet-10AMBatch\TestFile.txt";
                if (File.Exists(path))
                {
                    MessageBox.Show("File already exists");
                }
                else
                {
                    // Create and immediately close the file to release the lock
                    using (FileStream fs = File.Create(path)) { }
                    MessageBox.Show("File created successfully");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnWrite_Click(object sender, EventArgs e)
        {
            try
            {
                string path = @"D:\DotNet-10AMBatch\emp.dat";
                using (FileStream fs = new FileStream(path, FileMode.Create, FileAccess.Write))
                using (BinaryWriter bw = new BinaryWriter(fs))
                {
                    // Write data from TextBoxes to file
                    bw.Write(Convert.ToInt32(txtId.Text));
                    bw.Write(txtName.Text);
                    bw.Write(Convert.ToDouble(txtSalary.Text));
                }
                MessageBox.Show("Data written to file successfully");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnRead_Click(object sender, EventArgs e)
        {
            try
            {
                string path = @"D:\DotNet-10AMBatch\emp.dat";
                using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read))
                using (BinaryReader br = new BinaryReader(fs))
                {
                    // Read data from file and display in TextBoxes
                    txtId.Text = br.ReadInt32().ToString();
                    txtName.Text = br.ReadString();
                    txtSalary.Text = br.ReadDouble().ToString();
                }
                MessageBox.Show("Data read from file successfully");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void txtId_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
