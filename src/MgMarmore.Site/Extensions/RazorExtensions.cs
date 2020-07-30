using Microsoft.AspNetCore.Mvc.Razor;
using System;

namespace MgMarmore.Site.Extensions
{
    public static class RazorExtensions
    {
        public static string FormataDocumento(this RazorPage page, int tipoCliente, string documento)
        {
            return tipoCliente == 1 ? Convert.ToInt64(documento).ToString(@"000\.000\.000-00") : Convert.ToUInt64(documento).ToString(@"00\.000\.000\/0000\-00");
        }
    }
}
