using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace REF_SITE
{
    public class REF_Client
    {
        public int APPOINTMENT_ID { get; set; }
        public String APPOINTMENT_NAME { get; set; }
        public String PARENT { get; set; }
        public int LIMIT_MONTH { get; set; }
        public int LIMIT_YEAR { get; set; }
        public int STATUS { get; set; }
        public int CREATED_BY { get; set; }
        public String CREATED_DATE { get; set; }
        public int MODIFIED_BY { get; set; }
        public String MODIFIED_DATE { get; set; }
    }
}
