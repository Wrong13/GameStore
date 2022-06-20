using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Domain.Entities
{
    public class Game
    {
        [HiddenInput(DisplayValue =false)]
        public int GameId { get; set; }
        public string Name { get; set; }
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
        public string Category { get; set; }
        [Range(0.01,double.MaxValue )]
        public decimal Price { get; set; }
    }
}
