using Mobile.SQLiteModel;
using SQLite;
using System.Linq;

namespace Mobile.Repository
{
    public class EventRepository
    {
        private SQLiteConnection _connection;
        public EventRepository(SQLiteConnection connection)
        {
            _connection = connection;
            _connection.CreateTable<EventLite>();
        }
        /// <summary>
        /// Create Report
        /// </summary>
        /// <param name="EventLite"></param>
        public void Create(EventLite EventLite)
        {
            _connection.Insert(EventLite);
            _connection.Commit();
        }
        /// <summary>
        /// Delete Report
        /// </summary>
        /// <param name="EventLite"></param>
        public void Delete(EventLite EventLite)
        {
            _connection.Delete(EventLite);
            _connection.Commit();
        }
        /// <summary>
        /// Get Report
        /// </summary>
        /// <param name="EventId"></param>
        /// <returns></returns>
        public EventLite Get(int EventId)
        {
            var query = from c in _connection.Table<EventLite>()
                        where c.EventId == EventId
                        select c;

            return query.FirstOrDefault();
        }
        /// <summary>
        /// List all report
        /// </summary>
        /// <returns></returns>
        public System.Collections.Generic.List<EventLite> GetAll()
        {
            var query = from c in _connection.Table<EventLite>()
                        select c;
            return query.ToList();
        }
        /// <summary>
        /// Update Report
        /// </summary>
        /// <param name="EventLite"></param>
        public void Update(EventLite EventLite)
        {
            _connection.Update(EventLite);
            _connection.Commit();
        }
    }
}
