using System;

namespace InfiniteScroll.InfiniteScrollModule
{
	public interface IInfiniteScrollLoading
	{
		bool IsLoadingMore { get; }

		event EventHandler<LoadingMoreEventArgs> LoadingMore;
	}
}
