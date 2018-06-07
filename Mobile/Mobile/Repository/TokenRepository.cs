using Mobile.Common;
using Mobile.SQLiteModel;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mobile.Repository
{
    public class TokenRepository
    {
        private SQLiteConnection _connection;
        public TokenRepository(SQLiteConnection connection)
        {
            _connection = connection;
            _connection.CreateTable<TokenLite>();
        }
        /// <summary>
        /// Create Report
        /// </summary>
        /// <param name="TokenLite"></param>
        public void Create(TokenLite TokenLite)
        {
            _connection.Insert(TokenLite);
            _connection.Commit();
        }
        /// <summary>
        /// Delete Report
        /// </summary>
        /// <param name="TokenLite"></param>
        public void Delete(TokenLite TokenLite)
        {
            _connection.Delete(TokenLite);
            _connection.Commit();
        }
        /// <summary>
        /// Get Report
        /// </summary>
        /// <param name="ReportId"></param>
        /// <returns></returns>
        public TokenLite Get(string email)
        {
            string encryptEmail = VikingCommonHelper.VikingEncodeData.Encrypt(email, true, CommonConstant.DefaultSecureKey);
            var query = from c in _connection.Table<TokenLite>()
                        where c.UserId.Equals(encryptEmail)
                        select c;
            TokenLite tokenLite = query.FirstOrDefault();
            return tokenLite;
        }
        public TokenLite GetLastLogin()
        {
            var query = from c in _connection.Table<TokenLite>()
                        orderby c.Id descending
                        select c;
            TokenLite tokenLite = query.FirstOrDefault();
            if (tokenLite != null)
            {
                string email = tokenLite.UserId;
                tokenLite.UserId = VikingCommonHelper.VikingEncodeData.Decrypt(email, true, CommonConstant.DefaultSecureKey);
            }
            return tokenLite;
        }
    }
}
