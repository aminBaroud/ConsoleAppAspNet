using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BelleBoucheeConsoleApp.Models
{
    public class Order
    {
        public int Id { get; set; }
        public Client Client { get; set; }
        public DateTime CreationDate { get; set; }
        public double SubTotal { get; set; }
        public double Total { get; set; }
        public double TVQ { get; set; }
        public double TPS { get; set; }
    }
}
