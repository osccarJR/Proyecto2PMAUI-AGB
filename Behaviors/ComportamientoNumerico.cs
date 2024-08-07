﻿using System.Linq;
using Microsoft.Maui.Controls;

namespace InterfazTicketsApp.Behaviors
{
    public class ComportamientoNumerico : Behavior<Entry>
    {
        public int MaxLength { get; set; }

        protected override void OnAttachedTo(Entry bindable)
        {
            bindable.TextChanged += OnEntryTextChanged;
            base.OnAttachedTo(bindable);
        }

        protected override void OnDetachingFrom(Entry bindable)
        {
            bindable.TextChanged -= OnEntryTextChanged;
            base.OnDetachingFrom(bindable);
        }

        void OnEntryTextChanged(object sender, TextChangedEventArgs e)
        {
            var entry = (Entry)sender;
            string newText = new string(entry.Text.Where(char.IsDigit).ToArray());

            if (newText.Length > MaxLength)
            {
                newText = newText.Substring(0, MaxLength);
            }

            entry.Text = newText;
        }
    }
}
