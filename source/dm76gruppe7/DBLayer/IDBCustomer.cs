using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataTier;

namespace DBLayer
{
    public interface IDBCustomer
    {
        List<Customer> getAllCustomers();
        Customer searchCustomerID(int id);
        Boolean updateCustomer(Customer Customer);
        Boolean createCustomer(Customer Customer);
        Boolean deleteCustomer(Customer Customer);
    }
}
