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
    public partial class Form1 : Form
    {

        public static GameMaze gamemaze = new GameMaze();
        public static Food food = new Food();
        public static Pacman pacman = new Pacman();
        public static Ghost ghost = new Ghost();
        public static Player player = new Player();
        public static Highscore highscore = new Highscore();
        private static FormElements formelements = new FormElements();

        public Form1()
        {
            InitializeComponent();
            SetupGame(1);
        }

        public void SetupGame(int Level)
        {
            gamemaze.CreateMaze(this, Level);

            Tuple<int, int> PacmanStartCoordinates = gamemaze.InitialiseMazeGrid(Level);

            player.CreatePlayerDetails(this);
            player.CreateLives(this);

            formelements.CreateFormElements(this);

            food.CreateFoodImages(this);

            ghost.CreateGhostImage(this);

            pacman.CreatePacmanImage(this, PacmanStartCoordinates.Item1, PacmanStartCoordinates.Item2);
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);
            switch (e.KeyCode)
            {
                case Keys.Up: pacman.nxtDrctn = 1; pacman.MovePacman(1); break;
                case Keys.Right: pacman.nxtDrctn= 2; pacman.MovePacman(2); break;
                case Keys.Down: pacman.nxtDrctn = 3; pacman.MovePacman(3); break;
                case Keys.Left: pacman.nxtDrctn = 4; pacman.MovePacman(4); break;
            }
        }


    }
}
