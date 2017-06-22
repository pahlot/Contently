using System;
using System.Collections.Generic;
using System.Text;

namespace Contently.Core.Domain.Interfaces
{
    public interface IPage
    {
        string Name { get; set; }
        string Slug { get; set; }

        string SeoTitle { get; set; }
        string MetaTitle { get; set; }
        string MetaKeywords { get; set; }
        string MetaDescription { get; set; }

        string Intro { get; set; }
        string Content { get; set; }

        bool IsDraft { get; set; }

        bool IsPublished { get; set; }
        DateTime PublishDate { get; set; }
        DateTime UnPublishDate { get; set; }
    }
}
