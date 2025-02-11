using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platform.Extensions.Enum
{
    public interface IviewModel
    {
        string? Title { get; set; }

        EDialogResult DialogResult { get; protected set; }
    }
}
