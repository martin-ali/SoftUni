# Notes

- Don't forget to run "npm install"
- I used async/await where I could(in get), but Sammy doesn't play well with async/await in post since those return promises, and they are not falsy, so I used promises where I was forced to. It was not my intention to create mixed code like that, rather it was a limitation of Sammy
- It's a single controller because the alarm clock died and I woke up at 09:50. Since I was already an hour late, I had to rush
- Believe me, I also want to refactor it real bad, but that's never a good idea in the last 20m of the exam
- Used username for identification instead of id since both are unique
- As per the assignment, I have set the firebase read/write permissions as "true" and not "auth !== null"