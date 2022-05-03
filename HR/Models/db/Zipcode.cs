using System;
using System.Collections.Generic;

namespace HR.Models.db
{
    public partial class Zipcode
    {
        public int Id { get; set; }
        public string ZipcodeName { get; set; } = null!;
        public int? SubdistrictId { get; set; }
    }
}
