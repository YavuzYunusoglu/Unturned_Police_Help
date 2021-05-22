using Rocket.API;
using Rocket.Unturned.Chat;
using Rocket.Unturned.Player;
using SDG.Unturned;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Police_Help.Commands
{
    public class HelpCommand : IRocketCommand
    {
        public AllowedCaller AllowedCaller => AllowedCaller.Player;

        public string Name => "destek";

        public string Help => "Polis Cagirmani Saglar";

        public string Syntax => "<name>";

        public List<string> Aliases => new List<string> {"155","police", "polis" };

        public List<string> Permissions => new List<string> { Main.Instance.Configuration.Instance.SivilPermission};

        [Obsolete]
        public void Execute(IRocketPlayer caller, string[] command)
        {
            string message = string.Join(" ", command);
            var c = Main.Instance.Configuration.Instance; // Config Dosyasını Kısayol Olarak Kayıt Et
            string aciklama = c.Aciklama.Replace('{', '<').Replace('}', '>').Replace("%MESSAGE%", message); // Açıklama Mesajını "aciklama" Olarak Kayıt Et
            if (command.Count() != 0) // Komut Doğru Kullanılırsa
            {
                UnturnedChat.Say(caller, c.SivilMesaj, Main.Instance.SivilRenk); // Polis Çağırıldı Mesajı Yolla
                foreach (var steamPlayer in Provider.clients) // Sunucudaki Bütün Polislere Alttaki Komutları Gönder
                {
                    UnturnedPlayer polis = UnturnedPlayer.FromSteamPlayer(steamPlayer); // Polis Kişisini Tanımla
                    if (polis.HasPermission(c.PolisPermission)) // Eğer Oyuncuda Polis Yetkisi Varsa Aşağıdaki Komutları Uygula
                    {
                        UnturnedPlayer player = caller as UnturnedPlayer; // Mesaj Gönderen Kişiyi Tanımla

                        var node = LevelNodes.nodes.OfType<LocationNode>().OrderBy(k => Vector3.Distance(k.point, player.Position)).FirstOrDefault();

                        polis.Player.quests.askSetMarker(player.CSteamID, true, player.Position); // Polislerin Haritasında İşaretleme Yap
                        UnturnedChat.Say(polis, c.PolisMesaj, Main.Instance.PolisRenk);// Polislere Çağırma Mesajı Gönder
                        UnturnedChat.Say(polis, c.KonumMesaj + node.name, Main.Instance.KonumRenk);// Polislere Konum Mesajı Gönder
                        UnturnedChat.Say(polis, aciklama, Main.Instance.SebepRenk); //Polislere Açıklama Mesajı Gönder
                    }
                }
            }
            else // Komut Yanlış Kullanılırsa
            {
                UnturnedChat.Say(caller, c.YanlisMesaj,Main.Instance.YanlisRenk);
            }

        }
    }
}
