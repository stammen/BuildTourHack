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
using Microsoft.Knowzy.Common.Contracts;
using Microsoft.Knowzy.WPF.Messages;
using Microsoft.Knowzy.WPF.ViewModels.Models;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using Microsoft.Knowzy.Authentication;

namespace Microsoft.Knowzy.WPF.ViewModels
{
    public class MainViewModel : Screen
    {
        private const int TabListView = 0;
        private const int TabGridView = 1;
        private readonly IDataProvider _dataProvider;
        private readonly IEventAggregator _eventAggregator;
        private readonly IAuthenticationService _authenticationService;


        public MainViewModel(IDataProvider dataProvider, IEventAggregator eventAggregator, IAuthenticationService authenticationService)
        {
            _dataProvider = dataProvider;
            _eventAggregator = eventAggregator;
            _authenticationService = authenticationService;
        }
        
        private int _selectedIndexTab;

        public int SelectedIndexTab
        {
            get => _selectedIndexTab;
            set
            {
                _selectedIndexTab = value;
                NotifyOfPropertyChange(() => SelectedIndexTab);
            }
        }

        public List<Screen> ScreenList { get; set; }

        public ObservableCollection<ItemViewModel> DevelopmentItems { get; set; } = new ObservableCollection<ItemViewModel>();

        public string LoggedUser
        {
            get
            {
                NotifyOfPropertyChange(() => HasLoggedUser);
                return _authenticationService.UserLogged;
            }
        }

        public bool HasLoggedUser => !string.IsNullOrWhiteSpace(_authenticationService.UserLogged);

        protected override void OnViewAttached(object view, object context)
        {
            foreach (var item in _dataProvider.GetData())
            {
                DevelopmentItems.Add(new ItemViewModel(item));
            }
            
            base.OnViewAttached(view, context);
        }

        public void ShowListView()
        {
            if (SelectedIndexTab == TabListView) return;
            SelectedIndexTab --;
        }

        public void ShowGridView()
        {
            if (SelectedIndexTab == TabGridView) return;
            SelectedIndexTab ++;
        }

        public void NewItem()
        {
            var item = new ItemViewModel();
            _eventAggregator.PublishOnUIThread(new EditItemMessage(item));

            if (item.Id == null) return;
            DevelopmentItems.Add(item);
        }

        public void Login()
        {
            _eventAggregator.PublishOnUIThread(new OpenLoginMessage());
        }

        public void Logout()
        {
            _authenticationService.Logout();
            NotifyOfPropertyChange(() => LoggedUser);
        }

        public void About()
        {
            _eventAggregator.PublishOnUIThread(new OpenAboutMessage());
        }

        public void Exit()
        {
            Application.Current.Shutdown();
        }

        public void Save()
        {
            var products = DevelopmentItems?.Select(item => item.Product).ToArray();
            _dataProvider.SetData(products);
        }
    }
}
