using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI3.Models
{
    [Table("WordList")]
    public partial class WordList
    {
        [Key]
        public int Id { get; set; }
        [Column("Word_Tr")]
        public string WordTr { get; set; }
        [Column("Word_En")]
        public string WordEn { get; set; }
    }
}
