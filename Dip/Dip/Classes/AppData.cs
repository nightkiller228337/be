using Dip.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Dip.Classes
{
    internal class AppData
    {
        public static Frame MainFrame = new Frame();
        public static DiplomEntities8 Context = new DiplomEntities8();
    }
}
