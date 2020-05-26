using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using HostnoMore.Models;
using HostnoMore.Services;

namespace HostnoMore.Services
{
        public class Repository : IRepository
    {
        IList<OrderItem> itemFromSomeDataSource = null;
        IList<RestaurantSideItem> itemFromSomeDataSource0 = null;
        IList<Restaurant2SideItem> itemFromSomeDataSource1 = null;
        IList<Blog> cartList = null;

        public Repository()
        {
            Debug.WriteLine($"**** {this.GetType().Name}.{nameof(Repository)}:  ctor");
        }

        // Method summary provided in interface.
        public async Task<IList<OrderItem>> GetItem()
        {
            await Task.Delay(500);

            return itemFromSomeDataSource;
        }

        public async Task<Blog> GetLastItem()
        {
            await Task.Delay(500);

            return cartList[cartList.Count-1];
        }

        public async Task<IList<Blog>> GetItem1()
        {
            await Task.Delay(500);

            return cartList;
        }

        public async Task<IList<OrderItem>> GetItem(int numberOfItems)
        {
            itemFromSomeDataSource = new List<OrderItem>();

            for (int i = 0; i < numberOfItems; i++)
            {
                var newOrderItem = new OrderItem()
                {
                    Item = $"{i}"
                };

                itemFromSomeDataSource.Add(newOrderItem);
            }

            await Task.Delay(500);

            return itemFromSomeDataSource;
        }
        // Method summary provided in interface.
        public async Task AddItem(OrderItem newOrderItem)
        {
            if (itemFromSomeDataSource == null)
            {
                itemFromSomeDataSource = new List<OrderItem>();
            }
            itemFromSomeDataSource.Add(newOrderItem);
            await Task.Delay(500);
        }

        public async Task AddItem1(Blog newOrderItem)
        {
            if (cartList == null)
            {
                cartList = new List<Blog>();
            }
            cartList.Add(newOrderItem);
            await Task.Delay(500);
        }

        public async Task RemoveItem(OrderItem removeOrderItem)
        {
            if (itemFromSomeDataSource == null)
            {
            }
            itemFromSomeDataSource.Remove(removeOrderItem);
            await Task.Delay(500);
        }

        public async Task RemoveItem1(Blog removeOrderItem)
        {
            if (cartList == null)
            {
            }
            cartList.Remove(removeOrderItem);
            await Task.Delay(500);
        }

        public async Task RemoveAllItems(OrderItem removeAllItems)
        {
            itemFromSomeDataSource = new List<OrderItem>();

            if (itemFromSomeDataSource != null)
            {
                itemFromSomeDataSource.Remove(removeAllItems);
            }
        }

        public async Task AddItem(RestaurantSideItem newOrderItem0)
        {
            if (itemFromSomeDataSource0 == null)
            {
                itemFromSomeDataSource0 = new List<RestaurantSideItem>();
            }
            itemFromSomeDataSource0.Add(newOrderItem0);
            await Task.Delay(500);
        }

        public async Task RemoveItem(RestaurantSideItem removeOrderItem0)
        {
            if (itemFromSomeDataSource == null)
            {
            }
            itemFromSomeDataSource0.Remove(removeOrderItem0);
            await Task.Delay(500);
        }

        public async Task<IList<RestaurantSideItem>> GetItems()
        {
            await Task.Delay(500);

            return itemFromSomeDataSource0;
        }

        public async Task<IList<RestaurantSideItem>> GetItems(int numberOfItems)
        {
            itemFromSomeDataSource0 = new List<RestaurantSideItem>();

            for (int i = 0; i < numberOfItems; i++)
            {
                var newOrderItem = new RestaurantSideItem()
                {
                    Item = $"{i}"
                };

                itemFromSomeDataSource0.Add(newOrderItem);
            }

            await Task.Delay(500);

            return itemFromSomeDataSource0;
        }

        public async Task<IList<Restaurant2SideItem>> GetItems2()
        {
            await Task.Delay(500);

            return itemFromSomeDataSource1;
        }

        public async Task<IList<Restaurant2SideItem>> GetItems2(int numberOfItems)
        {
            itemFromSomeDataSource1 = new List<Restaurant2SideItem>();

            for (int i = 0; i < numberOfItems; i++)
            {
                var newOrderItem = new Restaurant2SideItem()
                {
                    Item = $"{i}"
                };

                itemFromSomeDataSource1.Add(newOrderItem);
            }

            await Task.Delay(500);

            return itemFromSomeDataSource1;
        }


        public async Task AddItem(Restaurant2SideItem newOrderItem1)
        {
            if (itemFromSomeDataSource1 == null)
            {
                itemFromSomeDataSource1 = new List<Restaurant2SideItem>();
            }
            itemFromSomeDataSource1.Add(newOrderItem1);
            await Task.Delay(500);
        }

        public async Task RemoveItem(Restaurant2SideItem removeOrderItem1)
        {
            if (itemFromSomeDataSource1 == null)
            {
            }
            itemFromSomeDataSource1.Remove(removeOrderItem1);
            await Task.Delay(500);
        }

        public double GetTotal()
        {
            double total = 0;
            for (int i = 0; i < cartList.Count; i++)
            {
                total += cartList[i].Price;
            }

            return total;
        }
    }
}