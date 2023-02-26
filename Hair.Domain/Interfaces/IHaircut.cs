namespace Hair.Domain.Interfaces
{
    public interface IHaircut : IBase
    {
        bool Avaible { get; set; }
        IClient Client { get; set; }
        DateTime HaircuteTime { get; set; }
        Guid SaloonId { get; set; }
    }
}