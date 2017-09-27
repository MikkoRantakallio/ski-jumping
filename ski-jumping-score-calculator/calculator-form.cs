using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ski_jumping_score_calculator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private decimal CalcGatePoints()
        {
            decimal pointsPerMeter = numericUpDownPointsPerM.Value;
            decimal gateDiff = numericUpDownStartGate.Value;
            decimal lengthDiff = gateDiff * 5;
            decimal gatePoints = lengthDiff * pointsPerMeter;

            return gatePoints;
        }

        private decimal CalcWindPoints()
        {
            int kPoint = (int)numericUpDownKPoint.Value;
            decimal pointsPerMeter = numericUpDownPointsPerM.Value;
            decimal windAverage = numericUpDownWindAverage.Value;
            decimal correctionMeters = windAverage * (kPoint - 36) / 20;
            decimal windPoints = pointsPerMeter * correctionMeters;

            return windPoints;
        }

        private decimal CalcJudgePoints()
        {
            decimal[] judgePoints = new decimal[5];

            judgePoints[0] = numericUpDownJudge1.Value;
            judgePoints[1] = numericUpDownJudge2.Value;
            judgePoints[2] = numericUpDownJudge3.Value;
            judgePoints[3] = numericUpDownJudge4.Value;
            judgePoints[4] = numericUpDownJudge5.Value;

            Array.Sort(judgePoints);

            decimal judgePointsSum = 0;

            for (int i=1; i <= 3; i++)
            {
                judgePointsSum += judgePoints[i];
            }
            return judgePointsSum;
        }

        private decimal CalcLengthPoints(decimal length)
        {
            // Get setup values
            int kPoint = (int)numericUpDownKPoint.Value;
            decimal pointsPerMeter = numericUpDownPointsPerM.Value;

            // Calc difference to K point and final length points
            decimal lengthOffset = length - kPoint;
            decimal points = 60 + (lengthOffset * pointsPerMeter);

            return points;
        }

        private void buttonCalculate_Click(object sender, EventArgs e)
        {
            decimal baseLengthPoints = CalcLengthPoints(numericUpDownJumpLength.Value);
            decimal judgePoints = CalcJudgePoints();
            decimal windPoints = CalcWindPoints();
            decimal gatePoints = CalcGatePoints();

            textBoxScore.Text = (baseLengthPoints + judgePoints + windPoints + gatePoints).ToString();

            decimal compNum = numericUpDownCompetitorNumber.Value;
            compNum += 1;
            numericUpDownCompetitorNumber.Value = compNum;
        }
    }
}
