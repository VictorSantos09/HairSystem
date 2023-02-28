namespace Hair.Application.ExceptionHandlling
{
    public class ExceptionDto
    {
        public int _StatusCode { get; set; }
        public object _Data { get; set; }

        public ExceptionDto(int statusCode, object data)
        {
            _StatusCode = statusCode;
            _Data = data;
        }
    }
}