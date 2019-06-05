﻿// Copyright 2007-2018 Chris Patterson, Dru Sellers, Travis Smith, et. al.
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
namespace MassTransit.RabbitMqTransport.Topology
{
    using System;
    using System.Collections.Generic;


    /// <summary>
    /// Specify the receive settings for a receive transport.
    /// 为接收传输指定接收设置。
    /// </summary>
    public interface ReceiveSettings :
        EntitySettings
    {
        /// <summary>
        /// The queue name to receive from
        /// 接收队列名称
        /// </summary>
        string QueueName { get; }

        /// <summary>
        /// The number of unacknowledged messages to allow to be processed concurrently
        /// 允许并发处理的未确认消息的数量
        /// </summary>
        ushort PrefetchCount { get; }

        /// <summary>
        /// True if the queue receive should be exclusive and not shared
        /// 如果队列接收应该是互斥的而不是共享的，则为真
        /// </summary>
        bool Exclusive { get; }

        /// <summary>
        /// Arguments passed to QueueDeclare
        /// </summary>
        IDictionary<string, object> QueueArguments { get; }

        /// <summary>
        /// 路由键
        /// </summary>
        string RoutingKey { get; }

        IDictionary<string, object> BindingArguments { get; }

        /// <summary>
        /// If True, and a queue name is specified, if the queue exists and has messages, they are purged at startup
        /// If the connection is reset, messages are not purged until the service is reset
        /// </summary>
        bool PurgeOnStartup { get; }

        /// <summary>
        /// Arguments passed to the basicConsume
        /// </summary>
        IDictionary<string, object> ConsumeArguments { get; }

        /// <summary>
        /// Get the input address for the transport on the specified host
        /// </summary>
        Uri GetInputAddress(Uri hostAddress);
    }
}