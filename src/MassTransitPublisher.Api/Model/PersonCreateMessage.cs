using System.Text.Json.Serialization;

namespace MassTransitPublisher.Api.Model
{
    public class PersonCreateMessage
    {
        [JsonIgnore]
        public Guid Id { get; protected set; } = Guid.NewGuid();
        public string Name { get; set; } = string.Empty;
        public int Age { get; set; }
    }
}
