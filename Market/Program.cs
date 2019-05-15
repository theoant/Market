using System;

namespace Market
{
    class Program
    {
        static void Main(string[] args)
        {
            var basketCall = new Basket();
            basketCall.fillWithDummyData();
            //Console.WriteLine(basketCall);
            //basketCall.SaveToFile();
            //basketCall.SaveToJson();
            //basketCall.SaveToExcel();
            //basketCall.LoadText();
            //basketCall.LoadJson();
            basketCall.LoadExcel();
            basketCall.Print();
        }
    }
}
