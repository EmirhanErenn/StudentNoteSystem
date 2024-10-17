using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace ogrencinotuygulamasi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            listView1.View = View.Details;
            listView1.Columns.Add("ADI SOYADI", 115);
            listView1.Columns.Add("ÖĞRENCİ NO", 115);
            listView1.Columns.Add("VİZE", 115);
            listView1.Columns.Add("FİNAL", 115);
            listView1.Columns.Add("BÜTÜNLEME", 115);
            listView1.Columns.Add("ORTALAMASI", 115);
            listView1.Columns.Add("HARF NOTU", 115);
            listView1.Columns.Add("DURUM", 115);

            textBox5.Enabled = false;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int vize = Convert.ToInt16(textBox1.Text);
            int final = textBox2.Enabled ? Convert.ToInt16(textBox2.Text) : 0;
            int but = textBox2.Enabled ? 0 : Convert.ToInt16(textBox5.Text); // Bütünleme notunu kontrol et
            double ort = (vize * 0.4) + (but > 0 ? but * 0.6 : final * 0.6);
            string adsoy = textBox4.Text;
            string ogr_no = textBox3.Text;
            string durum;
            string harfnot;

            if (vize > 100 || vize < 0)
            {
                MessageBox.Show("Lütfen Geçerli Bir Vize Notu Girin!");
                return;
            }

            if (final > 100 || final < 0)
            {
                MessageBox.Show("Lütfen Geçerli Bir Final Notu Girin!");
                return;
            }

            if (but > 100 || but < 0)
            {
                MessageBox.Show("Lütfen Geçerli Bir Bütünleme Notu Girin!");
                return;
            }

            if (textBox3.Text.Length > 10)
            {
                MessageBox.Show("Girilen öğrenci numarası 10 karakterden fazla olamaz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            if (ort >= 90)
            {
                harfnot = "AA";
                durum = "Geçti";
            }
            else if (ort >= 85)
            {
                harfnot = "BA";
                durum = "Geçti";
            }
            else if (ort >= 80)
            {
                harfnot = "BB";
                durum = "Geçti";
            }
            else if (ort >= 75)
            {
                harfnot = "CB";
                durum = "Geçti";
            }
            else if (ort >= 70)
            {
                harfnot = "CC";
                durum = "Geçti";
            }
            else if (ort >= 65)
            {
                harfnot = "DC";
                durum = "Geçti";
            }
            else if (ort >= 60)
            {
                harfnot = "DD";
                durum = "Geçti";
            }
            else if (ort >= 55)
            {
                but = GetButNotu();
                ort = (vize * 0.4) + (but * 0.6);
                if (ort >= 60)
                {
                    harfnot = "DD";
                    durum = "Geçti";
                }
                else
                {
                    harfnot = "FD";
                    durum = "Kaldı";
                }
            }
            else
            {
                but = GetButNotu();
                ort = (vize * 0.4) + (but * 0.6);
                if (ort >= 60)
                {
                    harfnot = "DD";
                    durum = "Geçti";
                }
                else
                {
                    harfnot = "FF";
                    durum = "Kaldı";
                }
            }

            string[] ogrenci = { adsoy, ogr_no, vize.ToString(), final.ToString(), but.ToString(), ort.ToString(), harfnot, durum };

            var list = new ListViewItem(ogrenci);
            listView1.Items.Add(list);
        }

        private void button2_Click(object sender, EventArgs e)
        {
      
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
        }

        private int GetButNotu()
        {
            while (true)
            {
                string input = Interaction.InputBox("Final notu yeterli değil, bütünleme notu giriniz.", "UYARI", "");
                if (int.TryParse(input, out int butNotu) && butNotu >= 0 && butNotu <= 100)
                {
                    return butNotu;
                }
                else
                {
                    MessageBox.Show("Lütfen geçerli bir bütünleme notu girin (0-100 arası bir sayı)!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
