using System;
using System.ComponentModel.DataAnnotations;


namespace BarCodeScanner_api.Models
{

    public class DeviceSetupModel
    {
        [Key]
        public Guid Id { get; set; }
    }


    //public class MasterKeys
    //{
    //    [Key]
    //    public int Id { get; set; }

    //    [Required]
    //    public string AccessKey { get; set; }
    //}
}
