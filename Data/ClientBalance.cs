using Newtonsoft.Json;

namespace PinnacleWrapper.Data
{
    public class ClientBalance
    {
        [JsonProperty(PropertyName = "availableBalance")]
        public decimal AvailableBalance;

        [JsonProperty(PropertyName = "outstandingTransactions")]
        public decimal OutstandingTransactions;

        [JsonProperty(PropertyName = "givenCredit")]
        public decimal GivenCredit;

        [JsonProperty(PropertyName = "currency")]
        public string Currency;
    }
}
