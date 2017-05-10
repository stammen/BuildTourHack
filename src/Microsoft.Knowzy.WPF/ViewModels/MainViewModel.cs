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
using Microsoft.Knowzy.Domain;
using System.Linq;
using Microsoft.Knowzy.Common.Messages;

namespace Microsoft.Knowzy.WPF.ViewModels
{
    public class MainViewModel : Screen
    {
        private readonly IDataProvider _dataProvider;
        private readonly IEventAggregator _eventAggregator;
        private readonly EditItemViewModel _editItemViewModel;
        private DevelopmentItem _selectedDevelopmentItem;

        public MainViewModel(EditItemViewModel editItemViewModel, IDataProvider dataProvider, IEventAggregator eventAggregator)
        {
            _editItemViewModel = editItemViewModel;
            _dataProvider = dataProvider;
            _eventAggregator = eventAggregator;
        }

        public List<DevelopmentItem> DevelopmentItems { get; private set; }

        public DevelopmentItem SelectedDevelopmentItem
        {
            get { return _selectedDevelopmentItem; }
            set
            {
                if (Equals(value, _selectedDevelopmentItem)) return;
                _selectedDevelopmentItem = value;
                NotifyOfPropertyChange(() => SelectedDevelopmentItem);
            }
        }

        public void  EditItem()
        {
            _eventAggregator.PublishOnUIThread(new EditItemMessage(SelectedDevelopmentItem));
        }

        protected override void OnActivate()
        {
            base.OnActivate();
            DevelopmentItems = _dataProvider.GetData().ToList();
        }
    }
}
