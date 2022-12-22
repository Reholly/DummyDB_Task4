using DummyDB_Task4.WorkWitchSchema;
using DummyDB_Task4.WorkWithTables;
using Newtonsoft.Json;

namespace DummyDB_Task4
{
    class DataWork
    {
        public static void CreateFileBySchema(List<string> content, Schema schema, string path)
        {
            try
            {
                content.Insert(0, GetTableHeader(schema));
                if (!SchemaValidator.IsValidToSchema(content.ToArray(), schema))
                {
                    return;
                }
                else
                {                 
                    File.WriteAllLines(path, content);
                }
            }
            catch(FormatException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static void CreateFileByTable(Table table, string path)
        {
            List<string> lines = new List<string>();

            string header = GetTableHeader(table.Schema);

            lines.Add(header);

            foreach (var value in table.Rows)
            {
                lines.Add(String.Join(";", value.Data.Values));
            }

            File.WriteAllLines(path, lines.ToArray());
        }

        public static void AppendLineToFile(string line, Schema schema, string path)
        {
            try
            {
                if (!SchemaValidator.IsValidToSchema(line, schema))
                {
                    return;
                }
                else
                {
                    string[] lines = new string[] { line };
                    File.AppendAllLines(path, lines);
                }
            }
            catch(FormatException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static string[] GetFileContent(string filePath)
        {
            return File.ReadAllLines(filePath);
        }

        public static Schema GetSchema(string schemaPath)
        {
            return JsonConvert.DeserializeObject<Schema>(File.ReadAllText(schemaPath));
        }

        private static string GetTableHeader(Schema schema)
        {
            List<string> columnsNames = new List<string>();

            foreach(SchemaColumn column in schema.Columns)
            {
                columnsNames.Add(column.Name);
            }

            return String.Join(";", columnsNames);            
        }
    }
}
