using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Sternbilder
{
    public partial class Anzeige : Form
    {
        private Sternbilder steuerung;
        private PictureBox element = null;
        private PictureBox[] wolken = null;
        private Random rand = new Random();

        public Anzeige()
        {
            InitializeComponent();
            wolken = new PictureBox[10];
            for (int i = 0; i < 10; i++) wolken[i] = null;
        }
        public Anzeige(Sternbilder frmSteuerung)
            : this()
        {
            steuerung = frmSteuerung;
        }

        private void Anzeige_MouseClick(object sender, MouseEventArgs e)
        {
            steuerung.txtX.Text = e.X.ToString();
            steuerung.txtY.Text = e.Y.ToString();
            if (element != null)
            {
                steuerung.setKoordinates(steuerung.cmbSternbild.Text, e.X, e.Y);
                this.Invalidate(new Rectangle(element.Location, element.Size));
                Point p =  e.Location;
                p.Offset(-element.Size.Width/2, -element.Size.Height/2 );
                element.Location = p;
                this.Invalidate(new Rectangle(element.Location, element.Size));
                element = null;
                steuerung.cmbSternbild.BackColor = Color.White;
            }
            else
            {
                foreach (PictureBox p in this.Controls)
                {
                    if (p.Bounds.IntersectsWith(new Rectangle(e.X, e.Y, 1, 1)))
                    {
                        element = p;
                        if (p.Name.Substring(0,5) != "Regen" ) // keine Regenwolken 
                        {
                            steuerung.cmbSternbild.Text = p.Name;
                            steuerung.cmbSternbild.BackColor = Color.Yellow;
                        }
                    }
                }
            }
            // wenn Steuerung im gleichen Fenster, wieder sichtbar machen
            steuerung.Focus();
        }
        public void verstecke(string Sternbild)
        {
            try
            {
                Invalidate(new Rectangle(Controls[Sternbild].Location, Controls[Sternbild].Size));
                Controls.RemoveByKey(Sternbild);        
            }
            catch (Exception)
            { 
            }
        }
        public void createWolke()
        {
            int pos = 0;
            while (pos < 10 && wolken[pos] != null)
            {
                pos++;
            }
            if (pos < 10)
            {
                PictureBox p = new PictureBox();
                p.Image = (Bitmap)global::Sternbilder.Properties.Resources.ResourceManager.GetObject("Regenwolke");
                p.SizeMode = PictureBoxSizeMode.AutoSize;
                p.Location = new System.Drawing.Point(Convert.ToInt16(rand.Next(this.Size.Width)),
                    Convert.ToInt16(rand.Next(this.Size.Height)));
                p.Tag = Convert.ToString(rand.Next(50) - 25) + ":" + Convert.ToString(rand.Next(50) - 25);
                if (p.Tag.ToString() == "0:0") p.Tag = "1:0";
                p.Name = "Regenwolke" + pos.ToString();
                p.BackColor = Color.Transparent;
                Bitmap b = (Bitmap)p.Image;
                Color backColor = b.GetPixel(1, 1);
                b.MakeTransparent(backColor);
                p.Image = b;
                p.Enabled = false;
                p.Size = new System.Drawing.Size(b.Width, b.Height);
                p.Visible = false;
                Controls.Add(p);
                wolken[pos] = p;
            }
        }

        public void exchange(string Sternbild, bool linie)
        {
            try
            {
                PictureBox p = (PictureBox)this.Controls[Sternbild];
                if (linie)
                {
                    Sternbild = Sternbild + "_Linie";
                }
                Invalidate(new Rectangle(p.Location, p.Size));
                Bitmap b = (Bitmap)global::Sternbilder.Properties.Resources.ResourceManager.GetObject(Sternbild);
                p.SizeMode = PictureBoxSizeMode.AutoSize;
                p.BackColor = Color.Transparent;
                Color backColor = b.GetPixel(1, 1);
                b.MakeTransparent(backColor);
                p.Image = b;
                p.Size = new System.Drawing.Size(b.Width, b.Height);
                Invalidate(new Rectangle(p.Location, p.Size));
            }
            catch (Exception)
            { }

        }
        public void showSternbild(string Sternbild, string x, string y)
        {
            try
            {
                PictureBox p;
                p = (PictureBox)this.Controls[Sternbild];
                if (p == null)
                {
                    int xx;
                    int yy;
                    p = new PictureBox();
                    p.Name = Sternbild;
                    if (steuerung.chkLinien.Checked) Sternbild += "_Linie";
                    p.Image = (Bitmap)global::Sternbilder.Properties.Resources.ResourceManager.GetObject(Sternbild);
                    p.SizeMode = PictureBoxSizeMode.AutoSize;
                    if (x == "" || y == "")
                    {
                        xx = rand.Next(Size.Width-p.Image.Size.Width/2);
                        yy = rand.Next(Size.Height-p.Image.Size.Height/2);
                    }
                    else
                    {
                        xx = Convert.ToInt16(x);
                        yy = Convert.ToInt16(y);
                        xx -= p.Image.Size.Width / 2;
                        yy -= p.Image.Size.Height / 2;
                    }
                    p.Location = new System.Drawing.Point(xx, yy);
                    p.BackColor = Color.Transparent;
                    Bitmap b = (Bitmap)p.Image;
                    Color backColor = b.GetPixel(1, 1);
                    b.MakeTransparent(backColor);
                    p.Image = b;
                    p.Enabled = false;
                    p.Size = new System.Drawing.Size(b.Width, b.Height);
                    p.Visible = false; 
                    Controls.Add(p);
                    steuerung.setKoordinates(Sternbild, p.Location.X, p.Location.Y);
                    Invalidate(new Rectangle(p.Location, p.Size));
                }
                else
                {
                    MessageBox.Show("Sternbild schon vorhanden");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        
        private void timer1_Tick(object sender, EventArgs e)
        {
            bool aenderung = false;
            timer1.Enabled = false;
            foreach (DataGridViewRow r in steuerung.grdView.Rows)
            {
                try
                {
                    if (r.Cells[3].Value != null && r.Cells[3].Value.ToString() != "")
                    {
                        // Bewegung angefordert
                        int time = Convert.ToInt16(r.Cells[5].Value.ToString());
                        r.Cells[5].Value = Convert.ToString(Convert.ToInt16(r.Cells[5].Value.ToString()) - 1);
                        double x = Convert.ToDouble(r.Cells[1].Value.ToString());
                        double y = Convert.ToDouble(r.Cells[2].Value.ToString());
                        int xz = Convert.ToInt16(r.Cells[3].Value.ToString());
                        int yz = Convert.ToInt16(r.Cells[4].Value.ToString());
                        double diffX = (x - xz) / time;
                        double diffY = (y - yz) / time;
                        PictureBox p = (PictureBox)Controls[r.Cells[0].Value.ToString()];
                        Invalidate(new Rectangle(p.Location, p.Size));
                        x -= diffX;
                        y -= diffY;
                        r.Cells[1].Value = x.ToString();
                        r.Cells[2].Value = y.ToString();
                        p.Location = new System.Drawing.Point(Convert.ToInt16(x), Convert.ToInt16(y));
                        Invalidate(new Rectangle(p.Location, p.Size));
                        // Bewegung stoppen ?
                        if (r.Cells[5].Value.ToString() == "0")
                        {
                            r.Cells[5].Value = "";
                            r.Cells[4].Value = "";
                            r.Cells[3].Value = "";
                            p.Location = new System.Drawing.Point(Convert.ToInt16(xz), Convert.ToInt16(yz));
                        }
                        aenderung = true;
                    }
                }
                catch (Exception)
                { 
                }
                
            }
            // Prüfung auf Zusammenstöße 
            try {
                PictureBox waechter = (PictureBox)this.Controls["Bauer"];
                PictureBox feger = (PictureBox)this.Controls["Fuchs"];
                if ( waechter.Bounds.IntersectsWith(feger.Bounds) )
                {
                    // 
                    showSternbild("toter_Fuchs", feger.Location.X.ToString(), feger.Location.Y.ToString());
                    steuerung.verstecke("Fuchs");
                    steuerung.verstecke("Bauer");
                    aenderung = true;
                }
            }
            catch (Exception)
            {
            }
            try
            {
                PictureBox waechter = (PictureBox)this.Controls["Huhn"];
                PictureBox feger = (PictureBox)this.Controls["Pilz"];
                if (waechter.Bounds.IntersectsWith(feger.Bounds))
                {
                    // 
                    showSternbild("totes_Huhn", feger.Location.X.ToString(), feger.Location.Y.ToString());
                    steuerung.verstecke("Huhn");
                    steuerung.verstecke("Pilz");
                    aenderung = true;
                }
            }
            catch (Exception)
            {
            }
            try
            {
                PictureBox waechter = (PictureBox)this.Controls["Feenstab"];
                PictureBox feger = (PictureBox)this.Controls["Mond"];
                if (waechter.Bounds.IntersectsWith(feger.Bounds))
                {
                    // 
                    showSternbild("Blume_der_Nacht", feger.Location.X.ToString(), feger.Location.Y.ToString());
                    steuerung.verstecke("Mond");
                    steuerung.verstecke("Feenstab");
                    aenderung = true;
                }
            }
            catch (Exception)
            {
            }
            try
            {
                PictureBox waechter = (PictureBox)this.Controls["Zauberlehrling"];
                PictureBox feger = (PictureBox)this.Controls["Pilz"];
                if (waechter.Bounds.IntersectsWith(feger.Bounds) )
                {
                    // 
                    showSternbild("angebissener_Pilz", feger.Location.X.ToString(), feger.Location.Y.ToString());
                    steuerung.verstecke("Zauberlehrling");
                    steuerung.verstecke("Pilz");
                    aenderung = true;
                }
            }
            catch (Exception)
            {
            }
            try
            {
                PictureBox waechter = (PictureBox)this.Controls["Turm"];
                PictureBox feger = (PictureBox)this.Controls["Feger"];
                if (waechter.Bounds.IntersectsWith(feger.Bounds) )
                {
                    // 
                    showSternbild("Zauberlehrling", feger.Location.X.ToString(), feger.Location.Y.ToString());
                    steuerung.verstecke("Turm");
                    steuerung.verstecke("Feger");
                    aenderung = true;
                }
            }
            catch (Exception)
            {
            }
            try
            {
                PictureBox waechter = (PictureBox)this.Controls["Huhn"];
                PictureBox feger = (PictureBox)this.Controls["Fuchs"];
                if (waechter.Bounds.IntersectsWith(feger.Bounds) )
                {
                    // 
                    showSternbild("satter_Fuchs", feger.Location.X.ToString(), feger.Location.Y.ToString());
                    steuerung.verstecke("Fuchs");
                    steuerung.verstecke("Huhn");
                    aenderung = true;
                }
            }
            catch (Exception)
            {
            }
            try
            {
                PictureBox waechter = (PictureBox)this.Controls["Bauer"];
                PictureBox feger = (PictureBox)this.Controls["Fuchs"];
                if (waechter.Bounds.IntersectsWith(feger.Bounds) )
                {
                    // 
                    showSternbild("wilde_Jagd", feger.Location.X.ToString(), feger.Location.Y.ToString());
                    steuerung.verstecke("Fuchs");
                    steuerung.verstecke("Huhn");
                    steuerung.verstecke("Bauer");
                    aenderung = true;
                }
            }
            catch (Exception)
            {
            }            
            try
            {
                PictureBox waechter = (PictureBox)this.Controls["Wächter"];
                PictureBox feger = (PictureBox)this.Controls["Flasche"];
                if (waechter.Bounds.IntersectsWith(feger.Bounds))
                {
                    // 
                    showSternbild("betrunkener_Wächter", feger.Location.X.ToString(), feger.Location.Y.ToString());
                    steuerung.verstecke("Flasche");
                    steuerung.verstecke("Wächter");
                    aenderung = true;
                }
            }
            catch (Exception)
            {
            }
            try
            {
                PictureBox waechter = (PictureBox)this.Controls["Wolke"];
                PictureBox feger = (PictureBox)this.Controls["Zipferlake"];
                if (waechter.Bounds.IntersectsWith(feger.Bounds))
                {
                    
                    foreach (DataGridViewRow r in steuerung.grdView.Rows)
                    {
                        if (r.Cells[0].Value.ToString() == "Tod" && 
                            (r.Cells[1].Value == null || r.Cells[1].Value.ToString() == "") )
                        {
                            showSternbild("Tod", feger.Location.X.ToString(), feger.Location.Y.ToString());
                            r.Cells[3].Value = 1600;
                            r.Cells[4].Value = 1100;
                            r.Cells[5].Value = "3600";
                        }
                    }
                    aenderung = true;
                }
            }
            catch (Exception)
            {
            }
            if ( aenderung ) 
            {
                steuerung.saveJournal();
            }
            try
            {
                    int d = rand.Next(4);
                    PictureBox p = (PictureBox)Controls["Wolke"];
                    switch (d)
                    {
                        case 0:
                            p.Image = (Bitmap)global::Sternbilder.Properties.Resources.ResourceManager.GetObject("Wolke");
                            break;
                        case 1:
                            p.Image = (Bitmap)global::Sternbilder.Properties.Resources.ResourceManager.GetObject("Wolke1");
                            break;
                        case 2:
                            p.Image = (Bitmap)global::Sternbilder.Properties.Resources.ResourceManager.GetObject("Wolke2");
                            break;
                        case 3:
                            p.Image = (Bitmap)global::Sternbilder.Properties.Resources.ResourceManager.GetObject("Wolke3");
                            break;
                    }
                    Bitmap b = (Bitmap)p.Image;
                    Color backColor = b.GetPixel(1, 1);
                    b.MakeTransparent(backColor);
                
                    this.Invalidate(new Rectangle(p.Location, p.Size));
                    
                
            }
            catch (Exception) { }
                
            if (steuerung.chkWetter.Checked)
            {
                // Wettersteuerung 
                System.Text.RegularExpressions.Regex r = new System.Text.RegularExpressions.Regex("^(?<x>.+):(?<y>.+)");
                for (int i = 0; i < 10; i++)
                {
                    PictureBox wolke = wolken[i];
                    if (wolke != null)
                    {
                        System.Text.RegularExpressions.Match m = r.Match(wolke.Tag.ToString());
                        int x = Convert.ToInt16(m.Groups["x"].Value);
                        int y = Convert.ToInt16(m.Groups["y"].Value);
                        Point p = wolke.Location;
                        p.Offset(x, y);
                        this.Invalidate(new Rectangle(wolke.Location, wolke.Size)); 
                        wolke.Location = p;
                        this.Invalidate(new Rectangle(wolke.Location, wolke.Size)); 
                        if (wolke.Location.X + wolke.Size.Width < 0 || wolke.Location.X > this.Size.Width ||
                            wolke.Location.Y + wolke.Size.Height < 0 || wolke.Location.Y > this.Size.Height)
                        {
                            // Wolke entfernen
                            Controls.Remove(wolke);
                            wolke = null;
                            wolken[i] = null;
                        }
                    }
                }
                try
                {
                    if (rand.NextDouble() < Convert.ToDouble(steuerung.txtWolkenwahrscheinlichkeit.Text))
                    {
                        createWolke();
                    }
                }
                catch (Exception)
                {
                    steuerung.txtWolkenwahrscheinlichkeit.Text = "0,001";                    
                }
            }
            else
            {
                for (int i = 0; i < 10; i++)
                {
                    if (wolken[i] != null)
                    {
                        this.Invalidate(new Rectangle(wolken[i].Location, wolken[i].Size));
                        Controls.Remove(wolken[i]);
                        wolken[i] = null;
                    }
                }
            }
            timer1.Enabled = true ;
        }

        private void Anzeige_Paint(object sender, PaintEventArgs e)
        {
            PictureBox wolke = null;
            foreach (Control c in Controls)
            {
                if (typeof(PictureBox) == c.GetType())
                {
                    PictureBox p = (PictureBox)c;
                    if (p.Name == "Wolke") wolke = p;
                    e.Graphics.DrawImage(p.Image, p.Location);
                }
            }
            if (wolke != null)
            {
                e.Graphics.DrawImage(wolke.Image, wolke.Location);
            }
            for (int i = 0; i < 10; i++)
            {
                PictureBox regenwolke = wolken[i];
                if (regenwolke != null)
                {
                    e.Graphics.DrawImage(regenwolke.Image, regenwolke.Location);
                }
            }
        }

        private void Anzeige_KeyPress(object sender, KeyPressEventArgs e)
        {
            steuerung.Focus();
            //Thread.Sleep(250);//warten bis es im fordergrund ist
            SendKeys.SendWait(e.KeyChar.ToString());//keys senden
            this.Focus();
        }

        private void Anzeige_Load(object sender, EventArgs e)
        {
            this.Icon = (Icon)global::Sternbilder.Properties.Resources.ResourceManager.GetObject("Sterne");
        }
        
    }
    
}