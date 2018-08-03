package exercises;

import java.util.ArrayList;

public class Student
{
    private String name;
    private ArrayList<Double> grades = new ArrayList<>();

    public Student(String name)
    {
        this.name = name;
    }

    public double getAverageGrade()
    {
        return this
                .grades
                .stream()
                .mapToDouble(x -> x)
                .average()
                .getAsDouble();
    }

    public String getName()
    {
        return name;
    }

    public void setName(String name)
    {
        this.name = name;
    }

    public ArrayList<Double> getGrades()
    {
        return grades;
    }

    public void setGrades(ArrayList<Double> grades)
    {
        this.grades = grades;
    }

    public void addGrade(Double grade)
    {
        this.grades.add(grade);
    }
}