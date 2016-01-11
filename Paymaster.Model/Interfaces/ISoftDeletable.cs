namespace Paymaster.Model.Interfaces
{
    public interface ISoftDeletable: IDeletable
    {
        bool IsDeleted { get; set; }
    }
}