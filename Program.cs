using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace test002
{

    class Program
    {
        static readonly char[] Separators = new char[] { '+', '-', '/', '*'};
        static readonly Dictionary<char, int> Prior = new Dictionary<char, int>()
            {
            {'+',6 },
            {'-',6 },
            {'/',5 },
            {'*',5 },
            };

        static double Calc(List<string> res)
        {
            return 0;
        }


        static List<string> SplitByOp(string str)
        {
            List<string> res = new List<string> { };
            int j = 0, brCounter = str[0] == '(' ? 1 : 0;

            if (Separators.Contains(str[0]) && !(str[0] == '-'))
            {
 //             throw new Exception("NoFirstOp");
                Console.WriteLine("NoFirstOp");
            }
            if (Separators.Contains(str[str.Length - 1]))
            {
//              throw new Exception("NoSecondOp");
                Console.WriteLine("NoSecondOp");
            }
            for (int i = 1; i < str.Length; i++)
            {
                if (str[i] == '(') brCounter++;

                if (brCounter == 0 && Separators.Contains(str[i]) && !(i == j && str[i] == '-' && str[i - 1] != ')'))
                {
                    res.Add(str.Substring(j, i - j));
                    res.Add(str[i].ToString());
                    j = i + 1;
                }

                if (str[i] == ')') brCounter--;
            }
            res.Add(str.Substring(j, str.Length - j).ToString());
            if (brCounter != 0)
            {
       //         throw new Exception("BracketCountErr");
                  Console.WriteLine("BracketCountErr");
            }
            return res;
        }

        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            //string input = "(-(12,23/45+221-44/4)*(2*(21-8))+(56/8*-7/9))-98/(45*-3)";
            input = input.Replace(" ", "").Replace(".", ",");

            //Console.WriteLine(Calc(SplitByOp(input)));
            List<string> res = SplitByOp(input);
            foreach (var item in res)
            {
                Console.WriteLine(item);
            }

        }
    }
}