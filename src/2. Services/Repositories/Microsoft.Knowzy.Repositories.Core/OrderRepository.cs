using System.Linq;
using System.Threading.Tasks;
using Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Knowzy.Domain;
using Microsoft.Knowzy.Domain.Data;
using Micrososft.Knowzy.Repositories.Contracts;

namespace Microsoft.Knowzy.Repositories.Core
{
    public class OrderRepository : IOrderRepository
    {
        #region Fields

        private readonly KnowzyContext _context;

        #endregion

        #region Properties     

        public IUnitOfWork UnitOfWork => _context;

        #endregion

        #region Constructor

        public OrderRepository(KnowzyContext context)
        {
            _context = context;
        }

        #endregion

        #region Public Methods

        public Task AddShipping(Shipping shipping)
        {
            return _context.AddAsync(shipping);
        }

        public async Task UpdateShipping(Shipping shipping)
        {
            var existingParent = await _context.Shippings
                .Include(shippingItem => shippingItem.OrderLines)
                .Where(shippingItem => shippingItem.OrderNumber == shipping.OrderNumber)
                .SingleOrDefaultAsync();

            if (existingParent != null)
            {
                _context.Entry(existingParent).CurrentValues.SetValues(shipping);

                foreach (var existingChild in existingParent.OrderLines.ToList())
                {
                    if (shipping.OrderLines.All(c => c.Id != existingChild.Id))
                        _context.OrderLines.Remove(existingChild);
                }

                var existingChilds = existingParent.OrderLines.ToList();

                foreach (var childModel in shipping.OrderLines)
                {
                    var existingChild = existingChilds
                        .SingleOrDefault(child => child.Id == childModel.Id);

                    childModel.OrderNumber = existingParent.OrderNumber;

                    if (existingChild != null)
                        _context.Entry(existingChild).CurrentValues.SetValues(childModel);
                    else
                    {
                        var newChild = new OrderLine
                        {
                            ItemNumber = childModel.ItemNumber,
                            Quantity = childModel.Quantity,
                            OrderNumber = childModel.OrderNumber
                        };
                        existingParent.OrderLines.Add(newChild);
                    }
                }
            }
        }

        public Task AddReceiving(Receiving receiving)
        {
            return _context.AddAsync(receiving);
        }

        public async Task UpdateReceiving(Receiving receiving)
        {
            var existingParent = await _context.Receivings
                .Include(receivingItem => receivingItem.OrderLines)
                .Where(receivingItem => receivingItem.OrderNumber == receiving.OrderNumber)
                .SingleOrDefaultAsync();

            if (existingParent != null)
            {
                _context.Entry(existingParent).CurrentValues.SetValues(receiving);

                foreach (var existingChild in existingParent.OrderLines.ToList())
                {
                    if (receiving.OrderLines.All(c => c.Id != existingChild.Id))
                        _context.OrderLines.Remove(existingChild);
                }

                var existingChilds = existingParent.OrderLines.ToList();

                foreach (var childModel in receiving.OrderLines)
                {
                    var existingChild = existingChilds
                        .SingleOrDefault(child => child.Id == childModel.Id);

                    childModel.OrderNumber = existingParent.OrderNumber;

                    if (existingChild != null)
                        _context.Entry(existingChild).CurrentValues.SetValues(childModel);
                    else
                    {
                        var newChild = new OrderLine
                        {
                            ItemNumber = childModel.ItemNumber,
                            Quantity = childModel.Quantity,
                            OrderNumber = childModel.OrderNumber
                        };
                        existingParent.OrderLines.Add(newChild);
                    }
                }
            }
        }

        #endregion
    }
}
