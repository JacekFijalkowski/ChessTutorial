﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChessTutorial.Models
{
    public class Location
    {
        private byte _x;
        private byte _y;

        public byte X
        {
            get => _x;
            set => _x = value;
        }

        public byte Y
        {
            get => _y;
            set => _y = value;
        }
    }
}