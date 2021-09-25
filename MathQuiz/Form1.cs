using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MathQuiz
{
    public partial class Form1 : Form
    {
        Random randomizer = new Random();

        int addend1; int addend2;
        int subtracted1; int subtracted2;
        int multiplied1; int multiplied2;
        int temporaryQuotient; int divisor; int dividend;

        int timeLeft;


        public void StartTheQuiz()
        {
            
            addend1 = randomizer.Next(51);  
            addend2 = randomizer.Next(51);
            subtracted1 = randomizer.Next(2, 101);
            subtracted2 = randomizer.Next(1, subtracted1);
            multiplied1 = randomizer.Next(2, 11);
            multiplied2 = randomizer.Next(2, 11);

            temporaryQuotient = randomizer.Next(2, 11);
            divisor = randomizer.Next(2, 11);
            dividend = divisor * temporaryQuotient;


            plusLeftLabel.Text = addend1.ToString();
            plusRightLabel.Text = addend2.ToString();
            minusLeftLabel.Text = subtracted1.ToString();
            minusRightLabel.Text = subtracted2.ToString();
            timesLeftLabel.Text = multiplied1.ToString();
            timesRightLabel.Text = multiplied2.ToString();
            dividedLeftLabel.Text = dividend.ToString();
            dividedRightLabel.Text = divisor.ToString();



            sum.Value = 0;
            difference.Value = 0;
            product.Value = 0;
            quotient.Value = 0;

            timeLeft = 30;
            timeLabel.Text = "30 seconds";
            timer1.Start();
        }

        public void DisplayDate()
        {
            currentDate.Text = DateTime.Now.ToString("dd MMMM yyyy");
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            StartTheQuiz();
            startButton.Enabled = false;
        }

        private bool CheckTheAnswer() {

            if ((addend1 + addend2 == sum.Value) && 
                (subtracted1 - subtracted2 == difference.Value) &&
                (multiplied1 * multiplied2 == product.Value) &&
                (dividend / divisor == quotient.Value))
                    return true;
                else
                    return false;
         }

        private void timer1_Tick_1(object sender, EventArgs e)
        {
            if (CheckTheAnswer() && timeLabel.Text != "")
            {
                timer1.Stop();
                MessageBox.Show("You got all the answers right!", "Congratulations!");
                startButton.Enabled = true;
            }
            else if (timeLeft > 0)
            {
                timeLeft--;
                timeLabel.Text = timeLeft + " seconds";
                if (timeLeft <= 3)
                {
                    timeLabel.BackColor = Color.Red;
                }
            }
            else
            {
                timer1.Stop();
                timeLabel.Text = "Time's up!";
                MessageBox.Show("You didn't finish in time.", "Sorry!");
                sum.Value = addend1 + addend2;
                difference.Value = subtracted1 - subtracted2;
                product.Value = multiplied1 * multiplied2;
                startButton.Enabled = true;
            }
        }

        private void answer_Enter(object sender, EventArgs e)
        {
            NumericUpDown answerBox = sender as NumericUpDown;

            if (answerBox != null)
            {
                int lengthOfAnswer = answerBox.Value.ToString().Length;
                answerBox.Select(0, lengthOfAnswer);
            }
        }


        public Form1()
        {
            InitializeComponent();
            DisplayDate();
        }
    }
}
