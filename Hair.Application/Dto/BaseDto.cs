namespace Application.Dto
{
    public class BaseDto
    {
        public int _StatusCode { get; set; }
        public string _Message { get; set; }
        public object _Data { get; set; }

        public BaseDto(int statusCode, object data)
        {
            _StatusCode = statusCode;
            _Data = data;
        }

        public BaseDto(int statusCode, string message)
        {
            _StatusCode = statusCode;
            _Message = message;
        }

        public BaseDto(int statusCode, string message, object data)
        {
            _Data = data;
            _StatusCode = statusCode;
            _Message = message;
        }
    }
}
