using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Text;

namespace examBusinessLogic.ViewModels
{
    [DataContract]
    public class ComponentViewModel
    {
        [DataMember]
        public int? Id { get; set; }
        [DisplayName("Название")]
        [DataMember]
        public string Name { get; set; }
        [DisplayName("Цена")]
        [DataMember]
        public double Price { get; set; }
        [DisplayName("Дата создания")]
        [DataMember]
        public DateTime DateCreate { get; set; }
        [DisplayName("Фирма")]
        [DataMember]
        public string Firm { get; set; }
        public int? SystemBlockId { get; set; }
    }
}
