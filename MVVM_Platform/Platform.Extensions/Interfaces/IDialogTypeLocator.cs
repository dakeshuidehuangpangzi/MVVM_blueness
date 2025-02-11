using Platform.Extensions.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platform.Extensions.Interfaces
{
    public interface IDialogTypeLocator
    {
        Type Locate(IviewModel viewModel);
    }
}
