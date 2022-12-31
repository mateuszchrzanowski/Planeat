using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planeat.Core.Domain
{
    public class User
    {
        public Guid Id { get; protected set; }
        public string Email { get; protected set; }
        public string Password { get; protected set; }
        public string FirstName { get; protected set; }
        public string LastName { get; protected set; }
        public Role Role { get; protected set; }
        //public int RoleId { get; protected set; }
        public IEnumerable<Meal> Meals { get; protected set; }
        public IEnumerable<Product> Products { get; protected set; }
        public DateTime CreatedAt { get; protected set; }
        public DateTime UpdatedAt { get; protected set; }

        protected User()
        {
        }

        public User(string email, string password, string firstName, string lastName, Role role)
        {
            Id = Guid.NewGuid();
            SetEmail(email);
            SetPassword(password);
            SetFirstName(firstName);
            SetLastName(lastName);
            SetRole(role);
            CreatedAt = DateTime.UtcNow;
            UpdatedAt = DateTime.UtcNow;
        }

        public void SetEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                throw new Exception("Email must not be empty");
            }

            if (email.Length > 100)
            {
                throw new Exception("Email must not be longer than 100 characters.");
            }

            if (email == Email)
            {
                return;
            }

            Email = email.ToLowerInvariant();
            UpdatedAt = DateTime.UtcNow;
        }

        public void SetPassword(string password)
        {
            if (string.IsNullOrWhiteSpace(password))
            {
                throw new Exception("Password must not be empty");
            }

            if (password.Length < 8)
            {
                throw new Exception("Password must be at least 8 characters long.");
            }

            if (password == Password)
            {
                return;
            }

            Password = password;
            UpdatedAt = DateTime.UtcNow;
        }

        public void SetFirstName(string firstName)
        {
            if (string.IsNullOrWhiteSpace(firstName))
            {
                throw new Exception("First Name must not be empty");
            }

            if (firstName.Length > 100)
            {
                throw new Exception("First Name must not be longer than 100 characters.");
            }

            if (firstName == FirstName)
            {
                return;
            }

            FirstName = firstName;
            UpdatedAt = DateTime.UtcNow;
        }

        public void SetLastName(string lastName)
        {
            if (string.IsNullOrWhiteSpace(lastName))
            {
                throw new Exception("Last Name must not be empty");
            }

            if (lastName.Length > 100)
            {
                throw new Exception("Last Name must not be longer than 100 characters.");
            }

            if (lastName == LastName)
            {
                return;
            }

            LastName = lastName;
            UpdatedAt = DateTime.UtcNow;
        }

        public void SetRole(Role role)
        {
            if (role == null)
            {
                throw new Exception("Role must not be empty");
            }

            if (role == Role)
            {
                return;
            }

            Role = role;
            UpdatedAt = DateTime.UtcNow;
        }
    }
}
