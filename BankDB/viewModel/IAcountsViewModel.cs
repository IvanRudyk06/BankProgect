﻿using BankDB.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankDB.viewModel
{
  public interface IAcountsViewModel
    {
        void refreshOperation(Operation op);
    }
}
