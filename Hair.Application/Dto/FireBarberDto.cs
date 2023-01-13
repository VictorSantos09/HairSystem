namespace Hair.Application.Dto
{
    public class FireBarberDto
    {
        public Guid SaloonId { get; set; }
        public Guid BarberId { get; set; }
        public string BarberName { get; set; }
        public string BarberEmail { get; set; }
        public string SaloonName { get; set; }

        public FireBarberDto(Guid saloonId, Guid barberId, string barberName, string barberEmail, string saloonName)
        {
            SaloonId = saloonId;
            BarberId = barberId;
            BarberName = barberName;
            BarberEmail = barberEmail;
            SaloonName = saloonName;
        }
    }
}
