using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Abstractions;

public interface ICustomerRepository
{
    List<Customer> GetAll();
    Customer GetById(int id);
    void Add(Customer customer);
    void Remove(int id);
}
