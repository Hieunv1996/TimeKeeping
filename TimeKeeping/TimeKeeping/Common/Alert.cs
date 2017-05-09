using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TimeKeeping.Common
{
    public class Alert
    {
        private string style;
        private string content;

        public Alert(string style, string content)
        {
            this.style = style;
            this.content = content;
        }
    }
}