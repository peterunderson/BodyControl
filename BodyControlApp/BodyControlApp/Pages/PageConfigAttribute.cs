using System;

namespace BodyControlApp.Pages
{  

    class PageConfigAttribute :Attribute
    {
        public PageConfigAttribute(string flyoutName, string flyoutIcon, int FlyoutItemPosition)
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
