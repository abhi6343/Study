using System.Text.RegularExpressions;

namespace Routing.CustomConstraints
{
    public partial class AlphaNumericConstraint : IRouteConstraint
    {
        public bool Match(HttpContext? httpContext, IRouter? route, string routeKey, RouteValueDictionary values, RouteDirection routeDirection)
        {
            //if (values.ContainsKey(routeKey) && values[routeKey] is string value)
            //{
            //    return value.All(c => char.IsLetterOrDigit(c));
            //}
            //return false;
            if (!values.ContainsKey(routeKey)) return false;

            var regex = MyRegex(); // new Regex("^[a-zA-Z0-9]*$");
            return regex.IsMatch(values[routeKey]?.ToString() ?? string.Empty);
        }

        [GeneratedRegex("^[a-zA-Z0-9]*$")]
        private static partial Regex MyRegex();
    }  
}
