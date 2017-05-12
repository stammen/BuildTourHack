using Caliburn.Micro;
using Microsoft.Knowzy.Domain.Enums;
using Microsoft.Knowzy.WPF.Messages;
using System.Collections.Generic;

namespace Microsoft.Knowzy.WPF.ViewModels
{
    public class StatusLaneViewModel : Screen
    {
        private readonly IEventAggregator _eventAggregator;
        private ItemViewModel _selectedDevelopmentItem;

        public StatusLaneViewModel(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
        }

        public DevelopmentStatus Status { get; set; }

        public IEnumerable<ItemViewModel> Items { get; set; }

        public int CascadeLevel { get; set; }

        public ItemViewModel SelectedDevelopmentItem
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
