namespace Sternbilder
{
    partial class Sternbilder
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.btnAnzeigen = new System.Windows.Forms.Button();
            this.txtX = new System.Windows.Forms.TextBox();
            this.txtY = new System.Windows.Forms.TextBox();
            this.btnBewegen = new System.Windows.Forms.Button();
            this.txtSek = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.grdView = new System.Windows.Forms.DataGridView();
            this.Sternbild = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.X = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Y = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.zuX = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.zuY = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Zeit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnVerstecken = new System.Windows.Forms.Button();
            this.btnLaden = new System.Windows.Forms.Button();
            this.chkLinien = new System.Windows.Forms.CheckBox();
            this.chkHintergrund = new System.Windows.Forms.CheckBox();
            this.chkWetter = new System.Windows.Forms.CheckBox();
            this.btnWolke = new System.Windows.Forms.Button();
            this.txtMin = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtWolkenwahrscheinlichkeit = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.cmbSternbild = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.grdView)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAnzeigen
            // 
            this.btnAnzeigen.Location = new System.Drawing.Point(118, 26);
            this.btnAnzeigen.Name = "btnAnzeigen";
            this.btnAnzeigen.Size = new System.Drawing.Size(75, 23);
            this.btnAnzeigen.TabIndex = 2;
            this.btnAnzeigen.Text = "&Anzeigen";
            this.toolTip1.SetToolTip(this.btnAnzeigen, "Sternbild an Position anzeigen");
            this.btnAnzeigen.UseVisualStyleBackColor = true;
            this.btnAnzeigen.Click += new System.EventHandler(this.btnAnzeigen_Click);
            // 
            // txtX
            // 
            this.txtX.Location = new System.Drawing.Point(16, 26);
            this.txtX.Name = "txtX";
            this.txtX.Size = new System.Drawing.Size(41, 20);
            this.txtX.TabIndex = 4;
            // 
            // txtY
            // 
            this.txtY.Location = new System.Drawing.Point(59, 26);
            this.txtY.Name = "txtY";
            this.txtY.Size = new System.Drawing.Size(41, 20);
            this.txtY.TabIndex = 5;
            // 
            // btnBewegen
            // 
            this.btnBewegen.Location = new System.Drawing.Point(118, 46);
            this.btnBewegen.Name = "btnBewegen";
            this.btnBewegen.Size = new System.Drawing.Size(75, 23);
            this.btnBewegen.TabIndex = 6;
            this.btnBewegen.Text = "&Bewegen";
            this.toolTip1.SetToolTip(this.btnBewegen, "Sternbild an Position bewegen");
            this.btnBewegen.UseVisualStyleBackColor = true;
            this.btnBewegen.Click += new System.EventHandler(this.btnBewegen_Click);
            // 
            // txtSek
            // 
            this.txtSek.Location = new System.Drawing.Point(16, 48);
            this.txtSek.Name = "txtSek";
            this.txtSek.Size = new System.Drawing.Size(22, 20);
            this.txtSek.TabIndex = 10;
            this.txtSek.Text = "10";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(36, 50);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(24, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "sek";
            // 
            // grdView
            // 
            this.grdView.AllowUserToAddRows = false;
            this.grdView.AllowUserToDeleteRows = false;
            this.grdView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Sternbild,
            this.X,
            this.Y,
            this.zuX,
            this.zuY,
            this.Zeit});
            this.grdView.Location = new System.Drawing.Point(10, 75);
            this.grdView.Name = "grdView";
            this.grdView.ReadOnly = true;
            this.grdView.Size = new System.Drawing.Size(474, 216);
            this.grdView.TabIndex = 12;
            this.grdView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdView_CellContentClick);
            this.grdView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdView_CellContentClick);
            // 
            // Sternbild
            // 
            this.Sternbild.HeaderText = "Sternbild";
            this.Sternbild.Name = "Sternbild";
            this.Sternbild.ReadOnly = true;
            this.Sternbild.Width = 150;
            // 
            // X
            // 
            this.X.HeaderText = "X";
            this.X.Name = "X";
            this.X.ReadOnly = true;
            this.X.Width = 50;
            // 
            // Y
            // 
            this.Y.HeaderText = "Y";
            this.Y.Name = "Y";
            this.Y.ReadOnly = true;
            this.Y.Width = 50;
            // 
            // zuX
            // 
            this.zuX.HeaderText = "zuX";
            this.zuX.Name = "zuX";
            this.zuX.ReadOnly = true;
            this.zuX.ToolTipText = "Zielkoordinate X";
            this.zuX.Width = 50;
            // 
            // zuY
            // 
            this.zuY.HeaderText = "zuY";
            this.zuY.Name = "zuY";
            this.zuY.ReadOnly = true;
            this.zuY.ToolTipText = "Zielkoordinate Y";
            this.zuY.Width = 50;
            // 
            // Zeit
            // 
            this.Zeit.HeaderText = "Zeit/s";
            this.Zeit.Name = "Zeit";
            this.Zeit.ReadOnly = true;
            this.Zeit.ToolTipText = "Zeit in s bis Ankunft";
            this.Zeit.Width = 50;
            // 
            // btnVerstecken
            // 
            this.btnVerstecken.Location = new System.Drawing.Point(204, 26);
            this.btnVerstecken.Name = "btnVerstecken";
            this.btnVerstecken.Size = new System.Drawing.Size(75, 23);
            this.btnVerstecken.TabIndex = 13;
            this.btnVerstecken.Text = "&Verstecken";
            this.toolTip1.SetToolTip(this.btnVerstecken, "Sternbild versteckne");
            this.btnVerstecken.UseVisualStyleBackColor = true;
            this.btnVerstecken.Click += new System.EventHandler(this.btnVerstecken_Click);
            // 
            // btnLaden
            // 
            this.btnLaden.Location = new System.Drawing.Point(285, 26);
            this.btnLaden.Name = "btnLaden";
            this.btnLaden.Size = new System.Drawing.Size(75, 23);
            this.btnLaden.TabIndex = 14;
            this.btnLaden.Text = "La&den";
            this.toolTip1.SetToolTip(this.btnLaden, "Gespeicherte Sternbildpositionen laden");
            this.btnLaden.UseVisualStyleBackColor = true;
            this.btnLaden.Click += new System.EventHandler(this.btnLaden_Click);
            // 
            // chkLinien
            // 
            this.chkLinien.AutoSize = true;
            this.chkLinien.Location = new System.Drawing.Point(367, 26);
            this.chkLinien.Name = "chkLinien";
            this.chkLinien.Size = new System.Drawing.Size(54, 17);
            this.chkLinien.TabIndex = 15;
            this.chkLinien.Text = "&Linien";
            this.toolTip1.SetToolTip(this.chkLinien, "Linien der Sternbilder ein/ausschalten");
            this.chkLinien.UseVisualStyleBackColor = true;
            this.chkLinien.CheckedChanged += new System.EventHandler(this.chkLinien_CheckedChanged);
            // 
            // chkHintergrund
            // 
            this.chkHintergrund.AutoSize = true;
            this.chkHintergrund.Checked = true;
            this.chkHintergrund.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkHintergrund.Location = new System.Drawing.Point(366, 46);
            this.chkHintergrund.Name = "chkHintergrund";
            this.chkHintergrund.Size = new System.Drawing.Size(81, 17);
            this.chkHintergrund.TabIndex = 16;
            this.chkHintergrund.Text = "&Hintergrund";
            this.toolTip1.SetToolTip(this.chkHintergrund, "Hintergrundsterne ein/ausschalten");
            this.chkHintergrund.UseVisualStyleBackColor = true;
            this.chkHintergrund.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // chkWetter
            // 
            this.chkWetter.AutoSize = true;
            this.chkWetter.Checked = true;
            this.chkWetter.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkWetter.Location = new System.Drawing.Point(366, 3);
            this.chkWetter.Name = "chkWetter";
            this.chkWetter.Size = new System.Drawing.Size(58, 17);
            this.chkWetter.TabIndex = 17;
            this.chkWetter.Text = "&Wetter";
            this.toolTip1.SetToolTip(this.chkWetter, "Wolken ein/ausschalten");
            this.chkWetter.UseVisualStyleBackColor = true;
            // 
            // btnWolke
            // 
            this.btnWolke.Location = new System.Drawing.Point(427, 3);
            this.btnWolke.Name = "btnWolke";
            this.btnWolke.Size = new System.Drawing.Size(57, 23);
            this.btnWolke.TabIndex = 18;
            this.btnWolke.Text = "W&olke";
            this.toolTip1.SetToolTip(this.btnWolke, "Neue Wolke erzeugen");
            this.btnWolke.UseVisualStyleBackColor = true;
            this.btnWolke.Click += new System.EventHandler(this.btnWolke_Click);
            // 
            // txtMin
            // 
            this.txtMin.Location = new System.Drawing.Point(59, 48);
            this.txtMin.Name = "txtMin";
            this.txtMin.Size = new System.Drawing.Size(41, 20);
            this.txtMin.TabIndex = 19;
            this.txtMin.Text = "0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(97, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(23, 13);
            this.label1.TabIndex = 20;
            this.label1.Text = "min";
            // 
            // txtWolkenwahrscheinlichkeit
            // 
            this.txtWolkenwahrscheinlichkeit.Location = new System.Drawing.Point(319, 0);
            this.txtWolkenwahrscheinlichkeit.Name = "txtWolkenwahrscheinlichkeit";
            this.txtWolkenwahrscheinlichkeit.Size = new System.Drawing.Size(41, 20);
            this.txtWolkenwahrscheinlichkeit.TabIndex = 21;
            this.txtWolkenwahrscheinlichkeit.Text = "0,001";
            this.toolTip1.SetToolTip(this.txtWolkenwahrscheinlichkeit, "Wahrscheinlichkeit für eine neue Wolke");
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(182, 4);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(131, 13);
            this.label2.TabIndex = 22;
            this.label2.Text = "Wolkenwahrscheinlichkeit";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // cmbSternbild
            // 
            this.cmbSternbild.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSternbild.FormattingEnabled = true;
            this.cmbSternbild.Location = new System.Drawing.Point(16, 1);
            this.cmbSternbild.Name = "cmbSternbild";
            this.cmbSternbild.Size = new System.Drawing.Size(160, 21);
            this.cmbSternbild.Sorted = true;
            this.cmbSternbild.TabIndex = 23;
            // 
            // Sternbilder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(496, 303);
            this.Controls.Add(this.cmbSternbild);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtWolkenwahrscheinlichkeit);
            this.Controls.Add(this.txtMin);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtSek);
            this.Controls.Add(this.btnWolke);
            this.Controls.Add(this.chkWetter);
            this.Controls.Add(this.chkHintergrund);
            this.Controls.Add(this.chkLinien);
            this.Controls.Add(this.btnLaden);
            this.Controls.Add(this.btnVerstecken);
            this.Controls.Add(this.grdView);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnBewegen);
            this.Controls.Add(this.txtY);
            this.Controls.Add(this.txtX);
            this.Controls.Add(this.btnAnzeigen);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Sternbilder";
            this.Text = "Sternbilder";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Sternbilder_KeyPress);
            ((System.ComponentModel.ISupportInitialize)(this.grdView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAnzeigen;
        public System.Windows.Forms.TextBox txtX;
        public System.Windows.Forms.TextBox txtY;
        private System.Windows.Forms.Button btnBewegen;
        private System.Windows.Forms.TextBox txtSek;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.DataGridView grdView;
        private System.Windows.Forms.Button btnVerstecken;
        private System.Windows.Forms.Button btnLaden;
        public System.Windows.Forms.CheckBox chkLinien;
        public System.Windows.Forms.CheckBox chkHintergrund;
        public System.Windows.Forms.CheckBox chkWetter;
        private System.Windows.Forms.Button btnWolke;
        private System.Windows.Forms.TextBox txtMin;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox txtWolkenwahrscheinlichkeit;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Sternbild;
        private System.Windows.Forms.DataGridViewTextBoxColumn X;
        private System.Windows.Forms.DataGridViewTextBoxColumn Y;
        private System.Windows.Forms.DataGridViewTextBoxColumn zuX;
        private System.Windows.Forms.DataGridViewTextBoxColumn zuY;
        private System.Windows.Forms.DataGridViewTextBoxColumn Zeit;
        public System.Windows.Forms.ComboBox cmbSternbild;
    }
}

