using System.Collections.Generic;
using System.Threading.Tasks;

namespace EventDriven.SchemaRegistry.Abstractions.Tests.Fakes
{
    public class FakeJsonSchemaRegistry : ISchemaRegistry
    {
        private readonly Dictionary<string, string> _registry = new();

        public Task<string> GetSchema(string topic)
        {
            return _registry.TryGetValue(topic, out var value)
                ? Task.FromResult(value)
                : Task.FromResult<string>(null);
        }

        public Task AddSchema(string topic, string schema)
        {
            _registry.Add(topic, schema);
            return Task.CompletedTask;
        }

        public Task UpdateSchema(string topic, string schema)
        {
            _registry[topic] = schema;
            return Task.CompletedTask;
        }

        public Task RemoveSchema(string topic)
        {
            _registry.Remove(topic);
            return Task.CompletedTask;
        }
    }
}