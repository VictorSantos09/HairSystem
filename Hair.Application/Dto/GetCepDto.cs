namespace Hair.Application.Dto
{
    public class GetCepDto
    {
        public string Code { get; set; }

        public GetCepDto(string code)
        {
            Code = code;
        }
    }
}