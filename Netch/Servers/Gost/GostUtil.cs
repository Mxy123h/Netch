using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using Netch.Controllers;
using Netch.Models;
using Netch.Servers.Gost.Form;
using Netch.Utils;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Netch.Servers.Gost
{
    public class GostUtil : IServerUtil
    {
        public ushort Priority { get; } = 4;
        public string TypeName { get; } = "Gost";
        public string FullName { get; } = "Gost";
        public string ShortName { get; } = "GO";
        public string[] UriScheme { get; } = {"null"};

        public Server ParseJObject(in JObject j)
        {
            return j.ToObject<Gost>();
        }

        public void Edit(Server s)
        {
            new GostForm((Gost) s).ShowDialog();
        }

        public void Create()
        {
            new GostForm().ShowDialog();
        }

        public string GetShareLink(Server s)
        {
            return "";
        }

        public IServerController GetController()
        {
            return new GostController();
        }

        public IEnumerable<Server> ParseUri(string text)
        {
            return null;
        }


        public bool CheckServer(Server s)
        {
            var server = (Gost) s;
            if (!GostGlobal.Transports.Contains(server.Transports))
            {
                Logging.Error($"不支持的 Transports 方式：{server.Transports}");
                {
                    return false;
                }
            }
            if (!GostGlobal.Protocols.Contains(server.Protocols))
            {
                Logging.Error($"不支持的 Protocols 方式：{server.Protocols}");
                {
                    return false;
                }
            }

            return true;
        }
    }
}