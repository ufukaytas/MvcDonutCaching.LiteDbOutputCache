namespace Aytass.LiteDbOutputCache
{
    public class Constants
    {
        public static readonly string LiteDbOutputCacheProviderDbPath = "~/App_Data/LiteDbCache.db";

        public static readonly string DbPath = System.Web.HttpContext.Current.Server.MapPath(LiteDbOutputCacheProviderDbPath);
         
        public static readonly string CollectionName = "OutputCacheLiteDb";
    }
}