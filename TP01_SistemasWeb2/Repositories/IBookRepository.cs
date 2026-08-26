//Nome e prontuário da dupla:
//Lucas da Silva Santos CB3030598
//Kaueh Farias Ferreira dos Santos CB3031438

using System;
using System.Collections.Generic;
using System.Text;
using TP01_SistemasWeb2.Models;

namespace TP01_SistemasWeb2.Repositories
{
    public interface IBookRepository
    {
        Book? GetBook();
    }
}
