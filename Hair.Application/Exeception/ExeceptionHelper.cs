namespace Hair.Application.Exeception
{
    public class ExeceptionHelper : IExeception
    {
        private readonly int _StatusCode = 400;
        public ExeceptionDto Error(Exception ex) => new(Build(ex));
        private object Build(Exception ex)
        {
            return new
            {
                StatusCode = _StatusCode,
                ex.Message,
                Target = ex.TargetSite
            };
        }
    }
}