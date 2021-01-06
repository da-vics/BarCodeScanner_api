
using System.ComponentModel.DataAnnotations;

namespace BarCodeScanner_api.DataProfiles
{
    public class FieldRegisterProfile
    {
        [Required]
        public string MasterKey { get; set; }
    }
}
