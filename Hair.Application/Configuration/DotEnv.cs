using Hair.Repository.Security;

namespace Hair.Application.Configuration
{
    public class DotEnv
    {
        public static void Load(string filePath)
        {
            if (!File.Exists(filePath))
            {
                Console.WriteLine($"Arquivo .env não encontrado no diretório {filePath}");
            }
            else
            {
                foreach (var line in File.ReadAllLines(filePath))
                {
                    var parts = line.Split(
                        '=',
                        StringSplitOptions.RemoveEmptyEntries);

                    if (parts.Length != 2)
                        continue;

                    Environment.SetEnvironmentVariable(parts[0], parts[1]);
                }

                Console.WriteLine("Arquivo .env encontrado");
            }
        }
    }
}
