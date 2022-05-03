using System;
using System.Collections.Generic;

namespace HR.Models.db
{
    public partial class Subdistrict
    {
        public int Id { get; set; }
        public string SubdistrictName { get; set; } = null!;
        public int DistrictId { get; set; }
    }
}
