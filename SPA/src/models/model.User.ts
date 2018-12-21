interface IUserBasicData {
    userId: number;
    userName: string;
    creationdate: Date;
}

interface IDetailedDataUser {
    userId: number;
    avatarUrl: string;
    userName: string;
    firstName: string;
    lastName: string;
    birthDate: Date;
    schoolMemberId: number;
    schoolStatusId: number;
    schoolStatusName: string;
}

export { IUserBasicData, IDetailedDataUser };
