using System;
using System.Collections.Generic;
using System.Text;

namespace DNet.Core.Model.ViewModels
{
    public class LoginInfoViewModels
    {
        public string uLoginName { get; set; }

        public string uLoginPwd { get; set; }

        public string VCode { get; set; }

        public bool IsMember { get; set; }
    }
}
