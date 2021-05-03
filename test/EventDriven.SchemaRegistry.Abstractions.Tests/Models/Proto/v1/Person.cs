using ProtoBuf;

namespace EventDriven.SchemaRegistry.Abstractions.Tests.Models.Proto.v1
{
    [ProtoContract]
    public class Person
    {
        [ProtoMember(1)]
        public string Name { get; set; }
        [ProtoMember(2)]
        public int? Age { get; set; }
    }
}