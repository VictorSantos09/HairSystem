namespace Hair.Application.Exeception
{
    public interface IExeception
    {
        ExeceptionDto Error(Exception ex);
    }
}
