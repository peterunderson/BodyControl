using System;
using System.Collections.Generic;
using System.Text;

namespace BodyControlApp
{  

    class FlyoutItemAttribute :Attribute
    {
        public FlyoutItemAttribute(string flyoutName, string flyoutIcon, int FlyoutItemPosition)
        {
            FlyoutName = flyoutName;
            FlyoutIcon = flyoutIcon;
            this.FlyoutItemPosition = FlyoutItemPosition;
        }

        public string FlyoutName { get; }
        public string FlyoutIcon { get; }
        public int FlyoutItemPosition { get; }
    }
}
