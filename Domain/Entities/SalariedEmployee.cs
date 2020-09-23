namespace API.Domain.Entities
{
    public abstract class SalariedEmployee : Employee
    {
        public abstract double AnualSalary
        {
            get;
            set;
        }
    }
}
