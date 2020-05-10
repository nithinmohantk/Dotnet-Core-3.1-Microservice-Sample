using Contoso.BackEnd.Generator.Api.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Contoso.BackEnd.Generator.Api.BLL
{
    public interface IRandomGeneratorEngine
    {
        Task<List<GeneratorItemModel>> Generate(int range);
    }
}