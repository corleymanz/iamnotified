namespace IAmNotified.Common.Serialize
{
    public class Json
    {
        public string Test { get; set; }

        public static string Serialize<T>(T item)
            where T : class
        {
            string result = Jil.JSON.Serialize(item);
            return result;
        }

        public static T DeSerialize<T>(string tekst)
            where T : class
        {
            var result = Jil.JSON.Deserialize<T>(tekst);
            return result;
        }
    }
}
