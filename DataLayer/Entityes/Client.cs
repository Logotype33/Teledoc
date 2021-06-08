using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Entityes
{
    public class Client
    {
        public int Id { get; set; }
        //На английском ИНН делится на 2 типа: ITN (Indi­vid­ual Tax­pay­er Num­ber) – для физических лиц и TIN (Tax­pay­er Iden­ti­fi­ca­tion Num­ber) – для юридических лиц;
        //Я выбрал создать 1 свойство
        public int INN { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public DateTime CreatingDate { get; set; }
        public DateTime ChangeDate { get; set; }
        public ICollection<Founder> Founders { get; set; }
        //public Client(Client client)
        //{
        //    if (Type == ClientTypes.Entity.ToString())
        //    {
        //        Founders = new Collection<Founder>();
        //    }
        //}

    }
    public enum ClientTypes
    {
        /// <summary>
        /// ИП
        /// </summary>
        SP,
        /// <summary>
        /// Юр. лицо
        /// </summary>
        Entity
    }
}
