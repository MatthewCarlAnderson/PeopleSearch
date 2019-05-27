using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PeopleSearchData.Models
{
    public class Value
    {
        [Key]
        public int Id { get; set; }
        public string stringValue { get; set; }
    }
}
