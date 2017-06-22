using System;
using System.Collections.Generic;
using System.Text;

namespace Contently.Core.Domain.Membership
{
    public class User : EntityBase
    {
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string Email { get; set; }
        public string Username { get; set; }

        public string Password { get; set; }

    }
}
