using System;
using System.Collections.Generic;
using System.IO;
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

    public class OutputData
    {
        public List<List<int>> Rides { get; set; }
        public OutputData()
        {
            Rides = new List<List<int>>();
        }
    }



    class Program
    {
        static void Main(string[] args)
        {  
            InputData inputData = ReadInputFile(@"a_example.in");
            Console.Write(inputData.R + " " + inputData.C + "  " + inputData.F + " " + inputData.N + " " + inputData.B + " " + inputData.T);
            Console.WriteLine();
            for (int i = 0; i < inputData.N; i++)
            {
                Console.Write(inputData.Rides[i].A + " " + inputData.Rides[i].B + " " + inputData.Rides[i].X + " " + inputData.Rides[i].Y + " " + inputData.Rides[i].S + " " + inputData.Rides[i].T);
                Console.WriteLine();

            }

            var outputData = new OutputData();

            outputData.Rides.Add(new List<int> { 1, 0 });
            outputData.Rides.Add(new List<int> { 2, 1 , 2 });

            GenerateFile(outputData,"out.txt");

            Console.ReadLine();
        }

        private static void GenerateFile(OutputData outputData, string filePath)
        {

            var file = new System.IO.StreamWriter(filePath);
            file.NewLine = "\n";
            foreach (var item in outputData.Rides)
            {
                StringBuilder s = new StringBuilder();
                foreach (var i in item)
                {
                    s.Append(i + " ");
                }

                file.WriteLine(s.ToString());
            }
            file.Flush();
            file.Close();
        }

        private static InputData ReadInputFile(string filePAth)
        {
            var inputData = new InputData();
            var s = Directory.GetCurrentDirectory();
            filePAth = Path.Combine(s, filePAth);
            string line = string.Empty;
            var file = new System.IO.StreamReader(filePAth);
            var firstLine = file.ReadLine().Split(new[] { ' ' });
            inputData.R = Convert.ToInt32(firstLine[0]);
            inputData.C = Convert.ToInt32(firstLine[1]);
            inputData.F = Convert.ToInt32(firstLine[2]);
            inputData.N = Convert.ToInt32(firstLine[3]);
            inputData.B = Convert.ToInt32(firstLine[4]);
            inputData.T = Convert.ToInt32(firstLine[5]);
            for (int i = 0; i < inputData.N; i++)
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
