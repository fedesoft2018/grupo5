using System;
using System.Collections.Generic;
using System.Text;

namespace Fedesoft.WomApp.App.Models
{
    public class MainMenuItem
    {
        public string Title { get; set; }
        public Type TargetType { get; set; }
        public string Icon { get; set; }
        public int IconWith { get; set; }
        public int IconHeight { get; set; }
        public string LineNumber { get; set; }
    }
}
