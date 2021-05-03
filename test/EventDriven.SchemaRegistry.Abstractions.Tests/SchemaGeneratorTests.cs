using EventDriven.SchemaRegistry.Abstractions.Tests.Fakes;
using EventDriven.SchemaRegistry.Abstractions.Tests.Schemas.Json.v1;
using Newtonsoft.Json.Schema.Generation;
using Newtonsoft.Json.Serialization;
using Xunit;
using JsonModels = EventDriven.SchemaRegistry.Abstractions.Tests.Models.Json;

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
            Assert.Equal(Person.Expected, schema);
        }
    }
}