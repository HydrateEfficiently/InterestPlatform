using Microsoft.AspNet.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InterestPlatform.Web.Utility
{
    public static class FormUtility
    {
        public static IEnumerable<SelectListItem> GetSelectList<ModelType, ModelIdType>(
            this IEnumerable<ModelType> modelCollection,
            ModelIdType id,
            Func<ModelType, ModelIdType> valueSelector,
            Func<ModelType, string> textSelector)
        {
            var selectList = new List<SelectListItem>();
            if (modelCollection != null)
            {
                foreach (var model in modelCollection)
                {
                    var modelId = valueSelector(model);
                    selectList.Add(new SelectListItem
                    {
                        Value = Convert.ToString(modelId),
                        Text = textSelector(model),
                        Selected = id != null && id.Equals(modelId)
                    });
                }
            }
            return selectList;
        }
    }
}
