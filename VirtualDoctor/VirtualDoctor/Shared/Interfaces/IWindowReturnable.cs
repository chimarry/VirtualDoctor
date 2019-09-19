using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace VirtualDoctor.Shared.Interfaces
{
    public interface IWindowReturnable
    {
        void ReturnToPreviousWindow();
        void SetReturningWindow(Window window);
    }
}
