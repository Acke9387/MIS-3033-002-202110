using System;
using System.Collections.Generic;
using System.Text;

namespace JSON_GOT
{
    public class GOTQuoteAPI
    {
        public string quote {get;set;}
        public string character { get; set; }

        public GOTQuoteAPI()
        {
            quote = string.Empty;
            character = string.Empty;
        }

    }
}
