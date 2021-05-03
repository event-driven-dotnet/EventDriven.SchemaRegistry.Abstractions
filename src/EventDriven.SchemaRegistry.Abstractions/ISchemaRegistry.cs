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
        Task<string> GetSchema(string topic);

        /// <summary>
        /// Add schema by topic name to the registry.
        /// </summary>
        /// <param name="topic">Fully qualified topic name</param>
        /// <param name="schema">Schema to add to the registry.</param>
        /// <returns>Task that will complete when the operation has completed.</returns>
        Task AddSchema(string topic, string schema);

        /// <summary>
        /// Replace schema registered to specified topic.
        /// </summary>
        /// <param name="topic">Fully qualified topic name</param>
        /// <param name="schema">Schema to add to the registry.</param>
        /// <returns>Task that will complete when the operation has completed.</returns>
        Task UpdateSchema(string topic, string schema);

        /// <summary>
        /// Remove schema registered to specified topic.
        /// </summary>
        /// <param name="topic">Fully qualified topic name</param>
        /// <returns>Task that will complete when the operation has completed.</returns>
        Task RemoveSchema(string topic);
    }
}