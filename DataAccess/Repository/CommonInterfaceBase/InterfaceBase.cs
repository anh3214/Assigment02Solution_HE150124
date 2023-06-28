﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public interface InterfaceBase<T>
    {
        public Task<IEnumerable<T>> GetList();
        public Task<bool> Update(T newValue);
        public Task<bool> Delete(Guid id);
        public Task<T> GetById(Guid id);
    }
}