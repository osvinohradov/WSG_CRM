using System;
using System.Collections.Generic;
using System.Linq;
using WSG.WEB.API.Models.General;

namespace WSG.WEB.API.Models.Entities
{
    /// <summary>
    /// Штраф
    /// </summary>
    public class Forfeit : AdditionalInfoBase
    {
        public Forfeit()
        {
        }

        public Forfeit(double amount, double mpe, string currency)
            :base(amount, mpe, currency)
        {
        }
    }
}