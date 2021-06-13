using System;
using System.Collections.Generic;
using System.Text;

namespace examBusinessLogic.BindingModels
{
    public class ComponentBindingModel
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public DateTime DateCreate { get; set; }
        public string Firm { get; set; }
        public int? SystemBlockId { get; set; }
    }
}
