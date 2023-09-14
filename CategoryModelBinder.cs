using DAL;
using DAL.Entity;
using DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ETicaret.ModelBinders
{
    public class CategoryModelBinder : DefaultModelBinder
    {
        public override object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            if (bindingContext.ModelType == typeof(Category))
            {
                Category category = new Category();
                var req = controllerContext.HttpContext.Request;
                category.Name = req.Form["Name"].ToString();
                category.CreateDate = DateTime.Now;

                if(req.Form["ParentCategory"]!=null && !String.IsNullOrWhiteSpace(req.Form["ParentCategory"].ToString()))
                {
                    int ParentId = Convert.ToInt32(req.Form["ParentCategory"].ToString());
                    if (ParentId != 0)
                    {
                        category.ParentCategory = new CategoryRepository().FindById(ParentId);
                    }
                }
                return category;
            }
            return base.BindModel(controllerContext, bindingContext);
        }
    }
}