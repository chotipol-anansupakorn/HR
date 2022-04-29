using System;
using System.Collections.Generic;

namespace HR.Models.db
{
    public partial class Holiday
    {
        public int HolidayId { get; set; }
        public string HolidayName { get; set; } = null!;
        public DateTime HolidayDate { get; set; }
    }
}
