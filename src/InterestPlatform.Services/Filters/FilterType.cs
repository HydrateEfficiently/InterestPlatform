﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InterestPlatform.Services.Filters
{
    public enum FilterType
    {
        [Display(Name = "--")]
        Unknown,

        Discrete,

        Continuous,

        Switch
    }
}
