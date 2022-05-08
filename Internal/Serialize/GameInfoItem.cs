using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.Cryptography;
using System.Text;

namespace AGCGM.Internal.Serialize
{
    [Serializable]
    public class GameInfoItem
    {
        //Propiedades publicas
        public int ID { get; set; }
        public string Code { get; set; }
        public string Title { get; set; }
        public string Maker { get; set; }
        public string Country { get; set; }
        public long Length { get; set; }
        public byte[] Integrity { get; set; }

        //Constructores.
        public GameInfoItem() { }
        public GameInfoItem(int ID, string Code, string Title, string Maker, string Country, long Length)
        {
            this.ID = ID;
            this.Code = Code;
            this.Title = Title;
            this.Maker = Maker;
            this.Country = Country;
            this.Length = Length;
            Integrity = GetHash();
        }

        //Metodos publicos.
        public string GetCodeID() => string.Format(Lang.strings.CONST_BACKUP_ID, Code, ID);

        public bool IsValid() => Integrity.Except(GetHash()).AsParallel().Count() == 0;

        //Metofos privados.
        private byte[] GetHash()
        {
            List<byte> data = new List<byte>();
            data.AddRange(Encoding.UTF7.GetBytes(GetCodeID() + Title + Maker + Country));
            data.AddRange(BitConverter.GetBytes(Length));
            return new MD5CryptoServiceProvider().ComputeHash(data.ToArray());
        }
    }
}
