﻿using Microsoft.EntityFrameworkCore;
using Resturant_RES_MVC_ITI_PRJ.Areas.Client.Models;
using Resturant_RES_MVC_ITI_PRJ.Models.Repositories.Client;

namespace Resturant_RES_MVC_ITI_PRJ.Models.RepoServices.Client
{
    public class CustomerRepoService : ICustomerRepository
    {
        public ResturantDbContext Ctx { get; }

        public CustomerRepoService(ResturantDbContext ctx)
        {
            Ctx = ctx;
        }
        public List<Customer> GetAllCustomers()
        {
            return Ctx.Customers
                 .Include(cs => cs.Testimonials)
                 .Include(cs => cs.Reservations)
                 .Include(cs => cs.CustomerAddersses)
                 .Include(cs => cs.Orders).ToList();
        }

        public Customer GetCustomerById(int id)
        {
            if (id == 0)
            {
                throw new ArgumentException($"Can't Find That Customer with Id: {id}");
            }
            return Ctx.Customers
                .Include(cs => cs.Testimonials)
                .Include(cs => cs.Reservations)
                .Include(cs => cs.CustomerAddersses)
                .Include(cs => cs.Orders)
                .Where(cs => cs.CustID == id).SingleOrDefault();
        }

        public void InsertCustomer(Customer customer)
        {
            if (customer != null)
            {
                Ctx.Customers.Add(customer);
                Ctx.SaveChanges();
            }
        }

        public void UpdateCustomer(Customer customer)
        {
            if (customer != null)
            {
                Ctx.Customers.Update(customer);
                Ctx.SaveChanges();
            }
        }

        public void DeleteCustomer(int id)
        {
            Ctx.Customers.Remove(GetCustomerById(id));
            Ctx.SaveChanges();
        }

    }
}
