using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LenaQuest.ViewModels
{
    public class SortViewModel
    {
        public int AgeMin { get; set; }
        public int AgeMax { get; set; }
        public int ExpMin { get; set; }
        public int ExpMax { get; set; }
        public string City { get; set; }
    }
}
