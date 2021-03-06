﻿using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using Microsoft.Extensions.Caching.Distributed;

namespace AspNetRC1RedisSample.Controllers
{
    public class RedisCacheController : Controller
    {
        private readonly IDistributedCache _redisCache;

        public RedisCacheController(IDistributedCache redisCache)
        {
            _redisCache = redisCache;
        }

        [HttpGet("api/rediscache/set/{key}/{value}", Name = "SetRedisValue")]
        public async Task<IActionResult> SetValue(string key, string value)
        {
            await _redisCache.SetAsync(key, Encoding.UTF8.GetBytes(value));
            return Content($"Successfully set the value for key '{key}' in redis cache.");
        }

        [HttpGet("api/rediscache/get/{key}", Name = "GetRedisValue")]
        public async Task<IActionResult> GetValue(string key)
        {
            var valueInBytes = await _redisCache.GetAsync(key);
            if (valueInBytes == null)
            {
                return new NoContentResult();
            }

            return Content(Encoding.UTF8.GetString(valueInBytes));
        }
    }
}