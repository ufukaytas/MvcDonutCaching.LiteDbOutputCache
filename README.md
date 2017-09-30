MvcDonutCaching.LiteDbOutputCache
==================================

MvcDonutCaching.LiteDbOutputCache custom cache provider for MvcDonutCaching.

ASP.NET MVC cache provider for use with [MvcDonutCaching] (https://github.com/moonpyk/mvcdonutcaching) 

The litedb database is stored in the AppData folder.


Configuration
==================================
you must add the following within the system.web element:

    <caching>
      <outputCache defaultProvider="LiteDbOutputCache">
        <providers>
          <add name="LiteDbOutputCache" type="Aytass.LiteDbOutputCache.LiteDbOutputCacheProvider, Aytass.LiteDbOutputCache, Version=1.0.0.0, Culture=neutral" />
        </providers>
      </outputCache>
    </caching>

 
More Information About Donut Caching
==================================
[MvcDonutCaching] (https://github.com/moonpyk/mvcdonutcaching) 

[DevTrends Blog] (https://www.devtrends.co.uk/blog/donut-output-caching-in-asp.net-mvc-3)
