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
        public int INN { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public DateTime CreatingDate { get; set; }
        public DateTime ChangeDate { get; set; }
        public ICollection<Founder> Founders { get; set; }
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
