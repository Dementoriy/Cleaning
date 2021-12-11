﻿using System;
using System.Collections.Generic;
using System.Text;

namespace CleaningDLL
{
    static class Context
    {
        public static ApplicationContext Db
        {
            get; private set;
        }
        internal static void AddDb(ApplicationContext application)
        {
            Db = application;
        }
    }
}