using System;
using System.Collections.Generic;

namespace on_time_for_the_exam
{
    class Program
    {
        enum ArrivalTiming { OnTime, Early, Late };

        static void Main()
        {
            // Initial setup
            ArrivalTiming arrivalTiming;            
            var beforeOrAfterMap = new Dictionary<ArrivalTiming, string>()
            {
                [ArrivalTiming.OnTime] = "Before",
                [ArrivalTiming.Early] = "Before",
                [ArrivalTiming.Late] = "After"
            };
            var ontimeEarlyLateMap = new Dictionary<ArrivalTiming, string>()
            {
                [ArrivalTiming.OnTime] = "On time",
                [ArrivalTiming.Early] = "Early",
                [ArrivalTiming.Late] = "Late"
            };

            // Get input
            int examHours = int.Parse(Console.ReadLine());
            int examMinutes = int.Parse(Console.ReadLine());
            int examTimeInMinutes = (examHours * 60) + examMinutes;

            int arrivalHours = int.Parse(Console.ReadLine());
            int arrivalMinutes = int.Parse(Console.ReadLine());
            int arrivalTimeInMinutes = (arrivalHours * 60) + arrivalMinutes;

            // Too late, can't think, don't forget to simplify
            int differenceBetweenArrivalAndExamTime = arrivalTimeInMinutes - examTimeInMinutes;
            bool studentArrivedOnTime = -30 <= differenceBetweenArrivalAndExamTime && differenceBetweenArrivalAndExamTime <= 0;
            bool studentArrivedEarly = differenceBetweenArrivalAndExamTime < -30;
            bool studentArrivedLate = differenceBetweenArrivalAndExamTime > 30;

            // Logic
            if (studentArrivedOnTime)
            {
                arrivalTiming = ArrivalTiming.OnTime;
            }
            else if (studentArrivedEarly)
            {
                arrivalTiming = ArrivalTiming.Early;
            }
            else
            {
                arrivalTiming = ArrivalTiming.Late;
            }

            int differenceInMinutes = Math.Abs(differenceBetweenArrivalAndExamTime);
            string beforeOrAfter = beforeOrAfterMap[arrivalTiming];
            string studentArrivalState = ontimeEarlyLateMap[arrivalTiming];
            string timeMeasurementUnit = "minutes";

            string time = differenceInMinutes.ToString();
            if (differenceInMinutes > 59)
            {
                int hoursDifference = differenceInMinutes / 60;
                int minutesDifference = differenceInMinutes - (hoursDifference * 60);
                time = $"{hoursDifference}:{minutesDifference:00}";
                timeMeasurementUnit = "hours";
            }

            Console.WriteLine(studentArrivalState);
            Console.WriteLine($"{time} {timeMeasurementUnit} {beforeOrAfter} the start");
        }
    }
}
