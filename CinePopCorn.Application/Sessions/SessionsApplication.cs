using CinePopCorn.Domain.Sessions;
using CinePopCorn.infrastructure.Sessions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinePopCorn.Application.Sessions
{

    public class SessionsApplication
    {
        SessionDAO dao;
        public SessionsApplication()
        {
            dao = new SessionDAO();
        }
        public List<Session> GetSessions()
        {
            return dao.GetSessions();
        }

        public string DeleteSession(int id)
        {
            Session session = new Session();
            session = dao.GetSessionById(id);

            if (session.Date >= DateTime.Now && DateTime.Now.AddDays(10) > session.Date)
                return "Sessão ocorrerá em menos de dez dias!! Exclusão não permitida!!";

            dao.DeleteSession(id);
            return "";
        }

        public string AddSession(Session m)
        {

            string result = dao.ValidateSessionsConcurrents(m, 0);
            if (result != "")
                return result;

            result = dao.AddSession(m);

            return result;
        }

        public Session GetSessionById(object idSession)
        {
            return dao.GetSessionById(idSession);
        }

        public string UpdateSession(Session m)
        {
            string result = dao.ValidateSessionsConcurrents(m, m.Id);
            if (result != "")
                return result;

            result = dao.UpdateSession(m);

            return result;
        }
    }
}
