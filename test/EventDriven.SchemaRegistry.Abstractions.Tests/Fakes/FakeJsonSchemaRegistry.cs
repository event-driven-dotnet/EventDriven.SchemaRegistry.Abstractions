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

        public Task<bool> AddSchema(string topic, string schema)
        {
            if (_registry.ContainsKey(topic)) return Task.FromResult(false);
            var result = _registry.TryAdd(topic, schema);
            return Task.FromResult(result);
        }

        public Task<bool> UpdateSchema(string topic, string schema)
        {
            if (!_registry.ContainsKey(topic)) return Task.FromResult(false);
            _registry[topic] = schema;
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