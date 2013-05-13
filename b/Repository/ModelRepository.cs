using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace b.Models
{
    public class Repository : IDisposable
    {
        private readonly bDBContext db = new bDBContext();
        public void Dispose()
        {
            db.Dispose();
        }
    }
}