using System.Collections.Generic;

namespace Contoso.BackEnd.BusinessLogic
{
    public interface IGeneratorManager
    {
        List<int> ProcessRequest(int limit);
    }
}