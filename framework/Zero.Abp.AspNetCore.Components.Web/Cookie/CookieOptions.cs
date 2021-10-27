﻿using System;

namespace Zero.Abp.AspNetCore.Components.Web.Cookie
{
    public class CookieOptions
    {
        public DateTimeOffset? ExpireDate { get; set; }
        public string Path { get; set; }
        public bool Secure { get; set; }
    }
}