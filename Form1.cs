using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KimMilyonerOlmakIster
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        public void tboxAd_TextChanged(object sender, EventArgs e)
        {

        }

        private void Login_Click(object sender, EventArgs e)
        {
            this.Hide();
            string a = tboxAd.Text;
            a = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(a);
            MessageBox.Show("Merhaba " + a +" hazır mısın?");
            Sorular sorular = new Sorular();            
            sorular.Show();
        }
    }
}
