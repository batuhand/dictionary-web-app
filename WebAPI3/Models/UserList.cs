using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI3.Models
{
    public partial class UserList
    {
        [Key]
        public int Id { get; set; }
        [Column("userName")]
        public string UserName { get; set; }
        [Column("password")]
        public string Password { get; set; }
        [Column("eMail")]
        public string EMail { get; set; }
        [Column("name")]
        public string Name { get; set; }
        [Column("surName")]
        public string SurName { get; set; }
    }
}
