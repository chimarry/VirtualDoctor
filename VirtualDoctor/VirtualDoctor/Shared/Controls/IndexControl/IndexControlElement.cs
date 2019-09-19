using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using VirtualDoctor.Shared.Controls.DataGridControls;
using VirtualDoctor.Shared.Helpers;

namespace VirtualDoctor.Shared.Controls.IndexControl
{
    public abstract class IndexControlElement
    {

        public abstract void Create(double height = 0.0, double width = 0.0);
        public abstract void Delete(object selectedItem, double height = 0.0, double width = 0.0);
        public abstract void Edit(object selectedItem, double height = 0.0, double width = 0.0);
        public virtual void Details(object selectedItem, double height = 0.0, double width = 0.0)
        {
            throw new NotImplementedException();
        }

    }
}
