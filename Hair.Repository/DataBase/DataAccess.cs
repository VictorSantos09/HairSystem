namespace Hair.Repository.DataBase
{
    /// <summary>
    /// Classe criada no intuito de estabelecer a conexão com a base de dados SQL.
    /// Data Source = nome da instância do banco atual;
    /// Initial catalog = nome do arquivo .bak da base de dados;
    /// User: usuário da instância;
    /// Password = senha da instância.
    /// </summary>
    public class DataAccess
    {
        public const string DBConnection = (@"Data Source=; Initial catalog=; User=;Password=;");
    }
}