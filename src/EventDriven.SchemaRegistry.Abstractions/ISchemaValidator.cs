using System.Collections.Generic;

namespace EventDriven.SchemaRegistry.Abstractions
{
    /// <summary>
    /// Validates messages by applying supplied schema.
    /// </summary>
    public interface ISchemaValidator
    {
        /// <summary>
        /// Validate messages by applying supplied schema.
        /// </summary>
        /// <param name="message">Message to validate against supplied schema.</param>
        /// <param name="schema">Schema for validating message.</param>
        /// <param name="errorMessages">Error messages generated while validating.</param>
        void ValidateSchema(string message, string schema, out IList<string> errorMessages);
    }
}