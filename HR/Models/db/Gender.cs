using System;
using System.Collections.Generic;

namespace HR.Models.db
{
    public partial class Gender
    {
        public int GenderId { get; set; }
        public string GenderName { get; set; } = null!;
    }
}
