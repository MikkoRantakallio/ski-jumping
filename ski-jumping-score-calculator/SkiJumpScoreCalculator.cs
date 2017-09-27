using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ski_jumping_score_calculator
{
    class SkiJumpScoreCalculator
    {
        private int _kPoint;
        private decimal _pointsPerMeter;

        public SkiJumpScoreCalculator()
        {
        }

        public void SetupHill (int kPoint, decimal pointsPerMeter)
        {
            _kPoint = kPoint;
            _pointsPerMeter = pointsPerMeter;
        }

        public decimal CalcLengthPoints(decimal length)
        {
            // Calc difference to K point and final length points
            decimal lengthOffset = length - _kPoint;
            decimal points = 60 + (lengthOffset * _pointsPerMeter);

            return decimal.Round(points, 1);
        }

        public decimal CalcJudgePoints(decimal j1, decimal j2, decimal j3, decimal j4, decimal j5)
        {
            decimal[] judgePoints = new decimal[5];

            // Create judge points array
            judgePoints[0] = j1;
            judgePoints[1] = j2;
            judgePoints[2] = j3;
            judgePoints[3] = j4;
            judgePoints[4] = j5;

            Array.Sort(judgePoints);

            decimal judgePointsSum = 0;

            // Loop the sorted array from index 1 to 3, to skip the biggest and lowest values
            for (int i = 1; i <= 3; i++)
            {
                judgePointsSum += judgePoints[i];
            }
            return judgePointsSum;
        }

        public decimal CalcWindPoints(decimal windAverage)
        {
            // Calculate meters and round to half number
            decimal correctionMeters = windAverage * (_kPoint - 36) / 20;
            correctionMeters = Math.Round(correctionMeters * 2, MidpointRounding.AwayFromZero) / 2;
            decimal windPoints = _pointsPerMeter * correctionMeters;

            return decimal.Round(windPoints, 1);
        }

        public decimal CalcGatePoints(decimal gateDiff)
        {
            decimal lengthDiff = gateDiff * 5;
            decimal gatePoints = lengthDiff * _pointsPerMeter;

            return decimal.Round(gatePoints, 1);
        }
    }
}
