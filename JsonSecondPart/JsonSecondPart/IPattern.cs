﻿using System;
using System.Collections.Generic;
using System.Text;

namespace JsonSecondPart
{
    public interface IPattern
    {
        IMatch Match(string text);
    }
}
