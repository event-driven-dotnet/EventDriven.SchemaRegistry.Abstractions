namespace EventDriven.SchemaRegistry.Abstractions
{
    /// <summary>
    /// Message schema.
    /// </summary>
    public class Schema
    {
        /// <summary>
        /// Fully qualified schema topic.
        /// </summary>
        public string Topic { get; set; }

        /// <summary>
        /// Schema content represented as a string.
        /// </summary>
        public string Content { get; set; }
    }
}