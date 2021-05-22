using Rocket.API;
using Rocket.API.Collections;
using Rocket.Core.Logging;
using Rocket.Core.Plugins;
using Rocket.Unturned;
using Rocket.Unturned.Chat;
using Rocket.Unturned.Events;
using Rocket.Unturned.Player;
using SDG.Unturned;
using Steamworks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Logger = Rocket.Core.Logging.Logger;

namespace Police_Help
{
    class Main : RocketPlugin<Config>
    {
        public static Main Instance { get; private set; }
        public Color PolisRenk { get; private set; }
        public Color SivilRenk { get; private set; }
        public Color SebepRenk { get; private set; }
        public Color YanlisRenk { get; private set; }
        public Color KonumRenk { get; private set; }
        protected override void Load()
        {

            Instance = this;

            //Renkler
            PolisRenk = UnturnedChat.GetColorFromName(Configuration.Instance.PolisRenk, Color.cyan);
            YanlisRenk = UnturnedChat.GetColorFromName(Configuration.Instance.YanlisRenk, Color.red);
            SivilRenk = UnturnedChat.GetColorFromName(Configuration.Instance.SivilRenk, Color.yellow);
            KonumRenk = UnturnedChat.GetColorFromName(Configuration.Instance.KonumRenk, Color.magenta);
            SebepRenk = UnturnedChat.GetColorFromName(Configuration.Instance.SebepRenk, Color.white);

            //Konsol Mesajı
            Logger.Log("********************************************");
            Logger.Log("                                            ");
            Logger.Log("                                            ");
            Logger.Log("               PLUIN YUKLENDI               ");
            Logger.Log("                                            ");
            Logger.Log($"            {Name} {Assembly.GetName().Version}    ");
            Logger.Log("                                            ");
            Logger.Log("                                            ");
            Logger.Log("********************************************");
        }
        protected override void Unload()
        {
            //Konsol Mesajı
            Logger.Log($"{Name} Devre Dışı");
        }
    }
}
