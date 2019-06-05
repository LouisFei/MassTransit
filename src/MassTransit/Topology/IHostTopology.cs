﻿// Copyright 2007-2017 Chris Patterson, Dru Sellers, Travis Smith, et. al.
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
namespace MassTransit.Topology
{
    public interface IHostTopology :
        IBusTopology
    {
        /// <summary>
        /// Returns a unique temporary queue name for the host/topology.
        /// 返回主机/拓扑的唯一临时队列名称。
        /// </summary>
        /// <param name="prefix">A prefix to distinguish the queue for the purpose.用于区分队列的前缀</param>
        /// <returns></returns>
        string CreateTemporaryQueueName(string prefix);
    }
}