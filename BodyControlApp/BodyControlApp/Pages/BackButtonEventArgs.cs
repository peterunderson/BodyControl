using System;
using System.Collections.Generic;
using System.Text;

namespace BodyControlApp.Pages
{
    public class BackButtonEventArgs :EventArgs
    {
        public bool Cancel { get; set; }

        public BackButtonEventArgs()
        {
           
        }
    }
}
