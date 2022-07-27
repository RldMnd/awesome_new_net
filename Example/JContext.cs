global using System.Text.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Threading.Tasks;

namespace Example
{
    [JsonSerializable(typeof(Person))]
    internal partial class JContext : JsonSerializerContext
    {
    }
}
