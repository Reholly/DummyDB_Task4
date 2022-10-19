using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace DummyDB_Task4.WorkWitchSchema
{
    class SchemaValidator
    {
        public static bool IsValidToSchema(string[] lines, Schema schema)
        {
            //начинаем с 1 строки, а не с нулевой ибо 1 строка у нас это названия колонок
            for (int i = 1; i < lines.Length; i++)
            {
                string[] lineElements = lines[i].Split(";");
                for (int j = 0; j < schema.Columns.Count; j++)
                {
                    string lineElement = lineElements[j];

                    switch (schema.Columns[j].Type)
                    {
                        case "int":
                            if (!int.TryParse(lineElement, out var integer))
                            {
                                DisplayErrorMessage(i, j, lineElements);

                                return false;
                            }
                            break;
                        case "bool":
                            if (!bool.TryParse(lineElement, out var boolean))
                            {
                                DisplayErrorMessage(i, j, lineElements);
                                return false;
                            }
                            break;
                        case "dateTime":
                            if (!DateTime.TryParse(lineElement, out var date))
                            {
                                DisplayErrorMessage(i, j, lineElements);
                                return false;
                            }
                            break;
                        default:
                            break;
                    }
                }
            }
            return true && IsColumnsValid(lines[0], schema);
        }

        public static bool IsValidToSchema(string line, Schema schema)
        {
            string[] lineElements = line.Split(";");
            for (int j = 0; j < schema.Columns.Count; j++)
            {
                string lineElement = lineElements[j];

                switch (schema.Columns[j].Type)
                {
                    case "int":
                        if (!int.TryParse(lineElement, out var integer))
                        {
                            DisplayErrorMessage(j, lineElements);

                            return false;
                        }
                        break;
                    case "bool":
                        if (!bool.TryParse(lineElement, out var boolean))
                        {
                            DisplayErrorMessage(j, lineElements);
                            return false;
                        }
                        break;
                    case "dateTime":
                        if (!DateTime.TryParse(lineElement, out var date))
                        {
                            DisplayErrorMessage(j, lineElements);
                            return false;
                        }
                        break;
                    default:
                        break;
                }
            }

            return true;
        }
        public static Schema GetSchema(string path)
        {
            return JsonConvert.DeserializeObject<Schema>(File.ReadAllText(path));
        }

        private static bool IsColumnsValid(string columns, Schema schema)
        {
            string[] columnsElements = columns.Split(";");
            for (int i = 0; i < columnsElements.Length; i++)
            {
                if (!(columnsElements[i] == schema.Columns[i].Name))
                {
                    DisplayErrorMessage(0, 0, columnsElements);
                    return false;
                }
            }
            return true;
        }

        private static void DisplayErrorMessage(int raw, int column, string[] line)
        {
            string errorAccured = $"Error accured! In raw {raw} and column {column} wrong Type!\n";
            string correctionInfo = $"In line: {raw} element: {line[column]}";

            throw new FormatException(string.Concat(errorAccured, correctionInfo));
        }

        private static void DisplayErrorMessage(int column, string[] line)
        {
            string errorAccured = $"Error accured! In column {column} and element: {line[column]}";
            string correctionInfo = $"In column: {column} element: {line[column]}";

            throw new FormatException(string.Concat(errorAccured, correctionInfo));
        }
    }
}
