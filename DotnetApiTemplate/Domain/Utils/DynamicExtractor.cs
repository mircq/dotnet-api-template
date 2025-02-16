
using System.Text.Json;

namespace Domain.Utils;

public static class DynamicExtractor
{
    public static object ExtractValue(JsonElement jsonElement)
    {
        switch (jsonElement.ValueKind)
        {
            case JsonValueKind.Number:
                // Try parsing as various numeric types
                if (jsonElement.TryGetInt32(out int intValue))
                    return intValue;
                if (jsonElement.TryGetInt64(out long longValue))
                    return longValue;
                if (jsonElement.TryGetDouble(out double doubleValue))
                    return doubleValue;
                break;
                
            case JsonValueKind.String:
                return jsonElement.GetString();

            case JsonValueKind.True:
            case JsonValueKind.False:
                return jsonElement.GetBoolean();

            case JsonValueKind.Null:
                return null;

            default:
                throw new InvalidOperationException($"Unsupported JsonValueKind: {jsonElement.ValueKind}");
        }

        throw new InvalidOperationException("Unable to extract value from JsonElement.");
    }
}