namespace EventDriven.SchemaRegistry.Abstractions.Tests.Expected.Proto.v1
{
    public static class Person
    {
        public const string Schema = @"syntax = ""proto3"";
package EventDriven.SchemaRegistry.Abstractions.Tests.Models.Proto.v1;

message Person {
   string Name = 1;
   int32 Age = 2;
}
";
    }
}