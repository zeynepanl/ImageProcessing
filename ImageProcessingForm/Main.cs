﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;

namespace ImageProcessingForm
{
    public partial class Main : Form
    {
        private Bitmap defaultImage;
        public Main()
        {
            InitializeComponent();

            string parentDirectory = Directory.GetParent(Directory.GetCurrentDirectory()).FullName;

            string imagePath = Path.Combine(parentDirectory, "Images", "girl.png");

            defaultImage = new Bitmap(imagePath); 
            beforePic.Image = defaultImage;
            afterPic.Image = defaultImage;
            afterPic.SizeMode = PictureBoxSizeMode.StretchImage;
            beforePic.SizeMode = PictureBoxSizeMode.StretchImage;

            beforePic.MouseUp += beforePic_MouseUp;

            comboBox1.Items.Add("Gri Dönüşüm");
            comboBox1.Items.Add("Binary Dönüşüm");
            comboBox1.Items.Add("Görüntü Döndürme");
            comboBox1.Items.Add("Görüntü Kırpma");
            comboBox1.Items.Add("Görüntü Yaklaştırma/Uzaklaştırma");
            comboBox1.Items.Add("Renk Uzayı Dönüşümleri");
            comboBox1.Items.Add("Giriş görüntüsüne ait histogram ve orjinal görüntü histogramını germe/genişletme");
            comboBox1.Items.Add("İki resim arasında aritmetik işlemler (ekleme, çarpma)");
            comboBox1.Items.Add("Parlaklık artırma");
            comboBox1.Items.Add("Konvolüsyon İşlemi (gauss)");
            comboBox1.Items.Add("Eşikleme işlemleri (Adaptif Eşikleme)");
            comboBox1.Items.Add("Kenar Bulma Algoritmalarının Kullanımı (sobel)");
            comboBox1.Items.Add("Görüntüye Gürültü Ekleme (Salt&Pepper) ve filtrelerin kullanımı (mean, median) ile gürültü temizleme");
            comboBox1.Items.Add("Görüntüye Filtre Uygulanması (Blurring)");
            comboBox1.Items.Add("Morfolojik İşlemler (Genişleme, Aşınma, Açma, Kapama)");

            // ComboBox'ın SelectedIndexChanged olayını dinleyelim
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
        }

        private void ResimYukle()
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            // Sadece resim dosyalarını filtrele
            openFileDialog1.Filter = "Resim Dosyaları|*.jpg;*.jpeg;*.png;*.gif;*.bmp|Tüm Dosyalar|*.*";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                beforePic.Image = null;
                // Seçilen resmi PictureBox kontrolüne yükle
                beforePic.Image = new Bitmap(openFileDialog1.FileName);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            string selectedOperation = comboBox1.SelectedItem.ToString();
            switch (selectedOperation)
            {
                case "Gri Dönüşüm":
                    GriDonusum();
                    break;
                case "Binary Dönüşüm":
                    BinaryDonusum();
                    break;
                case "Görüntü Döndürme":
                    GoruntuDonme();
                    break;
                case "Görüntü Kırpma":
                    GoruntuKirma();
                    break;
                case "Görüntü Yaklaştırma/Uzaklaştırma":
                    GoruntuYaklastirmaUzaklastirma();
                    break;
                case "Renk Uzayı Dönüşümleri":
                    RenkUzayiDonusumleri();
                    break;
                case "Giriş görüntüsüne ait histogram ve orjinal görüntü histogramını germe/genişletme":
                    HistogramGenisletme();
                    break;
                case "İki resim arasında aritmetik işlemler (ekleme, çarpma)":
                    AritmetikIslemler();
                    break;
                case "Parlaklık artırma":
                    ParlaklikArtirma();
                    break;
                case "Konvolüsyon İşlemi (gauss)":
                    KonvolusyonIslemi();
                    break;
                case "Eşikleme işlemleri (Adaptif Eşikleme)":
                    EsiklemeIslemleri();
                    break;
                case "Kenar Bulma Algoritmalarının Kullanımı (sobel)":
                    KenarBulma();
                    break;
                case "Görüntüye Gürültü Ekleme (Salt&Pepper) ve filtrelerin kullanımı (mean, median) ile gürültü temizleme":
                    GurultuEklemeTemizleme();
                    break;
                case "Görüntüye Filtre Uygulanması (Blurring)":
                    FiltreUygulama();
                    break;
                case "Morfolojik İşlemler (Genişleme, Aşınma, Açma, Kapama)":
                    MorfolojikIslemler();
                    break;
                default:
                    MessageBox.Show("Geçersiz işlem seçimi.");
                    break;
            }
        }


        private void GriDonusum()
        {

        }

        private void BinaryDonusum()
        {

        }

        private void GoruntuDonme()
        {

        }

        private void GoruntuKirma()
        {

        }

        private void GoruntuYaklastirmaUzaklastirma()
        {

        }

        private void RenkUzayiDonusumleri()
        {

        }

        private void HistogramGenisletme()
        {

        }

        private void AritmetikIslemler()
        {

        }

        private void ParlaklikArtirma()
        {

        }

        private void KonvolusyonIslemi()
        {

        }

        private void EsiklemeIslemleri()
        {

        }

        private void KenarBulma()
        {

        }

        private void GurultuEklemeTemizleme()
        {

        }

        private void FiltreUygulama()
        {
        }

        private void MorfolojikIslemler()
        {

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
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            beforePic.Image = null;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveImage();
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
    }

}

