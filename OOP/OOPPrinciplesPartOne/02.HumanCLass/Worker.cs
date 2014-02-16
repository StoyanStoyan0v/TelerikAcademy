namespace HumanCLass
{
    using System;

    public class Worker : Human
    {
        private string firstName;
        private string lastName;
        private decimal weekSalary;
        private float workHoursPerDay;

        public Worker(string firsName, string lastName, decimal weekSalary, float dailyWorkHours)
            : base(firsName, lastName)
        {
            this.WorkHoursPerDay = dailyWorkHours;
            this.WeekSalary = weekSalary;
        }

        public override string FirstName
        {
            get
            {
                return this.firstName;
            }
            protected set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Worker's first name cannot be empty!");
                }
                this.firstName = value;
            }
        }

        public override string LastName
        {
            get
            {
                return this.lastName;
            }
            protected set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Worker's last name cannot be empty!");
                }
                this.lastName = value;
            }
        }

        public float WorkHoursPerDay
        {
            get
            {
                return this.workHoursPerDay;
            }
            set
            {
                if (value < 0 || value > 24)
                {
                    throw new ArgumentException("Daily work hours of the worker cannot be a negative number or exceed 24.");
                }

                this.workHoursPerDay = value;
            }
        }

        public decimal WeekSalary
        {
            get
            {
                return this.weekSalary;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Worker's week salary cannot be a negative number!");
                }

                this.weekSalary = value;
            }
        }

        public decimal MoneyPerHour
        {
            get
            {
                return this.WeekSalary / ((decimal)this.WorkHoursPerDay * 5);
            }
        }

        public override string ToString()
        {
            return string.Format("Name: {0,-20} | Week salary: {1,-10:C2} | Money per hour: {2:C2}", this.FirstName + " " + this.LastName,
                this.WeekSalary, this.MoneyPerHour);
        }
    }
}
