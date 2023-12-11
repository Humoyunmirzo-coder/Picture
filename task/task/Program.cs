

namespace task
{
    internal class Program
    {
        static void Main(string[] args)
        {




            Console.Write(" Enter Number: ");
            int number = int.Parse(Console.ReadLine());
            number= number + 1;
    
          

            for (int i = 0; i < number; i++)
            {
                for (int j = number; j >=1; j--)
                {
                    if (i >= j)
                    {
                        Console.Write("* ");
                    }
                    else
                    {
                        Console.Write(" ");
                    };
                }
                    Console.WriteLine("");
            }
            
            
            for (int i = number; i >=1; i--)
            {
                for (int j = number; j >=1; j--)
                {
                    if (i >= j)
                    {
                        Console.Write("* ");
                    }
                    else
                    {
                        Console.Write(" ");
                    };
                }
                    Console.WriteLine("");
            }
        }
    }
}