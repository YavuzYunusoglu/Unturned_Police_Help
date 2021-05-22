using Rocket.API;
using Rocket.Core;
using Rocket.Unturned.Player;
using SDG.Unturned;
using Steamworks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Police_Help
{
    public class Config : IRocketPluginConfiguration
    {
        //Mesajlar
        public string PolisMesaj { get; set; }
        public string PolisPermission { get; set; }
        public string SivilPermission { get; set; }
        public string SivilMesaj { get; set; }
        public string YanlisMesaj { get; set; }
        public string KonumMesaj { get; set; }

        public string Aciklama;
        //Renkler
        public string PolisRenk { get; set; }
        public string SivilRenk { get; set; }
        public string SebepRenk { get; set; }
        public string YanlisRenk { get; set; }
        public string KonumRenk { get; set; }

        public void LoadDefaults()
        {
            // Yetkiler
            PolisPermission = "flame.polis";
            SivilPermission = "flame.sivil";
            //Mesaj Renkleri
            PolisRenk = "cyan";
            SivilRenk = "yellow";
            YanlisRenk = "red";
            SebepRenk = "white";
            KonumRenk = "magenta";
            // Mesajlar
            SivilMesaj = "Başarıyla Polis Çağırdın En Kısa Sürede Geleceklerdir";
            YanlisMesaj = "Doğru Kullanım Şekli: /polis <sebep>";
            Aciklama = "Şu Sebeple Çağırdı : %MESSAGE%";
            PolisMesaj = "Birisi Polis Çağırıyor Konumu Haritanda Işaretlendi";
            KonumMesaj = "En Yakın Konum: ";
        }
    }
}