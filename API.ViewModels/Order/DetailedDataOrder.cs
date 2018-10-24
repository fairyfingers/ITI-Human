﻿using API.ViewModels.Product.Ordered;
using System.Collections.Generic;

namespace API.ViewModels.Order
{
    /// <summary>
    /// Represents what a detailed Order is.
    /// </summary>
    public class DetailedDataOrder
    {
        /// <summary>
        /// Information on the mentionned Order.
        /// </summary>
        public BasicDataOrder OrderInfo { get; set; }

        /// <summary>
        /// Products that mentionned Order contains.
        /// </summary>
        public IEnumerable<BasicDataOrderedProduct> Products { get; set; }
    }
}
