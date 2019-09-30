using Models;

namespace HNWrapper
{
    public interface IHNWrapperService
    {
        Items GetNewStories();
        Items GetTopStories();
        Items GetBestStories();

        Item GetItemById(int id);
    }
}
