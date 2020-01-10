using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace PomodoroAPI.DAL
{
    public class PostPomodoro
    {
        Database db = new Database();
        public void postPomodoro(string ta, int ti)
        {
            db.connection.Open();
            MySqlCommand cmd = db.connection.CreateCommand();
            cmd.CommandText = "INSERT INTO pomodoro(id_tag, timer, date) VALUES (@tag, @tim, @date)";
            cmd.Parameters.AddWithValue("@tag", 1);
            cmd.Parameters.AddWithValue("@tim", ti);
            cmd.Parameters.AddWithValue("@date", DateTime.Now);
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();
        }
    }
}
