﻿using Resturant_RES_MVC_ITI_PRJ.Areas.Client.Models;

namespace Resturant_RES_MVC_ITI_PRJ.Models.Repositories.Client
{

    public interface ITableRepository
    {
        public List<Table> GetAllTables();

        public Table GetTableById(int id);

        public void InsertTable(Table Table);

        public void UpdateTable(Table Table);

        public void DeleteTable(int id);
    }
}
