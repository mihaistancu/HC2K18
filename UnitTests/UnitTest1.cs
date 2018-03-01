using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConsoleApp2;

namespace UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var inputData = new InputData();
            inputData.R = 3;
            inputData.C = 4;
            inputData.F = 2;
            inputData.N = 3;
            inputData.B = 2;
            inputData.T = 10;
                 
            inputData.Rides = new List<Ride>();
            inputData.Rides.Add(new Ride {A = 0, B = 0, X = 1, Y = 3, S = 2, T = 9});
            inputData.Rides.Add(new Ride {A = 1, B = 2, X = 1, Y = 0, S = 0, T = 9});
            inputData.Rides.Add(new Ride {A = 2, B = 0, X = 2, Y = 2, S = 0, T = 9});

            var outputData = new OutputData();

            outputData.Rides.Add(new List<int> { 0 });
            outputData.Rides.Add(new List<int> { 1, 2 });

            var score = new Score(inputData, outputData);
            var result = score.Compute();

            Assert.AreEqual(10, result);
        }
    }
}
