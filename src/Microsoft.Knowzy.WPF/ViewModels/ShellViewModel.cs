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

using System.Collections.Generic;
using Caliburn.Micro;
using Microsoft.Knowzy.WPF.Messages;

namespace Microsoft.Knowzy.WPF.ViewModels
{
    public class ShellViewModel : Conductor<Screen>, IHandle<EditItemMessage>, IHandle<UpdateLanesMessage>, IHandle<OpenAboutMessage>, IHandle<OpenLoginMessage>,
        IHandle<CloseLoginMessage>
    {
        private readonly MainViewModel _mainViewModel;
        private readonly ListProductsViewModel _listProductsViewModel;
        private readonly KanbanViewModel _kanbanViewModel;
        private readonly EditItemViewModel _editItemViewModel;
        private readonly LoginViewModel _loginViewModel;
        private readonly AboutViewModel _aboutViewModel;
        private readonly IEventAggregator _eventAggregator;
        private readonly IWindowManager _windowManager;

        public ShellViewModel(MainViewModel mainViewModel, ListProductsViewModel listProductsViewModel, KanbanViewModel kanbanViewModel, 
            EditItemViewModel editItemViewModel, LoginViewModel loginViewModel, AboutViewModel aboutViewModel,
            IEventAggregator eventAggregator, IWindowManager windowManager)
        {
            _mainViewModel = mainViewModel;
            _listProductsViewModel = listProductsViewModel;
            _kanbanViewModel = kanbanViewModel;
            _editItemViewModel = editItemViewModel;
            _loginViewModel = loginViewModel;
            _aboutViewModel = aboutViewModel;
            _eventAggregator = eventAggregator;
            _windowManager = windowManager;
        }

        protected override void OnViewAttached(object view, object context)
        {
            _eventAggregator.Subscribe(this);
            _mainViewModel.ScreenList = new List<Screen> { _listProductsViewModel, _kanbanViewModel}; 
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

        public void Handle(UpdateLanesMessage message)
        {
            _kanbanViewModel.InitializeLanes();
            _mainViewModel.Save();
        }

        public void Handle(OpenAboutMessage message)
        {
            _windowManager.ShowDialog(_aboutViewModel);
        }

        public void Handle(OpenLoginMessage message)
        {
            _windowManager.ShowDialog(_loginViewModel);
        }

        public void Handle(CloseLoginMessage message)
        {

        }
    }
}
