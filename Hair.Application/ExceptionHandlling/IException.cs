namespace Hair.Application.ExceptionHandlling
{
    public interface IException
    {
        ExceptionDto Error(Exception ex);
    }
}
