using EventDriven.SchemaRegistry.Abstractions.Tests.Fakes;
using Newtonsoft.Json.Schema.Generation;
using Newtonsoft.Json.Serialization;
using Xunit;
using JsonModels = EventDriven.SchemaRegistry.Abstractions.Tests.Models.Json;
using ProtoModels = EventDriven.SchemaRegistry.Abstractions.Tests.Models.Proto;

namespace EventDriven.SchemaRegistry.Abstractions.Tests
{
    public class SchemaGeneratorTests
    {
        [Fact]
        public void Json_SchemaGenerator_Should_Generate_Schema()
        {
            // Arrange
            var jsonSchemaGenerator = new JSchemaGenerator
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
                SchemaIdGenerationHandling = SchemaIdGenerationHandling.TypeName
            };
            var schemaGenerator = new FakeJsonSchemaGenerator(jsonSchemaGenerator);

            // Act
            var schema = schemaGenerator.GenerateSchema(typeof(JsonModels.v1.Person));

            // Assert
            Assert.Equal(Expected.Json.v1.Person.Schema, schema);
        }

        [Fact]
        public void Proto_SchemaGenerator_Should_Generate_Schema()
        {
            // Arrange
            var schemaGenerator = new FakeProtoSchemaGenerator();

            // Act
            var schema = schemaGenerator.GenerateSchema(typeof(ProtoModels.v1.Person));

            // Assert
            Assert.Equal(Expected.Proto.v1.Person.Schema, schema);
        }
    }
}