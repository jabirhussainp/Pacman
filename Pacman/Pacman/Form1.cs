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
            //Creating the maze in the form
            gamemaze.CreateMaze(this, Level);

            //Set the matrix
            Tuple<int, int> PacmanStartCoordinates = gamemaze.InitialiseMazeGrid(Level);
            
            // Player details
            player.CreatePlayerDetails(this);
            player.CreateLives(this);
            
            //Creating the elements in the form
            formelements.CreateFormElements(this);
            
            //Creating the pacman food
            food.CreateFoodImages(this);
            
            //Creating the ghosts
            ghost.CreateGhostImage(this);
            
            //Creating the pacman in the form
            pacman.CreatePacmanImage(this, PacmanStartCoordinates.Item1, PacmanStartCoordinates.Item2);
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            //Movement of the pacman using keyboard
            base.OnKeyDown(e);
            switch (e.KeyCode)
            {
                case Keys.Up: pacman.nxtDrctn = 1; pacman.MovePacman(1); break;
                case Keys.Right: pacman.nxtDrctn= 2; pacman.MovePacman(2); break;
                case Keys.Down: pacman.nxtDrctn = 3; pacman.MovePacman(3); break;
                case Keys.Left: pacman.nxtDrctn = 4; pacman.MovePacman(4); break;
            }
        }

        private void Form1_Click(object sender, EventArgs e)
        {
            Pacman pcmn = new Pacman();
            
        }
    }
}
