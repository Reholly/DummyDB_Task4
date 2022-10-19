namespace DummyDB_Task4
{
    class Table
    {
        public string Name { get; private set; }
        public List<Row> Rows { get; private set; }
        public Schema Schema { get; private set; }

        public Table(string name, List<Row> rows, Schema schema)
        {
            Name = name;
            Rows = rows;    
            Schema = schema;
        }
    }
}
