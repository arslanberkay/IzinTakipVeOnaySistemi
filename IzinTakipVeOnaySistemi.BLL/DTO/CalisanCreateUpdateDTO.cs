﻿using IzinTakipVeOnaySistemi.DAL.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IzinTakipVeOnaySistemi.BLL.DTO
{
    public record CalisanCreateUpdateDTO
    {
        public int Id { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string Eposta { get; set; }
        public string Sifre { get; set; }
        public Rol Rol { get; set; }
        public int DepartmanId { get; set; }
    }
}
