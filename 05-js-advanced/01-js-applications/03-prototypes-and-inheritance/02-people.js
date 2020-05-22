function solve()
{
    class Employee
    {
        name;
        age;
        salary;
        tasks;

        constructor(name, age, tasks)
        {
            if (new.target === Employee)
            {
                throw new Error('Cannot instantiate directly.');
            }

            this.name = name;
            this.age = age;
            this.salary = 0;
            this.tasks = tasks;
        }

        getSalary()
        {
            return this.salary;
        }

        work()
        {
            const currentTask = this.tasks.shift();

            console.log(`${this.name} ${currentTask}`);

            this.tasks.push(currentTask);
        }

        collectSalary()
        {
            console.log(`${this.name} received ${this.getSalary()} this month.`)
        }
    }

    class Junior extends Employee
    {
        constructor(name, age)
        {
            super(name, age, [`is working on a simple task.`]);
        }
    }

    class Senior extends Employee
    {
        constructor(name, age)
        {
            super(name, age,
            [
                `is working on a complicated task.`,
                `is taking time off work.`,
                `is supervising junior workers.`
            ]);
        }
    }

    class Manager extends Employee
    {
        dividend;

        constructor(name, age)
        {
            super(name, age,
            [
                `scheduled a meeting.`,
                `is preparing a quarterly report.`
            ]);

            this.dividend = 0;
        }

        getSalary()
        {
            return this.salary + this.dividend;
        }
    }

    return {
        Employee,
        Junior,
        Senior,
        Manager
    }
}