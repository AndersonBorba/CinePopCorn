using CinePopCorn.Domain.Rooms;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using CinePopCorn.infrastructure.AuxDao;

namespace CinePopCorn.infrastructure.Rooms
{
    public class RoomDAO
    {
        public List<Room> GetRooms()
        {
            SqlConnection connection = new SqlConnection(AuxDAO.GetConnectionString());
            connection.Open();
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = @"select Id, Name, Seats from room";
            SqlDataReader rdr = cmd.ExecuteReader();
            List<Room> rooms = new List<Room>();
            while (rdr.Read())
            {
                Room room = new Room();
                room.Id = Convert.ToInt32(rdr["Id"]);
                room.Name = Convert.ToString(rdr["Name"]);
                room.Seats = Convert.ToInt32(rdr["Seats"]);
                rooms.Add(room);
            }
            connection.Close();
            
            return rooms;
        }

        internal Room GetRoomById(int id)
        {
            SqlConnection connection = new SqlConnection(AuxDAO.GetConnectionString());
            connection.Open();
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = @"select Id, Name, Seats from room where id = @id;";
            cmd.Parameters.AddWithValue("@id", id);
            SqlDataReader rdr = cmd.ExecuteReader();
            Room room = new Room();
            if (rdr.Read())
            {
                room.Id = Convert.ToInt32(rdr["Id"]);
                room.Name = Convert.ToString(rdr["Name"]);
                room.Seats = Convert.ToInt32(rdr["Seats"]);
            }
            connection.Close();

            return room;
        }
    }
}
