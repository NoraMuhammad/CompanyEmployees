using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyEmployees_struct
{
    struct Employee
    {
        private int _id;
        private float _salary;
        private HiringDate _hiringDate;
        public Employee(int emp_ID, float empSalary, int HiringDay, int HiringMonth, int HiringYear)
        {
            _id = emp_ID;
            _salary = empSalary;
            _hiringDate = new HiringDate(HiringDay, HiringMonth, HiringYear);
        }
        public int ID
        {
            set
            {
                if (value > 0)
                    _id = value;
                else
                    _id = -1;
            }
            get
            {
                return _id;
            }
        }
        public float Salary
        {
            set
            {
                if (value > 0)
                    _salary = value;
                else
                    _salary = -1;
            }
            get
            {
                return _salary;
            }
        }
        public HiringDate HiringDate
        {
            set
            {
                _hiringDate.Day = value.Day;
                _hiringDate.Month = value.Month;
                _hiringDate.Year = value.Year;
            }
            get
            {
                return _hiringDate;
            }
        }
        public override string ToString()
        {
            return $"Employee ID: {_id}\nEmployee Salary: {_salary}$\nEmployee Hiring Date:{_hiringDate}\n";
        }
    }
    struct HiringDate
    {
        int _day, _month, _year;
        public HiringDate(int HiringDay, int HiringMonth, int HiringYear)
        {
            if (HiringDay > 0 && HiringDay <= 31)
                _day = HiringDay;
            else
                _day = -1;

            if (HiringMonth > 0 && HiringMonth <= 12)
                _month = HiringMonth;
            else
                _month = -1;

            if (HiringYear > 0 && HiringYear <= 2019)
                _year = HiringYear;
            else
                _year = -1;
        }
        public int Day
        {
            set
            {
                if (value > 0 && value <= 31)
                    _day = value;
                else
                    _day = -1;
            }
            get
            {
                return _day;
            }
        }
        public int Month
        {
            set
            {
                if (value > 0 && value <= 12)
                    _month = value;
                else
                    _month = -1;
            }
            get
            {
                return _month;
            }
        }
        public int Year
        {
            set
            {
                if (value > 0 && value <= 2019)
                    _year = value;
                else
                    _year = -1;
            }
            get
            {
                return _year;
            }
        }
        public override string ToString()
        {
            return $"{_day}/{_month}/{_year}";
        }
    }
    enum Gender
    {
        M,
        F
    }
    class Program
    {
        static void Main(string[] args)
        {
            int empCount = 3;
            bool validID = true, validSalary = true, validDate = true;
            Employee[] employees = new Employee[empCount];
            for(int i = 0; i < empCount; i++)
            {
                do
                {
                    validID = true;
                    Console.WriteLine($"Enter non-duplicated ID of employee {i}:");
                    if (int.TryParse(Console.ReadLine(), out int id))
                    {
                        for (int j = 0; j < empCount; j++)
                        {
                            if (j != i && employees[j].ID == id)
                                validID = false;
                        }
                        if (validID)
                        {
                            employees[i].ID = id;
                            if (employees[i].ID != -1)
                                validID = true;
                            else
                                validID = false;
                        }
                    }
                    else
                        validID = false;
                } while (!validID);

                do
                {
                    validSalary = true;
                    Console.WriteLine($"Enter salary of employee {i}(more than/equal zero):");
                    if (int.TryParse(Console.ReadLine(), out int salary))
                    {
                        employees[i].Salary = salary;
                        if (employees[i].Salary != -1)
                            validSalary = true;
                        else
                            validSalary = false;
                    }
                    else
                        validSalary = false;
                } while (!validSalary);

                do
                {
                    validDate = true;
                    Console.WriteLine("Enter valid employee hiring date(day/month/year):");
                    string hiringDate = Console.ReadLine();
                    string[] splitedDate = hiringDate.Split('/');

                    int.TryParse(splitedDate[0], out int day);
                    int.TryParse(splitedDate[1], out int month);
                    int.TryParse(splitedDate[2], out int year);

                    employees[i].HiringDate = new HiringDate(day, month, year);
                    if (employees[i].HiringDate.Day != -1 && employees[i].HiringDate.Month != -1 && employees[i].HiringDate.Year != -1)
                        validDate = true;
                    else
                        validDate = false;
                } while (!validDate);

                Console.WriteLine(employees[i] + "\n-------------------------------------------------\n");
            }
        }
    }
}
