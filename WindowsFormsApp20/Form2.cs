using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Runtime.CompilerServices;

namespace WindowsFormsApp20
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        SqlConnection baglan = new SqlConnection("Data Source=BURAK\\SQLEXPRESS;Initial Catalog=siteler;Integrated Security=True");
        private void verilerigoster()
        {
            baglan.Open();
            SqlCommand komut = new SqlCommand("Select *from sitebilgi", baglan);
            SqlDataReader oku = komut.ExecuteReader();

            while (oku.Read())
            {
                ListViewItem ekle = new ListViewItem();
                ekle.Text = oku["id"].ToString();
                ekle.SubItems.Add(oku["site"].ToString());
                ekle.SubItems.Add(oku["oda"].ToString());
                ekle.SubItems.Add(oku["metre"].ToString());
                ekle.SubItems.Add(oku["fiyat"].ToString());
                ekle.SubItems.Add(oku["blok"].ToString());
                ekle.SubItems.Add(oku["no"].ToString());
                ekle.SubItems.Add(oku["adsoyad"].ToString());
                ekle.SubItems.Add(oku["telefon"].ToString());
                ekle.SubItems.Add(oku["notlar"].ToString());
                ekle.SubItems.Add(oku["satkira"].ToString());
                listView1.Items.Add(ekle);
            }
            baglan.Close();
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text == "Zambak Sitesi")
            {
                BtnZambak.BackColor = Color.Yellow;

            }
            if (comboBox1.Text == "Papatya Sitesi")
            {
                BtnPapatya.BackColor = Color.Yellow;

            }
            if (comboBox1.Text == "Gül Sitesi")
            {
                BtnGul.BackColor = Color.Yellow;

            }
            if (comboBox1.Text == "Menekşe Sitesi")
            {
                BtnMenekse.BackColor = Color.Yellow;

            }
        }

        private void BtnGoruntule_Click(object sender, EventArgs e)
        {
            verilerigoster();
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            baglan.Open();
            SqlCommand komut = new SqlCommand("Insert into sitebilgi (id,site,oda,metre,fiyat,blok,no,adsoyad,telefon,notlar,satkira) values (@pid,@psite,@poda,@pmetre,@pfiyat,@pblok,@pno,@padsoyad,@ptelefon,@pnotlar,@psatkira)", baglan);

            komut.Parameters.AddWithValue("@pid", textBox7.Text);
            komut.Parameters.AddWithValue("@psite", comboBox1.Text);
            komut.Parameters.AddWithValue("@poda", comboBox3.Text);
            komut.Parameters.AddWithValue("@pmetre", textBox1.Text);
            komut.Parameters.AddWithValue("@pfiyat", textBox2.Text);
            komut.Parameters.AddWithValue("@pblok", comboBox4.Text);
            komut.Parameters.AddWithValue("@pno", textBox6.Text);
            komut.Parameters.AddWithValue("@padsoyad", textBox4.Text);
            komut.Parameters.AddWithValue("@ptelefon", textBox5.Text);
            komut.Parameters.AddWithValue("@pnotlar", textBox3.Text);
            komut.Parameters.AddWithValue("@psatkira", comboBox2.Text);
            komut.ExecuteNonQuery();
            baglan.Close();
            verilerigoster();
        }
        int selectedID;
       
        int id = 0;
        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            
        }
    }
}
