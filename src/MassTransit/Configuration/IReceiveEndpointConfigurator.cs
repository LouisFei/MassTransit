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
namespace MassTransit
{
    using System;
    using System.ComponentModel;
    using System.Net.Mime;


    /// <summary>
    /// Configure a receiving endpoint.
    /// 配置一个接收端点
    /// </summary>
    public interface IReceiveEndpointConfigurator :
        IConsumePipeConfigurator,
        ISendPipelineConfigurator,
        IPublishPipelineConfigurator
    {
        /// <summary>
        /// Returns the input address of the receive endpoint.
        /// 获得接收端点地址。
        /// </summary>
        Uri InputAddress { get; }

        /// <summary>
        /// 添加接收端点规范
        /// </summary>
        /// <param name="configurator"></param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        void AddEndpointSpecification(IReceiveEndpointSpecification configurator);

        /// <summary>
        /// Sets the outbound message serializer.
        /// 设置出站消息序列化程序
        /// </summary>
        /// <param name="serializerFactory">The factory to create the message serializer</param>
        void SetMessageSerializer(SerializerFactory serializerFactory);

        /// <summary>
        /// Adds an inbound message deserializer to the available deserializers.
        /// 向可用的反序列化程序添加入站消息反序列化程序
        /// </summary>
        /// <param name="contentType">The content type of the deserializer</param>
        /// <param name="deserializerFactory">The factory to create the deserializer</param>
        void AddMessageDeserializer(ContentType contentType, DeserializerFactory deserializerFactory);
    }
}