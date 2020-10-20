using System;

namespace Domain
{
    public class Player
    {
        public Guid Id { get; private set; } = Guid.NewGuid();
        public string Name { get; private set; }

        public Player(string name)
        {
            Id = Guid.NewGuid();
            Name = name;
        }
        



    }
}