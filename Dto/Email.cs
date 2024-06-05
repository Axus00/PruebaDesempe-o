using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Veterinaria.Dto
{
    public class Email
    {
        public From From { get; set; }
        public To[] To { get; set; }
        public string subject { get; set; }
        public string text { get; set; }
        public string html { get; set; }
    }

    //We create a object about From and To for Email send.
    public class From
    {
        public string Email { get; set; }
    }

    public class To
    {
        public string Email { get; set; }
    }
}