using Caliburn.Micro;
using Microsoft.Knowzy.Domain.Enums;
using Microsoft.Knowzy.WPF.Messages;
using System.Collections.Generic;

namespace Microsoft.Knowzy.WPF.ViewModels
{
    public class StatusLaneViewModel : Screen
    {
        private readonly IEventAggregator _eventAggregator;
        private ItemViewModel _selectedItem;

        public StatusLaneViewModel(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
        }

        public DevelopmentStatus Status { get; set; }

        public IEnumerable<ItemViewModel> Items { get; set; }

        public int CascadeLevel { get; set; }

        public ItemViewModel SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                if (Equals(value, _selectedItem)) return;
                _selectedItem = value;
                NotifyOfPropertyChange(() => SelectedItem);
                EditItem();
            }
        }

        public void EditItem()
        {
            _eventAggregator.PublishOnUIThread(new EditItemMessage(SelectedItem));
        }
    }
}
