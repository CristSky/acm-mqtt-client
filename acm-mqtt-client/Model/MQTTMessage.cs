using System;
using IMQTTClientRx.Model;

namespace acmmqttclient.Model
{
    internal class MQTTMessage : IMQTTMessage
    {
        public string Topic { get; internal set; }

        public byte[] Payload { get; internal set; }

        public QoSLevel QualityOfServiceLevel { get; internal set; }

        public bool Retain { get; internal set; }
    }
}
