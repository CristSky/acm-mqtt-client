using System;
using System.Collections.Generic;
using IMQTTClientRx.Model;

namespace acmmqttclient.Model
{
    internal class Options : ITlsOptions, IClientOptions
    {
        public Uri Uri { get; internal set; }

        public string UserName { get; internal set; }

        public string Password { get; internal set; }

        public string ClientId { get; internal set; }

        public bool CleanSession { get; internal set; }

        public TimeSpan KeepAlivePeriod { get; internal set; }

        public TimeSpan DefaultCommunicationTimeout { get; internal set; }

        public ProtocolVersion ProtocolVersion { get; internal set; }

        public ConnectionType ConnectionType { get; internal set; }

        public bool UseTls { get; internal set; }

        public IEnumerable<byte[]> Certificates { get; internal set; }

        public bool IgnoreCertificateChainErrors { get; internal set; }

        public bool IgnoreCertificateRevocationErrors { get; internal set; }

        public bool AllowUntrustedCertificates { get; internal set; }
    }
}
