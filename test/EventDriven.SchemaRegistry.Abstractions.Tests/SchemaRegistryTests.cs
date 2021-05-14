using System.Threading.Tasks;
using EventDriven.SchemaRegistry.Abstractions.Tests.Fakes;
using EventDriven.SchemaRegistry.Abstractions.Tests.Models.Json.v1;
using Xunit;

namespace EventDriven.SchemaRegistry.Abstractions.Tests
{
    public class SchemaRegistryTests
    {
        [Fact]
        public async Task Json_SchemaRegistry_Should_Get_Schema()
        {
            // Arrange
            var schemaRegistry = new FakeJsonSchemaRegistry();
            var topic = $"v1.{nameof(Person)}";
            await schemaRegistry.AddSchema(new Schema
            {
                Topic =  topic,
                Content = Schemas.Json.v1.Person.Expected
            });

            // Act
            var schema = await schemaRegistry.GetSchema(topic);

            // Assert
            Assert.Equal(topic, schema.Topic);
            Assert.Equal(Schemas.Json.v1.Person.Expected, schema.Content);
        }
        
        [Fact]
        public async Task Json_SchemaRegistry_Should_Add_Schema()
        {
            // Arrange
            var schemaRegistry = new FakeJsonSchemaRegistry();

            // Act
            var topic = $"v1.{nameof(Person)}";
            var result = await schemaRegistry.AddSchema(new Schema
            {
                Topic =  topic,
                Content = Schemas.Json.v1.Person.Expected
            });

            // Assert
            Assert.True(result);
            var schema = await schemaRegistry.GetSchema(topic);
            Assert.Equal(topic, schema.Topic);
            Assert.Equal(Schemas.Json.v1.Person.Expected, schema.Content);
        }
        
        [Fact]
        public async Task Json_SchemaRegistry_Should_Update_Schema()
        {
            // Arrange
            var schemaRegistry = new FakeJsonSchemaRegistry();
            var topic = $"v1.{nameof(Person)}";
            await schemaRegistry.AddSchema(new Schema
            {
                Topic =  topic,
                Content = Schemas.Json.v1.Person.Expected
            });

            // Act
            var result = await schemaRegistry.UpdateSchema(new Schema
            {
                Topic =  topic,
                Content = Schemas.Json.v2.Person.Expected
            });

            // Assert
            Assert.True(result);
            var schema = await schemaRegistry.GetSchema(topic);
            Assert.Equal(topic, schema.Topic);
            Assert.Equal(Schemas.Json.v2.Person.Expected, schema.Content);
        }
        
        [Fact]
        public async Task Json_SchemaRegistry_Should_Remove_Schema()
        {
            // Arrange
            var schemaRegistry = new FakeJsonSchemaRegistry();
            var topic = $"v1.{nameof(Person)}";
            await schemaRegistry.AddSchema(new Schema
            {
                Topic =  topic,
                Content = Schemas.Json.v1.Person.Expected
            });

            // Act
            var result = await schemaRegistry.RemoveSchema(topic);

            // Assert
            Assert.True(result);
            var schema = await schemaRegistry.GetSchema(topic);
            Assert.Null(schema);
        }
    }
}