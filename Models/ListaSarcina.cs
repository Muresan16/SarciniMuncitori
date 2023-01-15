using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace SarciniMuncitori.Models
{
    public class ListaSarcina
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        [ForeignKey(typeof(SarcinaMuncitor))]
        public int SarcinaMuncitorID { get; set; }
        public int ProductID { get; set; }
    }
}
