using Netch.Forms;

namespace Netch.Servers.Gost.Form
{
    public class GostForm : ServerForm
    {
        protected override string TypeName { get; } = "Gost";

        public GostForm(Gost server = default)
        {
            server ??= new Gost();
            Server = server;
            CreateComboBox("Protocols", "Protocols",
                GostGlobal.Protocols,
                s => server.Protocols = s,
                server.Protocols);
            CreateComboBox("Transports", "Transports",
                GostGlobal.Transports,
                s => server.Transports = s,
                server.Transports);
            CreateTextBox("user", "user",
                s => true,
                s => server.user = s,
                server.user);
            CreateTextBox("pass", "pass",
                s => true,
                s => server.pass = s,
                server.pass);
            CreateTextBox("auth", "auth",
                s => true,
                s => server.auth = s,
                server.auth);
            
        }
    }
}