using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace PomodoroAPI.DAL
{
    public class GetPomodoro
    {

        Database db = new Database();
        public List<Pomodoro> getPomodoro()
        {
            db.connection.Open();
            List<Pomodoro> results = new List<Pomodoro>();

            MySqlCommand cmd = db.connection.CreateCommand();

            cmd.CommandText = "SELECT timer, date, intitule FROM pomodoro p JOIN tag t ON p.id_tag=t.id_tag";
            var r = cmd.ExecuteReader();
            while (r.Read())
            {
                results.Add(new Pomodoro { Tag = r.GetString(2), Timer = r.GetUInt16(0), Date = (DateTime)r.GetMySqlDateTime(1) });
            }

            cmd.Connection.Close();
            return results;
        }

        public List<Pomodoro> getPomodoroByTag(string tag)
        {
            db.connection.Open();
            List<Pomodoro> results = new List<Pomodoro>();
            MySqlCommand cmd = db.connection.CreateCommand();
            cmd.CommandText = "SELECT timer, date FROM pomodoro p JOIN tag t ON p.id_tag=t.id_tag WHERE t.intitule=@intit";
            cmd.Parameters.AddWithValue("@intit", tag);
            var r = cmd.ExecuteReader();
            while (r.Read())
            {
                results.Add(new Pomodoro { Tag = tag, Timer = r.GetUInt16(0),Date = (DateTime)r.GetMySqlDateTime(1) });
            }
            cmd.Connection.Close();
            return results;
        }
    }
}
