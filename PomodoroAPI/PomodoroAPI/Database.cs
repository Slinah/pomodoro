using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace PomodoroAPI
{
    public class Database
    {
        public MySqlConnection connection;

        public Database()
        {
            this.InitConnexion();
        }

        private void InitConnexion()
        {
            string cstr = "SERVER=127.0.0.1; PORT=3308; DATABASE=pomodoro; UID=root; PASSWORD=";
            this.connection = new MySqlConnection(cstr);
        }
    }
}
