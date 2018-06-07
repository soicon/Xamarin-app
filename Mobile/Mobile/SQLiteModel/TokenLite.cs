using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mobile.SQLiteModel
{
    public class TokenLite
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string UserId { get; set; }
        public string SecretCode { get; set; }
    }
}
