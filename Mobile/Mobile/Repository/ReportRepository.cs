using Mobile.SQLiteModel;
using SQLite;
using System.Linq;

namespace Mobile.Repository
{
    public class ReportRepository
    {
        private SQLiteConnection _connection;
        public ReportRepository(SQLiteConnection connection)
        {
            _connection = connection;
            _connection.CreateTable<ReportLite>();
        }
        /// <summary>
        /// Create Report
        /// </summary>
        /// <param name="reportLite"></param>
        public void Create(ReportLite reportLite)
        {
            _connection.Insert(reportLite);
            _connection.Commit();
        }
        /// <summary>
        /// Delete Report
        /// </summary>
        /// <param name="reportLite"></param>
        public void Delete(ReportLite reportLite)
        {
            _connection.Delete(reportLite);
            _connection.Commit();
        }
        /// <summary>
        /// Get Report
        /// </summary>
        /// <param name="ReportId"></param>
        /// <returns></returns>
        public ReportLite Get(int ReportId)
        {
            var query = from c in _connection.Table<ReportLite>()
                        where c.ReportId == ReportId
                        select c;

            return query.FirstOrDefault();
        }
        /// <summary>
        /// List all report
        /// </summary>
        /// <returns></returns>
        public System.Collections.Generic.List<ReportLite> GetAll()
        {
            var query = from c in _connection.Table<ReportLite>()
                        select c;
            return query.ToList();
        }
        /// <summary>
        /// Update Report
        /// </summary>
        /// <param name="reportLite"></param>
        public void Update(ReportLite reportLite)
        {
            _connection.Update(reportLite);
            _connection.Commit();
        }
    }
}
