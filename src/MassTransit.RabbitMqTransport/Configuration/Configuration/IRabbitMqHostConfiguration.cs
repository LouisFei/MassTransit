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
namespace MassTransit.RabbitMqTransport.Configuration
{
    using MassTransit.Configuration;
    using Transport;

    /// <summary>
    /// RabbitMq主机配置
    /// </summary>
    public interface IRabbitMqHostConfiguration :
        IHostConfiguration
    {
        /// <summary>
        /// RabbitMq总线配置
        /// </summary>
        IRabbitMqBusConfiguration BusConfiguration { get; }

        /// <summary>
        /// RabbitMq主机控制
        /// </summary>
        new IRabbitMqHostControl Host { get; }

        /// <summary>
        /// Create a receive endpoint configuration using the specified host.
        /// 使用指定的主机创建接收端点配置.
        /// </summary>
        /// <param name="queueName">消息队列名称</param>
        /// <returns></returns>
        IRabbitMqReceiveEndpointConfiguration CreateReceiveEndpointConfiguration(string queueName);
    }
}