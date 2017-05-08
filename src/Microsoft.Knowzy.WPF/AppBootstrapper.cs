/**
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
**/

using System;
using Autofac;
using Caliburn.Micro;
using Microsoft.Knowzy.WPF.ViewModels;

namespace Microsoft.Knowzy.WPF
{
    public class AppBootstrapper : BootstrapperBase
    {
        IContainer _container;

        public AppBootstrapper()
        {
            Initialize();
        }

        protected override void Configure()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<EventAggregator>().As<IEventAggregator>().SingleInstance();
            builder.RegisterType<WindowManager>().As<IWindowManager>().SingleInstance();

            builder.RegisterType<ShellViewModel>().SingleInstance();
            builder.RegisterType<MainViewModel>().SingleInstance();
            builder.RegisterType<AddNewItemViewModel>().SingleInstance();
            
            _container = builder.Build();
        }

        protected override object GetInstance(Type service, string key)
        {
            var instance = _container.Resolve(service);
            if (instance != null)
            {
                return instance;
            }
            throw new InvalidOperationException("Could not locate any instances.");
        }

        protected override void OnStartup(object sender, System.Windows.StartupEventArgs e)
        {
            DisplayRootViewFor<ShellViewModel>();
        }
    }
}