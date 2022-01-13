using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChopStickTest
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> chopStickArr =new List<int>{ 3, 5, 7 };
            
            int player = 1;


            while (true)
            {
                var rowNum = getRowNum(player);
                if (rowNum > chopStickArr.Count - 1)
                {
                    Console.WriteLine("rowNum out of range of index,please try again！");
                    continue;
                }
                var chopStick = getRandomAmount(player);
                if (chopStick < 1 || chopStick > chopStickArr[rowNum])
                {
                    Console.WriteLine("error input,please try again！");
                    continue;
                }
                chopStickArr[rowNum] -= chopStick;
                if (chopStickArr[rowNum] == 0)
                    chopStickArr.Remove(0);
                string baclance = string.Empty;
                foreach (var item in chopStickArr)
                {
                    baclance += item.ToString() + ",";
                }
                Console.WriteLine("the balance:" + string .Format("[" + baclance.TrimEnd(',') +"]"));
                if (chopStickArr.Count > 0)
                {
                    player = player == 1 ? 2 : 1;
                }
                else
                {
                    break;
                }
            }

            Console.WriteLine(" the player{0} lose",player);
            Console.ReadKey();

        }
        private static int getRowNum(int player)
        {
            int selectedrow = 0;
            bool res = false;
            while (!res)
            {
                Console.WriteLine("player{0} input row number:", player);
                res = int.TryParse(Console.ReadLine(),out selectedrow);
             
            }
            return --selectedrow;
        }

        private static int getRandomAmount(int player)
        {
            int stickAmount = 0;
            while (stickAmount <= 0)
            {
                Console.WriteLine("player{0} input chopstick amount:", player);
                stickAmount = int.Parse(Console.ReadLine());
            }
            
            return stickAmount;
            
        }
    }
   
}
