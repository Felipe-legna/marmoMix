using System;
using System.Collections.Generic;
using System.Text;

namespace MgMarmore.Business.Models
{
    [Flags]
    public enum TipoBase
    {
        SemConexaoLateral = 1,
        ConexaoUmaLateral,
        conexaoDuasLaterais        
    }
}
