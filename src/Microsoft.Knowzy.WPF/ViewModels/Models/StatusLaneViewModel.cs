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
using Microsoft.Knowzy.Domain.Enums;
using Microsoft.Knowzy.WPF.Messages;

namespace Microsoft.Knowzy.WPF.ViewModels.Models
{
    public class StatusLaneViewModel : Screen
    {
        private readonly IEventAggregator _eventAggregator;
        private ItemViewModel _selectedItem;

        public StatusLaneViewModel(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
        }

        public DevelopmentStatus Status { get; set; }

        public IEnumerable<ItemViewModel> Items { get; set; }

        public int CascadeLevel { get; set; }

        public ItemViewModel SelectedItem
        {
            get => _selectedItem;
            set
            {
                _selectedItem = value;
                NotifyOfPropertyChange(() => SelectedItem);
                EditItem();
            }
        }

        public void EditItem()
        {
            _eventAggregator.PublishOnUIThread(new EditItemMessage(SelectedItem));
        }
    }
}