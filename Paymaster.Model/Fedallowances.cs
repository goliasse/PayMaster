namespace Paymaster.Model
{
    public class Fedallowances
    {
        public virtual int Id { get; set; }
        public virtual int Year { get; set; }
        public virtual int Payfrequency { get; set; }
        public virtual string Eachallowanceamount { get; set; }
    }
}