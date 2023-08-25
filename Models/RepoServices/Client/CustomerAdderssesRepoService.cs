using Microsoft.EntityFrameworkCore;
using Resturant_RES_MVC_ITI_PRJ.Areas.Client.Models;
using Resturant_RES_MVC_ITI_PRJ.Areas.Management.Models;
using Resturant_RES_MVC_ITI_PRJ.Models.Repositories.Client;

namespace Resturant_RES_MVC_ITI_PRJ.Models.RepoServices.Client
{
    public class CustomerAdderssesRepoService : ICustomerAdderssesRepository
    {

        public ResturantDbContext Ctx { get; }

        public CustomerAdderssesRepoService(ResturantDbContext ctx)
        {
            Ctx = ctx;
        }

        public List<CustomerAddersses> GetAllCustomerAddersses()
        {
            return Ctx.CustomersAddersses.Include(add => add.Customer).ToList();
        }

        public CustomerAddersses GetCustomerAdderssById(int id)
        {
            if (id == 0)
            {
                throw new ArgumentException($"Can't Find That Customer Address with Id: {id}");
            }
            return Ctx.CustomersAddersses
                .Include(add => add.Customer)
                .Where(cs => cs.CustomerAdderssesID == id).SingleOrDefault();
        }

        public void InsertCustomerAdderss(CustomerAddersses customerAddersses)
        {
            if (customerAddersses != null)
            {
                try
                {
                    Ctx.CustomersAddersses.Add(customerAddersses);
                    Ctx.SaveChanges();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
        }

        public void UpdateCustomerAdderss(int id, CustomerAddersses customerAddersses)
        {
            var updatedCustomerAderss = GetCustomerAdderssById(id);
            if (updatedCustomerAderss != null)
            {
                try
                {
                    updatedCustomerAderss.CustAddressApartment = customerAddersses.CustAddressApartment;
                    updatedCustomerAderss.CustAddressFloor = customerAddersses.CustAddressFloor;
                    updatedCustomerAderss.CustAddressBuildingNo = customerAddersses.CustAddressBuildingNo;
                    updatedCustomerAderss.CustAddressStreet = customerAddersses.CustAddressStreet;
                    updatedCustomerAderss.CustAddressCity = customerAddersses.CustAddressCity;
                    updatedCustomerAderss.CustAddressCounty = customerAddersses.CustAddressCounty;
                    updatedCustomerAderss.CustomerID = customerAddersses.CustomerID;

                    Ctx.SaveChanges();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
        }

        public void DeleteCustomerAdderss(int id)
        {
            var deletedCustomerAderss = GetCustomerAdderssById(id);
            if(deletedCustomerAderss != null)
            {
                try
                {
                    Ctx.CustomersAddersses.Remove(deletedCustomerAderss);
                    Ctx.SaveChanges();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
        }
    }
}
