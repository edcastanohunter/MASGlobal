using MasGlobal.Core.SharedKernel;

namespace MasGlobal.Core.Entities
{
    public class MontlyEmployee : Employee
    {
        public MontlyEmployee()
        {
            ContractType = ContractType.Monthly;
        }
        public override decimal CalculatedAnnualSalary()
        {
            return Salary * 12;
        }
    }
}
