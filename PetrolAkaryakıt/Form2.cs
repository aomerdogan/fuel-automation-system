using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;

namespace PetrolAkaryakıt
{
    public partial class Form2 : Form
    {


        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.Ace.OleDb.12.0;Data Source=akaryakıtotomasyon.mdb");
        OleDbCommandBuilder gn;
        OleDbDataAdapter veri;        
        DataTable Tablo = new DataTable();
                

        public Form2()
        {
            InitializeComponent();
            dataGridView1.DataSource = listele();
        }

        DataTable listele()
        {
            veri = new OleDbDataAdapter("Select * From tblhareket", baglanti);
            veri.Fill(Tablo);
            return Tablo;
        }
       

        private void Form2_Load(object sender, EventArgs e)
        {
            {
                
              
                dataGridView1.Columns[0].Width = 120;
                dataGridView1.Columns[1].Width = 200;
                dataGridView1.Columns[2].Width = 200;
                dataGridView1.Columns[3].Width = 165;
                dataGridView1.Columns[4].Width = 175;

                dataGridView1.Columns[0].HeaderText = "ID";
                dataGridView1.Columns[1].HeaderText = "Plaka";
                dataGridView1.Columns[2].HeaderText = "Benzin Türü";
                dataGridView1.Columns[3].HeaderText = "Litre";
                dataGridView1.Columns[4].HeaderText = "Fiyat";
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            gn = new OleDbCommandBuilder(veri);
            veri.Update(Tablo);
            MessageBox.Show("Güncelleme Gerçekleştirildi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

       

       
    }
}
