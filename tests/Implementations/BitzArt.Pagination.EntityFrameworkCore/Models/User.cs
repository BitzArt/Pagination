using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace BitzArt.Pagination.Models
{
    [Table("users")]
    public class User
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
