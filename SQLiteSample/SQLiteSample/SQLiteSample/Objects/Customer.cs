using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace SQLiteSample.Objects
{
    public class Customer
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public String Name { get; set; }

        public string Phone { get; set; }
    }
}
