using System;
using System.Collections.Generic;

namespace GabitenStomatologiczny.Models;

public partial class Wizytyuslugi
{
    public int IdWizytyuslugi { get; set; }

    public int IdWizyty { get; set; }

    public int IdUslugi { get; set; }

    public virtual Uslugi IdUslugiNavigation { get; set; } = null!;

    public virtual Wizyty IdWizytyNavigation { get; set; } = null!;
}
