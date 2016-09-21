using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DeepAncestry.Web.Models
{
    public class Person
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public string Birthplace { get; set; }
        public string FatherId { get; set; }
        public string MotherId { get; set; }
    }
}