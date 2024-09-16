using VyacheslavsMegaServer.Data.Entities.Base;

namespace VyacheslavsMegaServer.Data.Entities
{
    public class Link : EntityBase
    {
        public string Url { get; set; }

        public string Content { get; set; }

        public string? Description { get; set; }

        #region Navigations
        public int ContactId { get; set; }
        public virtual Contact? Contact { get; set; }
        #endregion
    }
}
