// Copyright 2007-2016 Chris Patterson, Dru Sellers, Travis Smith, et. al.
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
    using System.Threading;
    using System.Threading.Tasks;


    /// <summary>
    /// 总线控制接口
    /// </summary>
    public interface IBusControl :
        IBus
    {
        /// <summary>
        /// Starts the bus (assuming the battery isn't dead). 
        /// 启动总线(假设电池没电)。
        /// Once the bus has been started, it cannot be started again, even after is has been stopped.
        /// 总线一旦启动，就无法重新启动，即使它已经停止。
        /// </summary>
        /// <returns>
        /// The BusHandle for the started bus. 
        /// 启动的公共汽车的拉手。
        /// This is no longer needed, as calling Stop on the IBusControl will stop the bus equally well.
        /// </returns>
        Task<BusHandle> StartAsync(CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Stops the bus if it has been started. If the bus hasn't been started, the method returns without any warning.
        /// </summary>
        Task StopAsync(CancellationToken cancellationToken = default(CancellationToken));
    }
}