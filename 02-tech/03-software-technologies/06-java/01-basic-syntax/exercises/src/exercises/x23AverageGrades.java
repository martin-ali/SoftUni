package exercises;

import java.util.ArrayList;
import java.util.Arrays;
import java.util.Comparator;
import java.util.Scanner;

public class x23AverageGrades
{
    public static void main(String[] args)
    {
        Scanner console = new Scanner(System.in);

        int studentCount = Integer.parseInt(console.nextLine());
        Student[] students = new Student[studentCount];
        for (int current = 0; current < studentCount; current++)
        {
            String[] studentData = console.nextLine().split(" ");
            Student student = new Student(studentData[0]);

            for (int grade = 1; grade < studentData.length; grade++)
            {
                student.addGrade(Double.parseDouble(studentData[grade]));
            }

            students[current] = student;
        }

        Arrays
                .stream(students)
                .filter(s -> s.getAverageGrade() >= 5.0)
                .sorted(Comparator
                        .comparing(Student::getName)
                        .thenComparing(Comparator.comparing(Student::getAverageGrade).reversed()))
                .forEach(s -> System.out.println(String.format("%s -> %.2f", s.getName(), s.getAverageGrade())));
    }
}
/*
6
Petar 3 5 4 3 2 5 6 2 6
Mitko 6 6 5 6 5 6
Gosho 6 6 6 6 6 6
Ani 6 5 6 5 6 5 6 5
Iva 4 5 4 3 4 5 2 2 4
Ani 5.50 5.25 6.00
 */