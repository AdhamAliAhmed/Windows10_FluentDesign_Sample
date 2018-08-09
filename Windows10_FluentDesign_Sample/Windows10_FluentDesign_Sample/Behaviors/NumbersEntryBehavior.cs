using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace Windows10_FluentDesign_Sample.Behaviors
{
    public class NumbersEntryBehavior : Behavior<Entry>
    {
        protected override void OnAttachedTo(Entry bindable)
        {
            base.OnAttachedTo(bindable);

            bindable.TextChanged += Entry_TextChanged;
        }

        protected override void OnDetachingFrom(Entry bindable)
        {
            base.OnDetachingFrom(bindable);

            bindable.TextChanged -= Entry_TextChanged;
        }

        private void Entry_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrEmpty(e.NewTextValue))
            {
                ((Entry)sender).Text = 0.ToString();
                return;
            }

            double _;
            if (!double.TryParse(e.NewTextValue, out _))
                ((Entry)sender).Text = e.OldTextValue;
        }
    }
}
