using System;
using System.Collections.Generic;

namespace Domain
{
    public class Championship
    {     
        public List<int> CreateMatchs(List<string> teams)
        {
            var rand = new Random();
            var match = new List<int>();
            
            for(int i = 0;i < teams.Count;i++)
            {
                var a = rand.Next(4);
                foreach(var x in match)
                {
                    
                }
                match[i] = rand.Next(4);
            }
            return match;
        }
    }
}