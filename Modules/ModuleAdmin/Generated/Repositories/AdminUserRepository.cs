﻿
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using ModuleAdmin.Generated.Entities;
using ModuleAdmin.Generated.Enums;
using ModuleAdmin.IRepositories;
using ModuleAdmin.Generated.Data;

using CoreCommon.Data.Domain.Entitites;
using CoreCommon.Data.Domain.Enums;
using CoreCommon.Data.EntityFrameworkBase.Base;
using CoreCommon.Data.ElasticSearch.Base;
using CoreCommon.Data.Domain.Business;

namespace ModuleAdmin.Repositories
{
    public partial class AdminUserRepository : EntityFrameworkBaseRepository<AdminUserEntity, MainConnectionDbContext>, IAdminUserRepository
    {

        public int DeleteById(int id)
        {            
            return DeleteBy(x => x.Id == id);
        }

        public AdminUserEntity GetById(int id)
        {
            return GetBy(x => x.Id == id);
        }

        public List<object> Search(string name,string email,Status? status,int? id, string orderBy, bool asc, int skip, int take, out long _total)
        {
            var result = GetDbSet().AsQueryable();
            if (!string.IsNullOrEmpty(name))
                result = result.Where(x => x.Name.ToLower().Contains(name.ToLower()));
            if (!string.IsNullOrEmpty(email))
                result = result.Where(x => x.Email.ToLower().Contains(email.ToLower()));
            if (status.HasValue)
                result = result.Where(x => x.Status.Equals(status));
            if (id.HasValue)
                result = result.Where(x => x.Id.Equals(id));
            var dic = new Dictionary<string, Func<AdminUserEntity, object>>
            {
                {"id", x => x.Id}
            };

            Func<AdminUserEntity, object> selectFunc = x => new {
                x.Id,
				x.No,
				x.Name,
				x.Email,
				x.Status,
				x.IsSuper
            };
            
            if (!string.IsNullOrEmpty(orderBy) && dic.ContainsKey(orderBy))
            {
                var result2 = asc ? result.OrderBy(dic[orderBy]) : result.OrderByDescending(dic[orderBy]);
                return SkipTake(result2.Select(selectFunc), skip, take, out _total);
            }
            return SkipTake(result.Select(selectFunc), skip, take, out _total);
        }
    }
}
