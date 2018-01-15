using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ATT_Test.Models
{
    public class Issues
    {
        public string title { get; set; }
        public string Repository_FullName { get; set; }
        public int Comments { get; set; }
        public string Commentsurl { get; set; }
        public string Body { get; set; }
        public string url { get; set; }
    }
}