namespace Hair.Application.ExceptionHandler
{
    public interface IException
    {
        ExceptionDto Error(Exception ex);
    }
}
