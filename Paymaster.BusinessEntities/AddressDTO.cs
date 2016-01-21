namespace Paymaster.BusinessEntities
{
    public class AddressDTO
    {
        public int Id { get; set; }
        public int EmployeesId { get; set; }
        public int Type { get; set; }
        public int Isprimary { get; set; }
        public string Line1 { get; set; }
        public string Line2 { get; set; }
        public string Line3 { get; set; }
        public int? City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string Notes { get; set; }
    }
}