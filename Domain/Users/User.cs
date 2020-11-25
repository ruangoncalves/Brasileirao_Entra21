using System;
using System.Collections.Generic;
using System.Linq;
using Domain.People;

namespace Domain.Users
{
    public class User : Person
    {
        public Profile Profile { get; set; }

        public User(string name, Profile profile) : base(name)
        {
            Profile = profile;
        }        
    
        public (IList<string> errors, bool isValid) Validate()
        {
            var errors = new List<string>();
            if (!ValidateName())
            {
                errors.Add("Nome inválido.");
            }
            return (errors, errors.Count == 0);
        }
    }
}