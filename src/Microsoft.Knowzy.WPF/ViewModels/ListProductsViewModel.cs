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

using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Data;
using Caliburn.Micro;
using Microsoft.Knowzy.WPF.Messages;
using Microsoft.Knowzy.WPF.ViewModels.Models;

namespace Microsoft.Knowzy.WPF.ViewModels
{
    public sealed class ListProductsViewModel : Screen
    {
        private ItemViewModel _selectedDevelopmentItem;
        private readonly MainViewModel _mainViewModel;
        private readonly IEventAggregator _eventAggregator;

        public ListProductsViewModel(MainViewModel mainViewModel, IEventAggregator eventAggregator)
        {
            _mainViewModel = mainViewModel;
            _eventAggregator = eventAggregator;
            DisplayName = Localization.Resources.ListView_Tab;
        }

        public ObservableCollection<ItemViewModel> DevelopmentItems => _mainViewModel.DevelopmentItems;

        public ItemViewModel SelectedDevelopmentItem
        {
            get => _selectedDevelopmentItem;
            set
            {
                if (Equals(value, _selectedDevelopmentItem)) return;
                _selectedDevelopmentItem = value;
                NotifyOfPropertyChange(() => SelectedDevelopmentItem);
                EditItem();
            }
        }

        public void EditItem()
        {
            _eventAggregator.PublishOnUIThread(new EditItemMessage(SelectedDevelopmentItem));
        }

        public void SortProducts(object sortField, bool isSortAscending)
        {
            var field = sortField as string;
            if (string.IsNullOrEmpty(field)) return;

            var view = CollectionViewSource.GetDefaultView(DevelopmentItems);

            var sortDirection = isSortAscending ? ListSortDirection.Ascending : ListSortDirection.Descending;
            view.SortDescriptions.Clear();
            view.SortDescriptions.Add(new SortDescription(field, sortDirection));
        }
    }
}
