using FamPix.Data.Abstracts;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Newtonsoft.Json;
using NodaTime;
using System;

namespace Microsoft.EntityFrameworkCore.Metadata.Builders
{
    public static class PropertyBuilderExtensions
    {
        #region NodaTime Converters
        public static PropertyBuilder<Instant> HasInstantConverter(this PropertyBuilder<Instant> builder)
        {
            var instantConverter = new ValueConverter<Instant, DateTimeOffset>(v => v.ToDateTimeOffset(), v => Instant.FromDateTimeOffset(v));
            return builder.HasConversion(instantConverter);
        }

        public static PropertyBuilder<LocalDate> HasLocalDateConverter(this PropertyBuilder<LocalDate> builder)
        {
            var localDateConverter = new ValueConverter<LocalDate, DateTime>(v => v.ToDateTimeUnspecified(), v => LocalDate.FromDateTime(v));
            return builder.HasConversion(localDateConverter);
        }

        public static PropertyBuilder<LocalDateTime> HasLocalDateTimeConverter(this PropertyBuilder<LocalDateTime> builder)
        {
            var localDateTimeConverter = new ValueConverter<LocalDateTime, DateTime>(v => v.ToDateTimeUnspecified(), v => LocalDateTime.FromDateTime(v));
            return builder.HasConversion(localDateTimeConverter);
        }
        #endregion

        #region Json Object Converter
        public static PropertyBuilder<T> HasJsonConverter<T>(this PropertyBuilder<T> builder) where T : IJsonSerializable
        {
            var converter = new ValueConverter<T, string>(v => JsonConvert.SerializeObject(v), v => JsonConvert.DeserializeObject<T>(v));
            return builder.HasConversion(converter);
        }
        #endregion
    }
}
