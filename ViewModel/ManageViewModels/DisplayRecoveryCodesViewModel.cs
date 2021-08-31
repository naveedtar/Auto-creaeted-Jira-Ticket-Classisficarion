using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HelpDesk.ViewModel
{
    public class DisplayRecoveryCodesViewModel
    {
        [Required]
        public IEnumerable<string> Codes { get; set; }

    }
}
