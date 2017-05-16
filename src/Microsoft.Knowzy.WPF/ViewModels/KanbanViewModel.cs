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

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Caliburn.Micro;
using Microsoft.Knowzy.Common.Contracts;
using Microsoft.Knowzy.Domain.Enums;
using Microsoft.Knowzy.WPF.ViewModels.Models;

namespace Microsoft.Knowzy.WPF.ViewModels
{
    public sealed class KanbanViewModel : Screen
    {
        private readonly MainViewModel _mainViewModel;
        private readonly IDataProvider _dataProvider;
        private readonly IEventAggregator _eventAggregator;

        public KanbanViewModel(MainViewModel mainViewModel, IDataProvider dataProvider, IEventAggregator eventAggregator)
        {
            _mainViewModel = mainViewModel;
            _dataProvider = dataProvider;
            _eventAggregator = eventAggregator;
            DisplayName = Localization.Resources.GridView_Tab;
        }

        public ObservableCollection<ItemViewModel> DevelopmentItems => _mainViewModel.DevelopmentItems;

        public List<StatusLaneViewModel> Lanes { get; private set; }

        protected override void OnViewAttached(object view, object context)
        {
            base.OnViewAttached(view, context);
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
                    Items = _mainViewModel.DevelopmentItems?.Where(item => item.Status == (DevelopmentStatus)status).ToList()
                });
                level++;
            }
        }
    }
}
