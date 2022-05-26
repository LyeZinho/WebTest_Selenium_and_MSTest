using System;
using System.Collections.Generic;
using System.Text;

namespace WebTest
{
    public interface ILogService
    {
        public void RegisterLog(Log newLog);
    }

    public interface ILogMethod
    {
        public void SaveLog(List<Log> logs);
    }
}
