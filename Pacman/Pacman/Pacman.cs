using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pacman
{
    public class Pacman
    {
        public int xCrdnte = 0;
        public int yCrdnte = 0;
        public int xStart = 0;
        public int yStart = 0;
        public int crntDrctn = 0;
        public int nxtDrctn = 0;
        public PictureBox PacmanImage = new PictureBox();
        private ImageList PacmanImages = new ImageList();
        private Timer timer11 = new Timer();

        private int imageOn = 0;

        public Pacman()
        {
            timer11.Interval = 100;
            timer11.Enabled = true;
            timer11.Tick += new EventHandler(timer11_Tick);

            PacmanImages.Images.Add(Properties.Resources.Pcmn_1_0);
            PacmanImages.Images.Add(Properties.Resources.Pcmn_1_1);
            PacmanImages.Images.Add(Properties.Resources.Pcmn_1_2);
            PacmanImages.Images.Add(Properties.Resources.Pcmn_1_3);

            PacmanImages.Images.Add(Properties.Resources.Pcmn_2_0);
            PacmanImages.Images.Add(Properties.Resources.Pcmn_2_1);
            PacmanImages.Images.Add(Properties.Resources.Pcmn_2_2);
            PacmanImages.Images.Add(Properties.Resources.Pcmn_2_3);

            PacmanImages.Images.Add(Properties.Resources.Pcmn_3_0);
            PacmanImages.Images.Add(Properties.Resources.Pcmn_3_1);
            PacmanImages.Images.Add(Properties.Resources.Pcmn_3_2);
            PacmanImages.Images.Add(Properties.Resources.Pcmn_3_3);

            PacmanImages.Images.Add(Properties.Resources.Pcmn_4_0);
            PacmanImages.Images.Add(Properties.Resources.Pcmn_4_1);
            PacmanImages.Images.Add(Properties.Resources.Pcmn_4_2);
            PacmanImages.Images.Add(Properties.Resources.Pcmn_4_3);

            PacmanImages.ImageSize = new Size(27, 28);
        }

        public void CreatePacmanImage(Form form1, int StartXCrdnt, int StartYcrdnt)
        {
            xStart = StartXCrdnt;
            yStart = StartYcrdnt;
            PacmanImage.Name = "PacmanImage";
            PacmanImage.SizeMode = PictureBoxSizeMode.AutoSize;
            SetPacman();
            form1.Controls.Add(PacmanImage);
            PacmanImage.BringToFront();
        }

        public void MovePacman(int direction)
        {
            
            bool canMove = check_direction(nxtDrctn);
            if (!canMove)
            {
                canMove = check_direction(crntDrctn); direction = crntDrctn;
            }
            else
            {
                direction = nxtDrctn;
            }
            if (canMove)
            {
                crntDrctn = direction;
            }

            if (canMove)
            {
                switch (direction)
                {
                    case 1: PacmanImage.Top -= 16; yCrdnte--; break;
                    case 2: PacmanImage.Left += 16; xCrdnte++; break;
                    case 3: PacmanImage.Top += 16; yCrdnte++; break;
                    case 4: PacmanImage.Left -= 16; xCrdnte--; break;
                }
                crntDrctn = direction;
                UpdatePacmanImage();
                CheckPacmanPosition();
                Form1.ghost.CheckForPacman();
            }
        }

        private void CheckPacmanPosition()
        {
            switch (Form1.gamemaze.Grid[yCrdnte, xCrdnte])
            {
                case 1: Form1.food.EatFood(yCrdnte, xCrdnte); break;
                case 2: Form1.food.EatSuperFood(yCrdnte, xCrdnte); break;
            }
        }

        private void UpdatePacmanImage()
        {
            PacmanImage.Image = PacmanImages.Images[((crntDrctn - 1) * 4) + imageOn];
            imageOn++;
            if(imageOn > 3) { imageOn = 0; }

        }

        private bool check_direction(int direction)
        {
            switch (direction)
            {
                case 1: return direction_ok(xCrdnte, yCrdnte - 1);
                case 2: return direction_ok(xCrdnte +1, yCrdnte);
                case 3: return direction_ok(xCrdnte, yCrdnte + 1);
                case 4: return direction_ok(xCrdnte - 1, yCrdnte);
                default: return false;
            }
        }

        private bool direction_ok(int x, int y)
        {
            if (x<0) { xCrdnte = 27; PacmanImage.Left = 429; return true; }
            if(x > 27) { xCrdnte = 0; PacmanImage.Left = -5; return true; }
            if(Form1.gamemaze.Grid[y, x] <4) { return true; } else { return false; }
        }
        
        private void timer11_Tick(object sender, EventArgs e)
        {
            MovePacman(crntDrctn);
            System.IO.Stream str = Properties.Resources.audio1;
            SoundPlayer snd = new SoundPlayer(str);
            snd.Play();

        }

        public void SetPacman()
        {
            PacmanImage.Image = Properties.Resources.Pcmn_2_1;
            crntDrctn = 0;
            nxtDrctn = 0;
            xCrdnte = xStart;
            yCrdnte = yStart;
            PacmanImage.Location = new Point(xStart * 16 - 3, yStart * 16 + 43);
        }
    }
}
