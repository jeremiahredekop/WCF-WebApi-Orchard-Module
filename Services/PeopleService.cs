using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using Orchard;
using myRestfulModule.Models;

namespace myRestfulModule.Services
{
    [ServiceContract]
    public class PeopleService 
        : IDependency // required for orchard
    {
        private static readonly List<Person> _people = Fabrication.Fabricator.Generate<Person>(500).ToList();

        [WebGet]
        public IQueryable<Person> GetPeople()
        {
            
            return _people.AsQueryable();
            //return new EnumerableQuery<Person>(new Person[]{});
        }

        [WebGet(UriTemplate = "{name}")]
        public Person GetPerson(string name) {
            return _people.Single(p=> p.Name == name);
        }
    }
}
