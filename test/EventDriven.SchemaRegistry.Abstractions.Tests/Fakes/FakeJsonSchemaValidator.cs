using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;

namespace EventDriven.SchemaRegistry.Abstractions.Tests.Fakes
{
    public class FakeJsonSchemaValidator : ISchemaValidator
    {
        public void ValidateSchema(string message, string schema, out IList<string> errorMessages)
        {
            var jObject = JObject.Parse(message);
            var jSchema = JSchema.Parse(schema);
            jObject.IsValid(jSchema, out errorMessages);
        }
    }
}