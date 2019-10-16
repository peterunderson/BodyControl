using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using System.Linq;

namespace BodyControlApp
{
    class NumericValidationBehaviour : Behavior<Entry>
    {
        protected override void OnAttachedTo(Entry entry)
        {
            entry.TextChanged += OnEntryTextChanged;
            base.OnAttachedTo(entry);
        }

        protected override void OnDetachingFrom(Entry entry)
        {
            entry.TextChanged -= OnEntryTextChanged;
            base.OnDetachingFrom(entry);
        }

        private static void OnEntryTextChanged(object sender, TextChangedEventArgs args)
        {
            if (args.NewTextValue!=null)
            {
                bool isValid = args.NewTextValue.ToCharArray().All(x => char.IsDigit(x) || x == '.' || x == ',');
                if (args.NewTextValue.ToCharArray().Count(x=>x=='.'||x==',')>1)                
                    isValid = false;                
                if (args.NewTextValue.StartsWith(',') || args.NewTextValue.StartsWith('.'))                
                    isValid = false;                
                ((Entry)sender).Text = isValid ? args.NewTextValue : args.NewTextValue.Remove(args.NewTextValue.Length - 1);
            }
        }

    }
}
