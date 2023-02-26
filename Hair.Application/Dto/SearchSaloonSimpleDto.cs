namespace Hair.Application.Dto
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
