using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sakila.Infrastructure;

public partial class Customer
{
    public override string ToString()
    {
        return $"{FirstName} {LastName} {Email}";
    }
}
