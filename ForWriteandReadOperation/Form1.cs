using System;
using System.IO;
using System.Windows.Forms;

namespace ForWriteandReadOperation
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            // Attach event handlers to the buttons
            btnSave.Click += btnSave_Click;
            btnRead.Click += btnRead_Click;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                int productId = int.Parse(txtProductId.Text);
                string productName = txtProductName.Text;
                decimal productPrice = decimal.Parse(txtPrice.Text);

                using (BinaryWriter writer = new BinaryWriter(File.Open("ProductData.bin", FileMode.Create)))
                {
                    writer.Write(productId);
                    writer.Write(productName);
                    writer.Write(productPrice);
                }

                MessageBox.Show("Product saved successfully!", "Success");
            }
            catch (FormatException)
            {
                MessageBox.Show("Invalid input. Please enter correct data.", "Input Error");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error");
            }
        }

        private void btnRead_Click(object sender, EventArgs e)
        {
            try
            {
                txtOutput.Clear();

                if (!File.Exists("ProductData.bin"))
                {
                    txtOutput.Text = "No data file found. Please save product details first.";
                    return;
                }

                using (BinaryReader reader = new BinaryReader(File.Open("ProductData.bin", FileMode.Open)))
                {
                    int productId = reader.ReadInt32();
                    string productName = reader.ReadString();
                    decimal productPrice = reader.ReadDecimal();

                    txtOutput.Text = $"Product Details:\nID: {productId}\nName: {productName}\nPrice: {productPrice:C}";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error");
            }
        }
    }
}
