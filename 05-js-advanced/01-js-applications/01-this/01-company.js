class Company
{
    /** @type {{ name: any; employees: { username: string; salary: number; position: string; }[]; }[]} */
    departments;

    constructor()
    {
        this.departments = [];
    }

    _throwIfInvalidParameter(parameter)
    {
        if (parameter === undefined
            || parameter === null
            || parameter === '')
        {
            throw new Error('Invalid input!');
        }
    }

    _getDepartmentAverageSalary(department)
    {
        const averageSalary = department.employees
            .reduce((sum, current) => sum + current.salary, 0) / department.employees.length;

        return averageSalary;
    }

    /**
     * @param {string} username
     * @param {number} salary
     * @param {string} position
     * @param {string} department
     */
    addEmployee(username, salary, position, department)
    {
        this._throwIfInvalidParameter(username);
        this._throwIfInvalidParameter(salary);
        this._throwIfInvalidParameter(position);
        this._throwIfInvalidParameter(department);

        if (salary < 0)
        {
            throw new Error(' Invalid input!');
        }

        const employee = {
            username,
            salary,
            position
        }

        let currentDepartment = this.departments.find(d => d.name === department);

        if (currentDepartment)
        {
            currentDepartment.employees.push(employee);
        }
        else
        {
            const newDepartment = { name: department, employees: [employee] };

            this.departments.push(newDepartment);
        }

        return `New employee is hired. Name: ${username}. Position: ${position}`;
    }

    bestDepartment()
    {
        const sortedDepartments = Array.from(this.departments);
        sortedDepartments.sort((departmentA, departmentB) =>
        {
            const departmentAAverageSalary = this._getDepartmentAverageSalary(departmentA)
            const departmentBAverageSalary = this._getDepartmentAverageSalary(departmentB);

            // Descending
            return departmentBAverageSalary - departmentAAverageSalary;
        });

        const bestDepartment = sortedDepartments[0];
        const averageSalary = this._getDepartmentAverageSalary(bestDepartment).toFixed(2);
        const sortedEmployees = Array.from(bestDepartment.employees);
        sortedEmployees
            .sort((employeeA, employeeB) =>
            {
                if (employeeA.salary !== employeeB.salary)
                {
                    // Descending
                    return employeeB.salary - employeeA.salary;
                }
                else
                {
                    return employeeA.username.localeCompare(employeeB.username);
                }
            });

        let result = '';

        result += `Best Department is: ${bestDepartment.name}\n`
        result += `Average salary: ${averageSalary}\n`;

        for (const employee of sortedEmployees)
        {
            result += `${employee.username} ${employee.salary} ${employee.position}\n`;
        }

        return result.trim();
    }
}

// let company = new Company();
// company.addEmployee("Stanimir", 2000, "engineer", "Construction");
// company.addEmployee("Pesho", 1500, "electrical engineer", "Construction");
// company.addEmployee("Slavi", 500, "dyer", "Construction");
// company.addEmployee("Stan", 2000, "architect", "Construction");
// company.addEmployee("Stanimir", 1200, "digital marketing manager", "Marketing");
// company.addEmployee("Pesho", 1000, "graphical designer", "Marketing");
// company.addEmployee("Gosho", 1350, "HR", "Human resources");
// console.log(company.bestDepartment());