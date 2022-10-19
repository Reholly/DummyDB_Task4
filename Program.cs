using DummyDB_Task4.WorkWitchSchema;
using DummyDB_Task4.WorkWithTables;
using Newtonsoft.Json;

namespace DummyDB_Task4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
                Создаю тестовый csv файл на основе Схемы. Там делаю первую тестовую строку. 
                Затем методом делаю на оснвое таблицы уже файл.
            */
            string pathOfProject = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
            Schema schema = JsonConvert.DeserializeObject<Schema>(File.ReadAllText(String.Concat(pathOfProject, "//Schemas//book.json")));

            List<Row> rows = new List<Row>();

            Row row1 = new Row();
            row1.Data.Add(schema.Columns[0], 1);
            row1.Data.Add(schema.Columns[1], "War And Piece");
            row1.Data.Add(schema.Columns[2], 245);

            rows.Add(row1);

            Table tasble = new Table(schema.Name, rows, schema);

            DataWriter.CreateFileByTable(tasble, String.Concat(pathOfProject, "//Data//", schema.Name, ".csv"));

        }
    }
}