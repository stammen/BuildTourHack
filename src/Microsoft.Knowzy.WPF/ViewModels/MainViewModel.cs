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
using Microsoft.Knowzy.Common.Contracts;
using Microsoft.Knowzy.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Microsoft.Knowzy.WPF.Messages;

namespace Microsoft.Knowzy.WPF.ViewModels
{
    public class MainViewModel : Screen
    {
        private readonly IDataProvider _dataProvider;
        private readonly IEventAggregator _eventAggregator;
        private ItemViewModel _selectedDevelopmentItem;
        private readonly EditItemViewModel _editItemViewModel;

        public MainViewModel(IDataProvider dataProvider, IEventAggregator eventAggregator)
        {
            _dataProvider = dataProvider;
            _eventAggregator = eventAggregator;
        }

        public List<ItemViewModel> DevelopmentItems { get; set; } = new List<ItemViewModel>();

        public List<StatusLaneViewModel> Lanes { get; private set; }

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

        protected override void OnActivate()
        {
            base.OnActivate();
            foreach (var item in _dataProvider.GetData())
            {
                DevelopmentItems.Add(new ItemViewModel(item));
            }
            InitializeLanes();
        }

        private void InitializeLanes()
        {
            Lanes = new List<StatusLaneViewModel>();
            var level = 0;
            foreach (var status in Enum.GetValues(typeof(DevelopmentStatus)))
            {
                Lanes.Add(new StatusLaneViewModel(_eventAggregator)
                {
                    Status = (DevelopmentStatus)status,
                    CascadeLevel = level,
                    Items = DevelopmentItems?.Where(item => item.Status == (DevelopmentStatus)status).ToList()
                });
                level++;
            }
        }

        public void SortProducts(object sortField, bool sort)
        {
            var field = sortField as string;
            if (string.IsNullOrEmpty(field)) return;

            DevelopmentItems = SortProductsByField(field);
            if (!sort)
            {
                DevelopmentItems.Reverse();
            }

            NotifyOfPropertyChange(() => DevelopmentItems);
        }

        private List<ItemViewModel> SortProductsByField(Object field)
        {
            var sortItem = new List<ItemViewModel>();
            switch (field)
            {
                case "Id":
                    sortItem = DevelopmentItems.OrderBy(item => item.Id).ToList();
                    break;
                case "Engineer":
                    sortItem = DevelopmentItems.OrderBy(item => item.Engineer).ToList();
                    break;
                case "Name":
                    sortItem = DevelopmentItems.OrderBy(item => item.Name).ToList();
                    break;
                case "Material":
                    sortItem = DevelopmentItems.OrderBy(item => item.RawMaterial).ToList();
                    break;
                case "Status":
                    sortItem = DevelopmentItems.OrderBy(item => item.Status).ToList();
                    break;
            }

            return sortItem;
        }
    }
}
