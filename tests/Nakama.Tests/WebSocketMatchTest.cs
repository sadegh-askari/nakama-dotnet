/**
 * Copyright 2018 The Nakama Authors
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
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using TinyJson;
    using Xunit;

    public class WebSocketMatchTest : IAsyncLifetime
    {
        private IClient _client;
        private ISocket _socket;

        [Fact]
        public async Task ShouldCreateMatch()
        {
            System.Console.WriteLine("client " + _client);

            var session = await _client.AuthenticateCustomAsync($"{Guid.NewGuid()}");
            System.Console.WriteLine("client " + _socket);

            await _socket.ConnectAsync(session);
            var match = await _socket.CreateMatchAsync();

            Assert.NotNull(match);
            Assert.NotNull(match.Id);
            Assert.NotEmpty(match.Id);
            Assert.False(match.Authoritative);
            Assert.True(match.Size > 0);
        }

        /** TODO -- presences on the server should be updated inside the match returned after a user joins
        // will file issue
        [Fact]
        public async Task ShouldCreateMatchAndSecondUserJoin()
        {
            var session1 = await _client.AuthenticateCustomAsync($"{Guid.NewGuid()}");
            var session2 = await _client.AuthenticateCustomAsync($"{Guid.NewGuid()}");
            await _socket.ConnectAsync(session1);

            var socket2 = Socket.From(_client);
            await socket2.ConnectAsync(session2);

            var match1 = await _socket.CreateMatchAsync();

            Console.WriteLine("match 1 " + match1);
            var match2 = await socket2.JoinMatchAsync(match1.Id);

            Assert.NotNull(match1);
            Assert.NotNull(match2);
            Assert.Equal(match1.Id, match2.Id);
            Assert.Equal(match1.Label, match2.Label);
            Assert.Equal(match1.Presences.Count(), 1);
            Assert.Equal(match2.Presences.Count(), 2);

            await socket2.CloseAsync();
        } **/

        [Fact]
        public async Task ShouldCreateMatchAndLeave()
        {
            var session = await _client.AuthenticateCustomAsync($"{Guid.NewGuid()}");
            await _socket.ConnectAsync(session);
            var match = await _socket.CreateMatchAsync();

            Assert.NotNull(match);
            Assert.NotNull(match.Id);
            // assert does not throw
            await _socket.LeaveMatchAsync(match.Id);
        }

        [Fact]
        public async Task ShouldCreateMatchAndSendState()
        {
            var session1 = await _client.AuthenticateCustomAsync($"{Guid.NewGuid()}");
            var session2 = await _client.AuthenticateCustomAsync($"{Guid.NewGuid()}");

            await _socket.ConnectAsync(session1);

            var socket2 = Socket.From(_client);
            await socket2.ConnectAsync(session2);

            var match = await _socket.CreateMatchAsync();
            await socket2.JoinMatchAsync(match.Id);

            var completer = new TaskCompletionSource<IMatchState>();

            socket2.ReceivedMatchState += (state) => completer.SetResult(state);

            var newState = new Dictionary<string, string> {{"hello", "world"}}.ToJson();
            await _socket.SendMatchStateAsync(match.Id, 0, newState);
            var result = await completer.Task;

            Assert.NotNull(result);
            Assert.Equal(newState, Encoding.UTF8.GetString(result.State));
        }

        // initialize here instead of constructor because we have implemented the IAsyncLifetime
        // interface
        Task IAsyncLifetime.InitializeAsync()
        {
            _client = new Client("http", "127.0.0.1", 7350,  "defaultkey");
            _socket = Socket.From(_client);
            return Task.CompletedTask;
        }

        Task IAsyncLifetime.DisposeAsync()
        {
            return _socket.CloseAsync();
        }
    }
}
