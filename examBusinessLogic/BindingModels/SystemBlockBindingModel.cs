using System;
using System.Collections.Generic;
using System.Text;

namespace examBusinessLogic.BindingModels
{
    public class SystemBlockBindingModel
    {
        public int? Id { get; set; }
        public string Brand { get; set; }
        public string BlockType { get; set; }
        public DateTime DateCreate { get; set; }
    }
}
