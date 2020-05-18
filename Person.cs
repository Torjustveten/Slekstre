using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace Slekstre
{
    public class Person
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int BirthYear { get; set; }
        public int DeathYear { get; set; }
        public Person Father { get; set; }
        public Person Mother { get; set; }

        public object GetDescription()
        {
            string description = null;
            description = GetDescriptionPerson(description);
            description = GetDescriptionFather(description);
            description = GetDescriptionMother(description);
            description += "\n";
            return description;
        }

        private string GetDescriptionPerson(string description)
        {
            if (FirstName != null) description += FirstName + " ";
            if (LastName != null) description += LastName;
            if (Id != 0) description += " [" + Id + "]";
            if (BirthYear != 0) description += " Født: " + BirthYear;
            if (DeathYear != 0) description += " Død: " + DeathYear;
            return description;
        }

        private string GetDescriptionFather(string description)
        {
            if (Father != null)
            {
                if (Father.FirstName != null) description += " Far: " + Father.FirstName;
                if (Father.Id != 0) description += " [" + Father.Id + "]";
            }

            return description;
        } 

        private string GetDescriptionMother(string description)
        {
            if (FirstName != null) description += FirstName + " ";
            if (LastName != null) description += LastName;
            if (Id != 0) description += "[" + Id + "]";
            if (BirthYear != 0) description += " Født: " + BirthYear;
            if (DeathYear != 0) description += " Død: " + DeathYear;

            return description;
        }
    }
}
