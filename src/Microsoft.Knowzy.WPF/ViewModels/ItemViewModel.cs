using System;
using Caliburn.Micro;
using Microsoft.Knowzy.Domain;
using Microsoft.Knowzy.Domain.Enums;

namespace Microsoft.Knowzy.WPF.ViewModels
{
    public class ItemViewModel : PropertyChangedBase
    {
        private readonly Product _developmentItem;

        public ItemViewModel(Product developmentItem)
        {
            _developmentItem = developmentItem;
        }

        public string Id
        {
            get => _developmentItem.Id;
            set
            {
                _developmentItem.Id = value;
                NotifyOfPropertyChange(() => Id);   
            }
        }

        public string Engineer
        {
            get => _developmentItem.Engineer;
            set
            {
                _developmentItem.Engineer = value;
                NotifyOfPropertyChange(() => Engineer);
            }
        }

        public string Name
        {
            get => _developmentItem.Name;
            set
            {
                _developmentItem.Name = value;
                NotifyOfPropertyChange(() => Name);
            }
        }

        public string RawMaterial
        {
            get => _developmentItem.RawMaterial;
            set
            {
                _developmentItem.RawMaterial = value;
                NotifyOfPropertyChange(() => RawMaterial);
            }
        }

        public DevelopmentStatus Status
        {
            get => _developmentItem.Status;
            set
            {
                _developmentItem.Status = value;
                NotifyOfPropertyChange(() => Status);
            }
        }

        public DateTime DevelopmentStartDate
        {
            get => _developmentItem.DevelopmentStartDate;
            set
            {
                _developmentItem.DevelopmentStartDate = value;
                NotifyOfPropertyChange(() => DevelopmentStartDate);
            }
        }

        public DateTime ExpectedCompletionDate
        {
            get => _developmentItem.ExpectedCompletionDate;
            set
            {
                _developmentItem.ExpectedCompletionDate = value;
                NotifyOfPropertyChange(() => ExpectedCompletionDate);
            }
        }

        public string SupplyManagementContact
        {
            get => _developmentItem.SupplyManagementContact;
            set
            {
                _developmentItem.SupplyManagementContact = value;
                NotifyOfPropertyChange(() => SupplyManagementContact);
            }
        }

        public string Notes
        {
            get => _developmentItem.Notes;
            set
            {
                _developmentItem.Notes = value;
                NotifyOfPropertyChange(() => Notes);
            }
        }

        public string ImageSource
        {
            get => _developmentItem.ImageSource;
            set
            {
                _developmentItem.ImageSource = value;
                NotifyOfPropertyChange(() => ImageSource);
            }
        }
    }
}
