// jshint esversion:6
function solve([firstEmployee, secondEmployee, thirdEmployee, studentCount])
{
    // 'use strict';
    const questionsAnsweredPerHour = parseInt(firstEmployee) + parseInt(secondEmployee) + parseInt(thirdEmployee);
    const workHours = Math.ceil(parseInt(studentCount) / questionsAnsweredPerHour);
    const breakHours = Math.floor(workHours / 3);
    const unnecessaryBreak = (workHours / breakHours == 3 ? 1 : 0);
    const hoursNeeded = workHours + breakHours - unnecessaryBreak;

    console.log(`Time needed: ${hoursNeeded}h.`);
}

// solve([5, 6, 4, 20]);
// console.log('Expected 2');
// solve([1, 2, 3, 45]);
// console.log('Expected 10');
// solve([3, 2, 5, 40]);
// console.log('Expected 5');
// solve([24, 232, 234, 21213]);
// console.log('Expected 58');
// solve([1, 1, 1, 21213]);
// console.log('Expected 9427');
// solve([1, 1, 1, 34]);
// console.log('Expected 15');
// solve([131, 1231, 12, 123234234]);
// console.log('Expected 119587');