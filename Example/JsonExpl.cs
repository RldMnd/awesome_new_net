using System.Diagnostics;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;

namespace Example
{
    internal class JsonExpl
    {
        class Node
        {
            public string Description { get; set; }
            public object Next { get; set; }
        }

        public static void Test()
        {
            var node = new Node { Description = "DEMO" };
            node.Next = node;

            var opts = new JsonSerializerOptions { ReferenceHandler = ReferenceHandler.IgnoreCycles };

            string json = JsonSerializer.Serialize(node, opts);
            Console.WriteLine(json);
        }

        public static async void AsyncEnumExampleAsync()
        {
            static async IAsyncEnumerable<int> PrintNumbers(int n)
            {
                for (int i = 0; i < n; i++) yield return i;
            }

            using Stream stream = Console.OpenStandardOutput();
            var data = new { Data = PrintNumbers(3) };
            await JsonSerializer.SerializeAsync(stream, data);
        }

        public static void JsonDOMExample()
        {
            JsonNode jNode = JsonNode.Parse("{\"MyProperty\":42}");
            int value = (int)jNode["MyProperty"];
            Debug.Assert(value == 42);

            jNode = JsonNode.Parse("[10,11,12]");
            value = (int) jNode[1];
            Debug.Assert(value == 11);
            
            value = jNode[1].GetValue<int>();
            Debug.Assert(value == 11);

            var jObject = new JsonObject
            {
                ["MyChildObject"] = new JsonObject
                {
                    ["MyProperty"] = "Hello",
                    ["MyArray"] = new JsonArray(10, 11, 12)
                }
            };

            string json = jObject.ToJsonString();
            Console.WriteLine(json); // {"MyChildObject":{"MyProperty":"Hello","MyArray":[10,11,12]}}
            Debug.Assert(jObject["MyChildObject"]["MyArray"][1].GetValue<int>() == 11);
        }

        public static void StreamEx()
        {
            var stream = new MemoryStream(Encoding.UTF8.GetBytes("[0,1,2,3,4]"));
            var arr = JsonSerializer.Deserialize<int[]>(stream);
            Console.WriteLine(arr.Length);
        }

    }

    public class Person : IJsonOnDeserialized, IJsonOnSerializing
    {
        [JsonPropertyOrder(1)]
        public string FirstName { get; set; }

        [JsonPropertyOrder(2)]
        public string LastName { get; set; }

        [JsonPropertyOrder(-1)]
        public int Age { get; set; }

        void IJsonOnDeserialized.OnDeserialized() => ValidateDeser();
        void IJsonOnSerializing.OnSerializing() => ValidateSer();

        private void ValidateDeser()
        {
            Console.WriteLine("ДеСериализация");
        }
        private void ValidateSer()
        {
            Console.WriteLine("Сериализация");
        }
    }
}
