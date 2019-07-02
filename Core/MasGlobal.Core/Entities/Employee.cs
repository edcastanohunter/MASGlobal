using MasGlobal.Core.SharedKernel;

namespace MasGlobal.Core.Entities
{
    public abstract class Employee : BaseEntity
    {
        public string Name { get; set; }
        public ContractType ContractType { get; set; }
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public string RoleDescription { get; set; }
        public decimal Salary { get; set; }

        public abstract decimal CalculatedAnnualSalary();
    }
}
