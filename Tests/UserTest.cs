using System;
using Xunit;
using Domain;

namespace Tests
{
    public class UserTest
    {
        [Fact]
        public void Should_contains_same_parameters_provided()
        {
            var name = "João da Silva";
            var perfil = "CBF";
            
            var user = new User(name, perfil);

            Assert.Equal(name, user.Name);
            Assert.Equal(perfil, user.Perfil);
        }
    }
}
