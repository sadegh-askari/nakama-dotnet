/**
 * Copyright 2020 The Nakama Authors
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

namespace Nakama.Tests
{
    using System;
    using System.Threading.Tasks;
    using Xunit;

    public class WebSocketMatchmakerTest : IAsyncLifetime
    {
        private IClient _client;
        private ISocket _socket;

        [Fact]
        public async Task ShouldJoinMatchmaker()
        {
            var session = await _client.AuthenticateCustomAsync($"{Guid.NewGuid()}");
            await _socket.ConnectAsync(session);
            var matchmakerTicket = await _socket.AddMatchmakerAsync("*");

            Assert.NotNull(matchmakerTicket);
            Assert.NotEmpty(matchmakerTicket.Ticket);
        }

        [Fact]
        public async Task ShouldJoinAndLeaveMatchmaker()
        {
            var session = await _client.AuthenticateCustomAsync($"{Guid.NewGuid()}");
            await _socket.ConnectAsync(session);
            var matchmakerTicket = await _socket.AddMatchmakerAsync("*");

            Assert.NotNull(matchmakerTicket);
            Assert.NotEmpty(matchmakerTicket.Ticket);
            // assert does not throw
            await _socket.RemoveMatchmakerAsync(matchmakerTicket);
        }

        Task IAsyncLifetime.InitializeAsync()
        {
            _client = new Client("http", "127.0.0.1", 7350, "defaultkey");
            _socket = Socket.From(_client);
            return Task.CompletedTask;
        }

        Task IAsyncLifetime.DisposeAsync()
        {
            return _socket.CloseAsync();
        }
    }
}
