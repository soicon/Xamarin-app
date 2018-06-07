using Mobile.SQLiteModel;
using SQLite;
using System.Linq;

namespace Mobile.Repository
{
    public class UserRepository
    {
        private SQLiteConnection _connection;
        public UserRepository(SQLiteConnection connection)
        {
            _connection = connection;
            _connection.CreateTable<UserLite>();
        }
        /// <summary>
        /// Create user
        /// </summary>
        /// <param name="UserLite"></param>
        public void Create(UserLite UserLite)
        {
            _connection.Insert(UserLite);
            _connection.Commit();
        }
        /// <summary>
        /// Delete user
        /// </summary>
        /// <param name="UserLite"></param>
        public void Delete(UserLite UserLite)
        {
            _connection.Delete(UserLite);
            _connection.Commit();
        }
        /// <summary>
        /// Get user by id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public UserLite Get(int Id)
        {
            var query = from c in _connection.Table<UserLite>()
                        where c.Id == Id
                        select c;

            return query.FirstOrDefault();
        }
        /// <summary>
        /// Get all user
        /// </summary>
        /// <returns></returns>
        public System.Collections.Generic.List<UserLite> GetAll()
        {
            var query = from c in _connection.Table<UserLite>()
                        select c;
            return query.ToList();
        }
        /// <summary>
        /// Update User
        /// </summary>
        /// <param name="UserLite"></param>
        public void Update(UserLite UserLite)
        {
            _connection.Update(UserLite);
            _connection.Commit();
        }
    }
}
