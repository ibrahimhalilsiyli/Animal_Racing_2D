using System;
using System.Windows.Forms;


namespace Racing_game
{

    public partial class Form1 : Form
    {

        int LeftLion, LeftBird, LeftHorse;
        Random rnd = new Random();
        private string predictedWinner;

        public Form1()
        {
            InitializeComponent();
        }

        // pictureBox1_Click event handler
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            // Buraya pictureBox1 tıklandığında yapılacak işlemler eklenebilir.
        }

        // label1_Click event handler
        private void label1_Click(object sender, EventArgs e)
        {
            // Buraya label1 tıklandığında yapılacak işlemler eklenebilir.
        }

        // label2_Click event handler
        private void label2_Click(object sender, EventArgs e)
        {
            // Buraya label2 tıklandığında yapılacak işlemler eklenebilir.
        }

        // label5_Click event handler
        private void label5_Click(object sender, EventArgs e)
        {
            // Buraya label5 tıklandığında yapılacak işlemler eklenebilir.
        }

        // panel1_Paint event handler
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            // Buraya panel1 boyandığında yapılacak işlemler eklenebilir.
        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            int widthlion = pictureBox1.Width;
            int widthbird = pictureBox2.Width;
            int widthhorse = pictureBox3.Width;
            

            // Rastgele hareket
            pictureBox1.Left += rnd.Next(1, 16);
            pictureBox2.Left += rnd.Next(1, 16);
            pictureBox3.Left += rnd.Next(1, 16);


            // Kim önde?
            if (pictureBox1.Left > pictureBox2.Left && pictureBox1.Left > pictureBox3.Left)
            {
                label6.Text = "Lion is leading";
            }
            if (pictureBox2.Left > pictureBox1.Left && pictureBox2.Left > pictureBox3.Left)
            {
                label6.Text = "Bird is leading";
            }
            if (pictureBox3.Left > pictureBox1.Left && pictureBox3.Left > pictureBox2.Left)
            {
                label6.Text = "Horse is leading";
            }

            // Kazananı belirle
            if (pictureBox1.Left > 835)
            {
                timer1.Stop();
                ShowWinner("Lion");

            }
            if (pictureBox2.Left > 852)
            {
                timer1.Stop();
                ShowWinner("Bird");
            }
            if (pictureBox3.Left > 830)
            {
                timer1.Stop();
                ShowWinner("Horse");

            }
            
        }

        private void ShowWinner(string winner)
        {
            string message = $"{winner} is the winner!";
            if (winner == predictedWinner)
            {
                message += "\nCongratulations! Your prediction was correct!";
            }
            else
            {
                message += $"\nSorry, you predicted {predictedWinner}.";
            }
            MessageBox.Show(message, "Race Over");

        }

        private void button1_Click(object sender, EventArgs e)
        {
            StartRace();
        }

        private void StartRace()
        {
            // Tahmini al
            predictedWinner = comboBox1.SelectedItem?.ToString();

            // Pozisyonları sıfırla
            pictureBox1.Left = LeftLion;
            pictureBox2.Left = LeftBird;
            pictureBox3.Left = LeftHorse;
            
            // Zamanlayıcıyı başlat
            timer1.Start();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            RestartRace();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {

        }

        private void RestartRace()
        {
            // Pozisyonları sıfırla
            pictureBox1.Left = LeftLion;
            pictureBox2.Left = LeftBird;
            pictureBox3.Left = LeftHorse;
            

            // Zamanlayıcıyı durdur
            timer1.Stop();

            // Tahmin ComboBox'ını sıfırla
            comboBox1.SelectedIndex = -1;

            // Lider etiketini sıfırla
            label6.Text = "No leader yet";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Başlangıç pozisyonlarını kaydet
            LeftLion = pictureBox1.Left;
            LeftBird = pictureBox2.Left;
            LeftHorse = pictureBox3.Left;

            // ComboBox'a seçenekleri ekle
            comboBox1.Items.AddRange(new string[] { "Lion", "Bird", "Horse" });
        }
    }
}