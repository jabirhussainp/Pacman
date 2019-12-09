using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;

namespace Pacman
{
    public class Audio
    {
        private const int players = 20;
        private SoundPlayer[] player = new SoundPlayer[players];


        public Audio()
        {
            for (int x = 0; x < players; x++)
            {
                player[x] = new SoundPlayer();
                player[x].Stream = Properties.Resources.audio1;
            }
        }

        public void Play(int num)
        {
            player[num].Play();
        }
    }
}
