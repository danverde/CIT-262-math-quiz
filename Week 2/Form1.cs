using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Week_2
{
    public partial class Form1 : Form
    {
        Random randomizer = new Random();
        //addition
        int addend1;
        int addend2;

        //subtraction
        int minend1;
        int minend2;

        //multiplication
        int multend1;
        int multend2;

        //division
        int divend1;
        int divend2;

        int timeLeft;

        public Form1()
        {
            InitializeComponent();
            insertDate();
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            StartTheQuiz();
            startButton.Enabled = false;
        }

        public void StartTheQuiz()
        {
            //random values for addition
            addend1 = randomizer.Next(51);
            addend2 = randomizer.Next(51);

            plusLeftLabel.Text = addend1.ToString();
            plusRightLabel.Text = addend2.ToString();

            sum.Value = 0;

            //random values for subtraction
            minend1 = randomizer.Next(1, 101);
            minend2 = randomizer.Next(1, minend1);

            minusLeftLabel.Text = minend1.ToString();
            minusRightLabel.Text = minend2.ToString();

            difference.Value = 0;

            //values for multiplcation
            multend1 = randomizer.Next(2, 11);
            multend2 = randomizer.Next(2, 11);

            timesLeftLabel.Text = multend1.ToString();
            timesRightLabel.Text = multend2.ToString();

            product.Value = 0;

            //values for division
            divend1 = randomizer.Next(2,11);
            int tempQuotient = randomizer.Next(2, 11);
            divend2 = divend1 * tempQuotient;

            dividedLeftLabel.Text = divend2.ToString();
            dividedRightLabel.Text = divend1.ToString();

            quotient.Value = 0;
            //start the timer
            timeLeft = 30;
            timeLabel.Text = "30 Seconds";
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (checkTheAnswer() == true)
            {
                timer1.Stop();
                MessageBox.Show("You got all the answers right! Congratulations!");
                startButton.Enabled = true;
            }
            else if (timeLeft > 0)
            {
                timeLeft--;
                timeLabel.Text = timeLeft + " Seconds";
            }
            else
            {
                timer1.Stop();
                timeLabel.Text = "Time's Up!";
                MessageBox.Show("You didn't finish in time. Sorry");
                sum.Value = addend1 + addend2;
                difference.Value = minend1 - minend2;
                product.Value = multend1 * multend2;
                quotient.Value = divend2 / divend1;
                startButton.Enabled = true;
            }
        }
        public bool checkTheAnswer()
        {
            if((sum.Value == addend1 + addend2) 
                && (difference.Value == minend1 - minend2) 
                && (product.Value == multend1 * multend2) 
                && (quotient.Value == divend2 / divend1))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void answer_enter(object sender, EventArgs e)
        {
            NumericUpDown answerBox = sender as NumericUpDown;

            if(answerBox != null)
            {
                int lengthOfAnswer = answerBox.Value.ToString().Length;
                answerBox.Select(0, lengthOfAnswer);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void insertDate()
        {
            var currDate =  DateTime.Now;
            /*int year = currDate.Year;
            int month = currDate.Month;
            int day = currDate.Day;*/
            

            currentDate.Text = currDate.ToString("dd/MM/yyyy");
        }
    }
}
