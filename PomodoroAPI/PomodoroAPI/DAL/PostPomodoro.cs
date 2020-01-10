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

        /// <summary>
        /// Pomodoro method to insert datas
        /// </summary>
        /// <param name="p">Pomodoro Object</param>
        public void insertPomodoro(Pomodoro p)
        {
            db.connection.Open();
            MySqlCommand cmd = db.connection.CreateCommand();
            cmd.CommandText = "INSERT INTO pomodoro(id_tag, timer, date) VALUES (@tag, @tim, @date)";
            cmd.Parameters.AddWithValue("@tag", p.Tag);
            cmd.Parameters.AddWithValue("@tim", p.Timer);
            cmd.Parameters.AddWithValue("@date", p.Date);
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();
        }
    }
}
