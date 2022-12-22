using System.Text;

namespace DummyDB_Task4.WorkWitchSchema
{
    class Row
    {
        public Dictionary<SchemaColumn, object> Data { get; private set; } = new Dictionary<SchemaColumn, object>();


        public override string ToString()
        {
            StringBuilder row = new StringBuilder();

            foreach(var data in Data)
            {
                row.Append($"{data.Key.Name} : {data.Value.ToString()}; ");
            }

            return row.ToString();
        }
    }
}
