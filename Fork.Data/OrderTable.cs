﻿using Fork.ViewModels.Order;
using CK.DB.Actor;
using CK.Setup;
using CK.SqlServer;
using CK.SqlServer.Setup;
using System;
using System.Threading.Tasks;

namespace Fork.Data
{
    [SqlTable("tOrder", Package = typeof(Package))]
    [Versions("1.0.0")]
    [SqlObjectItem("vOrderedProducts")]
    [SqlObjectItem("vOrders")]
    public abstract class OrderTable : SqlTable
    {
        void StObjConstruct(StorageTable sTable, UserTable uTable, ClassroomTable cTable)
        {
        }

        [SqlProcedure("sOrderCreate")]
        public abstract Task<int> Create(ISqlCallContext ctx, int actorId, int storageId, int userId, int classroomId, DateTime creationDate);

        [SqlProcedure("sOrderUpdate")]
        public abstract Task<bool> Update(ISqlCallContext ctx, int actorId, int orderId, State currentState);

        [SqlProcedure("sOrderDelete")]
        public abstract Task<bool> Delete(ISqlCallContext ctx, int actorId, int orderId);
    }
}
