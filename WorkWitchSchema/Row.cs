namespace DummyDB_Task4.WorkWitchSchema
{
    class Row
    {
        public Dictionary<SchemaColumn, object> Data { get; private set; } = new Dictionary<SchemaColumn, object>();
    }
}
