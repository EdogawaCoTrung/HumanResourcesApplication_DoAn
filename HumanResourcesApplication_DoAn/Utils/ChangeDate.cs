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
            string day = Int32.Parse(date.Day.ToString()) < 10 ? ("0"+date.Day.ToString()) : date.Day.ToString();
            string month = Int32.Parse(date.Month.ToString()) < 10 ? "0" + date.Month.ToString() : date.Month.ToString();
            string year = date.Year.ToString();
            return year+"-"+month+"-"+day;
        }
    }
}
