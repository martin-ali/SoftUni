package exercises;

import java.time.DayOfWeek;
import java.time.LocalDate;
import java.time.Month;
import java.time.format.DateTimeFormatter;
import java.util.Arrays;
import java.util.HashMap;
import java.util.Scanner;

public class x20CountWorkingDays
{
    public static void main(String[] args)
    {
        HashMap<Integer, Integer[]> holidays = new HashMap<>();
        holidays.put(1, new Integer[]{1});
        holidays.put(3, new Integer[]{3});
        holidays.put(5, new Integer[]{1, 6, 24});
        holidays.put(9, new Integer[]{6, 22});
        holidays.put(11, new Integer[]{1});
        holidays.put(12, new Integer[]{24, 25, 26});

        Scanner console = new Scanner(System.in);
        LocalDate start = LocalDate.parse(console.nextLine(), DateTimeFormatter.ofPattern("dd-MM-yyyy"));
        LocalDate end = LocalDate.parse(console.nextLine(), DateTimeFormatter.ofPattern("dd-MM-yyyy"));

        int workdayCount = 0;
        for (LocalDate currentDate = start; currentDate.isBefore(end.plusDays(1)); currentDate = currentDate.plusDays(1))
        {
            DayOfWeek day = currentDate.getDayOfWeek();
            Boolean isHoliday = holidays.containsKey(currentDate.getMonthValue())
                            && Arrays.asList(holidays.get(currentDate.getMonthValue())).contains(currentDate.getDayOfMonth());
            Boolean isWeekend = day == DayOfWeek.SATURDAY
                                || day == DayOfWeek.SUNDAY;

            if (!isWeekend && !isHoliday)
            {
                workdayCount++;
            }
        }

        System.out.println(workdayCount);
    }
}
