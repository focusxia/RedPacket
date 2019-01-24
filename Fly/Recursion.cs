using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fly
{
    public class Recursion
    {
        public static int RescursionMath(int position)
        {
            //一列数的规则如下: 1、1、2、3、5、8、13、21、34...... 求第30位数是多少，用递归算法实现。
            //公式：F(N) = F(N-1) + F(N-2) 

            if (position <= 0)
            {
                return 0;
            }
            else if (position > 0 && position <= 2)
            {
                return 1;
            }
            else
            {
                return RescursionMath(position - 1) + RescursionMath(position - 2);
            }
        }
    }
}
