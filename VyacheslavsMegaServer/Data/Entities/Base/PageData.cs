namespace VyacheslavsMegaServer.Data.Entities.Base
{
    public abstract class PageData : EntityBase
    {
        protected PageData() { }

        public string PageTitle { get; set; }

        public string MetatagDescription { get; set; }

        public string MetatagKeywords { get; set; }
    }
}
