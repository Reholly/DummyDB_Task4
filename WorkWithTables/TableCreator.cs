using DummyDB_Task4.WorkWitchSchema;

namespace DummyDB_Task4.WorkWithTables
{
    class TableCreator
    {
        public static Table CreateTableByFile(string tableName, Schema schema, string[] content)
        {
            List<Row> rows = new List<Row>();

            //Идем с 1 строки, ибо на 0 у нас названия колонок.
            for (int i = 1; i < content.Length; i++)
            {

                string[] lineElements = content[i].Split(";");

                Row row = new Row();

                for (int j = 0; j < lineElements.Length; j++)
                {
                    row.Data.Add(schema.Columns[j], GetValue(lineElements[j], schema.Columns[j]));
                }

                rows.Add(row);
            }

            return new Table(tableName, rows, schema);
        }

        private static object GetValue(string value, SchemaColumn column)
        {
            switch (column.Type)
            {
                case "int":
                    return int.Parse(value);
                case "float":
                    return float.Parse(value);
                case "dateTime":
                    return DateTime.Parse(value);
                case "bool":
                    return bool.Parse(value);
                default:
                    return value;
            }
        }
    }
}
