using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Maui.Controls;

namespace InterfazTicketsApp.Behaviors
{
    public class ComportamientoExpira : Behavior<Entry>
    {
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
            var text = entry.Text;

            if (string.IsNullOrEmpty(text))
                return;

            if (text.Length == 2 && e.OldTextValue?.Length != 3)
            {
                text += "/";
            }

            if (text.Length > 5)
            {
                text = text.Substring(0, 5);
            }

            entry.Text = text;

            if (text.Length == 5)
            {
                var month = int.Parse(text.Substring(0, 2));
                var year = int.Parse(text.Substring(3, 2)) + 2000;

                if (month < 1 || month > 12 || year < DateTime.Now.Year || (year == DateTime.Now.Year && month < DateTime.Now.Month))
                {
                    entry.Text = e.OldTextValue;
                }
            }
        }
    }
}