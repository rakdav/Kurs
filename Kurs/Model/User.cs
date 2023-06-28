using Kurs.View;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Kurs.Model
{
    public class User
    {
        [Key]
        public int id_user { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
    }
}
