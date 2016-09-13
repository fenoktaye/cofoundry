﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cofoundry.Domain.CQS;

namespace Cofoundry.Domain
{
    public class GetPageTemplateSectionsByPageTemplateIdQuery : IQuery<IEnumerable<PageTemplateSectionDetails>>
    {
        public int PageTemplateId { get; set; }
    }
}
