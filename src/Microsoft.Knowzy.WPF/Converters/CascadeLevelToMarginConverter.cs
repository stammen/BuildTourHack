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
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace Microsoft.Knowzy.WPF.Converters
{
    class CascadeLevelToMarginConverter : IValueConverter
    {
        public const int CascadeSize = 60;

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var level = (value is int)? (int)value : 0;
            return new Thickness(0, level * CascadeSize, 0, 0);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }    
    }
}
