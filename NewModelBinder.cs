using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace News.MyModelBinders
{
    public class NewModelBinder:DefaultModelBinder
    {
        public override object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            if(bindingContext.ModelType == typeof(NewsT))
            {
                var request = controllerContext.HttpContext.Request;
                int id = Convert.ToInt32(request.QueryString["id"]);
                var ctx = new NewsEntities();
                NewsT model = ctx.NewsT.FirstOrDefault(x=>x.Id==id);
                if(model==null)
                    return base.BindModel(controllerContext, bindingContext);

                return model;
            }
            else
            {
                return base.BindModel(controllerContext, bindingContext);
            }
        }
    }
}