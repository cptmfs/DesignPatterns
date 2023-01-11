﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace NullObject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CustomerManager customerManager = new CustomerManager(StubLogger.GetLogger());
            customerManager.Save();
            Console.ReadLine();
        }
    }
    class CustomerManager
    {
        ILogger _logger;

        public CustomerManager(ILogger logger)
        {
            _logger = logger;
        }

        public void Save()
        {
            Console.WriteLine("Saved");
            _logger.Log();
        }
    }

    interface ILogger
    {
        void Log();

    }

    class StubLogger : ILogger
    {
        private static StubLogger _stubLogger;
        private static object _lock = new object();

        private StubLogger()
        {

        }

        public static StubLogger GetLogger()
        {
           lock (_lock)
            {
                if (_stubLogger==null)
                {
                    _stubLogger = new StubLogger();
                }
            }
           return _stubLogger;
        }
        public void Log()
        {
        }
    }

    class Log4NetLogger : ILogger
    {
        public void Log()
        {
            Console.WriteLine("Logged with Log4Net");
        }
    }
    class NLogLogger : ILogger
    {
        public void Log()
        {
            Console.WriteLine("Logged with NLog");
        }
    }

    class CustomerManagerTest
    {
        public void Test()
        {
            CustomerManager customerManager = new CustomerManager(StubLogger.GetLogger());
            customerManager.Save();

        }
    }
}
