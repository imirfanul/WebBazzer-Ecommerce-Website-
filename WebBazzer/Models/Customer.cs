using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebBazzer.Models
{
    public  class Customer
    {
        public Customer()
        {
            this.Orders = new HashSet<Order>();
            this.RecentlyViews = new HashSet<RecentlyView>();
            this.Reviews = new HashSet<Review>();
            this.Wishlists = new HashSet<Wishlist>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Gender { get; set; }
        public string MobileNo { get; set; }
        public int CountryId { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public string PostalCode { get; set; }
        public string ImageUrl { get; set; }
    

        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<RecentlyView> RecentlyViews { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }
        public virtual ICollection<Wishlist> Wishlists { get; set; }
    }
}