using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Text;

namespace examBusinessLogic.ViewModels
{
    [DataContract]
    public class SystemBlockViewModel
    {
        [DataMember]
        public int? Id { get; set; }
        [DisplayName("Марка")]
        [DataMember]
        public string Brand { get; set; }
        [DisplayName("Тип блока")]
        [DataMember]
        public string BlockType { get; set; }
        [DisplayName("Дата создания")]
        [DataMember]
        public DateTime DateCreate { get; set; }
    }
}
