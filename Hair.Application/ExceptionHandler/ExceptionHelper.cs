namespace Hair.Application.ExceptionHandler
{
    public class ExceptionHelper : IException
    {
        private readonly int _StatusCode = 400;
        public ExceptionDto Error(Exception e) => new ExceptionDto(_StatusCode, BuildData(e));
        public object BuildData(Exception e)
        {
            return new
            {
                e.HResult,
                e.Message,
                e.InnerException,
                e.StackTrace,
                _StatusCode
            };
        }
    }
}