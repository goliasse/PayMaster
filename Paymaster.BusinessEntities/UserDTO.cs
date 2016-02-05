namespace Paymaster.BusinessEntities
{
    public class UserDTO
    {
        public virtual int Id { get; set; }
        public virtual int PayorId { get; set; }
        public virtual string Username { get; set; }
        public virtual bool Locked { get; set; }
    }
}