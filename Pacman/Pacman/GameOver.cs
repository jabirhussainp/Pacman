using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pacman
{
    public partial class GameOver : Form
    {
        public GameOver()
        {
            InitializeComponent();
        }

        private void GameOver_Load(object sender, EventArgs e)
        {

        }

        private void GameOver_KeyDown(object sender, KeyEventArgs e)
        {
            Form1 frm = new Form1();

            if (e.KeyCode == Keys.F1)
            {
                this.Hide();
                frm.Show();
            }

            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Start strt = new Start();
            strt.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
