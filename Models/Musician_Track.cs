﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace s23409_kolokwium_2.Models
{
    public class Musician_Track
    {
        public int IdTrack { get; set; }
        public int IdMusician { get; set; }
        public virtual Track Track { get; set; }
        public virtual Musician Musician { get; set; }
    }
}
