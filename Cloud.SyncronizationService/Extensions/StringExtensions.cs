namespace SmartSolucionesCuba.Covid19CubaInfo.Cloud.SyncronizationService.Extensions
{
    internal static class StringExtensions
    {
        internal static int ToProvinceId(this string source)
        {
            if (source.Contains("."))
            {
                return int.Parse(source.Split(".")[0]);
            }

            return int.Parse(source);
        }
    }
}
