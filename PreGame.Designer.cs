using System.ComponentModel;

namespace WINFSWEEPER;

partial class PreGame
{
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }

        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PreGame));
        pictureBox1 = new System.Windows.Forms.PictureBox();
        label1 = new System.Windows.Forms.Label();
        nud_Width = new System.Windows.Forms.NumericUpDown();
        label2 = new System.Windows.Forms.Label();
        label3 = new System.Windows.Forms.Label();
        nud_Height = new System.Windows.Forms.NumericUpDown();
        label4 = new System.Windows.Forms.Label();
        nud_Bombs = new System.Windows.Forms.NumericUpDown();
        btn_Go = new System.Windows.Forms.Button();
        lb_Error = new System.Windows.Forms.Label();
        ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
        ((System.ComponentModel.ISupportInitialize)nud_Width).BeginInit();
        ((System.ComponentModel.ISupportInitialize)nud_Height).BeginInit();
        ((System.ComponentModel.ISupportInitialize)nud_Bombs).BeginInit();
        SuspendLayout();
        // 
        // pictureBox1
        // 
        pictureBox1.Image = ((System.Drawing.Image)resources.GetObject("pictureBox1.Image"));
        pictureBox1.Location = new System.Drawing.Point(12, 12);
        pictureBox1.Name = "pictureBox1";
        pictureBox1.Size = new System.Drawing.Size(399, 176);
        pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
        pictureBox1.TabIndex = 0;
        pictureBox1.TabStop = false;
        // 
        // label1
        // 
        label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right));
        label1.Font = new System.Drawing.Font("Helvetica CE", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)238));
        label1.Location = new System.Drawing.Point(85, 191);
        label1.Name = "label1";
        label1.Size = new System.Drawing.Size(237, 37);
        label1.TabIndex = 1;
        label1.Text = "Game Settings";
        label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // nud_Width
        // 
        nud_Width.Font = new System.Drawing.Font("Helvetica CE", 11.999998F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)0));
        nud_Width.Location = new System.Drawing.Point(15, 273);
        nud_Width.Maximum = new decimal(new int[] { 40, 0, 0, 0 });
        nud_Width.Minimum = new decimal(new int[] { 5, 0, 0, 0 });
        nud_Width.Name = "nud_Width";
        nud_Width.Size = new System.Drawing.Size(188, 26);
        nud_Width.TabIndex = 2;
        nud_Width.Value = new decimal(new int[] { 10, 0, 0, 0 });
        // 
        // label2
        // 
        label2.Font = new System.Drawing.Font("Helvetica CE", 11.249998F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)0));
        label2.Location = new System.Drawing.Point(13, 252);
        label2.Name = "label2";
        label2.Size = new System.Drawing.Size(189, 21);
        label2.TabIndex = 3;
        label2.Text = "Width";
        label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // label3
        // 
        label3.Font = new System.Drawing.Font("Helvetica CE", 11.249998F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)0));
        label3.Location = new System.Drawing.Point(222, 252);
        label3.Name = "label3";
        label3.Size = new System.Drawing.Size(189, 21);
        label3.TabIndex = 5;
        label3.Text = "Height";
        label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // nud_Height
        // 
        nud_Height.Font = new System.Drawing.Font("Helvetica CE", 11.999998F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)0));
        nud_Height.Location = new System.Drawing.Point(224, 273);
        nud_Height.Maximum = new decimal(new int[] { 40, 0, 0, 0 });
        nud_Height.Minimum = new decimal(new int[] { 5, 0, 0, 0 });
        nud_Height.Name = "nud_Height";
        nud_Height.Size = new System.Drawing.Size(188, 26);
        nud_Height.TabIndex = 4;
        nud_Height.Value = new decimal(new int[] { 10, 0, 0, 0 });
        // 
        // label4
        // 
        label4.Font = new System.Drawing.Font("Helvetica CE", 11.249998F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)0));
        label4.Location = new System.Drawing.Point(122, 329);
        label4.Name = "label4";
        label4.Size = new System.Drawing.Size(189, 21);
        label4.TabIndex = 7;
        label4.Text = "Bomb Percentage (%)";
        label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // nud_Bombs
        // 
        nud_Bombs.Font = new System.Drawing.Font("Helvetica CE", 11.999998F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)0));
        nud_Bombs.Location = new System.Drawing.Point(124, 350);
        nud_Bombs.Maximum = new decimal(new int[] { 90, 0, 0, 0 });
        nud_Bombs.Minimum = new decimal(new int[] { 10, 0, 0, 0 });
        nud_Bombs.Name = "nud_Bombs";
        nud_Bombs.Size = new System.Drawing.Size(188, 26);
        nud_Bombs.TabIndex = 6;
        nud_Bombs.Value = new decimal(new int[] { 35, 0, 0, 0 });
        // 
        // btn_Go
        // 
        btn_Go.Location = new System.Drawing.Point(273, 529);
        btn_Go.Name = "btn_Go";
        btn_Go.Size = new System.Drawing.Size(138, 31);
        btn_Go.TabIndex = 8;
        btn_Go.Text = "Go!";
        btn_Go.UseVisualStyleBackColor = true;
        btn_Go.Click += new System.EventHandler(this.btn_Go_Click);
        // 
        // lb_Error
        // 
        lb_Error.Font = new System.Drawing.Font("Helvetica CE", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)0));
        lb_Error.ForeColor = System.Drawing.Color.Red;
        lb_Error.Location = new System.Drawing.Point(15, 445);
        lb_Error.Name = "lb_Error";
        lb_Error.Size = new System.Drawing.Size(396, 24);
        lb_Error.TabIndex = 9;
        lb_Error.Text = "DEBUG: ERROR MESSAGES HERE!";
        lb_Error.TextAlign = System.Drawing.ContentAlignment.TopCenter;
        // 
        // PreGame
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        ClientSize = new System.Drawing.Size(423, 572);
        Controls.Add(lb_Error);
        Controls.Add(btn_Go);
        Controls.Add(label4);
        Controls.Add(nud_Bombs);
        Controls.Add(label3);
        Controls.Add(nud_Height);
        Controls.Add(label2);
        Controls.Add(nud_Width);
        Controls.Add(label1);
        Controls.Add(pictureBox1);
        Text = "WinFSweeper | Game Settings";
        ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
        ((System.ComponentModel.ISupportInitialize)nud_Width).EndInit();
        ((System.ComponentModel.ISupportInitialize)nud_Height).EndInit();
        ((System.ComponentModel.ISupportInitialize)nud_Bombs).EndInit();
        ResumeLayout(false);
    }

    private System.Windows.Forms.Button btn_Go;
    private System.Windows.Forms.Label lb_Error;

    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.NumericUpDown nud_Bombs;

    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.NumericUpDown nud_Height;

    private System.Windows.Forms.NumericUpDown nud_Width;
    private System.Windows.Forms.Label label2;

    private System.Windows.Forms.Label label1;

    private System.Windows.Forms.PictureBox pictureBox1;

    #endregion
}