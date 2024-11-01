﻿using PaybillAPI.Models;

namespace PaybillAPI.ViewModel
{
    public class AuthResponseVM
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; } = string.Empty;
        public UserVM User { get; set; } = null!;
        public DashboardPref Pref { get; set; } = null!;
    }
}
