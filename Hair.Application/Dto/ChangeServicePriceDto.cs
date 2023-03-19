namespace Hair.Application.Dto
{
    public class ChangeServicePriceDto
    {
        public Guid UserID { get; set; }
        public double NewPrice { get; set; }
        public bool Confirmed { get; set; }

        public ChangeServicePriceDto(Guid userID, double newPrice, bool confirmed)
        {
            UserID = userID;
            NewPrice = newPrice;
            Confirmed = confirmed;
        }
    }
}
