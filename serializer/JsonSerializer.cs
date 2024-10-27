using Newtonsoft.Json;
using QuizTopEx.models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizTopEx.serializer
{
    public class JsonSerializer<TValue> : IJsonSerializer<TValue>
    {
        public string FileName { get; private set; }

        public JsonSerializer(string filename)
        {
            FileName = filename;
        }

        public void Save(List<TValue> items)
        {
            if (items == null)
                throw new ArgumentNullException(nameof(items));

            try
            {
                string json = JsonConvert.SerializeObject(items);
                File.WriteAllText(FileName, json);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при сохранении: {ex.Message}");
            }
        }
        public void Save(User user)
        {
            try
            {
                string json = JsonConvert.SerializeObject(user);
                File.WriteAllText(FileName, json);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при сохранении: {ex.Message}");
            }
        }
        public List<TValue> Load()
        {
            if (!File.Exists(FileName))
            {
                Console.WriteLine($"Файл не найден: {FileName}");
                return new List<TValue>();
            }

            string json = string.Empty;

            try
            {
                json = File.ReadAllText(FileName);
                return JsonConvert.DeserializeObject<List<TValue>>(json);
            }
            catch (JsonException jsonEx)
            {
                Console.WriteLine($"Ошибка десериализации: {jsonEx.Message}");
                return new List<TValue>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
                return new List<TValue>();
            }
        }
    }
}
