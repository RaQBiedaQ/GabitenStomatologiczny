using System;
using System.Collections.Generic;

namespace GabitenStomatologiczny.Models;

public partial class Pracownicy
{
    public int IdPracownika { get; set; }

    public string Imie { get; set; } = null!;

    public string Nazwisko { get; set; } = null!;

    public DateOnly DataUrodzenia { get; set; }

    public int NumerTelefonu { get; set; }

    public string MailPracownika { get; set; } = null!;

    public string AdresZamieszkania { get; set; } = null!;

    public int IdStanowiska { get; set; }

    public virtual Stanowiska IdStanowiskaNavigation { get; set; } = null!;

    public virtual ICollection<Wizyty> Wizyties { get; set; } = new List<Wizyty>();
}
