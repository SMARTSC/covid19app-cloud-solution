namespace SmartSolucionesCuba.Covid19CubaInfo.Cloud.SyncronizationService.Converters.Serialization
{
    public class CompatibleDateTimeSerializationConverter : Newtonsoft.Json.Converters.IsoDateTimeConverter, System.IFormatProvider
    {
        public CompatibleDateTimeSerializationConverter(string format)
        {
            DateTimeFormat = format;
        }

        public object GetFormat(System.Type formatType)
        {
            return DateTimeFormat;
        }

        public override object ReadJson(Newtonsoft.Json.JsonReader reader, System.Type objectType, object existingValue, Newtonsoft.Json.JsonSerializer serializer)
        {
            try
            {
                return base.ReadJson(reader, objectType, existingValue, serializer);
            }
            catch
            {
                var brokenDateTimeStringParts = reader.Value.ToString().Split('/');

                var fixedDateTimeString = string.Format("{0}/{2}{3}/{1}", brokenDateTimeStringParts[0], brokenDateTimeStringParts[2], brokenDateTimeStringParts[1][1], brokenDateTimeStringParts[1][0]);

                return System.DateTime.Parse(fixedDateTimeString, this);
            }
        }
    }
}
