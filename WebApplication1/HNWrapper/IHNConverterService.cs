using Models;
using System.Collections.Generic;

namespace HNWrapper
{
    public interface IHNConverterService
    {
        Item MapToItem(string content);

        List<int> MapToIds(string content);
    }
}
