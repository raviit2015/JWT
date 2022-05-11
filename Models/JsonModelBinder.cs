using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JWTAuthentication.Models
{
    public class JsonModelBinder : IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            if (bindingContext == null)
            {
                throw new ArgumentNullException(nameof(bindingContext));
            }

            // Check the value sent in
            var valueProviderResult = bindingContext.ValueProvider.GetValue(bindingContext.ModelName);
            if (valueProviderResult != ValueProviderResult.None)
            {
                bindingContext.ModelState.SetModelValue(bindingContext.ModelName, valueProviderResult);

                // Attempt to convert the input value
                var valueAsString = valueProviderResult.FirstValue;
                if (JsonHelper.TryParseJson(valueAsString, bindingContext.ModelType, out var result))
                {
                    if (result != null)
                    {
                        bindingContext.Result = ModelBindingResult.Success(result);
                    }
                }
                else
                {
                    bindingContext.ModelState.TryAddModelError(
                                   bindingContext.ModelName,
                                   "Invalid parametrs json string. Should be [{\"jsonschemaid\":\" name of schema \",\"jsondata\":\" some json data\"}]");
                }
            }

            return Task.CompletedTask;
        }
    }
}
