//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré à partir d'un modèle.
//
//     Des modifications manuelles apportées à ce fichier peuvent conduire à un comportement inattendu de votre application.
//     Les modifications manuelles apportées à ce fichier sont remplacées si le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace KnapSack.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Sac
    {
        public int idJoueur { get; set; }
        public int qteItem { get; set; }
        public int idItem { get; set; }
    
        public virtual Item Item { get; set; }
        public virtual Joueur Joueur { get; set; }
    }
}
