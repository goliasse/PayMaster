namespace Paymaster.Model
{
    public class Fedtaxtables
    {
        public virtual int Id { get; set; }
        public virtual int Year { get; set; }
        public virtual int Payfrequency { get; set; }
        public virtual int Maritalsatus { get; set; }
        public virtual string Over { get; set; }
        public virtual string Withhold { get; set; }
        public virtual string Pluspercentage { get; set; }
    }
}