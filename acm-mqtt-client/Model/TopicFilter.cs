using IMQTTClientRx.Model;

namespace acmmqttclient.Model
{
    internal class TopicFilter : ITopicFilter
    {
        public string Topic { get; internal set; }
        public QoSLevel QualityOfServiceLevel { get; internal set; }
    }
}
