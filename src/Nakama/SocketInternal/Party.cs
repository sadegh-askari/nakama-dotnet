/**
* Copyright 2021 The Nakama Authors
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

using System.Runtime.Serialization;

namespace Nakama.SocketInternal
{
    /// <summary>
    /// Incoming information about a party.
    /// </summary>
    public class Party : IParty
    {
        [DataMember(Name = "party_id", Order = 1), Preserve]
        public string PartyId { get; set; }

        [DataMember(Name = "open", Order = 2), Preserve]
        public bool Open { get; set; }

        [DataMember(Name = "max_size", Order = 3), Preserve]
        public bool MaxSize { get; set; }

        [DataMember(Name = "self", Order = 4), Preserve]
        public UserPresence Self { get; set; }

        [DataMember(Name = "leader", Order = 5), Preserve]
        UserPresence Leader { get; set; }

        [DataMember(Name = "presences", Order = 6), Preserve]
        UserPresence[] Presences { get; set; }
    }
}
