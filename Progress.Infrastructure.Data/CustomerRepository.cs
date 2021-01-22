﻿using Progress.Domain.Data;
using Progress.Domain.Interface;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Progress.Infrastructure.Data
{
   public class CustomerRepository : ICustomerRepository
    {
        private CustomerContext db;
        public CustomerRepository()
            => this.db = new CustomerContext();
        public void Create(Customer customer)
        {
            db.Customers.Add(customer);
            
        }

        public void Delete(int id)
        {
            var findCustomer = db.Customers.Find(id);
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
        public Customer GetCustomer(int id)
        {
            return db.Customers.Find(id);
        }
        public Customer GetRegistCustomer(CustomerRegister customerRegister)
        {
            return db.Customers.Where(a => a.Email == customerRegister.Login && a.Password == customerRegister.Password).FirstOrDefault();
            
        }
        public IEnumerable<Customer> GetCustomerList()
        {
            return db.Customers.ToList(); 
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public void UpDate(Customer customer)
        {
            db.Entry(customer).State = EntityState.Modified;
        }
        
    }
}