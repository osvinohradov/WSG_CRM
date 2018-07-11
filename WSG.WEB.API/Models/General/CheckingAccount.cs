using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WSG.WEB.API.Infrastructure;

namespace WSG.WEB.API.Models.General
{
    public class CheckingAccount : ICheckingAccount
    {
        public string Name { get; set; }
    }
}