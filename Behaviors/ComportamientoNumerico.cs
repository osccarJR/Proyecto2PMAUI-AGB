using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Maui.Controls;

namespace InterfazTicketsApp.Behaviors
{
    public class ComportamientoNumerico : Behavior<Entry>
    {
        public int MaxLength { get; set; }

        protected override void OnAttachedTo(Entry bindable)
        {
            bindable.TextChanged += OnTextChanged;
            base.OnAttachedTo(bindable);
        }

        protected override void OnDetachingFrom(Entry bindable)
        {
            bindable.TextChanged -= OnTextChanged;
            base.OnDetachingFrom(bindable);
        }

        private void OnTextChanged(object sender, TextChangedEventArgs e)
        {
            var entry = (Entry)sender;

            if (!string.IsNullOrEmpty(e.NewTextValue))
            {
                if (!int.TryParse(e.NewTextValue, out _))
                {
                    entry.Text = e.OldTextValue;
                }
                else if (MaxLength > 0 && e.NewTextValue.Length > MaxLength)
                {
                    entry.Text = e.NewTextValue.Substring(0, MaxLength);
                }
            }
        }
    }
}