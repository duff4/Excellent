using System;
using System.Collections.Generic;
using System.Text;
using App2.Entities;

namespace App2.ServerEntities
{
    class ServerGeneralRequest
    {
        public DateTime LastUpdate { get; set; }

        public IEnumerable<IEntity> Entities { get; set; }
    }
}
