using System;
using System.Collections.Generic;
using System.Text;

namespace FakeApiClient.ResponseTypes
{
    public class Colour
    {
        public int id { get; set; }

        public string name { get; set; }

        public int year { get; set; }

        public string color { get; set; }

        public string pantone_value { get; set; }
    }
}
