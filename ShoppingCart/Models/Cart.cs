using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoppingCart.Models
{
    [Serializable]
    public class Cart : IEnumerable<CartItem>
    {
        public Cart()
        {
            this.cartItems = new List<CartItem>();
        }

        private List<CartItem> cartItems;

        public int Count
        {
            get
            {
                return this.cartItems.Count;
            }
        }

        public decimal TotalAmount
        {
            get
            {
                decimal totalAmount = 0.0m;
                foreach (var cartItem in this.cartItems)
                {
                    totalAmount = totalAmount + cartItem.Amount;
                }
                return totalAmount;
            }
        }

        public bool AddProduct(int ProductId)
        {
            var findItem = cartItems.Where(w => w.Id == ProductId).FirstOrDefault();

            if (findItem == default(CartItem))
            {
                using (CartEntities db = new CartEntities())
                {
                    var product = db.Product.Where(w => w.Id == ProductId).FirstOrDefault();
                    if (product != default(Product))
                    {
                        this.AddProduct(product);
                    }
                }
            }
            else
            {
                findItem.Quantity += 1;
            }

            return true;
        }

        private bool AddProduct(Product product)
        {
            var cartItem = new CartItem()
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                DefaultImageURL = product.DefaultImageURL,
                Quantity = 1
            };

            cartItems.Add(cartItem);
            return true;

        }

        public bool RemoveProduct(int ProductId)
        {
            var findItem = this.cartItems.Where(w => w.Id == ProductId).Select(s =>s).FirstOrDefault();

            if (findItem == default(CartItem))
            {

            }
            else
            {
                this.cartItems.Remove(findItem);
            }

            return true;
        }

        public bool ClearCart()
        {
            this.cartItems.Clear();
            return true;
        }

        public List<OrderDetail> ToOrderDetailList(int orderId)
        {
            var result = new List<OrderDetail>();
            foreach (var item in cartItems)
            {
                result.Add(new OrderDetail
                {
                    Name = item.Name,
                    Price = item.Price,
                    Quantity = item.Quantity,
                    OrderId = orderId
                });
            }

            return result;
        }

        #region IEnumerator

        public IEnumerator<CartItem> GetEnumerator()
        {
            return this.cartItems.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.cartItems.GetEnumerator();
        }
        #endregion

    }
}