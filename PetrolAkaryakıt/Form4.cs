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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.Ace.OleDb.12.0;Data Source=akaryakıtotomasyon.mdb");

        void listele()
        {

            progressBar1.ForeColor = Color.Goldenrod;
            progressBar2.ForeColor = Color.Goldenrod;
            progressBar3.ForeColor = Color.Goldenrod;
            progressBar4.ForeColor = Color.Goldenrod;

            baglanti.Open();
            OleDbCommand komut = new OleDbCommand("Select * From tblbenzin where PETROLTUR='Kurşunsuz95'", baglanti);
            OleDbDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                lblkursunsuz.Text = dr[2].ToString();
                progressBar1.Value = int.Parse(dr[4].ToString());
                lblkursunsuzstok.Text = dr[4].ToString();
            }
            baglanti.Close();


            baglanti.Open();
            OleDbCommand komut2 = new OleDbCommand("Select * From tblbenzin where PETROLTUR='Motorin Ultra'", baglanti);
            OleDbDataReader dr2 = komut2.ExecuteReader();
            while (dr2.Read())
            {
                lblultra.Text = dr2[2].ToString();
                progressBar2.Value = int.Parse(dr2[4].ToString());
                lblultrastok.Text = dr2[4].ToString();
            }
            baglanti.Close();


            baglanti.Open();
            OleDbCommand komut3 = new OleDbCommand("Select * From tblbenzin where PETROLTUR='Motorin Eco'", baglanti);
            OleDbDataReader dr3 = komut3.ExecuteReader();
            while (dr3.Read())
            {
                lbleco.Text = dr3[2].ToString();
                progressBar3.Value = int.Parse(dr3[4].ToString());
                lblecostok.Text = dr3[4].ToString();
            }
            baglanti.Close();


            baglanti.Open();
            OleDbCommand komut4 = new OleDbCommand("Select * From tblbenzin where PETROLTUR='Gaz'", baglanti);
            OleDbDataReader dr4 = komut4.ExecuteReader();
            while (dr4.Read())
            {
                lblgaz.Text = dr4[2].ToString();
                progressBar4.Value = int.Parse(dr4[4].ToString());
                lblgazstok.Text = dr4[4].ToString();
            }
            baglanti.Close();

            baglanti.Open();
            OleDbCommand komut5 = new OleDbCommand("Select * From tblkasa", baglanti);
            OleDbDataReader dr5 = komut5.ExecuteReader();
            while (dr5.Read())
            {
                lblkasa.Text = dr5[1].ToString();

            }
            baglanti.Close();

        }
        private void Form4_Load(object sender, EventArgs e)
        {
            listele();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            double kursunsuz95, litre, tutar;
            kursunsuz95 = Convert.ToDouble(lblkursunsuz.Text);
            litre = Convert.ToDouble(numericUpDown1.Value);
            tutar = kursunsuz95 * litre;
            txtkursunsuztutar.Text = tutar.ToString();
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            double ultra, litre, tutar;
            ultra = Convert.ToDouble(lblultra.Text);
            litre = Convert.ToDouble(numericUpDown2.Value);
            tutar = ultra * litre;
            txtultratutar.Text = tutar.ToString();
        }

        private void numericUpDown3_ValueChanged(object sender, EventArgs e)
        {
            double eco, litre, tutar;
            eco = Convert.ToDouble(lbleco.Text);
            litre = Convert.ToDouble(numericUpDown3.Value);
            tutar = eco * litre;
            txtecotutar.Text = tutar.ToString();
        }

        private void numericUpDown4_ValueChanged(object sender, EventArgs e)
        {
            double gaz, litre, tutar;
            gaz = Convert.ToDouble(lblgaz.Text);
            litre = Convert.ToDouble(numericUpDown4.Value);
            tutar = gaz * litre;
            txtgaztutar.Text = tutar.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (numericUpDown1.Value != 0)
            {
                baglanti.Open();
                OleDbCommand komut = new OleDbCommand("insert into tblhareket (BENZINTURU,LITRE,FIYAT) values (@p2,@p3,@p4)", baglanti);
                
                komut.Parameters.AddWithValue("@p2", "Kurşunsuz 95");
                komut.Parameters.AddWithValue("@p3", numericUpDown1.Value);
                komut.Parameters.AddWithValue("@p4", double.Parse(txtkursunsuztutar.Text));
                komut.ExecuteNonQuery();
                baglanti.Close();

                baglanti.Open();
                OleDbCommand komut2 = new OleDbCommand("update tblkasa set MIKTAR=MIKTAR-@p1", baglanti);
                komut2.Parameters.AddWithValue("@p1", double.Parse(txtkursunsuztutar.Text));
                komut2.ExecuteNonQuery();
                baglanti.Close();


                baglanti.Open();
                OleDbCommand komut3 = new OleDbCommand("update tblbenzin set STOK=STOK+@p1 where PETROLTUR='Kurşunsuz95'", baglanti);
                komut3.Parameters.AddWithValue("@p1", numericUpDown1.Value);
                komut3.ExecuteNonQuery();
                baglanti.Close();
                MessageBox.Show("Alım İşlemi Gerçekleştirildi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                listele();
            }

            if (numericUpDown2.Value != 0)
            {
                baglanti.Open();
                OleDbCommand komut = new OleDbCommand("insert into tblhareket (BENZINTURU,LITRE,FIYAT) values (@p2,@p3,@p4)", baglanti);
                
                komut.Parameters.AddWithValue("@p2", "Motorin Ultra");
                komut.Parameters.AddWithValue("@p3", numericUpDown2.Value);
                komut.Parameters.AddWithValue("@p4", double.Parse(txtultratutar.Text));
                komut.ExecuteNonQuery();
                baglanti.Close();

                baglanti.Open();
                OleDbCommand komut2 = new OleDbCommand("update tblkasa set MIKTAR=MIKTAR-@p1", baglanti);
                komut2.Parameters.AddWithValue("@p1", double.Parse(txtultratutar.Text));
                komut2.ExecuteNonQuery();
                baglanti.Close();


                baglanti.Open();
                OleDbCommand komut3 = new OleDbCommand("update tblbenzin set STOK=STOK+@p1 where PETROLTUR='Motorin Ultra'", baglanti);
                komut3.Parameters.AddWithValue("@p1", numericUpDown2.Value);
                komut3.ExecuteNonQuery();
                baglanti.Close();
                MessageBox.Show("Alım İşlemi Gerçekleştirildi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                listele();
            }
            if (numericUpDown3.Value != 0)
            {
                baglanti.Open();
                OleDbCommand komut = new OleDbCommand("insert into tblhareket (BENZINTURU,LITRE,FIYAT) values (@p2,@p3,@p4)", baglanti);
                
                komut.Parameters.AddWithValue("@p2", "Motorin Eco");
                komut.Parameters.AddWithValue("@p3", numericUpDown3.Value);
                komut.Parameters.AddWithValue("@p4", double.Parse(txtecotutar.Text));
                komut.ExecuteNonQuery();
                baglanti.Close();

                baglanti.Open();
                OleDbCommand komut2 = new OleDbCommand("update tblkasa set MIKTAR=MIKTAR-@p1", baglanti);
                komut2.Parameters.AddWithValue("@p1", double.Parse(txtecotutar.Text));
                komut2.ExecuteNonQuery();
                baglanti.Close();


                baglanti.Open();
                OleDbCommand komut3 = new OleDbCommand("update tblbenzin set STOK=STOK+@p1 where PETROLTUR='Motorin Eco'", baglanti);
                komut3.Parameters.AddWithValue("@p1", numericUpDown3.Value);
                komut3.ExecuteNonQuery();
                baglanti.Close();
                MessageBox.Show("Alım İşlemi Gerçekleştirildi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                listele();
            }

            if (numericUpDown4.Value != 0)
            {
                baglanti.Open();
                OleDbCommand komut = new OleDbCommand("insert into tblhareket (BENZINTURU,LITRE,FIYAT) values (@p2,@p3,@p4)", baglanti);
                
                komut.Parameters.AddWithValue("@p2", "Gaz");
                komut.Parameters.AddWithValue("@p3", numericUpDown4.Value);
                komut.Parameters.AddWithValue("@p4", double.Parse(txtgaztutar.Text));
                komut.ExecuteNonQuery();
                baglanti.Close();

                baglanti.Open();
                OleDbCommand komut2 = new OleDbCommand("update tblkasa set MIKTAR=MIKTAR-@p1", baglanti);
                komut2.Parameters.AddWithValue("@p1", double.Parse(txtgaztutar.Text));
                komut2.ExecuteNonQuery();
                baglanti.Close();


                baglanti.Open();
                OleDbCommand komut3 = new OleDbCommand("update tblbenzin set STOK=STOK+@p1 where PETROLTUR='Gaz'", baglanti);
                komut3.Parameters.AddWithValue("@p1", numericUpDown4.Value);
                komut3.ExecuteNonQuery();
                baglanti.Close();
                MessageBox.Show("Alım İşlemi Gerçekleştirildi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                listele();
            }
        }
    }
}
