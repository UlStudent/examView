using examBusinessLogic.BindingModels;
using examBusinessLogic.HelperModels;
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
            return _componentStorage.GetFilteredList(new ComponentBindingModel
            {
                DateFrom = model.DateFrom,
                DateTo = model.DateTo
            })
            .Select(x => new ReportViewModel
            {
                Brand = _systemBlockStorage.GetElement(new SystemBlockBindingModel
                {
                    Id = x.SystemBlockId
                }).Brand,
                Firm = x.Firm,
                SystemBlockDateCreate = _systemBlockStorage.GetElement(new SystemBlockBindingModel
                {
                    Id = x.SystemBlockId
                }).DateCreate,
                ComponentName = x.Name,
                ComponentDateCreate = x.DateCreate
            })
           .ToList();
        }

        [Obsolete]
        public void SaveOrdersToPdfFile(ReportBindingModel model)
        {
            SaveToPdf.CreateDoc(new PdfInfo
            {
                FileName = model.FileName,
                Title = "Список заказов",
                DateFrom = model.DateFrom,
                DateTo = model.DateTo,
                SystemBlocks = GetSysBlocks(model)
            });
        }
    }
}
