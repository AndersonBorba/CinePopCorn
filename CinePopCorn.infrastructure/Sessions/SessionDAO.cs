using CinePopCorn.Domain.Movies;
using CinePopCorn.Domain.Rooms;
using CinePopCorn.Domain.Sessions;
using CinePopCorn.infrastructure.AuxDao;
using CinePopCorn.infrastructure.Movies;
using CinePopCorn.infrastructure.Rooms;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinePopCorn.infrastructure.Sessions
{
    public class SessionDAO
    {
        MovieDAO movieDAO = new MovieDAO();
        RoomDAO roomDAO = new RoomDAO();
        public List<Session> GetSessions()
        {
            SqlConnection connection = new SqlConnection(AuxDAO.GetConnectionString());
            connection.Open();
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = @"Select Id, Date, Value, TypeAnimation, TypeSound, IdMovie, IdRoom from Session;";
            SqlDataReader rdr = cmd.ExecuteReader();
            List<Session> Sessions = new List<Session>();
            while (rdr.Read())
            {
                Session Session = new Session();
                Session.Id = Convert.ToInt32(rdr["Id"]);
                Session.Date = Convert.ToDateTime(rdr["Date"]);
                Session.Value = Convert.ToDecimal(rdr["Value"]);
                Session.TypeAnimation = Convert.ToInt32(rdr["TypeAnimation"]);
                Session.TypeSound = Convert.ToInt32(rdr["TypeSound"]);
                Session.movie = new Movie();
                Session.movie = movieDAO.GetMovieById(Convert.ToInt32(rdr["IdMovie"]));
                Session.room = new Room();
                Session.room = roomDAO.GetRoomById(Convert.ToInt32(rdr["IdRoom"]));
                Sessions.Add(Session);
            }
            connection.Close();

            return Sessions;
        }

        public string ValidateSessionsConcurrents(Session m, int Id)
        {
            DateTime dtIni = m.Date;
            DateTime dtFim = dtIni.AddMinutes(m.movie.Time);

            SqlConnection connection = new SqlConnection(AuxDAO.GetConnectionString());
            connection.Open();
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = @"select s.Date, m.Time from Session s join Movie m on m.Id = s.IdMovie WHERE S.IdRoom = @IdRoom";
            cmd.CommandText += @" AND S.Id <> @Id;";
            cmd.Parameters.AddWithValue("@IdRoom", m.room.Id);
            cmd.Parameters.AddWithValue("@Id", Id);
            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                DateTime dtIniBD = Convert.ToDateTime(rdr["Date"]);
                DateTime dtFimBD = dtIniBD.AddMinutes(Convert.ToInt32(rdr["Time"]));

                if (dtIniBD <= dtIni && dtFimBD >= dtIni)
                    return "Sala já possui outra sessão para o mesmo horário";
                if (dtIniBD <= dtFim && dtFimBD >= dtFim)
                    return "Sala já possui outra sessão para o mesmo horário";
                if (dtIniBD <= dtIni && dtFimBD >= dtFim)
                    return "Sala já possui outra sessão para o mesmo horário";
                if (dtIniBD >= dtIni && dtFimBD <= dtFim)
                    return "Sala já possui outra sessão para o mesmo horário";
            }
            connection.Close();
            return "";
        }

        public string UpdateSession(Session m)
        {
            try
            {
                SqlConnection connection = new SqlConnection(AuxDAO.GetConnectionString());
                connection.Open();
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = @"UPDATE Session set Date = @Date, Value = @Value, TypeAnimation = @TypeAnimation, 
                                    TypeSound = @TypeSound, IdMovie = @IdMovie, IdRoom = @IdRoom WHERE id = @id;";
                cmd.Parameters.AddWithValue("@Date", m.Date);
                cmd.Parameters.AddWithValue("@Value", m.Value);
                cmd.Parameters.AddWithValue("@TypeAnimation", m.TypeAnimation);
                cmd.Parameters.AddWithValue("@TypeSound", m.TypeSound);
                cmd.Parameters.AddWithValue("@IdMovie", m.movie.Id);
                cmd.Parameters.AddWithValue("@IdRoom", m.room.Id);
                cmd.Parameters.AddWithValue("@Id", m.Id);
                cmd.ExecuteScalar();

                connection.Close();
            }
            catch (Exception ex)
            {
                return "Erro ao atualizar o filme!!";
            }
            return "";
        }

        public Session GetSessionById(object idSession)
        {
            SqlConnection connection = new SqlConnection(AuxDAO.GetConnectionString());
            connection.Open();
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = @"select Id, Date, Value, TypeAnimation, TypeSound, IdMovie, IdRoom from Session where Id = @Id;";
            cmd.Parameters.AddWithValue("@Id", idSession);
            SqlDataReader rdr = cmd.ExecuteReader();
            Session Session = new Session();
            if (rdr.Read())
            {
                Session.Id = Convert.ToInt32(rdr["Id"]);
                Session.Date = Convert.ToDateTime(rdr["Date"]);
                Session.Value = Convert.ToDecimal(rdr["Value"]);
                Session.TypeAnimation = Convert.ToInt32(rdr["TypeAnimation"]);
                Session.TypeSound = Convert.ToInt32(rdr["TypeSound"]);
                Session.movie = movieDAO.GetMovieById(Convert.ToInt32(rdr["IdMovie"]));
                Session.room = new Room();
                Session.room.Id = Convert.ToInt32(rdr["IdRoom"]);
            }
            connection.Close();

            return Session;
        }

        public string AddSession(Session m)
        {
            try
            {
                SqlConnection connection = new SqlConnection(AuxDAO.GetConnectionString());
                connection.Open();
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = @"insert into Session (Date, Value, TypeAnimation, TypeSound, IdMovie, IdRoom) 
values (@Date, @Value, @TypeAnimation, @TypeSound, @IdMovie, @IdRoom);";
                cmd.Parameters.AddWithValue("@Date", m.Date);
                cmd.Parameters.AddWithValue("@Value", m.Value);
                cmd.Parameters.AddWithValue("@TypeAnimation", m.TypeAnimation);
                cmd.Parameters.AddWithValue("@TypeSound", m.TypeSound);
                cmd.Parameters.AddWithValue("@IdMovie", m.movie.Id);
                cmd.Parameters.AddWithValue("@IdRoom", m.room.Id);
                cmd.ExecuteScalar();
                connection.Close();
            }
            catch (Exception ex)
            {
                return "Erro ao cadastrar sessão!!";
            }

            return "";
        }

        public void DeleteSession(int id)
        {
            SqlConnection connection = new SqlConnection(AuxDAO.GetConnectionString());
            connection.Open();
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = @"delete from Session where id = @id;";
            cmd.Parameters.AddWithValue(@"@id", id);
            cmd.ExecuteNonQuery();
            connection.Close();
        }
    }
}
