using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC.Models;
using MVC.Models.ViewModels;

namespace MVC.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ApiBeerController : ControllerBase
	{
		private readonly PubContext _context;

		public ApiBeerController(PubContext context)
		{
			this._context = context;	
		}
		public async Task<List<BeerViewModel>> Get() => await _context.Beers.Include(b => b.Brand)
			.Select(b=>new BeerViewModel
			{
				Name = b.Name,
				Brand = b.Brand.Name,
			})
			.ToListAsync();
	}
}
