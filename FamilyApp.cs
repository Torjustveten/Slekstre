using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Slekstre
{
    public class FamilyApp
    {
        public List<Person> _people;

        public string WelcomeMessage { get; set; }
        public string CommandPrompt { get; set; }

        public FamilyApp(params Person[] people)
        {
            _people = new List<Person>(people);
        }

        private static void ShowHelp()
        {

            
        }

        public string HandleCommand()
        {

        }
    }
}
