using CinePopCorn.Domain.DTOs;
using CinePopCorn.infrastructure.Loggers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinePopCorn.Application.Loggers
{
   public class LoggersApplication
    {
        LoggerDAO logger;
        public LoggersApplication()
        {
            logger = new LoggerDAO(string.Empty);
        }

        public async Task logar(string action, string description)
        {
            LoggerDTO dto = new LoggerDTO()
            {
                Action = action,
                Description = description
            };

            logger.Logger(dto);
        }
    }
}
