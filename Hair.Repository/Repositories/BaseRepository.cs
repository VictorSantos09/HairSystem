using Domain.Entities;
using System.Text.Json;

namespace Repository.Repository
{
    public class BaseRepository<T> where T : BaseEntity
    {
        private readonly string _pathFile;

        public BaseRepository(string pathFile)
        {
            _pathFile = $@"{Directory.GetCurrentDirectory()}..\..\Hair.Repository\DataBase\{pathFile}.json";
        }

        public void Add(T entity)
        {
            var list = GetAll();

            list.Add(entity);

            string json = JsonSerializer.Serialize(list);
            File.WriteAllText(_pathFile, json);
        }
        public List<T> GetAll()
        {
            using (StreamReader r = new StreamReader(_pathFile))
            {
                string json = r.ReadToEnd();

                if (string.IsNullOrWhiteSpace(json))
                {
                    return new List<T>();
                }

                return JsonSerializer.Deserialize<List<T>>(json);
            }
        }
        public T? GetById(Guid id)
        {
            return GetAll().Find(x => x.Id == id);
        }
        public void Remove(Guid id)
        {
            var list = GetAll();

            var entity = list.Find(x => x.Id == id);

            if (entity == null)
                return;

            list.Remove(entity);

            string json = JsonSerializer.Serialize(list);
            File.WriteAllText(_pathFile, json);
        }
        public void Update(Guid id, T newEntity)
        {
            var list = GetAll();

            var entity = list.Find(x => x.Id == id);

            if (entity == null)
                return;

            list.Remove(entity);

            list.Add(newEntity);

            string json = JsonSerializer.Serialize(list);
            File.WriteAllText(_pathFile, json);
        }
    }
}
