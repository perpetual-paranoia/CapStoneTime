using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapStoneTime
{
    class Program
    {
        static void Main(string[] args)
        {
            #region first format
            Console.CursorVisible = false;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.Clear();
            #endregion

            #region opening menu
            Console.WriteLine();
            Console.WriteLine("\t\tFinding the Cost of a House");
            Console.WriteLine();
            Console.WriteLine("\t\t  Program by Patrick Payne");
            Console.WriteLine();
            Console.WriteLine();
            ContinuePrompt();

            #endregion

            #region first contact
            Console.Clear();
            Console.CursorVisible = true;

            bool validresponse;
            string yesorno;

            do
            {

                validresponse = false;

                Console.WriteLine();
                Console.WriteLine("\tAre you ready to start the calculations? [yes/no]");
                Console.Write("\t\t ");
                yesorno = Console.ReadLine().ToLower();


                if (yesorno != "yes" && yesorno != "no")
                {
                    Console.Clear();
                    Console.WriteLine("\t\tPlease input a valid answer to the question.");
                    Console.WriteLine();
                }
                else
                {
                    validresponse = true;
                }

            } while (!validresponse);

            if (yesorno == "no")
            {
               EarlyExit();
            }
            if (yesorno == "yes")
            {
               TheGoodStuff();
            }

            #endregion
            
        }

        static void EarlyExit()
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("\t\tMaybe another time then.");
            Console.WriteLine("\t\tHave a nice day.");

            ContinuePrompt();
        }

        static void TheGoodStuff()
        {
            Console.Clear();
            int rooms;
            string userresponse;
            bool validresponse = false;


            do
            {

                Console.WriteLine();
                Console.WriteLine("\tHow many rooms do you have in your house?");
                Console.Write("\t\t ");
                userresponse = Console.ReadLine();


                if (int.TryParse(userresponse, out rooms))
                {
                    if (rooms <= 0)
                    {
                        Console.WriteLine("\t\tPlease input a valid number of rooms.");
                        Console.WriteLine();
                    }
                    else
                    {
                        validresponse = true;
                    }

                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("It looks like you didn't input a number");
                }


            } while (!validresponse);

            Console.WriteLine($"\tSo you have {rooms} rooms.");

            int Height;

            do
            {

                Console.WriteLine();
                Console.WriteLine("\tHow tall are your ceilings in feet?");
                Console.Write("\t\t ");
                userresponse = Console.ReadLine();


                if (int.TryParse(userresponse, out Height))
                {
                    if (Height <= 0)
                    {
                        Console.WriteLine("\t\tPlease input a valid number of feet.");
                        Console.WriteLine();
                    }
                    else
                    {
                        validresponse = true;
                    }

                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("It looks like you didn't input a number");
                }


            } while (!validresponse);

            roomwidths(rooms, Height);
        }

        static void roomwidths(int rooms, int Height)
        {
            Console.Clear();

            int[] Width = new int[rooms];
            

            Console.WriteLine("Please input the widths of the rooms: ");
            for (int index = 0; index < Width.Length; index++)
            {
                Console.WriteLine($"Width {index + 1}: ");
                Width[index] = int.Parse(Console.ReadLine());
            }


            ContinuePrompt();

            roomlengths(rooms, Width, Height);
        }

        static void roomlengths(int rooms, int[] Width, int Height)
        {
            Console.Clear();
            int[] Length = new int[rooms];
            Console.WriteLine("Please input the lengths of the rooms: ");
            for (int index = 0; index < Length.Length; index++)
            {
                Console.WriteLine($"Length {index + 1}: ");
                Length[index] = int.Parse(Console.ReadLine());
            }

            Cost(Length, Width, rooms, Height);
        }

        static void Cost(int[] length, int[] width, int rooms, int Height)
        {
            Console.Clear();

            int twoheight = 2 * Height;
            const int COST = 6;

            Console.WriteLine("The cost of the house is: ");
            int[] bullet = length.Concat(width).ToArray();
            foreach (int kill in bullet)
            for (int index = 0; index < rooms; index++)
            {
                Console.WriteLine("$" + kill * twoheight * COST);
            }

            ContinuePrompt();
        }

        static void ContinuePrompt()
        {
            Console.WriteLine();
            Console.WriteLine("\t\tPress any Key to continue");
            Console.ReadKey();
        }
    }
}
