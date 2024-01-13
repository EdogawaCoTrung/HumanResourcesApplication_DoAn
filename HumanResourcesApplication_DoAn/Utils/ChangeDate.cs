using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanResourcesApplication_DoAn.Utils
{
    public class ChangeDate
    {
        
        public string ChangeDateFormat(DateTime date)
        {
            string day = date.Day.ToString();
            string month = date.Month.ToString();
            string year = date.Year.ToString();
            return year+"-"+month+"-"+day;
        }
    }
}
