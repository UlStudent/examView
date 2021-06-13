using examBusinessLogic.BindingModels;
using examBusinessLogic.Interfaces;
using examBusinessLogic.ViewModels;
using examDatabaseImplement.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace examDatabaseImplement.Implements
{
    public class ComponentStorage : IComponentStorage
    {
        public void Delete(ComponentBindingModel model)
        {
            using (var context = new ExamDatabase())
            {
                Component element = context.Components.FirstOrDefault(rec => rec.Id == model.Id);
                if (element != null)
                {
                    context.Components.Remove(element);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Элемент не найден");
                }
            }
        }

        public ComponentViewModel GetElement(ComponentBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using (var context = new ExamDatabase())
            {
                var component = context.Components
                    .FirstOrDefault(rec => rec.Name == model.Name || rec.Id == model.Id);
                return component != null ?
                    new ComponentViewModel
                    {
                        Id = component.Id,
                        Name = component.Name,
                        Price = component.Price,
                        Firm = component.Firm,
                        DateCreate = component.DateCreate,
                        SystemBlockId = component.SystemBlockId
                    } : null;
            }
        }

        public List<ComponentViewModel> GetFilteredList(ComponentBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using (var context = new ExamDatabase())
            {
                return context.Components
                    .Where(rec => rec.Name.Contains(model.Name))
                    .Select(rec => new ComponentViewModel
                    {
                        Id = rec.Id,
                        Name = rec.Name,
                        Price = rec.Price,
                        Firm = rec.Firm,
                        DateCreate = rec.DateCreate,
                        SystemBlockId = rec.SystemBlockId,
                    })
                    .ToList();
            }
        }

        public List<ComponentViewModel> GetFullList()
        {
            using (var context = new ExamDatabase())
            {
                return context.Components
                    .Select(rec => new ComponentViewModel
                    {
                        Id = rec.Id,
                        Name = rec.Name,
                        Price = rec.Price,
                        Firm = rec.Firm,
                        DateCreate = rec.DateCreate,
                        SystemBlockId = rec.SystemBlockId,
                    })
                    .ToList();
            }
        }

        public void Insert(ComponentBindingModel model)
        {
            using (var context = new ExamDatabase())
            {
                context.Components.Add(CreateModel(model, new Component()));
                context.SaveChanges();
            }
        }

        public void Update(ComponentBindingModel model)
        {
            using (var context = new ExamDatabase())
            {
                var element = context.Components.FirstOrDefault(rec => rec.Id == model.Id);
                if (element == null)
                {
                    throw new Exception("Элемент не найден");
                }
                CreateModel(model, element);
                context.SaveChanges();
            }
        }
        private Component CreateModel(ComponentBindingModel model, Component component)
        {
            if (model.Id.HasValue)
            {
                component.Name = model.Name;
                component.Price = model.Price;
                component.Firm = model.Firm;
                component.DateCreate = model.DateCreate;
                component.SystemBlockId = model.SystemBlockId;
            }
            return component;
        }
    }
}
