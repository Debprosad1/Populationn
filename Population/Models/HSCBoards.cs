using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Population.Models
{
    public class HSCBoards
    {
        public int Id { get; set; }
        [Required]
        public string HSCBoard { get; set; }
    }
}
