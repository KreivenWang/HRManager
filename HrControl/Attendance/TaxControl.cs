using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HRModel;

namespace HrControl
{
    public class TaxControl
    {
        public Tax GetTaxArgu()
        {
            return Tax.GetInstance();
        }

        public void UpdateTaxArgu(Tax tax)
        {
            SerializeHelper.Serialize(tax, "tax.data");
        }
    }
}
