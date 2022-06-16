
namespace KimMilyonerOlmakIster
{
    partial class Form1
    {
        /// <summary>
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer üretilen kod

        /// <summary>
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            this.tboxAd = new System.Windows.Forms.TextBox();
            this.Login = new System.Windows.Forms.Button();
            this.Exit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tboxAd
            // 
            this.tboxAd.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.tboxAd.Location = new System.Drawing.Point(92, 68);
            this.tboxAd.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tboxAd.Name = "tboxAd";
            this.tboxAd.Size = new System.Drawing.Size(132, 22);
            this.tboxAd.TabIndex = 1;
            this.tboxAd.Text = "Lütfen Adınızı Girin";
            this.tboxAd.TextChanged += new System.EventHandler(this.tboxAd_TextChanged);
            // 
            // Login
            // 
            this.Login.Location = new System.Drawing.Point(16, 159);
            this.Login.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Login.Name = "Login";
            this.Login.Size = new System.Drawing.Size(133, 47);
            this.Login.TabIndex = 2;
            this.Login.Text = "Giriş";
            this.Login.UseVisualStyleBackColor = true;
            this.Login.Click += new System.EventHandler(this.Login_Click);
            // 
            // Exit
            // 
            this.Exit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Exit.Location = new System.Drawing.Point(185, 159);
            this.Exit.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Exit.Name = "Exit";
            this.Exit.Size = new System.Drawing.Size(133, 47);
            this.Exit.TabIndex = 3;
            this.Exit.Text = "Çıkış";
            this.Exit.UseVisualStyleBackColor = true;
            this.Exit.Click += new System.EventHandler(this.Exit_Click);
            // 
            // Form1
            // 
            this.AcceptButton = this.Login;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.Exit;
            this.ClientSize = new System.Drawing.Size(329, 230);
            this.Controls.Add(this.Exit);
            this.Controls.Add(this.Login);
            this.Controls.Add(this.tboxAd);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Form1";
            this.Text = "Kim Cahil Olmak İster";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox tboxAd;
        private System.Windows.Forms.Button Login;
        private System.Windows.Forms.Button Exit;
    }
}

