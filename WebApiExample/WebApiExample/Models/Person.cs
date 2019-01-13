using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApiExample.Models
{
    public class Person
    {
        public Person()
        {
            Phone = new HashSet<Phone>();
        }

        public Person(long id, string name, short? age, ICollection<Phone> phone)
        {
            Id = id;
            Name = name;
            Age = age;
            Phone = phone;
        }

        public long Id { get; set; }
        [StringLength(50)]
        public string Name { get; set; }
        public short? Age { get; set; }

        [InverseProperty("Person")]
        public virtual ICollection<Phone> Phone { get; set; }
    }
}