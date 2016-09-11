using System;
using System.Web.Mvc;
using Task4.Models;

namespace Task4.Infrastructure
{
    public class AddressModelBInder : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            Address model = bindingContext.Model as Address ?? new Address();
            model.Line1 = GetValue(bindingContext, controllerContext, CreateValueName("Line1"));
            model.Line2 = GetValue(bindingContext, controllerContext, CreateValueName("Line2"));
            model.City = GetValue(bindingContext, controllerContext, CreateValueName("City"));
            model.PostalCode = GetValue(bindingContext, controllerContext, CreateValueName("PostalCode"));
            model.Country = GetValue(bindingContext, controllerContext, CreateValueName("Country"));
            model.AddressSummary = GetSummary(model.PostalCode, model.City, model.Line1);
            return model;
        }

        private string GetValue(ModelBindingContext bindingContext, ControllerContext controllerContext, string name)
        {
            var result = bindingContext.ValueProvider.GetValue(name);
            if (result != null)
            {
                if (name.Contains("Line2"))
                {
                    if (String.IsNullOrWhiteSpace(result.AttemptedValue))
                        return "<not defined>";
                }
                else if (name.Contains("PostalCode"))
                {
                    if (result.AttemptedValue.Length < 7)
                        return "<not defined>";
                }
                else if (result.AttemptedValue.ToLower().Contains("po box"))
                {
                    return "<not defined>";
                }
                return result.AttemptedValue;
            }
            return null;
        }

        private string GetSummary(string postalCode, string city, string line1)
        {
            if (CheckProperty(postalCode) && CheckProperty(city) && CheckProperty(line1))
                return $"{postalCode} {city}, {line1}";
            return "No personal address";
        }

        private bool CheckProperty(string property)
        {
            return !String.IsNullOrWhiteSpace(property) && property != "<not defined>";
        }

        private string CreateValueName(string name)
        {
            return "HomeAddress." + name;
        }
    }
}