﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcWepApp2.DAL
{
    public static class ConnectionString
    {
        private static string _connection = @"Data Source = EMINE; Initial Catalog = YonetimPaneli; Integrated Security = True";
        public static string Connection { get { return _connection; } }

    }
}