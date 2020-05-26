using System.Collections.Generic;
using System.Threading.Tasks;
using HostnoMore.Models;

namespace HostnoMore.Services
{
    public interface IRepository
    {
            Task<IList<OrderItem>> GetItem();

            Task<IList<Blog>> GetItem1();

            Task<Blog> GetLastItem();

            Task<IList<OrderItem>> GetItem(int numberOfItems);

            Task AddItem(OrderItem newOrderItem);

            Task AddItem1(Blog newOrderItem);

            Task RemoveItem(OrderItem removeOrderItem);

            Task RemoveItem1(Blog removeOrderItem);

            Task RemoveAllItems(OrderItem removeAllItems);

            Task<IList<RestaurantSideItem>> GetItems();

            Task<IList<RestaurantSideItem>> GetItems(int numberOfItems);

            Task AddItem(RestaurantSideItem newOrderItem0);

            Task RemoveItem(RestaurantSideItem removeOrderItem0);

            Task<IList<Restaurant2SideItem>> GetItems2();

            Task<IList<Restaurant2SideItem>> GetItems2(int numberOfItems);

            Task AddItem(Restaurant2SideItem newOrderItem1);

            Task RemoveItem(Restaurant2SideItem removeOrderItem1);

            double GetTotal();


    }
}