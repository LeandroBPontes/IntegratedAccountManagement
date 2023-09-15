using Microsoft.AspNetCore.Mvc.Filters;


namespace IntegratedAccountManagement.ApiConfiguration.ActionFilters;

    public class ExceptionActionFilterAttribute : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            //TODO-CREATE RETURN OF EXCEPTION
        }
    }
