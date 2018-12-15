using System;
using ECommerceDomain.Common;
using ECommerceDomain.Identity.Events;

namespace ECommerceDomain.Identity.User
{
    public class User : AggregateRoot
    {
        public Guid Id { get; }
        public string Username { get; }
        public string Password { get; }
        public string Email { get; }
        public string UserType { get; }

        public User(string username, string password, string email, string userType)
        {
            Id = Guid.NewGuid();
            Username = username;
            Password = password;
            Email = email;
            UserType = userType;

            AddEvent(new UserCreatedEvent(Id));
        }
    }
}
