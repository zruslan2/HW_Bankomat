﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KKB.BankClient.BLL.Account
{
    public enum Currency { usd, kzt, rur }
    public class Account
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Number { get; set; }
        public DateTime CreateDate { get; set; }
        public Currency Currency { get; set; }
        public decimal Balance { get; set; }
    }
}
