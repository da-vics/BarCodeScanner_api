using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BarCodeScanner_api.Models
{
    public class ProductRecords
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public Guid DeviceId { get; set; }

        [ForeignKey("DeviceId")]
        public DeviceSetupModel setupModel { get; set; }

        [Required]
        public DateTime DataInsertDat { get; set; }

        [Required]
        [MaxLength(100)]
        public string BarCodeData { get; set; }

    }
}
