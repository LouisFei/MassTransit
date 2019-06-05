// Copyright 2007-2018 Chris Patterson, Dru Sellers, Travis Smith, et. al.
//  
// Licensed under the Apache License, Version 2.0 (the "License"); you may not use
// this file except in compliance with the License. You may obtain a copy of the 
// License at 
// 
//     http://www.apache.org/licenses/LICENSE-2.0 
// 
// Unless required by applicable law or agreed to in writing, software distributed
// under the License is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR 
// CONDITIONS OF ANY KIND, either express or implied. See the License for the 
// specific language governing permissions and limitations under the License.
namespace MassTransit.RabbitMqTransport
{
    using System;
    using System.Threading;
    using Configuration;
    using Configurators;
    using MassTransit.Topology;
    using MassTransit.Topology.EntityNameFormatters;
    using MassTransit.Topology.Topologies;

    /// <summary>
    /// 基于RabbitMq传输的总线工厂类
    /// </summary>
    public static class RabbitMqBusFactory
    {
        public static IMessageTopologyConfigurator MessageTopology => Cached.MessageTopologyValue.Value;

        /// <summary>
        /// Configure and create a bus for RabbitMQ
        /// 为RabbitMQ配置和创建总线
        /// </summary>
        /// <param name="configure">The configuration callback to configure the bus.配置回调函数来配置总线</param>
        /// <returns>返回总线控制</returns>
        public static IBusControl Create(Action<IRabbitMqBusFactoryConfigurator> configure)
        {
            var topologyConfiguration = new RabbitMqTopologyConfiguration(MessageTopology);
            var busConfiguration = new RabbitMqBusConfiguration(topologyConfiguration);
            var busEndpointConfiguration = busConfiguration.CreateEndpointConfiguration();

            var configurator = new RabbitMqBusFactoryConfigurator(busConfiguration, busEndpointConfiguration);

            configure(configurator);

            return configurator.Build();
        }


        static class Cached
        {
            internal static readonly Lazy<IMessageTopologyConfigurator> MessageTopologyValue =
                new Lazy<IMessageTopologyConfigurator>(() => new MessageTopology(_entityNameFormatter),
                    LazyThreadSafetyMode.PublicationOnly);

            static readonly IEntityNameFormatter _entityNameFormatter;

            static Cached()
            {
                _entityNameFormatter = new MessageNameFormatterEntityNameFormatter(new RabbitMqMessageNameFormatter());
            }
        }
    }
}