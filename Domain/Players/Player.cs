using System;
using System.Collections.Generic;
using System.Linq;
using Domain.People;

namespace Domain.Players
{
    public class Player : Person
    {
        public int Goals { get; private set; }

        public Player(string name) : base(name)
        {
            Name = name;
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