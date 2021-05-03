namespace EventDriven.SchemaRegistry.Abstractions.Tests.Expected.Json.v1
{
    public static class Person
    {
        public const string Schema = @"{
  ""$id"": ""Person"",
  ""type"": ""object"",
  ""properties"": {
    ""name"": {
      ""type"": [
        ""string"",
        ""null""
      ]
    },
    ""age"": {
      ""type"": [
        ""integer"",
        ""null""
      ]
    }
  },
  ""required"": [
    ""name"",
    ""age""
  ]
}";
    }
}