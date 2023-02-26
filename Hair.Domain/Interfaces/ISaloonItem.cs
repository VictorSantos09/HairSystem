namespace Hair.Domain.Interfaces
{
    public interface ISaloonItem : IBase
    {
        string Name { get; set; }
        double Price { get; set; }
        int QuantityAvaible { get; set; }
        Guid SaloonId { get; set; }
    }
}