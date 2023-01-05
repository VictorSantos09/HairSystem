namespace Hair.Application.Dto
{
    public class ChangePriceDto
    {
        public Guid SaloonId { get; set; }
        public double NewPrice { get; set; }
        public bool Hair { get; set; }
        public bool Beard { get; set; }
        public bool Mustache { get; set; }
        public bool Confirmed { get; set; }

        public ChangePriceDto(Guid saloonId, double newPrice, bool hair, bool beard, bool mustache, bool confirmed)
        {
            SaloonId = saloonId;
            NewPrice = newPrice;
            Hair = hair;
            Beard = beard;
            Mustache = mustache;
            Confirmed = confirmed;
        }
    }
}
