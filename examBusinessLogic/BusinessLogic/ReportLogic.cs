using examBusinessLogic.BindingModels;
using examBusinessLogic.Interfaces;
using examBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace examBusinessLogic.BusinessLogic
{
    public class ReportLogic
    {
        private readonly IComponentStorage _componentStorage;
        private readonly ISystemBlockStorage _systemBlockStorage;
        public ReportLogic(ISystemBlockStorage systemBlockStorage, IComponentStorage componentStorage)
        {
            _systemBlockStorage = systemBlockStorage;
            _componentStorage = componentStorage;
        }
        /// <summary>
        /// Получение списка компонент с указанием, в каких изделиях используются
        /// </summary>
        /// <returns></returns>104
      
        /// <summary>
        /// Получение списка заказов за определенный период
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public List<ReportViewModel> GetSysBlocks(ReportBindingModel model)
        {
            return _systemBlockStorage.GetFilteredList(new SystemBlockBindingModel
            {
                Brand = model.Brand,
                DateCreate = model.SystemBlockDateCreate
            })
            .Select(x => new ReportViewModel
            {
                Brand = x.Brand,
                Firm = x.F,
                SystemBlockDateCreate = x.DateCreate,
                ComponentName = x.Sum,
                ComponentDateCreate = x.Status
            })
           .ToList();
        }
       
        public void SaveOrdersToPdfFile(ReportBindingModel model)
        {
            SaveToPdf.CreateDoc(new PdfInfo
            {
                FileName = model.FileName,
                Title = "Список заказов",
                DateFrom = model.DateFrom.Value,
                DateTo = model.DateTo.Value,
                Orders = GetOrders(model)
            });
        }

    }
}
