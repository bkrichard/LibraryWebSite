using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BusinessObjectHelper
{
    public class Event
    {
        public delegate void IsSavableHandler(Boolean savable);
        public event IsSavableHandler evtIsSavable;

        public void RaiseEvent(Boolean savable)
        {
            if (evtIsSavable == null)
            {
                return;
            }
            else
            {
                evtIsSavable(savable);
            }
        }
    }
}