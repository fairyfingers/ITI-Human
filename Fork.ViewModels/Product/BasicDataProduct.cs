﻿namespace Fork.ViewModels.Product
{
    /// <summary>
    /// Represents what a product is.
    /// </summary>
    public class BasicDataProduct
    {
        /// <summary>
        /// Product id.
        /// </summary>
        public int ProductId { get; set; }

        /// <summary>
        /// Product (unique) name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Product description.
        /// </summary>
        public string Desc { get; set; }

        /// <summary>
        /// Product avatar url.
        /// </summary>
        public string Url { get; set; }
    }
}
