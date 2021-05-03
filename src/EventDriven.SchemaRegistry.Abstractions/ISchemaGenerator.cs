using System;

namespace EventDriven.SchemaRegistry.Abstractions
{
    /// <summary>
    /// Generates default schemas based on message structure.
    /// </summary>
    public interface ISchemaGenerator
    {
        /// <summary>
        /// Generate default schemas based on message structure.
        /// </summary>
        /// <param name="messageType">Message type from which to generate a schema.</param>
        /// <returns>Generated schema.</returns>
        string GenerateSchema(Type messageType);
    }
}