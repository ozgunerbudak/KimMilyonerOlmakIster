using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace KimMilyonerOlmakIster
{
    public partial class Cahil : Form
    {
        public Cahil()
        {
            InitializeComponent();
        }
        public DialogResult cevap;
        private void Cahil_Load(object sender, EventArgs e)
        {
            playSimpleSound();
        }
        private void playSimpleSound()
        {
            SoundPlayer simpleSound = new SoundPlayer(@"C:\Users\HUAWEI\OneDrive\Resimler\cahil.wav");
            simpleSound.Play();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            cevap = DialogResult.OK;
            Close();
        }
    }
}
