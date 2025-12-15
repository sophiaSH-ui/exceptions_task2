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

        private void button1_Click_1(object sender, EventArgs e)
        {
            string targetDir = @"C:\Users\Asus\Desktop\exceptions_task2\ex-task2\ex-task2\bin\Debug\net9.0-windows\photo";

            if (!Directory.Exists(targetDir))
            {
                MessageBox.Show($"Папку не знайдено за шляхом:\n{targetDir}", "Помилка шляху", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string[] files = Directory.GetFiles(targetDir);
            Regex regexExtForImage = new Regex(@"^((bmp)|(gif)|(tiff?)|(jpe?g)|(png))$", RegexOptions.IgnoreCase);

            int processedCount = 0;

            foreach (string filePath in files)
            {
                if (filePath.Contains("-mirrored.gif")) continue;

                try
                {
                    using (Bitmap bmp = new Bitmap(filePath))
                    {
                        bmp.RotateFlip(RotateFlipType.RotateNoneFlipX);
                        string fileNameNoExt = Path.GetFileNameWithoutExtension(filePath);
                        string newFileName = fileNameNoExt + "-mirrored.gif";
                        string savePath = Path.Combine(targetDir, newFileName);
                        bmp.Save(savePath, ImageFormat.Gif);

                        processedCount++;
                    }
                }
                catch
                {
                    string ext = Path.GetExtension(filePath).TrimStart('.');
                    if (regexExtForImage.IsMatch(ext))
                    {
                        MessageBox.Show(
                            $"Знайдено битий файл: '{Path.GetFileName(filePath)}'\nРозширення правильне, але це не картинка.",
                            "Увага, помилка файлу!",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);
                    }
                }
            }

            if (processedCount == 0)
            {
                MessageBox.Show("У папці не знайдено жодної нормальної картинки для обробки, або шлях досі неправильний.", "Пусто", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show($"Готово! Оброблено файлів: {processedCount}", "Успіх");
            }
        }
    }
}