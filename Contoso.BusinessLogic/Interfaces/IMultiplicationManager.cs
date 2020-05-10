using System.Collections.Generic;

namespace Contoso.BackEnd.BusinessLogic
{
    public interface IMultiplicationManager
    {
        List<int> ProcessRequest(int limit);
    }
}