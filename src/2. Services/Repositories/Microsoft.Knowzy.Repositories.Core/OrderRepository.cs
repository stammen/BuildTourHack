using System;
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

        public async Task UpdateShipping(Shipping shippingToUpdate)
        {
            var existingParent = await  _context.Shippings
                .Include(shipping => shipping.OrderLines)
                .Where(shipping => shipping.OrderNumber == shippingToUpdate.OrderNumber)                
                .SingleOrDefaultAsync();

            if (existingParent != null)
            {
                _context.Entry(existingParent).CurrentValues.SetValues(shippingToUpdate);
                existingParent.PostalCarrier = await 
                    _context.PostalCarriers.FirstOrDefaultAsync(
                        postalCarrier => postalCarrier.Id == shippingToUpdate.PostalCarrier.Id);
                foreach (var existingChild in existingParent.OrderLines.ToList())
                {
                    if (shippingToUpdate.OrderLines.All(c => c.Id != existingChild.Id))
                        _context.OrderLines.Remove(existingChild);
                }

                foreach (var childModel in shippingToUpdate.OrderLines)
                {
                    var existingChild = existingParent.OrderLines
                        .SingleOrDefault(c => c.Id == childModel.Id);

                    if (existingChild != null)
                        _context.Entry(existingChild).CurrentValues.SetValues(childModel);
                    else
                    {
                        var newChild = new OrderLine
                        {
                            Item = childModel.Item,
                            Quantity = childModel.Quantity
                        };
                        existingParent.OrderLines.Add(newChild);
                    }
                }
            }
        }

        #endregion
    }
}
