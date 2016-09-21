using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DeepAncestry.Web.Models;
using System.IO;
using Newtonsoft.Json.Linq;

namespace DeepAncestry.Web.Services
{
    public class SearchService : ISearchService
    {
        /*
         *  Usually I wouldn't implement a data store like this
         *  In the interest of time management I've used the quicked method
         *  Also, regarding parsing the data, I would usually like to parse into a c# 
         *  object first and perform linq queries to find results
         */ 

        private JObject json { get; set; }

        public List<Person> FindFamily(string name, string gender, string direction)
        {
            LoadData();
            var people = new List<Person>();

            var allPeople = (JArray)json["people"];

            foreach (var p in allPeople)
            {
                if (p["name"].ToString().Equals(name, StringComparison.InvariantCultureIgnoreCase))
                {
                    people.Add(new Person
                    {
                        Id = p["id"].ToString(),
                        Name = p["name"].ToString(),
                        Gender = p["gender"].ToString().Equals("m", StringComparison.InvariantCultureIgnoreCase) ? "Male" : "Female",
                        Birthplace = FindBirthplace(p["place_id"].ToString()),
                        FatherId = p["father_id"].ToString(),
                        MotherId = p["mother_id"].ToString(),
                    });
                    break;
                }
            }

            if (!people.Any() || !direction.Equals("ancestors", StringComparison.InvariantCultureIgnoreCase))
            {
                return people;
            }

            int count = 0;

            do
            {
                var f_id = people[count].FatherId;
                var m_id = people[count].MotherId;

                if (string.IsNullOrEmpty(f_id) && string.IsNullOrEmpty(m_id))
                {
                    break;
                }

                if (!string.IsNullOrEmpty(f_id))
                {
                    var person = FindPersonById(f_id);
                    if (person != null)
                    {
                        people.Add(person);
                    }
                }

                if (!string.IsNullOrEmpty(m_id))
                {
                    var person = FindPersonById(m_id);
                    if (person != null)
                    {
                        people.Add(person);
                    }
                }

            } while (people.Count < 5);

            return people;
        }

        public List<Person> FindPerson(string name, string gender)
        {
            LoadData();
            var people = new List<Person>();

            var allPeople = (JArray)json["people"];

            foreach (var p in allPeople)
            {
                if (people.Count >= 10)
                {
                    break;
                }

                if (p["name"].ToString().IndexOf(name, StringComparison.InvariantCultureIgnoreCase) != -1)
                {
                    var p_gender = p["gender"].ToString().Equals("m", StringComparison.InvariantCultureIgnoreCase) ? "Male" : "Female";

                    if ((!string.IsNullOrEmpty(gender) && p_gender.Equals(gender, StringComparison.InvariantCultureIgnoreCase)) || string.IsNullOrEmpty(gender))
                    {
                        people.Add(new Person
                        {
                            Id = p["id"].ToString(),
                            Name = p["name"].ToString(),
                            Gender = p_gender,
                            Birthplace = FindBirthplace(p["place_id"].ToString())
                        });
                    }
                }
            }

            return people;
        }

        private Person FindPersonById(string personId)
        {
            var places = (JArray)json["people"];

            foreach (var p in places)
            {
                if (p["id"].ToString().Equals(personId))
                {
                    var p_gender = p["gender"].ToString().Equals("m", StringComparison.InvariantCultureIgnoreCase) ? "Male" : "Female";

                    return new Person
                    {
                        Id = p["id"].ToString(),
                        Name = p["name"].ToString(),
                        Gender = p_gender,
                        Birthplace = FindBirthplace(p["place_id"].ToString())
                    };
                }
            }

            return null;
        }

        private string FindBirthplace(string placeId)
        {
            var places = (JArray)json["places"];

            foreach (var p in places)
            {
                if (p["id"].ToString().Equals(placeId))
                {
                    return p["name"].ToString();
                }
            }

            return "";
        }

        private void LoadData()
        {
            string file = string.Empty;

            using (StreamReader r =
                new StreamReader(Path.GetDirectoryName(System.AppDomain.CurrentDomain.BaseDirectory) + @"\data\data_small.json"))
            {
                file = r.ReadToEnd();
            }

            json = JObject.Parse(file);
        }
    }
}