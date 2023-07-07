using System;

namespace InfiniteScroll.InfiniteScrollModule
{
	public class LoadingMoreEventArgs : EventArgs
	{
		public LoadingMoreEventArgs(bool isLoadingMore)
		{
			IsLoadingMore = isLoadingMore;
		}

		public bool IsLoadingMore { get; }
	}
}
