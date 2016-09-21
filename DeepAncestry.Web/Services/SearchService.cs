using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DeepAncestry.Web.Models;

namespace DeepAncestry.Web.Services
{
    public class SearchService : ISearchService
    {
        public List<Person> FindFamily(string name, string gender, string direction)
        {
            throw new NotImplementedException();
        }

        public List<Person> FindPerson(string name, string gender)
        {
            throw new NotImplementedException();
        }
    }
}