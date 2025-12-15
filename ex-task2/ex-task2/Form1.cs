using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;


namespace ex_task2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent(); 
            button1.Text = "Обробити папку photo";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string targetDir = @"C:\Users\Asus\Desktop\exceptions-task2\ex_task2\ex_task2\bin\Debug\net9.0\photo";

            if (!Directory.Exists(targetDir))
            {
                MessageBox.Show($"Папку не знайдено за шляхом:\n{targetDir}", "Помилка шляху", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string[] files = Directory.GetFiles(targetDir);
            Regex regexExtForImage = new Regex(@"^((bmp)|(gif)|(tiff?)|(jpe?g)|(png))$", RegexOptions.IgnoreCase);

            

        }
    }
}

