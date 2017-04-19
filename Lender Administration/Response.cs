using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lender_Administration
{

    class Response
    {
        public string Message { get; set; }
        public List<ApplicationModel> Applications { get; set; }
        public List<LenderModel> Lenders { get; set; }
        public List<UserModel> Users { get; set; }
        public string access_token { get; set; }
    }
}
