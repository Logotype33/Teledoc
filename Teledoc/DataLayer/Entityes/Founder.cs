using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Entityes
{
    public class Founder
    {
        public int Id { get; set; }
        public int INN { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        /// <summary>
        /// Отчество
        /// </summary>
        public string Patronymic { get; set; }
        public DateTime CreatingDate { get; set; }
        public DateTime ChangeDate { get; set; }
    }
    
}
