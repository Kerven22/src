namespace DataProcessorService.Models
{
    public class RabbitMQSettings
    {
        public string HostName { get; set; }
        public string Exchange { get; set; }
        public string RoutingKey { get; set; }
    }
}
