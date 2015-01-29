using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Sternbilder
{
    public partial class Sternbilder : Form
    {
        private Anzeige frmAnzeige;
        public Sternbilder()
        {
            InitializeComponent();
        }
        public void saveJournal()
        {
            System.IO.StreamWriter t = new System.IO.StreamWriter("sternbilder.txt");
            foreach (DataGridViewRow r in grdView.Rows)
            {
                t.Write(r.Cells[0].Value+";");
                t.Write(r.Cells[1].Value+";");
                t.Write(r.Cells[2].Value+";");
                t.Write(r.Cells[3].Value+";");
                t.Write(r.Cells[4].Value+";");
                t.WriteLine(r.Cells[5].Value);
            }
            t.Close();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            this.Icon = (Icon)global::Sternbilder.Properties.Resources.ResourceManager.GetObject("Steinsbergwappenicon");
                           
            frmAnzeige = new Anzeige(this);
            frmAnzeige.Show();
            grdView.Rows.Add();
            grdView.Rows[grdView.RowCount - 1].Cells[0].Value = "Wächter";
            grdView.Rows.Add();
            grdView.Rows[grdView.RowCount - 1].Cells[0].Value = "betrunkener_Wächter";
            grdView.Rows.Add();
            grdView.Rows[grdView.RowCount - 1].Cells[0].Value = "offenes_Tor";
            grdView.Rows.Add();
            grdView.Rows[grdView.RowCount - 1].Cells[0].Value = "geschlossenes_Tor";
            grdView.Rows.Add();
            grdView.Rows[grdView.RowCount - 1].Cells[0].Value = "Zipferlake";
            grdView.Rows.Add();
            grdView.Rows[grdView.RowCount - 1].Cells[0].Value = "Wolke";
            grdView.Rows.Add();
            grdView.Rows[grdView.RowCount - 1].Cells[0].Value = "Flasche";
            grdView.Rows.Add();
            grdView.Rows[grdView.RowCount - 1].Cells[0].Value = "Feger";
            grdView.Rows.Add();
            grdView.Rows[grdView.RowCount - 1].Cells[0].Value = "Feenstab";
            grdView.Rows.Add();
            grdView.Rows[grdView.RowCount - 1].Cells[0].Value = "Pilz";
            grdView.Rows.Add();
            grdView.Rows[grdView.RowCount - 1].Cells[0].Value = "angebissener_Pilz";
            grdView.Rows.Add();
            grdView.Rows[grdView.RowCount - 1].Cells[0].Value = "Bauer";
            grdView.Rows.Add();
            grdView.Rows[grdView.RowCount - 1].Cells[0].Value = "toter_Bauer";
            grdView.Rows.Add();
            grdView.Rows[grdView.RowCount - 1].Cells[0].Value = "Mond";
            grdView.Rows.Add();
            grdView.Rows[grdView.RowCount - 1].Cells[0].Value = "Mond_von_der_Seite";
            grdView.Rows.Add();
            grdView.Rows[grdView.RowCount - 1].Cells[0].Value = "Zauberlehrling";
            grdView.Rows.Add();
            grdView.Rows[grdView.RowCount - 1].Cells[0].Value = "Turm";
            grdView.Rows.Add();
            grdView.Rows[grdView.RowCount - 1].Cells[0].Value = "Fuchs";
            grdView.Rows.Add();
            grdView.Rows[grdView.RowCount - 1].Cells[0].Value = "satter_Fuchs";
            grdView.Rows.Add();
            grdView.Rows[grdView.RowCount - 1].Cells[0].Value = "toter_Fuchs";
            grdView.Rows.Add();
            grdView.Rows[grdView.RowCount - 1].Cells[0].Value = "Huhn";
            grdView.Rows.Add();
            grdView.Rows[grdView.RowCount - 1].Cells[0].Value = "totes_Huhn";
            grdView.Rows.Add();
            grdView.Rows[grdView.RowCount - 1].Cells[0].Value = "Wilde_Jagd";
            grdView.Rows.Add();
            grdView.Rows[grdView.RowCount - 1].Cells[0].Value = "Blume_der_Nacht";
            grdView.Rows.Add();
            grdView.Rows[grdView.RowCount - 1].Cells[0].Value = "Sanduhr";
            grdView.Rows.Add();
            grdView.Rows[grdView.RowCount - 1].Cells[0].Value = "Tod";
            grdView.Rows.Add();
            grdView.Rows[grdView.RowCount - 1].Cells[0].Value = "Steinsberg";
            grdView.Rows.Add();
            grdView.Rows[grdView.RowCount - 1].Cells[0].Value = "Thaskar";
            grdView.Rows.Add();
            grdView.Rows[grdView.RowCount - 1].Cells[0].Value = "Allerland";
            grdView.Rows.Add();
            grdView.Rows[grdView.RowCount - 1].Cells[0].Value = "Stern1_Rot";
            grdView.Rows.Add();
            grdView.Rows[grdView.RowCount - 1].Cells[0].Value = "Stern2_Gelb"; 
            grdView.Rows.Add();
            grdView.Rows[grdView.RowCount - 1].Cells[0].Value = "Stern3_Grün"; 
            grdView.Rows.Add();
            grdView.Rows[grdView.RowCount - 1].Cells[0].Value = "Stern4_Blau";
            foreach (DataGridViewRow r in grdView.Rows)
            {
                cmbSternbild.Items.Add(r.Cells[0].Value.ToString());
            }
            cmbSternbild.Text = "Wächter";
        }

        private void btnAnzeigen_Click(object sender, EventArgs e)
        {
            frmAnzeige.showSternbild(cmbSternbild.Text, txtX.Text, txtY.Text);
            saveJournal();
        }

        private void grdView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

                cmbSternbild.Text = grdView.Rows[e.RowIndex].Cells[0].Value.ToString();
            }
            catch (Exception) { }
        }
        public void setKoordinates(string Sternbild, int x, int y)
        {
            foreach (DataGridViewRow r in grdView.Rows)
            {
                if (r.Cells[0].Value.ToString() == Sternbild)
                {
                    r.Cells[1].Value = x.ToString();
                    r.Cells[2].Value = y.ToString();
                }
            }

        }

        private void btnBewegen_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow r in grdView.Rows)
            {
                if (r.Cells[0].Value.ToString() == cmbSternbild.Text && r.Cells[1].Value.ToString() != "" )
                {
                    r.Cells[3].Value = txtX.Text;
                    r.Cells[4].Value = txtY.Text;
                    int sek = 0;
                    try
                    {
                        sek = Convert.ToInt16(txtSek.Text);
                        sek += Convert.ToInt16(txtMin.Text) * 60;
                    }
                    catch (Exception)
                    {
                    }
                    r.Cells[5].Value = Convert.ToString(sek);
                }
            }
            saveJournal();
        }

        public void verstecke(string Sternbild)
        {
            foreach (DataGridViewRow r in grdView.Rows)
            {
                if (r.Cells[0].Value.ToString() == Sternbild)
                {
                    r.Cells[1].Value = "";
                    r.Cells[2].Value = "";
                    r.Cells[3].Value = "";
                    r.Cells[4].Value = "";
                    r.Cells[5].Value = "";
                    frmAnzeige.verstecke(Sternbild);
                }
            }
            saveJournal();
        }
        private void btnVerstecken_Click(object sender, EventArgs e)
        {
            verstecke(cmbSternbild.Text);
        }
        public DataGridViewRow getRow(string Sternbild)
        {
            foreach (DataGridViewRow r in grdView.Rows)
            {
                if (r.Cells[0].Value.ToString() == Sternbild)
                {
                    return r;
                }
            }
            return null;
            
        }
        private void btnLaden_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow r in grdView.Rows)
            {
                frmAnzeige.verstecke(r.Cells[0].Value.ToString());
            }
            grdView.Rows.Clear();
            try
            {
                System.IO.StreamReader t = new System.IO.StreamReader("sternbilder.txt");
                while (!t.EndOfStream)
                {
                    grdView.Rows.Add();
                    string line = t.ReadLine();
                    string[] ar = line.Split(new Char[] { ';' });
                    for (int i = 0; i < ar.Length; i++)
                    {

                        grdView.Rows[grdView.RowCount - 1].Cells[i].Value = ar[i];
                    }
                }
                t.Close();
                foreach (DataGridViewRow r in grdView.Rows)
                {
                    if (r.Cells[1].Value != null && r.Cells[1].Value != "" )
                    {
                        frmAnzeige.showSternbild(r.Cells[0].Value.ToString(), r.Cells[1].Value.ToString(), r.Cells[2].Value.ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void chkLinien_CheckedChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow r in grdView.Rows)
            {
                if (r.Cells[0].Value.ToString() != "")
                {
                    frmAnzeige.exchange(r.Cells[0].Value.ToString(), chkLinien.Checked);
                }
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (chkHintergrund.Checked)
            {
                frmAnzeige.BackgroundImage = global::Sternbilder.Properties.Resources.Milchstrasse_Cen_Sag;
            }
            else
            {
                frmAnzeige.BackgroundImage = null;
            }
        }

        private void btnWolke_Click(object sender, EventArgs e)
        {
            frmAnzeige.createWolke();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Sternbilder_KeyPress(object sender, KeyPressEventArgs e)
        {

        }
    }
}