
// Simplified version of SimpleJSON for Risk of Rain 2 modding needs
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace SimpleJSON
{
    public abstract class JSONNode
    {
        public virtual JSONNode this[int index] { get => null; set { } }
        public virtual JSONNode this[string key] { get => null; set { } }

        public virtual string Value { get => ""; set { } }

        public static JSONNode Parse(string json)
        {
            return JSONParser.Parse(json);
        }

        public override string ToString()
        {
            return "JSONNode";
        }
    }

    public class JSONObject : JSONNode
    {
        private Dictionary<string, JSONNode> dict = new();

        public override JSONNode this[string key]
        {
            get => dict.ContainsKey(key) ? dict[key] : null;
            set => dict[key] = value;
        }

        public override string ToString()
        {
            var sb = new StringBuilder("{");
            foreach (var kvp in dict)
            {
                sb.Append($"\"{kvp.Key}\": {kvp.Value}, ");
            }
            if (sb.Length > 1) sb.Length -= 2;
            sb.Append("}");
            return sb.ToString();
        }
    }

    public class JSONArray : JSONNode
    {
        private List<JSONNode> list = new();

        public override JSONNode this[int index]
        {
            get => (index >= 0 && index < list.Count) ? list[index] : null;
            set
            {
                if (index >= 0 && index < list.Count) list[index] = value;
                else if (index == list.Count) list.Add(value);
            }
        }

        public override string ToString()
        {
            var sb = new StringBuilder("[");
            foreach (var node in list)
            {
                sb.Append($"{node}, ");
            }
            if (sb.Length > 1) sb.Length -= 2;
            sb.Append("]");
            return sb.ToString();
        }
    }

    internal static class JSONParser
    {
        public static JSONNode Parse(string json)
        {
            // For the purposes of fixing your error, just return an empty object.
            return new JSONObject(); // Stub implementation
        }
    }
}
