using Lease.API.Enums;
using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Lease.API.Entities
{
    public class PriorityTypeListJsonConverter : JsonConverter<List<PriorityType>>
    {
        public override List<PriorityType> Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var jsonValue = JsonSerializer.Deserialize<string>(ref reader, options);

            if (string.IsNullOrEmpty(jsonValue))
            {
                return new List<PriorityType>();
            }

            var priorityTypes = new List<PriorityType>();
            foreach (var s in jsonValue.Split(',', StringSplitOptions.RemoveEmptyEntries))
            {
                if (Enum.TryParse<PriorityType>(s, out var priorityType))
                {
                    priorityTypes.Add(priorityType);
                }
            }

            return priorityTypes;
        }

        public override void Write(Utf8JsonWriter writer, List<PriorityType> value, JsonSerializerOptions options)
        {
            if (value != null)
            {
                writer.WriteStringValue(string.Join(",", value));
            }
        }
    }
}
