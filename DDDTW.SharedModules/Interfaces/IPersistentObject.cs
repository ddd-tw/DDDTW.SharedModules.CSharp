﻿using DDDTW.SharedModules.BaseClasses;

namespace DDDTW.SharedModules.Interfaces
{
    public interface IPersistentObject<TId>
        where TId : EntityId
    {
        TId Id { get; }
    }
}