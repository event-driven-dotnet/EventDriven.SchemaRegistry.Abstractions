using System.Threading.Tasks;

namespace EventDriven.SchemaRegistry.Abstractions
{
    /// <summary>
    /// Persists schemas by topic name in a key-value store.
    /// </summary>
    public interface ISchemaRegistry
    {
        /// <summary>
        /// Retrieve a schema by topic name from the registry.
        /// </summary>
        /// <param name="topic">Fully qualified topic name.</param>
        /// <returns>Registered schema with task that will complete when the operation has completed.</returns>
        Task<Schema> GetSchema(string topic);

        /// <summary>
        /// Add schema by topic name to the registry.
        /// </summary>
        /// <param name="schema">Schema to add to the registry.</param>
        /// <returns>True if add was successful with task that will complete when the operation has completed.</returns>
        Task<bool> AddSchema(Schema schema);

        /// <summary>
        /// Replace schema registered to specified topic.
        /// </summary>
        /// <param name="schema">Schema to add to the registry.</param>
        /// <returns>True if update was successful with task that will complete when the operation has completed.</returns>
        Task<bool> UpdateSchema(Schema schema);

        /// <summary>
        /// Remove schema registered to specified topic.
        /// </summary>
        /// <param name="topic">Fully qualified topic name</param>
        /// <returns>True if remove was successful with task that will complete when the operation has completed.</returns>
        Task<bool> RemoveSchema(string topic);
    }
}