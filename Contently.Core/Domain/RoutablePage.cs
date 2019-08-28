using Contently.Core.Domain.Interfaces;
using System;

namespace Contently.Core.Domain
{
    public class RoutablePage : EntityBase, IRoutablePage
    {
        public string AreaName => "";
        public string RoutingController => "Page";

        public string Title { get; set; }

        public string Name { get; set; }
        public string Slug { get; set; }
        public string SeoTitle { get; set; }
        public string MetaTitle { get; set; }
        public string MetaKeywords { get; set; }
        public string MetaDescription { get; set; }
        public string Intro { get; set; }

        public string Content { get; set; }

        public bool IsDraft { get; set; }
        public bool IsPublished { get; set; }
        public DateTime PublishDate { get; set; }
        public DateTime UnPublishDate { get; set; }
       
    }
}
