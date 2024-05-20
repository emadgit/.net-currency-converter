using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class OrderService
{
    private readonly MyDbContext _context;

    public OrderService(MyDbContext context)
    {
        _context = context;
    }

    public async Task<List<string>> GetCountries()
    {
        return await _context.Orders.Select(o => o.ShipCountry).Distinct().ToListAsync();
    }

    public async Task<decimal> GetAverageFreight(string country)
    {
        return await _context.Orders.Where(o => o.ShipCountry == country).AverageAsync(o => o.Freight);
    }

    public async Task<decimal> GetAverageFreightSP(string country)
    {
        var result = await _context.Orders
            .FromSqlRaw("CALL GetAverageFreight({0})", country)
            .Select(o => o.Freight)
            .ToListAsync();

        return result.FirstOrDefault();
    }
}
