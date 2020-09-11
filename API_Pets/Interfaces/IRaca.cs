﻿using API_PetShop.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_PetShop.Interfaces
{
    interface IRaca
    {
        List<Raca> ReadAll();
        List<Raca> Create(Raca a);
        List<Raca> Update(int id, Raca a);
        public void Delete(int id);
        Raca SearchForId(int id);
    }
}
