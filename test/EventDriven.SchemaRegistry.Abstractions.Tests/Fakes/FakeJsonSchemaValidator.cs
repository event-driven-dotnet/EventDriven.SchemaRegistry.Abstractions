using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;

namespace EventDriven.SchemaRegistry.Abstractions.Tests.Fakes
{
    public class FakeJsonSchemaValidator : ISchemaValidator
    {
        public bool ValidateMessage(string message, string schema, out IList<string> errorMessages)
        {
            var jObject = JObject.Parse(message);
            var jSchema = JSchema.Parse(schema);
            return jObject.IsValid(jSchema, out errorMessages);
        }
    }
}