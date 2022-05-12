using CinePopCorn.Domain.Rooms;
using CinePopCorn.infrastructure.Rooms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinePopCorn.Application.Rooms
{
    public class RoomsApplication
    {
        public List<Room> GetRooms()
        {
            RoomDAO dao = new RoomDAO();
            return dao.GetRooms();
        }
    }
}
