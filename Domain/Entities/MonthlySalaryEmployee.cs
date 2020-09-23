namespace API.Domain.Entities
{
    public class MonthlySalaryEmployee : SalariedEmployee
    {
        public override double AnualSalary
        {
            get => MonthlySalary * 12;
            set => MonthlySalary = value / 12;
        }
    }
}
