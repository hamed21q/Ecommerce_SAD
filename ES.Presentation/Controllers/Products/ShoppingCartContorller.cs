using ES.Domain.Entities.ShoppingCart.ShoppingCart;
using ES.Domain.Entities.Users.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Security.Claims;

namespace Basket.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShoppingCartController : ControllerBase
    {
        private readonly IShoppingCartService repo;
        private readonly IUserService userService;
        public ShoppingCartController(IShoppingCartService repo, IUserService userService)
        {
            this.repo = repo;
            this.userService = userService;
        }
        [HttpGet("{username}", Name = "GetBasket")]
        [ProducesResponseType(typeof(ShoppingCart), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ShoppingCart>> GetBasket(long id)
        {
            var user = await userService.GetBy(id);
            var basket = await repo.GetBasket(user.EmailAddress);
            return Ok(basket ?? new ShoppingCart(user.EmailAddress));   
        }
        [HttpPost]
        [ProducesResponseType(typeof(ShoppingCart), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ShoppingCart>> UpdateBasket([FromBody] ShoppingCart basket)
        {
            return Ok(await repo.UpdateBasket(basket));
        }
        
        [HttpDelete("{username}", Name = "DeleteBasket")]
        [ProducesResponseType(typeof(ShoppingCart), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteBascket(string username)
        {
            await repo.DeleteBaske(username);
            return Ok();
        }
    }
}
