using System;
using Newtonsoft.Json.Schema.Generation;

namespace EventDriven.SchemaRegistry.Abstractions.Tests.Fakes
{
    public class FakeJsonSchemaGenerator : ISchemaGenerator
    {
        private readonly JSchemaGenerator _jsonSchemaGenerator;

        public FakeJsonSchemaGenerator(JSchemaGenerator jsonSchemaGenerator)
        {
            _jsonSchemaGenerator = jsonSchemaGenerator;
        }

        public string GenerateSchema(Type messageType) =>
            _jsonSchemaGenerator.Generate(messageType).ToString();
    }
}