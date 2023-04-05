namespace PostcodesWrapper.Models
{
    public class AutoCompletePostcode
    {
        // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
        public int status { get; set; }
        public List<string> result { get; set; }
        public int area { get; set; }

    }
}
