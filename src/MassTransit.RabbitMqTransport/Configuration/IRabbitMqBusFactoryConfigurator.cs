// Copyright 2007-2017 Chris Patterson, Dru Sellers, Travis Smith, et. al.
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
    using System.ComponentModel;
    using MassTransit.Builders;
    using Topology;

    /// <summary>
    /// 
    /// </summary>
    public interface IRabbitMqBusFactoryConfigurator :
        IBusFactoryConfigurator,
        IQueueEndpointConfigurator
    {
        new IRabbitMqSendTopologyConfigurator SendTopology { get; }

        new IRabbitMqPublishTopologyConfigurator PublishTopology { get; }

        /// <summary>
        /// Set to true if the topology should be deployed only
        /// </summary>
        bool DeployTopologyOnly { set; }

        /// <summary>
        /// Configure the send topology of the message type
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="configureTopology"></param>
        void Send<T>(Action<IRabbitMqMessageSendTopologyConfigurator<T>> configureTopology)
            where T : class;

        /// <summary>
        /// Configure the send topology of the message type
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="configureTopology"></param>
        void Publish<T>(Action<IRabbitMqMessagePublishTopologyConfigurator<T>> configureTopology)
            where T : class;

        [EditorBrowsable(EditorBrowsableState.Never)]
        void AddReceiveEndpointSpecification(IReceiveEndpointSpecification<IBusBuilder> specification);

        /// <summary>
        /// In most cases, this is not needed and should not be used. However, if for any reason the default bus
        /// endpoint queue name needs to be changed, this will do it. Do NOT set it to the same name as a receive
        /// endpoint or you will screw things up.
        /// </summary>
        void OverrideDefaultBusEndpointQueueName(string value);

        /// <summary>
        /// Configure a Host that can be connected. 
        /// 配置可以连接的主机。
        /// If only one host is specified, it is used as the default host for receive endpoints.
        /// 如果只指定了一台主机，则将其用作接收端点的默认主机。
        /// </summary>
        /// <param name="settings">RabbitMq主机连接设置</param>
        /// <returns>返回一个RabbitMq主机实例</returns>
        IRabbitMqHost Host(RabbitMqHostSettings settings);

        /// <summary>
        /// Declare a ReceiveEndpoint on the broker and configure the endpoint settings and message consumers.
        /// 在代理上声明ReceiveEndpoint并配置端点设置和消息使用者。
        /// </summary>
        /// <param name="host">The host for this endpoint. 这个端点的主机</param>
        /// <param name="queueName">The input queue name. 输入队列名称</param>
        /// <param name="configure">The configuration method. 配置方法</param>
        void ReceiveEndpoint(IRabbitMqHost host, string queueName, Action<IRabbitMqReceiveEndpointConfigurator> configure);
    }
}