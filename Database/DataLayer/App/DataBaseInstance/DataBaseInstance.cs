﻿using DataLayer.InternalDataBaseInstanceComponents;
using DataLayer.Shared.ExtentionMethods;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace DataLayer
{
    
     [Serializable]
     public class DataBaseInstance
     {
         //fields
         List<Table> _tablesDB = new List<Table>();
         string _name;
         //properties
         public string Name { get => _name; set => _name = value; }
         public List<Table> TablesDB { get => _tablesDB; set => _tablesDB = value; }
         
         // Now you can't create DataBaseInstance directly because of internal spec.
         // only through Kernel object
         /// <summary>
         /// DB constructor
         /// </summary>
         /// <param name="name"></param>
         public DataBaseInstance(string name)
         {
             _name = name;
         }
        //
        /// <summary>
        /// Add table to this Database
        /// </summary>
        /// <param name="bufTable"></param>
        public void AddTable(string name)
        {
            Table bufTable = new Table(name);
            AddTable(bufTable);
        }

        public void AddTable(Table bufTable)
         {
             if (bufTable.Name.isThereNoUndefinedSymbols())
             {
                 foreach (Table tbl in TablesDB)
                 {
                     if (tbl.Name == bufTable.Name) throw new FormatException("Invalid table name. Some table in this database have same name!");
                 }
                 TablesDB.Add(bufTable);
             }
             else throw new FormatException("There is invalid symbols in table's name!");
         }
        
     }
    
}
