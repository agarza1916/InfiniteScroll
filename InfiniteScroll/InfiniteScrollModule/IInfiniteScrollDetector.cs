namespace InfiniteScroll.InfiniteScrollModule
{
	public interface IInfiniteScrollDetector
	{
		bool ShouldLoadMore(object currentItem);
	}
}
