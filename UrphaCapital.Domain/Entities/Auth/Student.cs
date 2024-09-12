﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UrphaCapital.Domain.Entities.Auth
{
    public class Student
    {
        public long Id { get; set; }
        public string FullName { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string Salt { get; set; }
        public List<string> CourseIds { get; set; }
        public string Role { get; set; }
    }
}
