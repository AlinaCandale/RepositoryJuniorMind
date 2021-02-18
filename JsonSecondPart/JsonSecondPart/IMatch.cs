using System;
using System.Collections.Generic;
using System.Text;

namespace JsonSecondPart
{
    public interface IMatch
    {
        bool Success();
        string RemainingText();
    }
}
