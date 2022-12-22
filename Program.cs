using DummyDB_Task4.WorkWitchSchema;
using DummyDB_Task4.WorkWithTables;
using Newtonsoft.Json;

namespace DummyDB_Task4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string projectPath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;

            string schemasPath = String.Concat(projectPath, "//Schemas//");
            string dataPath = String.Concat(projectPath, "//Data//");

            string userSchemaName = InputJsonSchemaName();
            string neededSchemaPath = String.Concat(schemasPath, userSchemaName);

            Schema schema = DataWork.GetSchema(neededSchemaPath);

            //Здесь создание тестовой таблицы на основе схемы
            Table table = CreateTestTable(schema);

            string csvFilePath = String.Concat(dataPath, schema.Name, ".csv");
            DataWork.CreateFileByTable(table, csvFilePath);
            
            //Здесь считывается из файла все в таблицу
            Table readTable = TableCreator.CreateTableByFile(schema.Name, schema, DataWork.GetFileContent(csvFilePath));        
            DisplayTestTable(readTable);
        }

        private static string InputJsonSchemaName()
        {
            Console.WriteLine("Введите название json-схемы (пример: book.json):");
            string userSchemaName = Console.ReadLine();

            return userSchemaName;
        }

        private static Table CreateTestTable(Schema schema)
        {
            List<Row> rows = new List<Row>();

            Row row1 = new Row();

            // 0 - id; 1 - name; 2 - cost
            row1.Data.Add(schema.Columns[0], 1);
            row1.Data.Add(schema.Columns[1], "War And Piece");
            row1.Data.Add(schema.Columns[2], 245);

            rows.Add(row1);

            Table table = new Table(schema.Name, rows, schema);

            return table;
        }

        private static void DisplayTestTable(Table table)
        {
            Console.WriteLine(table.Name);
           
            foreach(Row row in table.Rows)
            {
                Console.WriteLine($"{row.ToString()}");
            }
        }
    }
}