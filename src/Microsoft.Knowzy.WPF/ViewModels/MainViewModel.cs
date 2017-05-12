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
using Microsoft.Knowzy.Common.Messages;
using Microsoft.Knowzy.Domain;
using Microsoft.Knowzy.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Microsoft.Knowzy.WPF.ViewModels
{
    public class MainViewModel : Screen
    {
        private readonly IDataProvider _dataProvider;
        private readonly IEventAggregator _eventAggregator;
        private readonly EditItemViewModel _editItemViewModel;
        private DevelopmentItem _selectedDevelopmentItem;

        public MainViewModel(EditItemViewModel editItemViewModel, IDataProvider dataProvider,
            IEventAggregator eventAggregator)
        {
            _editItemViewModel = editItemViewModel;
            _dataProvider = dataProvider;
            _eventAggregator = eventAggregator;
        }

        public List<DevelopmentItem> DevelopmentItems { get; private set; }

        public List<StatusLaneViewModel> Lanes { get; private set;}

        public DevelopmentItem SelectedDevelopmentItem
        {
            get { return _selectedDevelopmentItem; }
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
            DevelopmentItems = _dataProvider.GetData().ToList();
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
    }
}
