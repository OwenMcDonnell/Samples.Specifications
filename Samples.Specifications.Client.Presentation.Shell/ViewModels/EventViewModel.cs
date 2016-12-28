﻿using System;
using System.Threading.Tasks;
using LogoFX.Client.Mvvm.ViewModel.Extensions;
using Samples.Client.Model.Contracts;

namespace Samples.Specifications.Client.Presentation.Shell.ViewModels
{
    public sealed class EventViewModel : EditableObjectViewModel<IEvent>
    {
        public EventViewModel(IEvent model)
            : base(model)
        {

        }

        public DateTime Time
        {
            get { return Model.Time; }
        }

        public string Message
        {
            get { return Model.Message; }
        }

        protected override Task<bool> SaveMethod(IEvent model)
        {
            throw new NotImplementedException();
        }
    }
}