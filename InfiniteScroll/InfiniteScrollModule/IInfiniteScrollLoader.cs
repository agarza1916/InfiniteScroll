using System.Threading.Tasks;

namespace InfiniteScroll.InfiniteScrollModule
{
	public interface IInfiniteScrollLoader
	{
		bool CanLoadMore { get; }

		Task LoadMoreAsync();
	}
}
