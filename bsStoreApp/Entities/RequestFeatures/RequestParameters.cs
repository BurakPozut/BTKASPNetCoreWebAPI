namespace Entities.RequestFeatures
{
    public abstract class RequestParameters
    {
		const int maxPageSize = 50;

		// Auto-implemented property
        public int PageNumber { get; set; }

		// Full-property
		private int _pagesSize;
		public int PageSize
		{
			get { return _pagesSize; }
			set { _pagesSize = value > maxPageSize ? maxPageSize : value; }
		}
	}
}
