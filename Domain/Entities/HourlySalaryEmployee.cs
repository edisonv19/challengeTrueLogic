namespace API.Domain.Entities
{
    public class HourlySalaryEmployee : SalariedEmployee
    {
        public override double AnualSalary
        {
            get => 120 * HourlySalary * 12;
            set => HourlySalary = value / (120 * 12);
        }
    }
}
