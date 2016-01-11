namespace Paymaster.Model.Interfaces
{
    public interface ISoftDeletable : IIsDeletable
    {
        bool IsDeleted { get; set; }
    }
}