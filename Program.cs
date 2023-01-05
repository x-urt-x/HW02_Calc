using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace HW01_Calc1
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
            double num1, num2;
            if (res.Count == 1)
            {
                if (double.TryParse(res[0].ToString(), out num1))
                {
                    return num1;
                }
                else
                {
                    if (res[0][0] == '-' && res[0][1] == '(')
                    {
                        return -Calc(SplitByOp(res[0].ToString().Substring(1, res[0].ToString().Length - 1)));
                    }
                    if (res[0][0] == '(')
                    {
                        return Calc(SplitByOp(res[0].ToString().Substring(1, res[0].ToString().Length - 2)));
                    }
                    else
                    {
                        Console.WriteLine("InvalidInput");
                    }
                }
            }
            if (res.Count == 3)
            {
                if (!(double.TryParse(res[0].ToString(), out num1))) num1 = Calc(SplitByOp(res[0].ToString()));
                if (!(double.TryParse(res[2].ToString(), out num2))) num2 = Calc(SplitByOp(res[2].ToString()));
                return DoOp(num1, num2, res[1][0]);
            }
            int indMaxPrior = 1, MaxPrior = 0;
            for (int i = 1; i < res.Count; i += 2)
            {
                if (Prior[res[i][0]] >= MaxPrior)
                {
                    indMaxPrior = i;
                    MaxPrior = Prior[res[i][0]];
                }
            }
            double n1 = Calc(res.GetRange(0, indMaxPrior));
            double n2 = Calc(res.GetRange(indMaxPrior + 1, res.Count() - indMaxPrior - 1));
            return DoOp(n1, n2, res[indMaxPrior][0]);
 
        }

        static double DoOp(double num1, double num2, char op)
        {
            return 1;
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

            Console.WriteLine(Calc(SplitByOp(input)));

        }
    }
}