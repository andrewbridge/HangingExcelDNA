using System;
using System.Collections.Generic;
using System.Text;

namespace FakeApiClient.ResponseTypes
{
    public class ColoursResponse
    {
        public int page { get; set; }
        
        public int per_page { get; set; }

        public int total { get; set; }

        public int total_pages { get; set; }
        
        public Colour[] data { get; set; }
    }
}
