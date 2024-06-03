using System;
using System.Collections.Generic;

namespace GabitenStomatologiczny.Models;

public partial class Klient
{
    public int IdKlienta { get; set; }

    public string Imie { get; set; } = null!;

    public string Nazwisko { get; set; } = null!;

    public DateOnly DataUrodzenia { get; set; }

    public int NumerTelefonu { get; set; }

    public string MailKlienta { get; set; }

    public string AdresZamieszkania { get; set; }

    public virtual ICollection<Wizyty> Wizyties { get; set; } = new List<Wizyty>();
}
