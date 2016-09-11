using System;
using System.Globalization;
using System.Web.Mvc;
using Task4.Models;

namespace Task4.Infrastructure
{
    public class PersonModelBinder : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            Person model = bindingContext.Model as Person ?? new Person();
            model.FirstName = GetValue(bindingContext, controllerContext, "FirstName")?.ToString();
            model.LastName = GetValue(bindingContext, controllerContext, "LastName")?.ToString();
            var dateofBirth = GetValue(bindingContext, controllerContext, "DOB");
            if (dateofBirth != null)
                model.DOB = (DateTime) dateofBirth;
            var role = GetValue(bindingContext, controllerContext, "Role");
            if (role != null)
                model.Role = (Role) role;
            model.HomeAddress = (Address) new AddressModelBInder().BindModel(controllerContext, bindingContext);
            return model;
        }


        private object GetValue(ModelBindingContext bindingContext, ControllerContext controllerContext, string name)
        {
            var result = bindingContext.ValueProvider.GetValue(name);
            if (result != null)
            {
                switch (name)
                {
                    case "Role":
                    {
                        if (result.AttemptedValue == "0")
                        {
                            if (controllerContext.HttpContext.Request.IsLocal)
                            {
                                return Role.Admin;
                            }
                            else
                            {
                                return Role.User;
                            }
                        }
                        else if (result.AttemptedValue == "1")
                        {
                            return Role.User;
                        }
                        else
                        {
                            return Role.Guest;
                        }   
                    }
                    case "DOB":
                    {
                        DateTime date;
                        if (
                            !DateTime.TryParse(result.AttemptedValue.ToLower(), CultureInfo.InvariantCulture,
                                DateTimeStyles.None, out date))
                        {
                            DateTime.TryParseExact(result.AttemptedValue.ToLower(), "dd/MMM/YYYY",
                                new CultureInfo("en-Us"), DateTimeStyles.None, out date);
                        }
                        return date;
                    }
                }
                return result.AttemptedValue;
            }
            return null;
        }
    }
}