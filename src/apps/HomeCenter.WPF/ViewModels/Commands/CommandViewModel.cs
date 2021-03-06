﻿using System;
using Caliburn.Micro;

namespace HomeCenter.NET.ViewModels.Commands
{
    public class CommandViewModel : Screen
    {
        #region Properties

        public string Name { get; set; }

        public Action<string>? DescriptionEditAction { get; set; }

        private string _description = string.Empty;
        public string Description
        {
            get => _description;
            set
            {
                _description = value;
                DescriptionEditAction?.Invoke(value);
                NotifyOfPropertyChange(nameof(Description));
            }
        }

        public bool IsEditable { get; }
        public bool IsNotEditable => !IsEditable;

        public bool CommandNameIsVisible => Name != null;
        public bool RunIsVisible { get; }
        public bool EditIsVisible { get; }
        public bool DeleteIsVisible { get; }

        public string? HotKey { get; }
        public bool HotKeyIsVisible => HotKey != null;

        #endregion

        #region Constructors

        public CommandViewModel(string name, string description, string? hotKey = null, bool editable = false,
        bool run = false, bool edit = false, bool delete = false)
        {
            Name = name;
            Description = description;

            IsEditable = editable;
            RunIsVisible = run;
            EditIsVisible = edit;
            DeleteIsVisible = delete;

            HotKey = hotKey;
        }

        #endregion
    }
}
