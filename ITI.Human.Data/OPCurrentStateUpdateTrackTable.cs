﻿using CK.Setup;
using CK.SqlServer.Setup;

namespace ITI.Human.Data
{
    [SqlTable("tOPCurrentStateUpdateTrack", Package = typeof(Package))]
    [Versions("1.0.0")]
    public abstract class OPCurrentStateUpdateTrackTable : SqlTable
    {
        void StObjConstruct(OrderedProductUpdateTrackTable opUTrackTable)
        {
        }
    }
}
