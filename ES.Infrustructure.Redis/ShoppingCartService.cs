using ES.Domain.Entities.ShoppingCart.ShoppingCart;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;

namespace ES.Infrustructure.Redis
{
    public class ShoppingCartService : IShoppingCartService
    {
        private readonly IDistributedCache redis;

        public ShoppingCartService(IDistributedCache redis)
        {
            this.redis = redis;
        }

        public async Task DeleteBaske(string username)
        {
            await redis.RemoveAsync(username);
        }

        public async Task<ShoppingCart> GetBasket(string username)
        {
            var basket = await redis.GetStringAsync(username);
            if (String.IsNullOrEmpty(basket)) throw new ArgumentException();
            return JsonConvert.DeserializeObject<ShoppingCart>(basket);
        }

        public async Task<ShoppingCart> UpdateBasket(ShoppingCart shopingCart)
        {
            await redis.SetStringAsync(shopingCart.UserId.ToString(), JsonConvert.SerializeObject(shopingCart));
            return await GetBasket(shopingCart.UserId.ToString());
        }
    }
}
