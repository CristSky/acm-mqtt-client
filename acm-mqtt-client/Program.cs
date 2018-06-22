using System;
using System.Text;
using System.Threading.Tasks;
using IMQTTClientRx.Model;
using MQTTClientRx.Service;
using acmmqttclient.Model;


namespace acm_mqtt_client
{
    class Program
    {
        private static IDisposable _disp1;

        static async Task Main(string[] args)
        {
            await Start();

            Console.ReadLine();
            //await _disp1.DisposeAsync();
            //await _disp2.DisposeAsync();
            await Task.Delay(TimeSpan.FromSeconds(1));
            Console.WriteLine("Press any key to exit...");
            Console.ReadLine();
        }

        static async Task Start()
        {
            var mqttService = new MQTTService();

            var mqttClientOptions = new Options
            {
                // uri sera o endereço do service ACM broker
                Uri = new Uri("mqtt://localhost:1883"),
                // ClientId é o token de conexão do usuário
                ClientId = "s3sHXqoqdQdKV19nRePsVCVjiyWHAXza2M8s8HU8TCUgrATTV29zHC192Tlne5Ef",
                // Server = "broker.mqttdashboard.com",
                // Port = 1883,
                // Port = 8000,
                // Url = "broker.mqttdashboard.com",
                // Path = "mqtt",
                ConnectionType = ConnectionType.Tcp,
                // ConnectionType = ConnectionType.WebSocket
            };

            var topic1 = new TopicFilter
            {
                QualityOfServiceLevel = QoSLevel.ExactlyOnce,
                // O tópico permitido é o padrão "user/" + id do usuário do token.
                Topic = "user/5a0de046f47ed1037289edc8"
            };

            ITopicFilter[] topicFilters = {
                topic1,
            };

            var MQTTService = mqttService.CreateObservableMQTTService(mqttClientOptions, topicFilters);

            _disp1 = MQTTService.observableMessage.Subscribe(
                msg =>
                {
                    if (msg.Topic.Contains("EFM"))
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                    }

                    Console.WriteLine($"{Encoding.UTF8.GetString(msg.Payload)}, " +
                                      $"{msg.QualityOfServiceLevel.ToString()}, " +
                                      $"Retain: {msg.Retain}, " +
                                      $"Topic: {msg.Topic}");
                },
                ex =>
                {
                    Console.WriteLine($"{ex.Message} : inner {ex.InnerException.Message}");
                },
                () =>
                {
                    Console.WriteLine("Completed...");
                });

            await Task.Delay(TimeSpan.FromSeconds(5));

            // não é permitido o envio de mensagens para o broker.
            // var newMessage = new MQTTMessage
            // {
            //     Payload = Encoding.UTF8.GetBytes("Hello MQTT EO"),
            //     QualityOfServiceLevel = QoSLevel.ExactlyOnce,
            //     Retain = false,
            //     Topic = "MQTTClientRx/Test"
            // };
        }
    }
}
