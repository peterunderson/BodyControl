using System;
using System.Collections.Generic;
using System.Text;

namespace BodyControlApp
{  

    class PageConfigAttribute :Attribute
    {
        public PageConfigAttribute(string flyoutName, string flyoutIcon,string navBarImage, int FlyoutItemPosition)
        {
            FlyoutName = flyoutName;
            FlyoutIcon = flyoutIcon;
            NavBarImage = navBarImage;
            this.FlyoutItemPosition = FlyoutItemPosition;
        }

        public string FlyoutName { get; }
        public string FlyoutIcon { get; }
        public string NavBarImage { get; }
        public int FlyoutItemPosition { get; }
    }
}
