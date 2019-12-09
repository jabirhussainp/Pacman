using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pacman
{
    public class FormElements
    {
        public Label PlayerOneScoreText = new Label();
        public Label HighScoreText = new Label();

        public void CreateFormElements(Form form1)
        {
            PlayerOneScoreText.ForeColor = System.Drawing.Color.White;
            PlayerOneScoreText.Font = new System.Drawing.Font("Folio XBd BT", 14);
            PlayerOneScoreText.Top = 5;
            PlayerOneScoreText.Left = 20;
            PlayerOneScoreText.Height = 20;
            PlayerOneScoreText.Width = 100;
            PlayerOneScoreText.Text = "1UP";
            form1.Controls.Add(PlayerOneScoreText);

            HighScoreText.ForeColor = System.Drawing.Color.White;
            HighScoreText.Font = new System.Drawing.Font("Folio XBd BT", 14);
            HighScoreText.Top = 5;
            HighScoreText.Left = 155;
            HighScoreText.Height = 20;
            HighScoreText.Width = 200;
            HighScoreText.Text = "HIGH SCORE";
            form1.Controls.Add(HighScoreText);
        }
    }
}

  