using System;
using System.Collections.Generic;

namespace GabitenStomatologiczny.Models;

public partial class Pomieszczenium
{
    public int IdPomieszczenia { get; set; }

    public string NazwaPomieszczenia { get; set; } = null!;

    public int NumerPomieszczenia { get; set; }

    public virtual ICollection<Wizyty> Wizyties { get; set; } = new List<Wizyty>();
}
