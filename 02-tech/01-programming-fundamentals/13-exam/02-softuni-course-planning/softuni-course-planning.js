// jshint esversion:6
function solve(commands)
{
    // 'use strict';
    const lessons = commands.shift().split(', ');
    const lessonsWithExercise = new Map();
    for (let lesson of lessons)
    {
        lessonsWithExercise.set(lesson, false);
    }

    commands.pop();
    for (let command of commands)
    {
        const data = command.split(':');
        const commandType = data[0];
        const lesson = data[1];

        if (commandType == 'Add')
        {
            if (lessonsWithExercise.has(lesson) == false)
            {
                lessons.push(lesson);
                lessonsWithExercise.set(lesson, false);
            }
        }
        else if (commandType == 'Insert')
        {
            const index = +data[2];

            if (lessonsWithExercise.has(lesson) == false)
            {
                lessons.splice(index, 0, lesson);
                lessonsWithExercise.set(lesson, false);
            }
        }
        else if (commandType == 'Remove')
        {
            const indexOfLesson = lessons.indexOf(lesson);

            if (indexOfLesson >= 0)
            {
                lessons.splice(indexOfLesson, 1);
                lessonsWithExercise.delete(lesson);
            }
        }
        else if (commandType == 'Swap')
        {
            const firstLesson = lesson;
            const secondLesson = data[2];
            const indexOfFirstLesson = lessons.indexOf(firstLesson);
            const indexOfSecondLesson = lessons.indexOf(secondLesson);

            if (indexOfFirstLesson >= 0 && indexOfSecondLesson >= 0)
            {
                lessons[indexOfFirstLesson] = secondLesson;
                lessons[indexOfSecondLesson] = firstLesson;
            }
        }
        else if (commandType == 'Exercise')
        {
            if (lessonsWithExercise.has(lesson) == false)
            {
                lessons.push(lesson);
            }

            lessonsWithExercise.set(lesson, true);
        }
    }

    for (let current = 0, course = 1; current < lessons.length; ++current)
    {
        console.log(`${course++}.${lessons[current]}`);
        if (lessonsWithExercise.get(lessons[current]))
        {
            console.log(`${course++}.${lessons[current]}-Exercise`);
        }
    }
}

// solve([
//     'Data Types, Objects, Lists, Exercise: Databases, Exercise: Lists',
//     'Add:Databases',
//     'Insert:Arrays:0',
//     'Remove:Lists',
//     'Exercise:Databases',
//     'Exercise:Databases',
//     'Exercise:Databases',
//     'Exercise:Lists',
//     'course start'
// ]);

// solve([
//     'Data Types, Objects, Lists',
//     'Add:Databases',
//     'Insert:Arrays: 0',
//     'Remove:Lists',
//     'course start'
// ]);

// solve([
//     'Arrays, Lists, Methods',
//     'Swap:Arrays:Methods',
//     'Exercise:Databases',
//     'Swap:Lists:Databases',
//     'Insert:Arrays:0',
//     'course start'
// ]);