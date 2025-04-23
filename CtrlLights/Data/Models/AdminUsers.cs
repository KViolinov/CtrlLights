using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CtrlLights.Data.Models
{
    public class AdminUsers
    {
        public int Id { get; set; }

        public string Username { get; set; } = string.Empty;

        public string Key { get; set; } = string.Empty;
    }
}
