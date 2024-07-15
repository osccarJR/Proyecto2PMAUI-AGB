using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace InterfazTicketsApp.Models
{
    public class WeatherRecord
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string CityName { get; set; }
        public string Country { get; set; }
        public string Temperature { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
    }
}

