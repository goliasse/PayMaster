using Paymaster.Model.Interfaces;

namespace Paymaster.DataModel
{
    public class EmployeeDeduction : IIdAble<int>, IIsDeletable
    {
        public virtual int Id { get; set; }
        public virtual Employee Employees { get; set; }
        public virtual string Description { get; set; }
        public virtual int Frequency { get; set; }
        public virtual int Skip { get; set; }
        public virtual int? Amountflag { get; set; }
        public virtual string Amount { get; set; }
        public virtual string Annuallimit { get; set; }
    }
}