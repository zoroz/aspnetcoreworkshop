using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace WebApplication2.Models
{
    public static class Extensions
    {
        public static string Butify(this IHtmlHelper helper, string text)
        {
            return $"zoro's {text}";
        }
    }
}
