﻿
using System;
using CoreCommon.Data.Domain.Entitites;
using CoreCommon.Data.Domain.Enums;
using ModuleAccount.Generated.Enums;
using ModuleAccount.Generated.Entities;

namespace ModuleAccountApi.Generated.RequestEntities
{
    public class UserSearchRequest
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public bool? EmailConfirmed { get; set; }
        public Status? Status { get; set; }
    }
}
