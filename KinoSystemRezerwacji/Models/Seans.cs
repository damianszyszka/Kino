using System;
using System.Collections.Generic;

namespace KinoSystemRezerwacji.Models
{
    public class Seans
    {
        public int Id { get; set; }
        public int FilmId { get; set; }
        public Film Film { get; set; }
        public DateTime DataSeansu { get; set; }
    }
}
