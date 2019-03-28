using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.DTO
{
    public class ShoppingItem
    {
        // Prin atribute putem sa deifinim constrangeri asupra unei prorietati
        // Daca aceste constrangeri nu sunt respectate, se vor arunca exceptii
        // Acesta este un atribut si se refera la faptul ca ID va fi cheie primara
        [PrimaryKey]
        public uint ID { get; set; }

        // Vrem sa ne asiguram ca numele Item-ului nu este null
        [NotNull]
        public string ItemName { get; set; }
    }
}
