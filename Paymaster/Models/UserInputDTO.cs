namespace Paymaster.Models
{
    public class UserInputDTO
    {
        public virtual int Id { get; set; }
        public virtual int PayorId { get; set; }
        public virtual string Username { get; set; }
        public virtual string Password { get; set; }
    }
}