using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StonesAndBugs
{
    class Program
    {
        static void Main(string[] args)
        {
            ulong X=0, Y=0;
            List<ulong> freeStones = new List<ulong>();
            try
            {
                Console.Write("Введите количество камней X= ");
                X = ulong.Parse(Console.ReadLine());

                Console.Write("Введите количество жуков Y= ");
                Y = ulong.Parse(Console.ReadLine());

                if (Y > X)
                {
                    throw new ArgumentException();
                }

                freeStones.Add(X);

                ulong leftStones = 0;
                ulong rightStones = 0;

                while (Y > 0)
                {
                    var maxFreeStones = freeStones.Max();
                    var indexMaxFreeStones = freeStones.IndexOf(maxFreeStones);
                    if (maxFreeStones % 2 == 0)
                    {
                        leftStones = maxFreeStones / 2 - 1;
                        rightStones = maxFreeStones / 2;
                    }
                    else
                    {
                        leftStones = maxFreeStones / 2;
                        rightStones = maxFreeStones / 2;
                    }

                    freeStones[indexMaxFreeStones] = leftStones;
                    freeStones.Add(rightStones);
                    Y--;
                }
                Console.WriteLine($"Ответ: {leftStones},{rightStones}");
            }
            catch (FormatException)
            {
                Console.WriteLine("Вводимое число должно быть натуральным!");
            }
            catch (OverflowException)
            {
                Console.WriteLine("Вводимое должны быть натуральным и меньше 18 446 744 073 709 551 615 !");
            }
            catch (ArgumentException)
            {
                Console.WriteLine("Количество жуков не может быть больше числа камней!");
            }
            finally
            {
                Console.ReadKey();
            }

        }
    }
}
