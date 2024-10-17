using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ogrencinotuygulamasi
{
    public partial class Form2 : Form
    {
        public int ButNotu { get; private set; } // Bütünleme notunu saklayacak
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int butNotu;
            if (int.TryParse(textBox1.Text, out butNotu) && butNotu >= 0 && butNotu <= 100)
            {
                ButNotu = butNotu;
                this.DialogResult = DialogResult.OK; // Formun başarıyla kapandığını belirtir
                this.Close();
            }
            else
            {
                MessageBox.Show("Lütfen geçerli bir bütünleme notu girin (0-100 arası)!");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
