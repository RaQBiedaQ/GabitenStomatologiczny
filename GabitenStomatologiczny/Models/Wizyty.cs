using System;
using System.Collections.Generic;

namespace GabitenStomatologiczny.Models;

public partial class Wizyty
{
    public int IdWizyty { get; set; }

    public int IdKlienta { get; set; }

    public int IdPracownika { get; set; }

    public int IdPomieszczenia { get; set; }

    public DateOnly DataWizyty { get; set; }

    public virtual Klient IdKlientaNavigation { get; set; } = null!;

    public virtual Pomieszczenium IdPomieszczeniaNavigation { get; set; } = null!;

    public virtual Pracownicy IdPracownikaNavigation { get; set; } = null!;

    public virtual ICollection<Wizytyuslugi> Wizytyuslugis { get; set; } = new List<Wizytyuslugi>();
}
