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
using System.Linq;
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

        public void SortProducts(object sortField, bool sort)
        {
            var field = sortField as string;
            if (string.IsNullOrEmpty(field)) return;

            _mainViewModel.DevelopmentItems = SortProductsByField(field);
            if (!sort)
            {
                _mainViewModel.DevelopmentItems.Reverse();
            }

            NotifyOfPropertyChange(() => _mainViewModel.DevelopmentItems);
        }

        private ObservableCollection<ItemViewModel> SortProductsByField(object field)
        {
            // TODO: Better order in Visual
            var sortItem = new ObservableCollection<ItemViewModel>();
            switch (field)
            {
                // TODO: don't use magical strings
                case "Id":
                    sortItem = new ObservableCollection<ItemViewModel>(_mainViewModel.DevelopmentItems.OrderBy(item => item.Id));
                    break;
                case "Engineer":
                    sortItem = new ObservableCollection<ItemViewModel>(_mainViewModel.DevelopmentItems.OrderBy(item => item.Engineer).ToList());
                    break;
                case "Name":
                    sortItem = new ObservableCollection<ItemViewModel>(_mainViewModel.DevelopmentItems.OrderBy(item => item.Name).ToList());
                    break;
                case "Material":
                    sortItem = new ObservableCollection<ItemViewModel>(_mainViewModel.DevelopmentItems.OrderBy(item => item.RawMaterial).ToList());
                    break;
                case "Status":
                    sortItem = new ObservableCollection<ItemViewModel>(_mainViewModel.DevelopmentItems.OrderBy(item => item.Status).ToList());
                    break;
            }

            return sortItem;
        }
    }
}
