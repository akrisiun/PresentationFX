using System;
using MS.Internal;

namespace System.Windows.Input
{
    /////////////////////////////////////////////////////////////////////////
    /// <summary>
    ///     The Stylus struct used to store Stylus cursor information.
    /// </summary>
    internal struct StylusDeviceInfo
    {
        public string   CursorName;
        public int      CursorId;
        public bool     CursorInverted;
        public StylusButtonCollection ButtonCollection;
    }
}

