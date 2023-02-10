using System.Runtime.CompilerServices;

internal class Program
{
    private static void Main(string[] args)
    {
        UserImputMethod();

        static void UserImputMethod()
        {
            int hourValue, minuteValue;
            Console.WriteLine("Please set the analogue clocks time:");
            while(true)
            {
                Console.WriteLine("Please set the hour arrow (1-12):");
                try
                {
                    hourValue = int.Parse(Console.ReadLine());
                    Console.WriteLine("Please set the minute arrow (0-60)");
                    minuteValue = int.Parse(Console.ReadLine());
                    if ((hourValue <= 0 || hourValue > 12) || (minuteValue < 0 || minuteValue > 60))
                    { Console.WriteLine("Error: invalid number"); 
                      continue; 
                    }
                }
                catch (FormatException e)
                {
                    Console.WriteLine(e.Message);
                    continue;
                }
                break;
            }
            Console.WriteLine("The hour arrow is set to {0} and the minute arrow is set to {1}", hourValue, minuteValue);
            double finalLesserAngle = DegreeCalculation(hourValue, minuteValue);
            Console.WriteLine("The lesser angle between these time arrows is: " + finalLesserAngle + " degrees");
            Console.ReadLine();
        }

        static double DegreeCalculation(int hour, int minute)
        {
            int degrees = 360;
            double lesserAngleDeggrees;
            double hourArrowDegree = degrees / 12 * hour;
            double minuteArrowDegree = degrees / 60 * minute;
            Console.WriteLine("Hour degrees {0}\nMinute degrees {1}", hourArrowDegree,minuteArrowDegree);
            if (hourArrowDegree > minuteArrowDegree)
            {
                lesserAngleDeggrees = hourArrowDegree - minuteArrowDegree;
            }
            else
            {
                lesserAngleDeggrees = minuteArrowDegree - hourArrowDegree;
            }
            return  lesserAngleDeggrees;
        }
    }
}