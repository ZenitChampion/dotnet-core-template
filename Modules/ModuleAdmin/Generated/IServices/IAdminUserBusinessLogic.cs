﻿
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using ModuleAdmin.Generated.Entities;
using ModuleAdmin.Generated.Enums;

using CoreCommon.Business.Service.Base;
using CoreCommon.Data.Domain.Business;
using CoreCommon.Data.Domain.Entitites;
using CoreCommon.Data.Domain.Enums;

namespace ModuleAdmin.IServices
{
    public partial interface IAdminUserBusinessLogic : IBusinessLogicBase<AdminUserEntity>
    {
        
        ServiceResult<int> DeleteById(int id);
        ServiceResult<AdminUserEntity> GetById(int id);
        ServiceResult<List<object>> Search(string name,string email,Status? status,int? id, string orderBy, bool asc, int skip, int take, out long _total);
	}
}    
