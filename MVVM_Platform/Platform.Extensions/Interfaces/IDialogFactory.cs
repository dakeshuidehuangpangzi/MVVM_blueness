using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platform.Extensions.Interfaces
{
    public interface IDialogFactory
    {
        iWindow Create(Type dialogType);
    }
}
