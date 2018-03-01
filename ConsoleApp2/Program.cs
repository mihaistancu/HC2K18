using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    public class InputData
    {
        public int R { get; set; }
        public int C { get; set; }
        public int F { get; set; }
        public int N { get; set; }
        public int B { get; set; }
        public int T { get; set; }


        public List<Ride> Rides { get; set; }
        public InputData()
        {
            Rides = new List<Ride>();
        }
    }

    public class Ride
    {
        public int A { get; set; }
        public int B { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public int S { get; set; }
        public int T { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            InputData inputData = ReadInputFile(@"C:\Users\AdiB\Downloads\a_example.in");
            Console.Write(inputData.R + " " + inputData.C)


            Console.ReadLine();
        }

        private static InputData ReadInputFile(string filePAth)
        {
            var inputData = new InputData();

            string line = string.Empty;
            var file = new System.IO.StreamReader(filePAth);
            var firstLine = file.ReadLine().Split(new[] { ' ' });
            inputData.R = Convert.ToInt32(firstLine[0]);
            inputData.C = Convert.ToInt32(firstLine[1]);
            inputData.F = Convert.ToInt32(firstLine[2]);
            inputData.N = Convert.ToInt32(firstLine[3]);
            inputData.B = Convert.ToInt32(firstLine[4]);
            inputData.T = Convert.ToInt32(firstLine[5]);
            for (int i = 0; i < inputData.F; i++)
            {
                var l = file.ReadLine().Split(new[] { ' ' });

                inputData.Rides.Add(new Ride() {
                    A = Convert.ToInt32(l[0]),
                    B = Convert.ToInt32(l[1]),
                    X = Convert.ToInt32(l[2]),
                    Y = Convert.ToInt32(l[3]),
                    S = Convert.ToInt32(l[4]),
                    T = Convert.ToInt32(l[5]),
                });
            }

            return inputData;
        }
    }
}
