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
using Microsoft.Knowzy.WPF.Messages;
using Microsoft.Knowzy.WPF.ViewModels.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Microsoft.Knowzy.WPF.ViewModels
{
    public class MainViewModel : Screen, IHandle<UpdateLanesMessage>
    {
        private readonly IDataProvider _dataProvider;

        public MainViewModel(IDataProvider dataProvider)
        {
            _dataProvider = dataProvider;
        }

        public List<Screen> ScreenList { get; set; }

        public ObservableCollection<ItemViewModel> DevelopmentItems { get; set; } = new ObservableCollection<ItemViewModel>();

        protected override void OnViewAttached(object view, object context)
        {
            foreach (var item in _dataProvider.GetData())
            {
                DevelopmentItems.Add(new ItemViewModel(item));
            }
            
            base.OnViewAttached(view, context);
        }

        public void Handle(UpdateLanesMessage message)
        {
            throw new System.NotImplementedException();
        }
    }
}
