using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Flappy_Bird_Windows_Form
{
    public partial class Form1 : Form
    {

        int pipeSpeed = 5;
        int gravity = 10;
        int score = 0;
        

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void gameTimerEvent(object sender, EventArgs e)
        {
            flappyBird.Top += gravity;
            pipebottom1.Left -= pipeSpeed;
            pipeTop.Left-= pipeSpeed;
            scoreText.Text = "Score:" + score;

            if (pipebottom1.Left < -150)
            {
                pipebottom1.Left = 700;
                score++;
            }
            if (pipeTop.Left < -180)
            {

                pipeTop.Left = 850;
                score++;
            }
            if(flappyBird.Bounds.IntersectsWith(pipebottom1.Bounds) ||
                flappyBird.Bounds.IntersectsWith(pipeTop.Bounds)||
                flappyBird.Bounds.IntersectsWith(ground1.Bounds)||
                flappyBird.Top < -25)
            {
                EndGame();
                
               
            }
            if (score>5)
            {
                pipeSpeed = 10;
            }
          


        }

        private void gamekeyisdawn(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                gravity = -10;
            }
        }

        private void gamekeyisup(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                gravity = 10;
            }

        }
        private void EndGame()
        {
            gameTimer.Stop();
            scoreText.Text += " " +
                "" +
                "" +
                "" +
                "" +
                "Game over!!!";
            
           
        }
        private void Return()
        {
            gameTimer.Start();
            
        }

        private void ground1_Click(object sender, EventArgs e)
        {


        }

        private void scoreText_Click(object sender, EventArgs e)
        {

        }

        private void flappyBird_Click(object sender, EventArgs e)
        {

        }
    }
}
