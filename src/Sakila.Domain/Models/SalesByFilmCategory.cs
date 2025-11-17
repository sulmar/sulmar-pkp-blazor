using System;
using System.Collections.Generic;

namespace Sakila.Infrastructure;

public partial class SalesByFilmCategory
{
    public string Category { get; set; } = null!;

    public decimal? TotalSales { get; set; }
}
