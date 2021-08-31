using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelpDesk.Model
{
    public partial class RoleMenu
    {
        public int Id { get; set; }
        public int MenuId { get; set; }

        public string RoleId { get; set; }

        public virtual Menu Menu { get; set; }
    }
}
