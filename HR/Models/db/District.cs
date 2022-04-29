using System;
using System.Collections.Generic;

namespace HR.Models.db
{
    public partial class District
    {
        public int Id { get; set; }
        public string DistrictName { get; set; } = null!;
        public int ProvinceId { get; set; }
    }
}
