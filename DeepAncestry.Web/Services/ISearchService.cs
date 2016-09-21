using DeepAncestry.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeepAncestry.Web.Services
{
    public interface ISearchService
    {
        List<Person> FindPerson(string name, string gender);

        List<Person> FindFamily(string name, string gender, string direction);
    }
}
