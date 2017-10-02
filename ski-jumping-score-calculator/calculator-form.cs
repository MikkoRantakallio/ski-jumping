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
    public partial class CalculatorForm : Form
    {
        private SkiJumpScoreCalculator scoreCalculator;
        private List<string[]> scoreList;

        public CalculatorForm()
        {
            InitializeComponent();
        }

        private void buttonCalculate_Click(object sender, EventArgs e)
        {
            if (textBoxCompetitorName.Text.Trim()=="")
            {
                MessageBox.Show("Competitor cannot be empty!", "Missing data");
                return;
            }

            scoreCalculator.SetupHill((int)numericUpDownKPoint.Value, numericUpDownPointsPerM.Value);

            decimal baseLengthPoints = scoreCalculator.CalcLengthPoints(numericUpDownJumpLength.Value);
            decimal judgePoints = scoreCalculator.CalcJudgePoints(numericUpDownJudge1.Value, numericUpDownJudge2.Value, numericUpDownJudge3.Value,
                numericUpDownJudge4.Value, numericUpDownJudge5.Value);
            decimal windPoints = scoreCalculator.CalcWindPoints(numericUpDownWindAverage.Value);
            decimal gatePoints = scoreCalculator.CalcGatePoints(numericUpDownStartGate.Value);
            decimal points = baseLengthPoints + judgePoints + windPoints + gatePoints;

            textBoxScore.Text = (points).ToString();

            string[] arr = new string[4];
            ListViewItem itm;
            //add items to ListView
            arr[0] = "";
            arr[1] = numericUpDownCompetitorNumber.Value.ToString();
            arr[2] = textBoxCompetitorName.Text;
            arr[3] = points.ToString();

            scoreList.Add(arr);
            scoreList.Sort((x, y) => decimal.Parse(y[3]).CompareTo( decimal.Parse(x[3])));

            // Clear the list
            listViewResults.Items.Clear();
            listViewResults.Refresh();

            // Create new score list
            int i = 1;
            foreach (string[] comp in scoreList)
            {
                comp[0] = i.ToString();
                itm = new ListViewItem(comp);
                listViewResults.Items.Add(itm);
                i++;
            }

            // Increment the competitor number field and clear competitor name
            decimal compNum = numericUpDownCompetitorNumber.Value;
            compNum += 1;
            numericUpDownCompetitorNumber.Value = compNum;
            textBoxCompetitorName.Text = "";

            // Disable setup fields after first successful result

            numericUpDownKPoint.Enabled = false;
            numericUpDownPointsPerM.Enabled = false;
        }

        private void CalculatorForm_Load(object sender, EventArgs e)
        {
            // Create calculator and score array
            scoreCalculator = new SkiJumpScoreCalculator();
            scoreList = new List<string[]>();

            // Setup jumping hill
//            scoreCalculator.SetupHill((int)numericUpDownKPoint.Value, numericUpDownPointsPerM.Value);

            // Setup score board
            listViewResults.View = View.Details;
            listViewResults.GridLines = true;
            listViewResults.FullRowSelect = true;

            listViewResults.Columns.Add("Pos", 50);
            listViewResults.Columns.Add("Nbr", 50);
            listViewResults.Columns.Add("Competitor", 270);
            listViewResults.Columns.Add("Score", 80);
        }

        private void numericUpDownKPoint_ValueChanged(object sender, EventArgs e)
        {
            decimal value = numericUpDownKPoint.Value;
            numericUpDownJumpLength.Value = value;
        }
    }
}
