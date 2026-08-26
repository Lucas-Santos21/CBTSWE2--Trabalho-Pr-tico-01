//Nome e prontuário da dupla:
//Lucas da Silva Santos CB3030598
//Kaueh Farias Ferreira dos Santos CB3031438

using System;
using System.Collections.Generic;
using System.Text;

namespace TP01_SistemasWeb2.Data
{
    public class Author
    {
        private string name;
        private string email;
        private char gender;

        public Author(string name, string email, char gender)
        {
            this.name = name;
            this.email = email;
            this.gender = gender;
        }

        public string GetName()
        {
            return name;
        }

        public string GetEmail()
        {
            return email;
        }

        public char GetGender()
        {
            return gender;
        }

        public override string ToString()
        {
            return $"Author[name={name},email={email},gender={gender}]";
        }
    }
}
