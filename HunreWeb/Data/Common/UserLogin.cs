﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HunreWeb.Data.Common
{
    [Serializable]
    public class UserLogin
    {
        public long UserId { get; set; }
        public string UserName { get; set; }
    }
}