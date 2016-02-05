using Paymaster.Model.Interfaces;

namespace Paymaster.DataModel
{
    public class FedAllowance : IIdAble<int>, IIsDeletable
    {
        public virtual int Id { get; set; }
        public virtual int Year { get; set; }
        public virtual int Payfrequency { get; set; }
        public virtual string Eachallowanceamount { get; set; }
    }
}