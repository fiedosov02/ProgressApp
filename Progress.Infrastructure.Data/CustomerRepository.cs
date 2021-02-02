using Progress.Domain.Data;
using Progress.Domain.Interface;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Progress.Infrastructure.Data
{
   public class CustomerRepository : ICustomerRepository
    {
        private CustomerContext db;

        public CustomerRepository()=>
            this.db = new CustomerContext();

        public void Create(Customer customer)=>      
             db.Customers.Add(customer);
           
        public async void Delete(int id)
        {
            var findCustomer = await db.Customers.FindAsync(id);
            if(findCustomer != null)
            {
                db.Customers.Remove(findCustomer);
            }
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public async Task<Customer> GetCustomer(int id)
        {
            return await db.Customers.FindAsync(id);
        }

        public async Task<Customer> GetRegistCustomer(CustomerRegister customerRegister)
        {
            return await db.Customers.Where(a => a.Email == customerRegister.Login && a.Password == customerRegister.Password).FirstOrDefaultAsync();
            
        }

        public async Task<IEnumerable<Customer>> GetCustomerList()
        {
            return await db.Customers.ToListAsync(); 
        }

        public void Save()
        {
            //db.SaveChanges();
            try
            {

                db.SaveChangesAsync();

            }
            catch (DbEntityValidationException ex)
            {
                foreach (DbEntityValidationResult validationError in ex.EntityValidationErrors)
                {
                    HttpContext.Current.Response.Write("Object: " + validationError.Entry.Entity.ToString());
                    HttpContext.Current.Response.Write("");
                        foreach (DbValidationError err in validationError.ValidationErrors)
                    {
                        HttpContext.Current.Response.Write(err.ErrorMessage + "");
                        }
                }
            }
        }

        public void UpDate(Customer customer)
        {
            db.Entry(customer).State = EntityState.Modified;
        }
        
    }
}
