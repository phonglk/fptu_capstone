using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using System.Collections.Concurrent;
using System.Threading.Tasks;


// Modifying from https://github.com/tugberkugurlu/SignalRSamples/tree/master/ConnectionMappingSample
namespace DropIt.Hubs
{
    public class HubUser
    {
        public string UserName { get; set; }
        public HashSet<string> ConnectionIds { get; set; }
    }



    [Authorize]
    public class NotificationHub : Hub
    {
        public static readonly ConcurrentDictionary<string, HubUser> HubUsers
            = new ConcurrentDictionary<string, HubUser>(StringComparer.InvariantCultureIgnoreCase);

        public static void Send(dynamic message)
        {
            var context = GlobalHost.ConnectionManager.GetHubContext<NotificationHub>();

            context.Clients.All.received(message);
        }

        public static void Send(dynamic message, string to)
        {

            HubUser receiver;
            if (HubUsers.TryGetValue(to, out receiver))
            {
                var context = GlobalHost.ConnectionManager.GetHubContext<NotificationHub>();


                IEnumerable<string> allReceivers = receiver.ConnectionIds;

                foreach (var cid in allReceivers)
                {
                    context.Clients.Client(cid).received(message);
                }
            }
        }

        public IEnumerable<string> GetConnectedUsers()
        {

            return HubUsers.Where(x =>
            {

                lock (x.Value.ConnectionIds)
                {

                    return !x.Value.ConnectionIds.Contains(Context.ConnectionId, StringComparer.InvariantCultureIgnoreCase);
                }

            }).Select(x => x.Key);
        }

        public override Task OnConnected()
        {

            string userName = Context.User.Identity.Name;
            string connectionId = Context.ConnectionId;

            var user = HubUsers.GetOrAdd(userName, _ => new HubUser
            {
                UserName = userName,
                ConnectionIds = new HashSet<string>()
            });

            lock (user.ConnectionIds)
            {

                user.ConnectionIds.Add(connectionId);

                // // broadcast this to all clients other than the caller
                // Clients.AllExcept(user.ConnectionIds.ToArray()).userConnected(userName);

                // Or you might want to only broadcast this info if this 
                // is the first connection of the user
                if (user.ConnectionIds.Count == 1)
                {

                    Clients.Others.userConnected(userName);
                }
            }

            return base.OnConnected();
        }

        public override Task OnDisconnected()
        {

            string userName = Context.User.Identity.Name;
            string connectionId = Context.ConnectionId;

            HubUser user;
            HubUsers.TryGetValue(userName, out user);

            if (user != null)
            {

                lock (user.ConnectionIds)
                {

                    user.ConnectionIds.RemoveWhere(cid => cid.Equals(connectionId));

                    if (!user.ConnectionIds.Any())
                    {

                        HubUser removedUser;
                        HubUsers.TryRemove(userName, out removedUser);
                        Clients.Others.userDisconnected(userName);
                    }
                }
            }

            return base.OnDisconnected();
        }

        private static HubUser GetHubUser(string username)
        {

            HubUser user;
            HubUsers.TryGetValue(username, out user);

            return user;
        }
    }
}