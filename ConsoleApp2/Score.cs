using System;
using System.Runtime.InteropServices.WindowsRuntime;

namespace ConsoleApp2
{
    public class Score
    {
        private InputData input;
        private OutputData output;

        public Score(InputData input, OutputData output)
        {
            this.input = input;
            this.output = output;
        }

        public int Compute()
        {
            int score = 0;

            for (int i = 0; i < input.F; i++)
            {
                int a = 0;
                int b = 0;
                int t = 0;

                for (int j = 0; j < output.Rides[i].Count; j++)
                {
                    int ride = output.Rides[i][j];

                    t += Math.Abs(input.Rides[ride].A - a);
                    t += Math.Abs(input.Rides[ride].B - b);

                    a = input.Rides[ride].A;
                    b = input.Rides[ride].B;

                    int bonus = 0;
                    if (t <= input.Rides[ride].S)
                    {
                        bonus = input.B;
                        t = input.Rides[ride].S;
                    }

                    int d = 0;
                    d += Math.Abs(input.Rides[ride].X - a);
                    d += Math.Abs(input.Rides[ride].Y - b);

                    a = input.Rides[ride].X;
                    b = input.Rides[ride].Y;

                    if (t + d <= input.Rides[ride].T)
                        score += d + bonus;

                    t += d;
                }
            }

            return score;
        }
    }
}
