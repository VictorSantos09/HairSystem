namespace Hair.Application.Exeception
{
    public interface IException
    {
        ExceptionDto Error(Exception ex);
    }
}
