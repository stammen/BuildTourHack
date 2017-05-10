//*********************************************************
//
// Copyright (c) Microsoft. All rights reserved.
// This code is licensed under the MIT License (MIT).
// THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
// ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
// IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
// PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.
//
//*********************************************************

using Caliburn.Micro;
using Microsoft.Knowzy.Common.Messages;

namespace Microsoft.Knowzy.WPF.ViewModels
{
    public class ShellViewModel : Conductor<Screen>, IHandle<EditItemMessage>
    {
        private readonly MainViewModel _mainViewModel;
        private readonly EditItemViewModel _editItemViewModel;
        private readonly IEventAggregator _eventAggregator;
        private readonly IWindowManager _windowManager;

        public ShellViewModel(MainViewModel mainViewModel, EditItemViewModel editItemViewModel, IEventAggregator eventAggregator, IWindowManager windowManager)
        {
            _mainViewModel = mainViewModel;
            _editItemViewModel = editItemViewModel;
            _eventAggregator = eventAggregator;
            _windowManager = windowManager;
        }

        protected override void OnViewAttached(object view, object context)
        {
            _eventAggregator.Subscribe(this);
            ActivateItem(_mainViewModel);
            base.OnViewAttached(view, context);
        }

        protected override void OnDeactivate(bool close)
        {
            _eventAggregator.Unsubscribe(this);
            base.OnDeactivate(close);
        }

        public void Handle(EditItemMessage message)
        {
            _editItemViewModel.Item = message.Item;
            _windowManager.ShowDialog(_editItemViewModel);
        }
    }
}
