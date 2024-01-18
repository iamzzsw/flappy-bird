using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flappy_Bird
{
    class Result
    {
        public int id { get; set; }

        public string name { get; set; }

        public double classicRecord { get; set; }

        public double classicLevel { get; set; }

        public double countryRecord { get; set; }
        public double countryLevel { get; set; }

        public Result() { }

        public Result(string name, double classicRecord, double classicLevel, double countryRecord, double countryLevel)
        {
            this.name = name;
            this.classicRecord = classicRecord;
            this.classicLevel = classicLevel;
            this.countryRecord = countryRecord;
            this.countryLevel = countryLevel;
        }
    }
}
