using API_PetShop.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_PetShop.Interfaces
{
    interface ITipoPet
    {
        List<TipoPet> ReadAll();
        List<TipoPet> Create(TipoPet a);
        List<TipoPet> Update(int id, TipoPet a);
        public void Delete(int id);
        TipoPet SearchForId(int id);
    }
}
