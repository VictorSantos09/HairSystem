namespace Hair.Application.Dto
{
    public class ChangeBarberSalaryDto
    {
        public Guid SaloonId { get; set; }
        public Guid BarberId { get; set; }
        public string BarberName { get; set; }
        public double NewSalary { get; set; }

        public ChangeBarberSalaryDto(Guid saloonId, Guid barberId, string barberName, double newSalary)
        {
            SaloonId = saloonId;
            BarberId = barberId;
            BarberName = barberName;
            NewSalary = newSalary;
        }
    }
}
