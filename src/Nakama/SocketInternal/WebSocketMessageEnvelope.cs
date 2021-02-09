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

using System.Runtime.Serialization;

namespace Nakama.SocketInternal
{
    /// <summary>
    /// An envelope for messages received or sent on a <c>WebSocket</c>.
    /// </summary>
    [DataContract]
    public class WebSocketMessageEnvelope
    {
        [DataMember(Name="cid", Order = 1), Preserve]
        public string Cid { get; set; }

        [DataMember(Name="channel", Order = 2), Preserve]
        public Channel Channel { get; set; }

        [DataMember(Name="channel_join", Order = 3), Preserve]
        public ChannelJoinMessage ChannelJoin { get; set; }

        [DataMember(Name="channel_leave", Order = 4), Preserve]
        public ChannelLeaveMessage ChannelLeave { get; set; }

        [DataMember(Name="channel_message", Order = 5), Preserve]
        public ApiChannelMessage ChannelMessage { get; set; }

        [DataMember(Name="channel_message_ack", Order = 6), Preserve]
        public ChannelMessageAck ChannelMessageAck { get; set; }

        [DataMember(Name="channel_message_remove", Order = 9), Preserve]
        public ChannelRemoveMessage ChannelMessageRemove { get; set; }

        [DataMember(Name="channel_message_send", Order = 7), Preserve]
        public ChannelSendMessage ChannelMessageSend { get; set; }

        [DataMember(Name="channel_message_update", Order = 8), Preserve]
        public ChannelUpdateMessage ChannelMessageUpdate { get; set; }

        [DataMember(Name="channel_presence_event", Order = 10), Preserve]
        public ChannelPresenceEvent ChannelPresenceEvent { get; set; }

        [DataMember(Name="error", Order = 11), Preserve]
        public WebSocketErrorMessage Error { get; set; }

        [DataMember(Name="matchmaker_add", Order = 19), Preserve]
        public MatchmakerAddMessage MatchmakerAdd { get; set; }

        [DataMember(Name="matchmaker_matched", Order = 20), Preserve]
        public MatchmakerMatched MatchmakerMatched { get; set; }

        [DataMember(Name="matchmaker_remove", Order = 21), Preserve]
        public MatchmakerRemoveMessage MatchmakerRemove { get; set; }

        [DataMember(Name="matchmaker_ticket", Order = 22), Preserve]
        public MatchmakerTicket MatchmakerTicket { get; set; }

        [DataMember(Name="match", Order = 12), Preserve]
        public Match Match { get; set; }

        [DataMember(Name="match_create", Order = 13), Preserve]
        public MatchCreateMessage MatchCreate { get; set; }

        [DataMember(Name="match_join", Order = 16), Preserve]
        public MatchJoinMessage MatchJoin { get; set; }

        [DataMember(Name="match_leave", Order = 17), Preserve]
        public MatchLeaveMessage MatchLeave { get; set; }

        [DataMember(Name="match_presence_event", Order = 18), Preserve]
        public MatchPresenceEvent MatchPresenceEvent { get; set; }

        [DataMember(Name="match_data", Order = 14), Preserve]
        public MatchState MatchState { get; set; }

        [DataMember(Name="match_data_send", Order = 15), Preserve]
        public MatchSendMessage MatchStateSend { get; set; }

        [DataMember(Name="notifications", Order = 23), Preserve]
        public ApiNotificationList NotificationList { get; set; }

        [DataMember(Name="rpc", Order = 24), Preserve]
        public ApiRpc Rpc { get; set; }

        [DataMember(Name="status", Order = 25), Preserve]
        public Status Status { get; set; }

        [DataMember(Name="status_follow", Order = 26), Preserve]
        public StatusFollowMessage StatusFollow { get; set; }

        [DataMember(Name="status_presence_event", Order = 27), Preserve]
        public StatusPresenceEvent StatusPresenceEvent { get; set; }

        [DataMember(Name="status_unfollow", Order = 28), Preserve]
        public StatusUnfollowMessage StatusUnfollow { get; set; }

        [DataMember(Name="status_update", Order = 29), Preserve]
        public StatusUpdateMessage StatusUpdate { get; set; }

        [DataMember(Name="stream_presence_event", Order = 31), Preserve]
        public StreamPresenceEvent StreamPresenceEvent { get; set; }

        [DataMember(Name="stream_data", Order = 30), Preserve]
        public StreamState StreamState { get; set; }

        [DataMember(Name="party", Order = 34), Preserve]
        public Party Party { get; set; }

        [DataMember(Name="party_create", Order = 35), Preserve]
        public PartyCreate PartyCreate { get; set; }

        [DataMember(Name="party_join", Order = 36), Preserve]
        public PartyJoin PartyJoin { get; set; }

        [DataMember(Name="party_leave", Order = 37), Preserve]
        public PartyLeave PartyLeave { get; set; }

        [DataMember(Name="party_promote", Order = 38), Preserve]
        public PartyPromote PartyPromote { get; set; }

        [DataMember(Name="party_leader", Order =  39), Preserve]
        public PartyLeader PartyLeader { get; set; }

        [DataMember(Name="party_accept", Order =  40), Preserve]
        public PartyAccept PartyAccept { get; set; }

        [DataMember(Name="party_remove", Order =  41), Preserve]
        public PartyRemove PartyRemove { get; set; }

        [DataMember(Name="party_close", Order =  42), Preserve]
        public PartyClose PartyClose { get; set; }

        [DataMember(Name="party_join_request_list", Order =  43), Preserve]
        public PartyJoinRequestList PartyJoinRequestList { get; set; }

        [DataMember(Name="party_join_request", Order =  44), Preserve]
        public PartyJoinRequest PartyJoinRequest { get; set; }

        [DataMember(Name="party_matchmaker_add", Order =  45), Preserve]
        public PartyMatchmakerAdd PartyMatchmakerAdd { get; set; }

        [DataMember(Name="party_matchmaker_remove", Order =  46), Preserve]
        public PartyMatchmakerRemove PartyMatchmakerRemove { get; set; }

        [DataMember(Name="party_matchmaker_ticket", Order =  47), Preserve]
        public PartyMatchmakerTicket PartyMatchmakerTicket { get; set; }

        [DataMember(Name="party_data", Order =  48), Preserve]
        public PartyData PartyData { get; set; }

        [DataMember(Name="party_data_send", Order =  49), Preserve]
        public PartyDataSend PartyDataSend { get; set; }

        [DataMember(Name="party_presence_event", Order =  50), Preserve]
        public PartyPresenceEvent PartyPresenceEvent { get; set; }

        public override string ToString()
        {
            return "WebSocketMessageEnvelope";
        }
    }
}
