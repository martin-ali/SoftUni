using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _02_softuni_course_planning
{
    class SoftuniCoursePlanning
    {
        static void Main()
        {
            #if DEBUG
            Console.SetIn(new StreamReader("tests/test2.txt"));
            #endif

            var schedule = Console.ReadLine().Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries).ToList();
            var lessons = new List<string>();
            var lessonHasExercise = new Dictionary<string, bool>();

            foreach (var lesson in schedule)
            {
                if (lessonHasExercise.ContainsKey(lesson) == false)
                {
                    lessonHasExercise[lesson] = false;
                    lessons.Add(lesson);
                }
            }

            var input = Console.ReadLine();
            while (input != "course start")
            {
                var data = input.Split(':');
                var command = data[0];
                var lesson = data[1];

                if (command == "Add")
                {
                    if (lessonHasExercise.ContainsKey(lesson) == false)
                    {
                        lessons.Add(lesson);
                        lessonHasExercise[lesson] = false;
                    }
                }
                else if (command == "Insert")
                {
                    var index = int.Parse(data[2]);
                    // bool indexIsValid = 0 <= index && index < schedule.Count;
                    if (lessonHasExercise.ContainsKey(lesson) == false)
                    {
                        lessons.Insert(index, lesson);
                        lessonHasExercise[lesson] = false;
                    }
                }
                else if (command == "Remove")
                {
                    lessons.Remove(lesson);
                    lessonHasExercise.Remove(lesson);
                }
                else if (command == "Swap")
                {
                    var secondLesson = data[2];
                    var indexOfFirstLesson = lessons.IndexOf(lesson);
                    var indexOfSecondLesson = lessons.IndexOf(secondLesson);

                    if (indexOfFirstLesson >= 0 && indexOfSecondLesson >= 0)
                    {
                        var temp = lessons[indexOfFirstLesson];
                        lessons[indexOfFirstLesson] = lessons[indexOfSecondLesson];
                        lessons[indexOfSecondLesson] = temp;
                    }
                }
                else if (command == "Exercise")
                {
                    if (lessonHasExercise.ContainsKey(lesson) == false)
                    {
                        lessonHasExercise[lesson] = false;
                        lessons.Add(lesson);
                    }

                    lessonHasExercise[lesson] = true;
                }

                input = Console.ReadLine();
            }

            for (int current = 0, count = 1; current < lessons.Count; current++)
            {
                Console.WriteLine($"{count++}.{lessons[current]}");
                if (lessonHasExercise.ContainsKey(lessons[current]) && lessonHasExercise[lessons[current]])
                {
                    Console.WriteLine($"{count++}.{lessons[current]}-Exercise");
                }
            }
        }
    }
}
