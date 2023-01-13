using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StringCalculatorNS;

namespace UINS
{
    public class UserInterface
    {
        public void RunProgramm()
        {
            Console.WriteLine("#String Calculator#");

            var calc = new StringCalculator();

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "exit") break;
                DoCalc(calc, ref input);
                Console.WriteLine("============================\nto stop enter \"exit\"");
            }
        }
        private void DoCalc(StringCalculator calc, ref string input)
        {
            try
            {
                Console.WriteLine(calc.Calc(calc.StringFormat(input)));
            }
            catch (CalcException e)
            {
                Console.WriteLine("ошибка при вводе данных: " + e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine("при работе программы возникло исключение: " + e.Message);
            }
        }
    }
}
