using System;
using System.Collections.Generic;

namespace ODataAPI.EntityModels;

public partial class EvoListView
{
    public string? Pokemon { get; set; }

    public string? EvolvesTo { get; set; }

    public string? Trigger { get; set; }
}
