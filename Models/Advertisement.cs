using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Advertisement
    {
        public int id { get; set; }
        public string headline { get; set; }
        public string body { get; set; }
        public Advertisement() { }
        public Advertisement(string headline, string body)
        {
            this.headline = headline;
            this.body = body;
        }
        public Advertisement(string headline)
        {
            this.headline = headline;
        }
        public override string ToString()
        {
            return headline + $"\r\n{body}";
        }
    }
}
