using System;
using System.Collections.Generic;

namespace HR.Models.db
{
    public partial class Province
    {
        public int Id { get; set; }
        public string ProvinceName { get; set; } = null!;
    }
}
