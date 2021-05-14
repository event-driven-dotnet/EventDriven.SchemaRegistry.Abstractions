using System.Collections.Generic;
using System.Threading.Tasks;

namespace EventDriven.SchemaRegistry.Abstractions.Tests.Fakes
{
    public class FakeJsonSchemaRegistry : ISchemaRegistry
    {
        private readonly Dictionary<string, Schema> _registry = new();

        public Task<Schema> GetSchema(string topic)
        {
            return _registry.TryGetValue(topic, out var value)
                ? Task.FromResult(value)
                : Task.FromResult<Schema>(null);
        }

        public Task<bool> AddSchema(Schema schema)
        {
            if (_registry.ContainsKey(schema.Topic)) return Task.FromResult(false);
            var result = _registry.TryAdd(schema.Topic, schema);
            return Task.FromResult(result);
        }

        public Task<bool> UpdateSchema(Schema schema)
        {
            if (!_registry.ContainsKey(schema.Topic)) return Task.FromResult(false);
            _registry[schema.Topic] = schema;
            return Task.FromResult(true);
        }

        public Task<bool> RemoveSchema(string topic)
        {
            if (!_registry.ContainsKey(topic)) return Task.FromResult(false);
            var result = _registry.Remove(topic);
            return Task.FromResult(result);
        }
    }
}