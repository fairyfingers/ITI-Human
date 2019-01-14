interface IBasicDataStorage {
    storageId: number;
    projectId: number;
}

interface IStorageCreationViewModel {
    projectId: number;
}

interface IBasicDataStorageLinkedProduct {
    storageLinkedProductId: number;
    storageId: number;
    productId: number;
    productName: string;
    productDesc: string;
    productAvatarUrl: string;
    unitPrice: number;
    stock: number;
    creditState: boolean;
}

interface ILinkedProductCreationViewModel {
    userId: number;
    storageId: number;
    productId: number;
    unitPrice: number;
    stock: number;
}

interface ILinkedProductUpdateViewModel {
    storageLinkedProductId: number;
    unitPrice: number;
    stock: number;
}

export {
    IBasicDataStorage,
    IStorageCreationViewModel,
    IBasicDataStorageLinkedProduct,
    ILinkedProductCreationViewModel,
    ILinkedProductUpdateViewModel,
};
