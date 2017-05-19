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
using Microsoft.Knowzy.WPF.ViewModels.Models;

namespace Microsoft.Knowzy.WPF.Messages
{
    public class UpdateLanesMessage
    {
        public UpdateLanesMessage(ItemViewModel item, DevelopmentStatus previousStatus)
        {
            Item = item;
            PreviousStatus = previousStatus;
        }

        public ItemViewModel Item { get; }

        public DevelopmentStatus PreviousStatus { get; }
    }
}