using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Fly
{
    class Program
    {
        private static decimal totalM = 1000m;
        private static int numM = 5;
        private static decimal unitM = 0.1m;
        static void Main(string[] args)
        {
            var result = Recursion.RescursionMath(6);

            //求以下表达式的值，写出您想到的一种或几种实现方法： 1-2+3-4+……+m
            //var i = 6;
            //var sum = i % 2 == 1 ? i + -(i - 1) / 2 : -i / 2;
            DataTable dt = new DataTable();
            for (int i = 0; i < numM; i++)
            {
                dt.Columns.Add((i + 1).ToString());
            }

            for (int i = 0; i < 1000000; i++)
            {
                //Thread.Sleep(1000);
                var sum = RedPacket.CalRedPacket(totalM, numM, unitM);
                dt.Rows.Add(sum[0], sum[1], sum[2], sum[3], sum[4]);

                var rowTotal = sum[0] + sum[1] + sum[2] + sum[3] + sum[4];
                if (rowTotal != totalM)
                {
                    Console.WriteLine("异常");
                }
            }

            List<decimal> total1 = new List<decimal>();
            List<decimal> total2 = new List<decimal>();
            List<decimal> total3 = new List<decimal>();
            List<decimal> total4 = new List<decimal>();
            List<decimal> total5 = new List<decimal>();

            foreach (DataRow row in dt.Rows)
            {
                total1.Add(Convert.ToDecimal(row[0]));
                total2.Add(Convert.ToDecimal(row[1]));
                total3.Add(Convert.ToDecimal(row[2]));
                total4.Add(Convert.ToDecimal(row[3]));
                total5.Add(Convert.ToDecimal(row[4]));

                var rowTotal = Convert.ToDecimal(row[0]) + Convert.ToDecimal(row[1]) + Convert.ToDecimal(row[2]) + Convert.ToDecimal(row[3]) + Convert.ToDecimal(row[4]);
                if (rowTotal != totalM)
                {
                    Console.WriteLine("异常：" + Convert.ToDecimal(row[0]) + "," + Convert.ToDecimal(row[1]) + "," + Convert.ToDecimal(row[2]) + "," + Convert.ToDecimal(row[3]) + "," + Convert.ToDecimal(row[4]));
                }
            }

            var total1Sum = total1.Sum();
            var total2Sum = total2.Sum();
            var total3Sum = total3.Sum();
            var total4Sum = total4.Sum();
            var total5Sum = total5.Sum();

            var total = total1Sum + total2Sum + total3Sum + total4Sum + total5Sum;
            Console.WriteLine("total：" + total);
            Console.WriteLine("----");
            var value1 = (total1Sum / total).ToString("0.00");
            var value2 = (total2Sum / total).ToString("0.00");
            var value3 = (total3Sum / total).ToString("0.00");
            var value4 = (total4Sum / total).ToString("0.00");
            var value5 = (total5Sum / total).ToString("0.00");

            Console.WriteLine(string.Format("total1:{0}%---\ntotal2:{1}%---\ntotal3:{2}%---\ntotal4:{3}%---\ntotal5:{4}%---",
                value1,
                value2,
                value3,
                value4,
                value5));
            Console.WriteLine("----");
            Console.ReadKey();
        }
    }
}
