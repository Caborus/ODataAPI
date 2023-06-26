using System;
using System.Collections.Generic;

namespace ODataAPI.EntityModels;

public partial class PokemonTypesView
{
    public int? Id { get; set; }

    public string? Name { get; set; }

    public string? PokemonType { get; set; }
}
