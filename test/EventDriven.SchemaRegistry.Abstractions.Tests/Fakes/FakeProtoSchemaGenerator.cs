using System;
using ProtoBuf;
using ProtoBuf.Meta;

namespace EventDriven.SchemaRegistry.Abstractions.Tests.Fakes
{
    public class FakeProtoSchemaGenerator : ISchemaGenerator
    {
        public string GenerateSchema(Type messageType) =>
            Serializer.GetProto(new SchemaGenerationOptions { Types = { messageType } });
    }
}