using CinePopCorn.Application.Sessions;
using CinePopCorn.Domain.Sessions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinePopCornTest.Sessions
{
    [TestClass]
    public class SessionTest
    {
        SessionsApplication session = new SessionsApplication();
        [TestMethod]
        public void TestGetSessions()
        {
            List<Session> sessions = new List<Session>();
            sessions = session.GetSessions();
            Assert.IsNotNull(sessions, "Deve ser diferente de null");
        }
    }
}
