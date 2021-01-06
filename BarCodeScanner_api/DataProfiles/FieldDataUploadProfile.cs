using System;
using System.ComponentModel.DataAnnotations;

namespace BarCodeScanner_api.DataProfiles
{
    public class FieldDataUploadProfile
    {
        [Required]
        public Guid DeviceId { get; set; }

#nullable enable
        [Required]
        public string? Data { get; set; } = null;

    }
}
