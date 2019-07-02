using MasGlobal.Core.SharedKernel;

namespace MasGlobal.Core.Entities
{
    public class HourlyEmployee : Employee
    {
        public HourlyEmployee()
        {
            ContractType = ContractType.Hourly;
        }
        public override decimal CalculatedAnnualSalary()
        {
            return 120 * Salary * 12;
        }
    }
}
