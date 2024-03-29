﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pacman
{
    public class Highscore
    {
        public const int InitalScore = 100;
        public Label HighScoreText = new Label();
        public int Score = InitalScore;

        public void CreateHighScore(Form form1)
        {
            // Create Score label
            HighScoreText.ForeColor = System.Drawing.Color.White;
            HighScoreText.Font = new System.Drawing.Font("Folio XBd BT", 14);
            HighScoreText.Top = 23;
            HighScoreText.Left = 170;
            HighScoreText.Height = 20;
            HighScoreText.Width = 100;
            form1.Controls.Add(HighScoreText);
            HighScoreText.BringToFront();
            UpdateHighScore();
        }

        public void UpdateHighScore(int value = InitalScore)
        {
            Score = value;
            HighScoreText.Text = Score.ToString();
        }

    }
}

    
