using System.Collections.Generic;
using Netch.Models;

namespace Netch.Servers.Gost
{
    public class Gost : Server
    {
        /// <summary>
        ///     传输类型
        /// </summary>
        public string Transports { get; set; } = GostGlobal.Transports[0];
        /// <summary>
        ///     协议类型
        /// </summary>
        public string Protocols { get; set; } = GostGlobal.Protocols[0];



        /// <summary>
        ///     密码
        /// </summary>
        public string pass { get; set; }

        /// <summary>
        ///     用户
        /// </summary>
        public string user { get; set; }

        /// <summary>
        ///     auth
        /// </summary>
        public string auth { get; set; }

        public Gost()
        {
            Type = "Gost";
        }
    }

    public static class GostGlobal
    {
        /// <summary>
        /// 传输类型
        /// </summary>
        public static readonly List<string> Transports = new List<string>
        {
            "",
            "tcp",
            "tls",
            "mtls",
            "ws",
            "mws",
            "wss",
            "mwss",
            "kcp",
            "quic",
            "ssh",
            "h2",
            "h2c",
            "obfs4",
            "ohttp",
            "otls"
        };


        /// <summary>
        /// 协议类型
        /// </summary>
        public static readonly List<string> Protocols = new List<string>
        {
            "",
            "http",
            "http2",
            "socks4",
            "socks4a",
            "socks5",
            "ss",
            "ss2",
            "sni",
            "forward",
            "relay"
        };
    }
}