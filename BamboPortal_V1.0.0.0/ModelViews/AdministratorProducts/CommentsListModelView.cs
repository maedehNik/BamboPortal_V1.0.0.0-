﻿using BamboPortal_V1._0._0._0.Models.AdministratorProductsModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BamboPortal_V1._0._0._0.ModelViews.AdministratorProducts
{
    public class CommentsListModelView
    {
        public List<CommentModel> Comments { get; set; }
        public ReplySubmiterModel submiterModel { get; set; }
    }
}