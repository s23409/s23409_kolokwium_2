﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace s23409_kolokwium_2.Models
{
    public class MusicLabel
    {
        public int IdMusicLabel { get; set; }
        public string Name { get; set; }
        public virtual IEnumerable<Album> Albums { get; set; }
    }
}
