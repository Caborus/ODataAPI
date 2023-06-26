﻿using System;
using System.Collections.Generic;

namespace ODataAPI.EntityModels;

public partial class Ability
{
    public int Id { get; set; }

    public string Ability1 { get; set; } = null!;

    public virtual ICollection<Pokemon> Pokemons { get; set; } = new List<Pokemon>();
}
