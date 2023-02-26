namespace Hair.Domain.Interfaces
{
    public interface IHaircutPrice
    {
        double? Beard { get; set; }
        double Hair { get; set; }
        double? Mustache { get; set; }
    }
}