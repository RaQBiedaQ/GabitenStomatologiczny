using System;
using System.Collections.Generic;

namespace GabitenStomatologiczny.Models;

public partial class Uslugi
{
    public int IdUslugi { get; set; }

    public string NazwaUslugi { get; set; } = null!;

    public double CenaUslugi { get; set; }

    public virtual ICollection<Wizytyuslugi> Wizytyuslugis { get; set; } = new List<Wizytyuslugi>();
}
