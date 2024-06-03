using System;
using System.Collections.Generic;

namespace GabitenStomatologiczny.Models;

public partial class Stanowiska
{
    public int IdStanowiska { get; set; }

    public string NazwaStanowiska { get; set; } = null!;

    public virtual ICollection<Pracownicy> Pracownicies { get; set; } = new List<Pracownicy>();
}
