namespace Hair.Application.Dto.ClientCases
{
    public class SearchSaloonFilterDto
    {
        public string City { get; set; }
        public string Street { get; set; }
        public bool OnlyOpens { get; set; }

        public SearchSaloonFilterDto(string city, string street, bool onlyOpens)
        {
            City = city.ToUpper();
            Street = street.ToUpper();
            OnlyOpens = onlyOpens;
        }
    }
}
