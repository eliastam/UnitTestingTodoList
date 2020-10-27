using System;
using System.Collections.Generic;
using System.Text;

namespace NUnitTestProject1.Entities
{
    public class Project
    {
        public int id { get; set; }

        public string title { get; set; }

        public bool completed { get; set; }

        public bool active { get; set; }

        public string description { get; set; }

    }
}
