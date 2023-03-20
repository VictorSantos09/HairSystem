namespace Hair.Application.Dto.ClientCases
{
    public class SearchSaloonSimpleDto
    {
        public string SaloonName { get; set; }

        public SearchSaloonSimpleDto(string saloonName)
        {
            SaloonName = saloonName.ToUpper();
        }
    }
}
