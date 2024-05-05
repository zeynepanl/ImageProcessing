﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageProcessingForm
{
    public partial class Parlaklik : Form
    {
        private Bitmap defaultImage;
        private int currentBrightness = 0; // Güncel parlaklık değeri
        private int previousBrightness = 0; // Önceki parlaklık değeri

        public Parlaklik()
        {
            InitializeComponent();

            this.StartPosition = FormStartPosition.CenterScreen;

            string parentDirectory = Directory.GetParent(Directory.GetCurrentDirectory()).FullName;

            string imagePath = Path.Combine(parentDirectory, "Images", "girl.jpg");

            defaultImage = new Bitmap(imagePath);
            beforePic.Image = defaultImage;
            afterPic.Image = defaultImage;
            afterPic.SizeMode = PictureBoxSizeMode.StretchImage;
            beforePic.SizeMode = PictureBoxSizeMode.StretchImage;

            beforePic.MouseUp += beforePic_MouseUp;
        }



        private void beforePic_MouseUp(object sender, MouseEventArgs e)
        {

            if (e.Button == MouseButtons.Left)
            {
                ResimYukle();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            ResimYukle();
            afterPic.Image = null;
        }

        private void btnSave_Click_1(object sender, EventArgs e)
        {
            SaveImage();
        }

        private void btnDel_Click_1(object sender, EventArgs e)
        {
            beforePic.Image = null;
            afterPic.Image = null;
        }

        private void SaveImage()
        {
            if (afterPic.Image != null)
            {
                using (SaveFileDialog saveDialog = new SaveFileDialog())
                {
                    saveDialog.Filter = "JPEG Image|*.jpg";
                    saveDialog.Title = "Save Image";
                    saveDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
                    saveDialog.RestoreDirectory = true;

                    if (saveDialog.ShowDialog() == DialogResult.OK)
                    {
                        string savePath = saveDialog.FileName;
                        afterPic.Image.Save(savePath, ImageFormat.Jpeg);
                        MessageBox.Show("Image saved successfully to: " + savePath);
                    }
                }
            }
            else
            {
                MessageBox.Show("There is no image to save.");
            }
        }

        private void ResimYukle()
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            // Sadece resim dosyalarını filtrele
            openFileDialog1.Filter = "Resim Dosyaları|*.jpg;*.jpeg;*.png;*.gif;*.bmp|Tüm Dosyalar|*.*";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                beforePic.Image = null;
                afterPic.Image = null;
                // Seçilen resmi PictureBox kontrolüne yükle
                beforePic.Image = new Bitmap(openFileDialog1.FileName);
            }
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            previousBrightness = currentBrightness; // Önceki parlaklık değerini güncelle
            currentBrightness = (int)numericUpDown1.Value; // Yeni parlaklık değerini al

            ApplyBrightness(currentBrightness);
        }

        private void btnUndo_Click(object sender, EventArgs e)
        {
            numericUpDown1.Value = previousBrightness;

            // Geri alınan parlaklık değerini uygula
            ApplyBrightness(previousBrightness);


        }

        private void ApplyBrightness(int changeAmount)
        {
            if (beforePic.Image != null)
            {
                // Yeni bir bitmap oluştur
                Bitmap brightenedImage = new Bitmap(beforePic.Image.Width, beforePic.Image.Height);

                // Her pikseli dolaşarak parlaklığı değiştir
                for (int y = 0; y < beforePic.Image.Height; y++)
                {
                    for (int x = 0; x < beforePic.Image.Width; x++)
                    {
                        Color originalColor = ((Bitmap)beforePic.Image).GetPixel(x, y);

                        // Her renk bileşenine parlaklık artışını ekle
                        int newRed = Math.Min(originalColor.R + changeAmount, 255);
                        int newGreen = Math.Min(originalColor.G + changeAmount, 255);
                        int newBlue = Math.Min(originalColor.B + changeAmount, 255);

                        // Yeni renk bileşenleriyle bir renk oluştur
                        Color newColor = Color.FromArgb(newRed, newGreen, newBlue);

                        // Yeni pikseli ayarla
                        brightenedImage.SetPixel(x, y, newColor);
                    }
                }

                // Parlaklaştırılmış resmi göster
                afterPic.Image = brightenedImage;
            }
        }

        
    }
}
