using System.Collections.Generic;
using System.IO;
using Netch.Controllers;
using Netch.Models;
using Netch.Utils;
using Newtonsoft.Json;

namespace Netch.Servers.Gost
{
    public class GostController : Guard, IServerController
    {
        public GostController()
        {
            StartedKeywords.Add("route.go");
            StoppedKeywords.Add("route.go");
        }

        public override string MainFile { get; protected set; } = "gost.exe";
        public override string Name { get; } = "gost";
        public ushort? Socks5LocalPort { get; set; }
        public string LocalAddress { get; set; }


        public bool Start(in Server s, in Mode mode)
        {
            var server = (Gost) s;
            string userpass = string.Empty;
            string auth = string.Empty;
            if (!string.IsNullOrEmpty(server.user) && !string.IsNullOrEmpty(server.pass))
            {
                userpass = $"{server.user}:{server.pass}@";
            }
            else if (!string.IsNullOrEmpty(server.auth))
            {
                auth = $"?auth={server.auth}";
            }

            string puls = "+";
            if(string.IsNullOrEmpty(server.Protocols) || string.IsNullOrEmpty(server.Transports))
            {
                puls = "";
            }
            return StartInstanceAuto($"-L=socks5://:{this.Socks5LocalPort()} -F={server.Protocols}{puls}{server.Transports}://{userpass}{server.Hostname}:{server.Port}{auth}");
        }

        public override void Stop()
        {
            StopInstance();
        }
    }
}