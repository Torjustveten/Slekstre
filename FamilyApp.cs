using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Slekstre
{
    public class FamilyApp
    {
        private readonly List<Person> _people;

        public string WelcomeMessage { get; set; }
        public string CommandPrompt { get; set; }

        public FamilyApp(params Person[] people)
        {
            _people = new List<Person>(people);
            Console.WriteLine("Skriv hjelp for kommandoer");
        }

        public string HandleCommand(string command)
        {
            command = command.ToLower();
            switch (command)
            {
                case "hjelp":
                    Console.Clear();
                    Console.WriteLine("liste => lister alle personer med id, fornavn, fødselsår, dødsår og navn og id på mor og far om det finnes registrert.");
                    Console.WriteLine("vis => viser en bestemt person med mor, far og barn (+ id)");
                    break;
                case "liste":
                    Console.Clear();
                    return _people.Aggregate((string) null, (current, person) => current + person.GetDescription());
            }

            foreach (var person in _people)
            {
                var id = person.Id;
                if (command != $"vis {person.Id}" || person.Id != id) continue;
                var children = FindChildren(person);
                var description = (string)person.GetDescription();
                description = AddChildren(children, description);
                return description;
            }

            return null;
        }

        private static string AddChildren(List<Person> children, string description)
        {
            if (children.Count <= 0) return description;
            description += "  Barn:\n";
            return children.Aggregate(description, (current, child) => current + ("    " + child.FirstName + " [" + child.Id + "]" + " Født: " + child.BirthYear + "\n"));
        }

        private List<Person> FindChildren(Person person)
        {
            var children = new List<Person>();
            foreach (var haschild in _people)
            {
                if (haschild.Father == person || haschild.Mother == person)
                    children.Add(haschild);
            }
            return children;
        }
    }
}
