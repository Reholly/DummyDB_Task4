namespace DummyDB_Task4
{
    class TableCreator
    {
        public static Table CreateTable(string tableName, Schema schema, string[] fileLines, string allTablesPath)
        {
            List<Row> rows = new List<Row>();

            //Идем с 1 строки, ибо на 0 у нас названия колонок.
            for(int i = 1; i < fileLines.Length; i++)
            {
                
                string[] lineElements = fileLines[i].Split(";");
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
