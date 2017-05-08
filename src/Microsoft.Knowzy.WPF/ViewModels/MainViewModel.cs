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
using System.Collections.ObjectModel;
using System.Linq;

namespace Microsoft.Knowzy.WPF.ViewModels
{
    public class MainViewModel : Screen
    {
        private readonly IWindowManager _windowManager;
        private readonly IDataProvider _dataProvider;
        private readonly EditItemViewModel _editItemViewModel;

        public MainViewModel(IWindowManager windowManager, EditItemViewModel editItemViewModel, IDataProvider dataProvider)
        {
            _windowManager = windowManager;
            _editItemViewModel = editItemViewModel;
            _dataProvider = dataProvider;
        }

        public List<DevelopmentItem> DevelopmentItems { get; private set; }

        public void  EditItem()
        {
            _windowManager.ShowWindow(_editItemViewModel);
        }

        protected override void OnActivate()
        {
            base.OnActivate();
            DevelopmentItems = _dataProvider.GetData().ToList();
        }
    }
}
