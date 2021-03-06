﻿using Fork.ViewModels.Product;

namespace Fork.ViewModels.Storage.LinkedProduct
{
    public class BasicDataStorageSLP
    {
        /// <summary>
        /// Current Storage Linked Product id.
        /// </summary>
        public int StorageLinkedProductId { get; set; }

        /// <summary>
        /// Matching Storage id.
        /// </summary>
        public int StorageId { get; set; }

        /// <summary>
        /// Matching Product id.
        /// </summary>
        public int ProductId { get; set; }

        /// <summary>
        /// See <see cref="BasicDataProduct.Name"/>.
        /// </summary>
        public string ProductName { get; set; }

        /// <summary>
        /// See <see cref="BasicDataProduct.Desc"/>.
        /// </summary>
        public string ProductDesc { get; set; }

        /// <summary>
        /// See <see cref="BasicDataProduct.Url"/>.
        /// </summary>
        public string ProductAvatarUrl { get; set; }

        /// <summary>
        /// Current Storage Linked Product unit price.
        /// </summary>
        public int UnitPrice { get; set; }

        /// <summary>
        /// Stock of the mentionned product in storage.
        /// </summary>
        public int Stock { get; set; }

        /// <summary>
        /// Defines wether a SLP can be credited or not.
        /// </summary>
        public bool CreditState { get; set; }
    }
}
