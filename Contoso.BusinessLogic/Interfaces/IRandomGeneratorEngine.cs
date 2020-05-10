using Contoso.BackEnd.BusinessLogic.Models;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace Contoso.BackEnd.BusinessLogic
{
    public interface IRandomGeneratorEngine
    {
        Task<List<GeneratorItemModel>> Generate(int range);
    }
}