using System;
using System.ComponentModel.DataAnnotations;

namespace BarCodeScanner_api.DataProfiles
{
    public class FiledDeivceProfile
    {
        [Required]
        public Guid DeviceId { get; set; }
    }
}
