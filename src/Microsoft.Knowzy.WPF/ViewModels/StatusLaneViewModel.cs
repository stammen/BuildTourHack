using Caliburn.Micro;
using Microsoft.Knowzy.Common.Messages;
using Microsoft.Knowzy.Domain;
using Microsoft.Knowzy.Domain.Enums;
using System.Collections.Generic;

namespace Microsoft.Knowzy.WPF.ViewModels
{
    public class StatusLaneViewModel : Screen
    {
        private readonly IEventAggregator _eventAggregator;
        private Product _selectedDevelopmentItem;

        public StatusLaneViewModel(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
        }

        public DevelopmentStatus Status { get; set; }

        public IEnumerable<Product> Items { get; set; }

        public int CascadeLevel { get; set; }

        public Product SelectedDevelopmentItem
        {
            get { return _selectedDevelopmentItem; }
            set
            {
                if (Equals(value, _selectedDevelopmentItem)) return;
                _selectedDevelopmentItem = value;
                NotifyOfPropertyChange(() => SelectedDevelopmentItem);
                EditItem();
            }
        }

        public void EditItem()
        {
            _eventAggregator.PublishOnUIThread(new EditItemMessage(SelectedDevelopmentItem));
        }
    }
}
