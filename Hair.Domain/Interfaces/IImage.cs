namespace Hair.Domain.Interfaces
{
    public interface IImage : IBase
    {
        byte[] Img { get; set; }
        Guid SaloonId { get; set; }
    }
}