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
using System.Collections;


namespace KimMilyonerOlmakIster
{
    public partial class Sorular : Form
    {
        private const string CONNECTION_STRING = @"Data Source =LAPTOP-J3IMUHDN\ÖZGÜN;Initial Catalog = QuizDB; Integrated Security = True";

        public Sorular()
        {
            InitializeComponent();
            LoadSorular();
        }

        readonly Dictionary<int, bool> cevaplananSorular = new Dictionary<int, bool>();
        readonly List<Soru> sorular = new List<Soru>();
        Soru secilenSoru = null;





        //SqlConnection voconn = new SqlConnection(@"Data Source=LAPTOP-J3IMUHDN\ÖZGÜN;Initial Catalog=quizdb;Integrated Security=True");
        //SqlCommand komut;
        //SqlDataReader dr;

        public void RastgeleSoruGetir()
        {
            Random random = new Random();
            var qId = random.Next(1, sorular.Max(m => m.QId));

            if (cevaplananSorular.Any(a => a.Key == qId))
                RastgeleSoruGetir();

            var sonuc = SoruGetir(qId);
            if (!sonuc)
            {
                RastgeleSoruGetir();
            }

            EkranaSoruYaz();
        }

        private bool SoruGetir(int qId)
        {
            var soru = sorular.FirstOrDefault(r => r.QId == qId);
            if (soru is null)
                return false;

            secilenSoru = soru;
            return true;
        }

        public void EkranaSoruYaz()
        {
            if (cevaplananSorular.Count == sorular.Count)
            {
                MessageBox.Show("sorular bitti");
                Application.Exit();
            }
            else
            {
                soru.Text = secilenSoru.SoruAdi;

                button1.Text = secilenSoru.Cevaplar[0].CevapText;
                button2.Text = secilenSoru.Cevaplar[1].CevapText;
                button3.Text = secilenSoru.Cevaplar[2].CevapText;
                button4.Text = secilenSoru.Cevaplar[3].CevapText;
            }
        }




        public int DateTimedeğeri { get; private set; }
        public int sayac = 60;
        public void Sorular_Load(object sender, EventArgs e)
        {
            RastgeleSoruGetir();
        
            //count();
            //LoadSoruQIds();
            //Baglanti();
            timer1.Interval = 1000;
            timer1.Start();
        }

        private void LoadSorular()
        {
            using (SqlConnection connect = new SqlConnection(CONNECTION_STRING))
            using (var command = new SqlCommand("Select * from Questions", connect))
            {
                connect.Open();
                SqlDataReader dr = command.ExecuteReader();

                while (dr.Read())
                {
                    Soru soru = new Soru();
                    soru.QId = int.Parse(dr["QId"].ToString());
                    soru.SoruAdi = dr["QText"].ToString();

                    soru.Cevaplar = CevaplarGetir(soru.QId);
                    sorular.Add(soru);
                }

            }

        }

        private List<Cevap> CevaplarGetir(int qId)
        {
            var cevaplar = new List<Cevap>();
            using (SqlConnection connect = new SqlConnection(CONNECTION_STRING))
            using (var command = new SqlCommand("Select a.Atext, a.AID, ra.AID AS 'DOGRUCEVAP' from Answers a LEFT JOIN RightAnswers ra on a.AID =ra.AID where a.QID = @QID", connect))
            {
                command.Parameters.AddWithValue("@QID", qId);
                connect.Open();
                SqlDataReader dr = command.ExecuteReader();
                while (dr.Read())
                {
                    Cevap cevap = new Cevap
                    {
                        CevapText = dr["AText"].ToString(),
                        Id = int.Parse(dr["AId"].ToString())
                    };

                    int? dogruCevapId = null;
                    if (!dr.IsDBNull(2))
                    {
                        dogruCevapId = int.Parse(dr["DOGRUCEVAP"].ToString());

                        if (dogruCevapId.HasValue)
                            cevap.DogruCevapMi = true;
                    }



                    cevaplar.Add(cevap);

                }

            }
            return cevaplar;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            sayac--;
            Kronometre.Text = sayac.ToString();

            if (sayac == 0)
            {
                timer1.Stop();
                MessageBox.Show("süre doldu");
                sayac = 60;
                //Baglanti();
                EkranaSoruYaz();
                Kronometre.Text = sayac.ToString();
                timer1.Start();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var cevap = button1.Text;

            var secilenCevap = secilenSoru.Cevaplar.FirstOrDefault(r => r.CevapText == cevap);
            if (secilenCevap.DogruCevapMi)
            {
                cevaplananSorular.Add(secilenCevap.Id, true);
                MessageBox.Show("Elbet Cahilliğin Tescillenecek");

            }
            else
            {
                cevaplananSorular.Add(secilenCevap.Id, false);
                button1.BackColor = Color.Red;
                Cahil cahil = new Cahil();
                cahil.Show();
            }

            Cevap dogruCevap = secilenSoru.Cevaplar.FirstOrDefault(r => r.DogruCevapMi);
            DogruCevapIsaretle(nameof(button1), dogruCevap.CevapText);
            
            sayac = 60;

            RastgeleSoruGetir();
            Kronometre.Text = sayac.ToString();
            timer1.Start();
            ClearButton();
        }

        private void button3_Click(object sender, EventArgs e)
        {

            var cevap = button3.Text;

            var secilenCevap = secilenSoru.Cevaplar.FirstOrDefault(r => r.CevapText == cevap);
            if (secilenCevap.DogruCevapMi)
            {
                cevaplananSorular.Add(secilenCevap.Id, true);
                MessageBox.Show("Elbet Cahilliğin Tescillenecek");

            }
            else
            {
                cevaplananSorular.Add(secilenCevap.Id, false);
                button3.BackColor = Color.Red;
                Cahil cahil = new Cahil();
                cahil.Show();
            }


            Cevap dogruCevap = secilenSoru.Cevaplar.FirstOrDefault(r => r.DogruCevapMi);
            DogruCevapIsaretle(nameof(button3), dogruCevap.CevapText);

       
            sayac = 60;
            RastgeleSoruGetir();
            Kronometre.Text = sayac.ToString();
            timer1.Start();

            ClearButton();
        }

        private void ClearButton()
        {
            button1.BackColor = Color.White;
            button2.BackColor = Color.White;
            button3.BackColor = Color.White;
            button4.BackColor = Color.White;
        }

        private void DogruCevapIsaretle(string buttonName, string dogruCevapText)
        {
            if (button1.Text == dogruCevapText)
            {
                button1.BackColor = Color.Green;
            }
            else if (button2.Text == dogruCevapText)
            {
                button2.BackColor = Color.Green;
            }
            else if (button3.Text == dogruCevapText)
            {
                button3.BackColor = Color.Green;
            }
            else if (button4.Text == dogruCevapText)
            {
                button4.BackColor = Color.Green;
            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            var cevap = button2.Text;

            var secilenCevap = secilenSoru.Cevaplar.FirstOrDefault(r => r.CevapText == cevap);
            if (secilenCevap.DogruCevapMi)
            {
                cevaplananSorular.Add(secilenCevap.Id, true);

                MessageBox.Show("Elbet Cahilliğin Tescillenecek");

            }
            else
            {
                cevaplananSorular.Add(secilenCevap.Id, false);
                button2.BackColor = Color.Red;
                Cahil cahil = new Cahil();
                cahil.Show();
            }


            Cevap dogruCevap = secilenSoru.Cevaplar.FirstOrDefault(r => r.DogruCevapMi);
            DogruCevapIsaretle(nameof(button2), dogruCevap.CevapText);

    
            sayac = 60;

            RastgeleSoruGetir();
            Kronometre.Text = sayac.ToString();
            timer1.Start();
            ClearButton();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var cevap = button4.Text;

            var secilenCevap = secilenSoru.Cevaplar.FirstOrDefault(r => r.CevapText == cevap);
            if (secilenCevap.DogruCevapMi)
            {
                cevaplananSorular.Add(secilenCevap.Id, true);
                MessageBox.Show("Elbet Cahilliğin Tescillenecek");

            }
            else
            {
                cevaplananSorular.Add(secilenCevap.Id, false);
                button4.BackColor = Color.Red;
                Cahil cahil = new Cahil();
                cahil.Show();
            }


            Cevap dogruCevap = secilenSoru.Cevaplar.FirstOrDefault(r => r.DogruCevapMi);
            DogruCevapIsaretle(nameof(button4), dogruCevap.CevapText);

  
            sayac = 60;

            RastgeleSoruGetir();
            Kronometre.Text = sayac.ToString();
            timer1.Start();

            ClearButton();
        }
    }

    public class Soru
    {
        public int QId { get; set; }
        public string SoruAdi { get; set; }

        public List<Cevap> Cevaplar { get; set; }
        public Soru()
        {
            Cevaplar = new List<Cevap>();
        }
    }

    public class Cevap
    {
        public int Id { get; set; }
        public string CevapText { get; set; }
        public bool DogruCevapMi { get; set; }
    }

}
