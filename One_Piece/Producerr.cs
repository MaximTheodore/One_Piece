using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace One_Piece
{
    internal class Producerr
    {
        public  string name { get; set; }
        public Producerr(string name)
        {
            this.name = name;
        }
    }
    internal class Fact
    {
        public  string name { get; set;}
        public  string adress { get; set;}
        public Fact(string name, string adress)
        {
            this.name = name;
            this.adress = adress;   
        }
    }
}
