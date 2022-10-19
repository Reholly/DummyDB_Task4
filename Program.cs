using Newtonsoft.Json;

namespace DummyDB_Task4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Schema schema = JsonConvert.DeserializeObject<Schema>(File.ReadAllText());
        }
    }
}