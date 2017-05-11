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
using System.IO;
using Caliburn.Micro;
using System.Windows;
using System.Windows.Media.Imaging;
using Microsoft.Knowzy.Domain;
using Microsoft.Knowzy.Domain.Enums;
using Microsoft.Win32;

namespace Microsoft.Knowzy.WPF.ViewModels
{
    public class EditItemViewModel : Screen
    {
        private readonly string _imagesDirectory = AppDomain.CurrentDomain.BaseDirectory + "Assets\\";
        private DevelopmentItem _item;
        private DevelopmentStatus _status;
        private string _rawMaterial;
        private string _newProductName;
        private string _itemNumber;
        private string _engineer;
        private DateTime _developmentStartDate;
        private DateTime _expectedCompletionDate;
        private string _supplyManagementContact;
        private string _notes;
        private Uri _imageSource;

        public DevelopmentItem Item
        {
            get => _item;
            set
            {
                _item = value;
                Engineer = _item.Engineer;
                ItemNumber = _item.ItemNumber;
                NewProductName = _item.NewProductName;
                RawMaterial = _item.RawMaterial;
                DevelopmentStartDate = _item.DevelopmentStartDate;
                ExpectedCompletionDate = _item.ExpectedCompletionDate;
                SupplyManagementContact = _item.SupplyManagementContact;
                Notes = _item.Notes;
                Status = _item.Status;
                ImageSource = new Uri(_imagesDirectory + Item.ImageSource);
            }
        }

        public DateTime DevelopmentStartDate
        {
            get => _developmentStartDate;
            set
            {
                if (value.Equals(_developmentStartDate)) return;
                _developmentStartDate = value;
                NotifyOfPropertyChange(() => DevelopmentStartDate);
            }
        }

        public DateTime ExpectedCompletionDate
        {
            get => _expectedCompletionDate;
            set
            {
                if (value.Equals(_expectedCompletionDate)) return;
                _expectedCompletionDate = value;
                NotifyOfPropertyChange(() => ExpectedCompletionDate);
            }
        }

        public string SupplyManagementContact
        {
            get => _supplyManagementContact;
            set
            {
                if (value == _supplyManagementContact) return;
                _supplyManagementContact = value;
                NotifyOfPropertyChange(() => SupplyManagementContact);
            }
        }

        public string Notes
        {
            get => _notes;
            set
            {
                if (value == _notes) return;
                _notes = value;
                NotifyOfPropertyChange(() => Notes);
            }
        }

        public DevelopmentStatus Status
        {
            get => _status;
            set
            {
                if (value == _status) return;
                _status = value;
                NotifyOfPropertyChange(() => Status);
            }
        }

        public string RawMaterial
        {
            get => _rawMaterial;
            set
            {
                if (value == _rawMaterial) return;
                _rawMaterial = value;
                NotifyOfPropertyChange(() => RawMaterial);
            }
        }

        public string NewProductName
        {
            get => _newProductName;
            set
            {
                if (value == _newProductName) return;
                _newProductName = value;
                NotifyOfPropertyChange(() => NewProductName);
            }
        }

        public string ItemNumber
        {
            get => _itemNumber;
            set
            {
                if (value == _itemNumber) return;
                _itemNumber = value;
                NotifyOfPropertyChange(() => ItemNumber);
            }
        }

        public string Engineer
        {
            get => _engineer;
            set
            {
                if (value == _engineer) return;
                _engineer = value;
                NotifyOfPropertyChange(() => Engineer);
            }
        }

        public Uri ImageSource
        {
            get => _imageSource;
            set
            {
                if (value == _imageSource) return;
                _imageSource = value;
                NotifyOfPropertyChange(() => ImageSource);
            }
        }

        public void UploadPhoto()
        {
            var openFileDialog = new OpenFileDialog {Filter = "Image Files(*.BMP;*.JPG;*.PNG;*.GIF)|*.BMP;*.JPG;*.GIF;*.PNG"};
            if (openFileDialog.ShowDialog() == true)
            {
                var storeFilePath = _imagesDirectory + Path.GetFileName(openFileDialog.FileName);
                if (!File.Exists(storeFilePath))
                {
                    File.Copy(openFileDialog.FileName, storeFilePath);
                }
                ImageSource = new Uri(storeFilePath);
            }
        }

        public void CloseEditWindow()
        {
            var window = GetView() as Window;
            window?.Close();
        }

        public void SaveAndCloseEditWindow()
        {
            _item.Engineer = Engineer;
            _item.ItemNumber = ItemNumber;
            _item.NewProductName = NewProductName;
            _item.RawMaterial = RawMaterial;
            _item.DevelopmentStartDate = DevelopmentStartDate;
            _item.ExpectedCompletionDate = ExpectedCompletionDate;
            _item.SupplyManagementContact = SupplyManagementContact;
            _item.Notes = Notes;
            _item.Status = Status;
            _item.ImageSource = ImageSource.LocalPath.Replace(_imagesDirectory, string.Empty);
            CloseEditWindow();
        }
    }
}
