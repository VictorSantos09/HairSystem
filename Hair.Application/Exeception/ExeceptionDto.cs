namespace Hair.Application.Exeception
{
    public class ExeceptionDto
    {
        public int StatusCode { get; set; }
        public object Data { get; set; }

        public ExeceptionDto(object data)
        {
            Data = data;
        }

        public ExeceptionDto(int statusCode, object data)
        {
            StatusCode = statusCode;
            Data = data;
        }
    }
}