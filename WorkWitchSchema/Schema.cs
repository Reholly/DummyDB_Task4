using Newtonsoft.Json;

namespace DummyDB_Task4.WorkWitchSchema
{
    class Schema
    {
        [JsonProperty(PropertyName = "name")]
        public string Name { get; private set; }

        [JsonProperty(PropertyName = "columns")]
        public List<SchemaColumn> Columns { get; private set; } = new List<SchemaColumn>();
    }
}
