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

using Microsoft.Knowzy.Domain.Enums;
using Microsoft.Knowzy.WPF.Localization;
using System;
using System.Globalization;
using System.Windows.Data;

namespace Microsoft.Knowzy.WPF.Converters
{
    public class DevelopmentStatusToStringConverter : IValueConverter
    {
        public const string DevelopmentStatusResourcePrefix = "DevelopmentStatus_";

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (value == null || !(value is DevelopmentStatus))
                    ? string.Empty
                    : Resources.ResourceManager.GetString($"{DevelopmentStatusResourcePrefix}{value}");
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
