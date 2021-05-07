using EventDriven.SchemaRegistry.Abstractions.Tests.Fakes;
using EventDriven.SchemaRegistry.Abstractions.Tests.Models.Json.v1;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Xunit;

namespace EventDriven.SchemaRegistry.Abstractions.Tests
{
    public class SchemaValidatorTests
    {
        [Fact]
        public void Json_SchemaValidator_Should_Validate_Schema()
        {
            // Arrange
            var schemaValidator = new FakeJsonSchemaValidator();
            var person = new Person {Name = "Yoda", Age = 900};
            var settings = new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
                Formatting = Formatting.Indented
            };
            var json = JsonConvert.SerializeObject(person, settings);

            // Act
            var result = schemaValidator.ValidateMessage(json, 
                Schemas.Json.v1.Person.Expected, out var errorMessages);

            // Assert
            Assert.True(result);
            Assert.Empty(errorMessages);
        }
    }
}