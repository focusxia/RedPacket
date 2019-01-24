using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fly
{
    public class RedPacket
    {
        private static List<int> arr = new List<int>();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="total">红包总金额</param>
        /// <param name="num">红包个数</param>
        /// <param name="deci">红包单位，如：0.1元</param>
        /// <returns></returns>
        public static List<decimal> CalRedPacket(decimal total, int num, decimal deci)
        {
            arr.Clear();
            var returnValue = new List<decimal>();
            int totalDec = Convert.ToInt32(total / deci);

            for (int i = 0; i < num - 1; i++)
            {
                GenerateRandom(totalDec);
            }

            arr = arr.OrderBy(x => x).ToList();

            returnValue.Add(arr[0]);
            for (int i = 1; i < arr.Count(); i++)
            {
                var value = arr[i] - arr[i - 1];
                returnValue.Add(value);
            }
            returnValue.Add(totalDec - arr[arr.Count() - 1]);

            returnValue = returnValue.Select(x => Convert.ToDecimal(x * 0.1m)).ToList();

            if (returnValue.Count() != num)
            {
                CalRedPacket(total, num, deci);
            }
            return returnValue;
        }

        public static int GenerateRandom(int totalDec)
        {
            Random ran = new Random(Guid.NewGuid().GetHashCode() + Guid.NewGuid().GetHashCode());
            int random = ran.Next(1, totalDec);

            if (arr.Contains(random))
            {
                GenerateRandom(totalDec);
            }
            else
            {
                arr.Add(random);
            }

            return random;
        }
    }
}
