//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace testImageApp
{
    using System;
    using System.Collections.Generic;
    
    public partial class imagePathTable
    {
        public int idImage { get; set; }
        public byte[] img { get; set; }
        public Nullable<int> codeTable { get; set; }
    
        public virtual imageTable imageTable { get; set; }
    }
}
