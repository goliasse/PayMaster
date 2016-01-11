namespace Paymaster.Model
{
    public class Useraccess
    {
        public virtual int Id { get; set; }
        public virtual int? Userid { get; set; }
        public virtual int? Access { get; set; }
        public virtual int? Permission { get; set; }
    }
}